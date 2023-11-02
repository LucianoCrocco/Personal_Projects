<?php

use Slim\Psr7\Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Boolxy\Random\Random;

class SocioController
{

    public function AltaProducto(Request $request, Response $response, $args)
    {
        $parametros = $request->getParsedBody();
        //$data = json_decode($request->getAttribute("dataToken"));

        $nombre = strtolower($parametros['nombre']);
        $sector = strtolower($parametros['sector']);
        $tiempo_elaboracion = $parametros['tiempo_elaboracion'];
        $precio = $parametros['precio'];

        $data = Producto::AltaProducto($nombre, $sector, $tiempo_elaboracion, $precio);
        $payload = json_encode("Producto dado de alta correctamente");


        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(201);
    }
    public function AltaTrabajador(Request $request, Response $response, $args)
    {
        $parametros = $request->getParsedBody();
        //$data = json_decode($request->getAttribute("dataToken"));

        $nombre = strtolower($parametros['nombre']);
        $apellido = strtolower($parametros['apellido']);
        $edad = $parametros['edad'];
        $estado_laboral = strtolower($parametros['estado_laboral']);
        $tipo = strtolower($parametros['tipo']);
        $dni = $parametros['dni'];
        $codigo_login = Random::alpha(5);
        $date = date("Y-m-d");

        Trabajador::AltaTrabajador($nombre, $apellido, $estado_laboral, $tipo, $dni, $codigo_login, $edad);
        Trabajador::AltaFichaTrabajador($dni, $tipo, $date, NULL);

        $payload = json_encode("Trabajador y ficha laboral dados de alta correctamente");

        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(201);
    }
    public function AltaMesa(Request $request, Response $response, $args)
    {

        $codigo_alfanumerico = Random::alpha(5);
        $estado = "vacia";
        Mesa::AltaMesa($estado, $codigo_alfanumerico);

        $payload = json_encode("Mesa dada de alta correctamente");

        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(201);


    }
    public function CerrarMesa(Request $request, Response $response, $args)
    {
        $parametros = $request->getParsedBody();
        $codigo_alfanumerico = $parametros["codigoMesa"];
        $estado = "cerrada";

        Mesa::ActualizarEstadoMesa($estado, $codigo_alfanumerico);

        $payload = json_encode("Mesa cerrada correctamente");
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
    }

    public function DescargaProductosCSV(Request $request, Response $response, $args)
    {
        $productos = Producto::TraerTodos();
        Producto::DescargaProductosCSV($productos);

        readfile("./csv/dataProductos.csv");
        return $response->withHeader('Content-Type', 'text/csv')->withAddedHeader("Content-disposition", "attachment; filename=dataProductos.csv")->withStatus(200);
    }

    public function CargarProductosCSV(Request $request, Response $response, $args)
    {
        $archivo = $request->getUploadedFiles()["archivoCSV"];
        $nombre = $archivo->getClientFileName();
        $destino = "./csv/" . $nombre;
        $archivo->moveTo($destino);

        Producto::CargarProductosCSV($destino);

        $payload = json_encode("Productos cargados a la base de datos.");

        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(201);
    }
    public function SuspenderTrabajador(Request $request, Response $response, $args)
    {

        $parametros = $request->getParsedBody();
        $dni = $parametros["dni"];
        $sector = $parametros["sector"];
        $comienzo = date("Y-m-d H:i:s");
        $motivo = $parametros["motivo"];

        if (Trabajador::ActualizarEstadoEmpleado($dni, "suspendido")) {
            Trabajador::RegistrarSuspensionTrabajador($dni, $sector, $comienzo, $motivo);
            $idFicha = Trabajador::IdFichaSuspensionSinTerminar($dni);

            $payload = json_encode("Trabajador suspendido, id de la ficha para darlo de alta nuevamente: " . $idFicha);
            $response->getBody()->write($payload);
            return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
        } else {
            $payload = json_encode("No se encontro el trabajador a suspender");
            $response->getBody()->write($payload);
            return $response->withHeader('Content-Type', 'application/json')->withStatus(404);
        }

    }
    public function TerminarSuspension(Request $request, Response $response, $args)
    {

        $parametros = $request->getParsedBody();
        $dni = $parametros["dni"];
        $idFicha = $parametros["idFicha"];
        $fin = date("Y-m-d H:i:s");

        if (Trabajador::ActualizarEstadoEmpleado($dni, "activo")) {
            Trabajador::TerminarSuspensionTrabajador($dni, $fin, $idFicha);
            $payload = json_encode("El trabajador suspendido vuelve a estar activo");
            $response->getBody()->write($payload);
            return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
        } else {
            $payload = json_encode("No se encontro el trabajador a suspender");
            $response->getBody()->write($payload);
            return $response->withHeader('Content-Type', 'application/json')->withStatus(404);
        }

    }
    public function BajaTrabajador(Request $request, Response $response, $args)
    {

        $parametros = $request->getParsedBody();
        $dni = $parametros["dni"];
        $fecha = date("Y-m-d H:i:s");

        if (Trabajador::ActualizarEstadoEmpleado($dni, "baja")) {
            Trabajador::BajaTrabajador($dni, $fecha);
            $payload = json_encode("Trabajador dado de baja");
            $response->getBody()->write($payload);
            return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
        } else {
            $payload = json_encode("No se encontro el trabajador a suspender");
            $response->getBody()->write($payload);
            return $response->withHeader('Content-Type', 'application/json')->withStatus(404);
        }

    }
    public function TodosLogsTrabajadoresPDF(Request $request, Response $response, $args)
    {
        $arrayLogs = LogsTrabajadores::TraerTodos();
        $pdf = new TCPDF('P', 'mm', 'A4', true, 'UTF-8', false, true);


        $pdf->addPage();
        $pdf->setTitle("Todos los logs de los trabajadores");
        $pdf->SetFont('helvetica', '', 9.5, '');
        foreach ($arrayLogs as $v) {
            $mensaje = "DNI: " . $v["dni"] . " - Sector: " . $v["sector"] . " - Tiempo del registro: " . $v["tiempo"] . " - Endpoint: " . $v["endpoint"] . "\n";
            $pdf->write(0, $mensaje);
        }

        // Render and return pdf content as string
        $content = $pdf->output('doc.pdf', 'S');

        $response->getBody()->write($content);

        $response = $response
            ->withHeader('Content-Type', 'application/pdf')
            ->withHeader('Content-Disposition', 'attachment; filename="logs.pdf"');

        return $response;

    }
    public function EstadisticasPedidos(Request $request, Response $response, $args)
    {
        $tiempoHoy = date("Y-m-d H:i:s");
        $treintaDias = date("Y-m-d H:i:s", strtotime($tiempoHoy . ' - 30 days '));
        $consultas = [];

        $pdf = new TCPDF('P', 'mm', 'A4', true, 'UTF-8', false, true);


        $pdf->addPage();
        $pdf->setTitle("Estadisticas de los pedidos ultimos 30 dias");

        //* MAYOR DINERO
        $pdf->SetFont('helvetica', '', 13, '');
        $pdf->write(0, "El pedido de mayor dinero\n");
        $pdf->SetFont('helvetica', '', 9.5, '');

        $consulta = Estadisticas::PedidoMaximoDinero($tiempoHoy, $treintaDias);
        if ($consulta) {
            $pdf->write(0, $consulta . "$\n");
        } else {
            $pdf->write(0, "No hay pedidos." . "\n");
        }

        //* MENOR DINERO
        $pdf->SetFont('helvetica', '', 13, '');
        $pdf->write(0, "El pedido de menor dinero\n");
        $pdf->SetFont('helvetica', '', 9.5, '');

        $consulta = Estadisticas::PedidoMinimoDinero($tiempoHoy, $treintaDias);
        if ($consulta) {
            $pdf->write(0, $consulta . "$\n");
        } else {
            $pdf->write(0, "No hay pedidos." . "\n");
        }

        //* PRODUCTO MAS VENDIDO 
        $pdf->SetFont('helvetica', '', 13, '');
        $pdf->write(0, "El producto mas vendido\n");
        $pdf->SetFont('helvetica', '', 9.5, '');

        $consulta = Estadisticas::ProductoMasVendido($tiempoHoy, $treintaDias);

        if ($consulta) {
            $pdf->write(0, $consulta->nombre . ', cantidad: ' . $consulta->valor . "\n");
        } else {
            $pdf->write(0, "No hay pedidos." . "\n");
        }

        //* PRODUCTO MENOS VENDIDO 
        $pdf->SetFont('helvetica', '', 13, '');
        $pdf->write(0, "El producto menos vendido\n");
        $pdf->SetFont('helvetica', '', 9.5, '');

        $consulta = Estadisticas::ProductoMenosVendido($tiempoHoy, $treintaDias);

        if ($consulta) {
            $pdf->write(0, $consulta->nombre . ', cantidad: ' . $consulta->valor . "\n");
        } else {
            $pdf->write(0, "No hay pedidos." . "\n");
        }

        //* PEDIDO MAYOR TIEMPO DE ESPERA 
        $pdf->SetFont('helvetica', '', 13, '');
        $pdf->write(0, "El pedido con mayor tiempo de espera\n");
        $pdf->SetFont('helvetica', '', 9.5, '');

        $consulta = Estadisticas::PedidoMayorTiempoEspera($tiempoHoy, $treintaDias);

        if ($consulta) {
            $pdf->write(0, $consulta . ' minutos' . "\n");
        } else {
            $pdf->write(0, "No hay pedidos." . "\n");
        }

        //* PEDIDO MENOR TIEMPO DE ESPERA 
        $pdf->SetFont('helvetica', '', 13, '');
        $pdf->write(0, "El pedido con menor tiempo de espera\n");
        $pdf->SetFont('helvetica', '', 9.5, '');

        $consulta = Estadisticas::PedidoMenorTiempoEspera($tiempoHoy, $treintaDias);

        if ($consulta) {
            $pdf->write(0, $consulta . ' minutos' . "\n");
        } else {
            $pdf->write(0, "No hay pedidos." . "\n");
        }


        //* PEDIDO MENOR TIEMPO DE ESPERA 
        $pdf->SetFont('helvetica', '', 13, '');
        $pdf->write(0, "Lista de pedidos que no fueron entregados en el tiempo estipulado\n");
        $pdf->SetFont('helvetica', '', 9.5, '');
        $flag = 0;

        $consulta = Estadisticas::TiempoEstipuladoPedido();

        /*
         */
        $mensaje = "";
        foreach ($consulta as $v) {
            $tiempoOrden = $v["tiempo_orden"];
            if ($tiempoOrden >= $treintaDias && $tiempoOrden <= $tiempoHoy) {
                $tiempoEntregado = $v["tiempo_entrega"];
                if ($tiempoEntregado) {
                    $tiempoEstipulado = date('Y-m-d H:i:s', strtotime('+' . $v["tiempo_maximo"] . ' minutes', strtotime($tiempoOrden)));
                    if ($tiempoEntregado > $tiempoEstipulado) {
                        $mensaje .= "El tiempo de entrega maximo del pedido '" . $v["codigo_pedido"] . "' era de: " . $tiempoEstipulado . ". Pero se entrego tarde a las: " . $tiempoEntregado . "\n";
                        $flag++;
                    }
                }
            }
        }
        if ($flag) {
            $pdf->write(0, $mensaje . "\n");
        } else {
            $pdf->write(0, "No hay pedidos entregados fuera de tiempo." . "\n");
        }

        $content = $pdf->output('doc.pdf', 'S');
        $response->getBody()->write($content);
        $response = $response
            ->withHeader('Content-Type', 'application/pdf')
            ->withHeader('Content-Disposition', 'attachment; filename="logs.pdf"');
        return $response;

    }

}
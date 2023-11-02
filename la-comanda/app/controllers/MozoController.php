<?php

use Slim\Psr7\Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Boolxy\Random\Random;


class MozoController
{
    public function AsignarMesa(Request $request, Response $response, $args)
    {
        $mesaAsignada = Mesa::BuscarMesaMozo();

        if (!$mesaAsignada) {
            $payload = json_encode("No hay ninguna mesa sin mozo asignado");
            $response->getBody()->write(array("Error" =>$payload));
            return $response->withHeader('Content-Type', 'application/json')->withStatus(404);
        }

        $dni = json_decode($request->getAttribute("dataToken"))->dni;
        $codigo_alfanumerico = $mesaAsignada["codigo_alfanumerico"];

        Mesa::AsignarMozo($dni, $codigo_alfanumerico);
        Mesa::ActualizarEstadoMesa("esperando hacer el pedido", $codigo_alfanumerico);
        Mesa::ActualizarHorarioMesa($codigo_alfanumerico, NULL);

        $payload = json_encode("Numero de mesa asignado: " . $mesaAsignada["id"] . " - " . "codigo alfanumerico de la mesa: " . $codigo_alfanumerico);
        $response->getBody()->write(array("Ok" =>$payload));
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
    }

    public function AltaPedido(Request $request, Response $response, $args)
    {
        $parametros = $request->getParsedBody();
        $dni = json_decode($request->getAttribute("dataToken"))->dni;
        $arrayId = [];

        //Pedido
        $codigoMesa = $args['codigo_mesa'];
        $arrayProductos = $parametros["productos"];
        $tiempo_orden = date("Y-m-d H:i:s");
        $precio_pedido = 0;
        $tiempo_elaboracion = 0;

        foreach ($arrayProductos as $v) {
            array_push($arrayId, $v["id"]);
        }

        foreach ($arrayId as $v) {
            $precio_pedido += Producto::ProductoPrecio($v);
            $tiempo = Producto::ProductoTiempoElaboracion($v);
            if ($tiempo > $tiempo_elaboracion)
                $tiempo_elaboracion = $tiempo;
        }

        $codigo_pedido = Random::alpha(8);

        Pedido::AltaPedido($codigoMesa, $codigo_pedido, $dni, "en preparacion", $tiempo_orden, $tiempo_elaboracion, NULL, $precio_pedido);

        //Detalle
        foreach ($arrayProductos as $v) {
            Detalle::AltaDetalle($v["id"], $codigo_pedido, $v["cantidad"], "en cola");
        }

        Mesa::ActualizarEstadoMesa("con cliente esperando pedido", $codigoMesa);

        $payload = json_encode("Pedido dado de alta correctamente, codigo pedido: " . $codigo_pedido);

        $response->getBody()->write(array("Ok" =>$payload));
        return $response->withHeader('Content-Type', 'application/json')->withStatus(201);
    }

    public function ListarPedidosListos(Request $request, Response $response, $args)
    {
        $dni = json_decode($request->getAttribute("dataToken"))->dni;

        $array = Mozo::ProductosListosParaServir($dni, "listo para servir");
        $datos = [];

        foreach ($array as $k => $v) {
            $datos[$k]["codigo_pedido"] = $v["codigo_pedido"];
            $datos[$k]["id_producto_a_servir"] = $v["id"][0];
            $datos[$k]["nombre"] = $v["nombre"];
            $datos[$k]["cantidad"] = $v["cantidad"];
            $datos[$k]["codigo_mesa"] = $v["codigo_mesa"];
            $datos[$k]["mesa"] = $v["id"][1];
        }

        $payload = json_encode($datos);
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
    }
    public function ActualizarPedidoDetalle(Request $request, Response $response, $args)
    {
        $parametros = $request->getParsedBody();
        $codigoPedido = $parametros["codigoPedido"];
        $codigoMesa = $parametros["codigoMesa"];
        $arrayIdProductosServidos = $parametros["idProductos"];

        $pedidos = Pedido::TraerTodosProductosPedido($codigoPedido);

        foreach ($pedidos as &$v) {
            if (in_array($v["id_producto"], $arrayIdProductosServidos)) {
                Detalle::ActualizarEstadoDetalle($v["id"], 'servido');
                $v["estado"] = "servido";
            }
        }

        Mesa::ActualizarEstadoMesa("con cliente comiendo", $codigoMesa);
        Mesa::ActualizarHorarioMesa(NULL, $codigoMesa);

        $servido = true;
        foreach ($pedidos as $v) {
            if ($v["estado"] != "servido") {
                $servido = false;
                break;
            }
        }

        if ($servido) {
            $tiempo_orden = date("Y-m-d H:i:s");
            Pedido::ActualizarEstadoPedido($codigoPedido, 'servido');
            Pedido::ActualizarHorarioPedido($codigoPedido, $tiempo_orden);
        }

        $payload = json_encode(array("Productos servidos" => $pedidos));
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
    }
    public function CobrarMesa(Request $request, Response $response, $args)
    {
        $parametros = $request->getParsedBody();
        $codigoMesa = $parametros["codigoMesa"];

        $pedidos = Mesa::TraerEstadoTodosPedidosMesa($codigoMesa);

        foreach ($pedidos as $v) {
            if ($v["estado"] != "servido") {
                $payload = json_encode("No se puede cobrar la mesa, faltan servir pedidos");
                $response->getBody()->write($payload);
                return $response->withHeader('Content-Type', 'application/json')->withStatus(404);
            }
        }

        $totalAPagar = number_format(Mesa::TotalAPagar($codigoMesa), 2, ".", ",");
        Mesa::ActualizarEstadoMesa("con cliente pagando", $codigoMesa);


        $payload = json_encode("Mesa cobrada, monto pagado: " . $totalAPagar);
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
    }
    public function LiberarMesa(Request $request, Response $response, $args)
    {
        $parametros = $request->getParsedBody();
        $codigoMesa = $parametros["codigoMesa"];

        Mesa::ActualizarEstadoMesa("vacia", $codigoMesa);
        Mesa::AsignarMozo(NULL, $codigoMesa);

        $payload = json_encode("Mesa nuevamente disponible para ser utilizada");
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
    }

    public function MostrarDetalleEnCola(Request $request, Response $response, $args)
    {
        $pedidosAPreparar = Detalle::ListarEstadoDetalle("candy bar", "en cola");

        if (!$pedidosAPreparar) {
            $payload = json_encode("No hay ningun pedido sin estar asignado");
            $response->getBody()->write($payload);
            return $response->withHeader('Content-Type', 'application/json')->withStatus(404);
        }

        $payload = json_encode($pedidosAPreparar);
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
    }
}
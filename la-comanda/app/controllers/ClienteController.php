<?php

use Slim\Psr7\Response;
use Psr\Http\Message\ServerRequestInterface as Request;

class ClienteController
{

    public function AsignarMesa(Request $request, Response $response, $args)
    {
        $mesaAsignada = Mesa::BuscarMesaVacia();
        if (!$mesaAsignada) {
            $payload = json_encode("No hay mesa disponible.");
            $response->getBody()->write($payload);
            return $response->withHeader('Content-Type', 'application/json')->withStatus(404);
        }
        $tiempo_esperando = date("Y-m-d H:i:s");
        Mesa::ActualizarEstadoMesa("ocupada", $mesaAsignada["codigo_alfanumerico"]);
        Mesa::ActualizarHorarioMesa($mesaAsignada["codigo_alfanumerico"], $tiempo_esperando);

        $payload = json_encode("Mesa disponible, numero de mesa asignado: " . $mesaAsignada["id"] . " - " . "codigo alfanumerico de la mesa: " . $mesaAsignada["codigo_alfanumerico"]);
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);

    }
    public function EstadoPedido(Request $request, Response $response, $args)
    {
        $codigoPedido = $args['codigo_pedido'];

        $array = Pedido::TraerTodosProductosPedido($codigoPedido);

        $payload = json_encode($array);
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);

    }
    public function TiempoMaximoPedido(Request $request, Response $response, $args)
    {
        $codigoPedido = $args['codigo_pedido'];
        $codigoMesa = $args['codigo_mesa'];

        $tiempo_maximo = Pedido::TiempoMaximoPedido($codigoPedido, $codigoMesa);


        $payload = json_encode("Maximo de minutos para esperar el pedido: " . $tiempo_maximo);
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);

    }
    public function TotalAPagar(Request $request, Response $response, $args)
    {
        $codigoMesa = $args['codigo_mesa'];

        $total_a_pagar = number_format(Mesa::TotalAPagar($codigoMesa), 2, ".", ",");


        $payload = json_encode("Total a pagar: " . $total_a_pagar);
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);

    }

}
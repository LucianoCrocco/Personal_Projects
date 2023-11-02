<?php

use Slim\Psr7\Response;
use Psr\Http\Message\ServerRequestInterface as Request;


class BartenderController
{

    public function MostrarDetalleEnCola(Request $request, Response $response, $args)
    {
        $pedidosAPreparar = Detalle::ListarEstadoDetalle("bartender", "en cola");

        if (!$pedidosAPreparar) {
            $payload = json_encode(array("Error" => "No hay ningun pedido sin estar asignado"));
            $response->getBody()->write($payload);
            return $response->withHeader('Content-Type', 'application/json')->withStatus(404);
        }

        $payload = json_encode($pedidosAPreparar);
        $response->getBody()->write(array("Ok" => $payload));
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
    }
}
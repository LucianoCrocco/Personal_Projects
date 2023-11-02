<?php

use Slim\Psr7\Response;
use Psr\Http\Message\ServerRequestInterface as Request;


class CerveceroController
{

    public function MostrarDetalleEnCola(Request $request, Response $response, $args)
    {
        $pedidosAPreparar = Detalle::ListarEstadoDetalle("cervecero", "en cola");

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
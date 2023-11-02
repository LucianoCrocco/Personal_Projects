<?php

use Slim\Psr7\Response;
use Psr\Http\Message\ServerRequestInterface as Request;


class NegocioController
{
    public function ListarProductos(Request $request, Response $response, $args)
    {
        $data = Producto::TraerTodos();
        $payload = json_encode(array("Listado de productos" => $data));
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
    }
    public function ListarTrabajadores(Request $request, Response $response, $args)
    {
        $data = Trabajador::TraerTodos();
        $payload = json_encode(array("Listado de trabajadores" => $data));
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
    }
    public function ListarMesas(Request $request, Response $response, $args)
    {
        $data = Mesa::TraerTodos();
        $payload = json_encode(array("Listado de mesas" => $data));
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
    }
    public function ListarPedidos(Request $request, Response $response, $args)
    {
        $dataPedido = Pedido::TraerTodos();
        $payload = json_encode(array("Listado de pedidos" => $dataPedido));
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
    }
}
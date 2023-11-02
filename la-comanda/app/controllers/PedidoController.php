<?php

use Slim\Psr7\Response;
use Psr\Http\Message\ServerRequestInterface as Request;


class PedidoController
{
    public function PrepararPedidoDetalle(Request $request, Response $response, $args)
    {
        $parametros = $request->getParsedBody();
        $dni = json_decode($request->getAttribute("dataToken"))->dni;
        $arrayIdProductosAPreparar = $parametros["idDetalleProductos"];

        //* VERIFICAR QUE LOS PRODUCTOS NO TENGAN COCINERO ASIGNADO, SI LO TIENE INFROMAR QUE PRODUCTO YA TIENE. ASI VUELVE A HACER LA PETICION SIN ESE ID.
        //* VERIFICAR EN UN MW QUE EL PRODUCTO SEA DEL SECTOR DE COCINEROS O EL QUE CORRESPONDA.

        //!----MIDLEWARE?-----
        /* MAL 
        $arrayPedidosYaTomados = [];
        foreach ($arrayIdProductosAPreparar as $v) {
        array_push($arrayPedidosYaTomados, Pedido::VerificarEstadoDetalle($v, "haciendose"));
        }
        if (count($arrayPedidosYaTomados) > 0) {
        $payload = "Productos ya en preparacion";
        $response->getBody()->write(json_encode(array($payload, $arrayPedidosYaTomados)));
        return $response->withHeader('Content-Type', 'application/json')->withStatus(404);
        }*/
        //!----MIDLEWARE?-----

        foreach ($arrayIdProductosAPreparar as $v) {
            Detalle::ActualizarEstadoDetalle($v, "haciendose");
            Detalle::AsignarTrabajadorDetalle($v, $dni);
        }

        $payload = "Se le asignaron los pedidos correctamente";
        $response->getBody()->write(json_encode($payload));
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
    }
    public function ListoPedidoDetalle(Request $request, Response $response, $args)
    {

        $parametros = $request->getParsedBody();
        $arrayIdProductosAServir = $parametros["idDetalleProductos"];

        //* VERIFICAR QUE LOS PRODUCTOS LISTOS PARA SERVIR SEAN DEL COCINERO, SINO INFOMAR EL ERROR Y CUAL ES EL PRODUCTO. ASI VUELVE A HACER LA PETICION SIN ESE ID.
        //!----MIDLEWARE?-----
        //!----MIDLEWARE?-----
        foreach ($arrayIdProductosAServir as $v) {
            Detalle::ActualizarEstadoDetalle($v, "listo para servir");
        }

        $payload = "Los productos ingresados se encuentran listos para servir";
        $response->getBody()->write(json_encode($payload));
        return $response->withHeader('Content-Type', 'application/json')->withStatus(200);
    }
}
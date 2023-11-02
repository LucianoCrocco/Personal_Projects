<?php
require_once "./utils/JwtUtil.php";

use Firebase\JWT\JWT;
use Psr\Http\Message\ServerRequestInterface as Request;
use Psr\Http\Server\RequestHandlerInterface as RequestHandler;
use Slim\Psr7\Response;


class ValidarAccionTrabajadorMW
{

    public static function ValidarAccion(Request $request, RequestHandler $handler)
    {
        $parametros = $request->getParsedBody();
        //$tokenType = json_decode($request->getAttribute("dataToken"))->tipo;
        $endpoint = explode("/", $request->getRequestTarget())[1];

        $arrayIdProductosAPreparar = $parametros["idDetalleProductos"];
        $arrayErrores = [];
        foreach ($arrayIdProductosAPreparar as $v) {
            $producto = Detalle::TraerUnoId($v);

            if ($producto["sector"] == "candy bar") {
                $producto["sector"] = "mesero";
            }
            if ($producto["sector"] != $endpoint) {
                $mensajeError = "Usted no puede preparar el producto: " . $v . " de nombre: " . $producto["nombre"] . " ya que pertenece al sector: " . $producto["sector"];
                array_push($arrayErrores, $mensajeError);
            }
        }


        if (count($arrayErrores) > 0) {
            $payload = json_encode($arrayErrores);
            $response = new Response();
            $response->getBody()->write($payload);
            return $response->withHeader('Content-Type', 'application/json')->withStatus(403);
        }

        $response = $handler->handle($request);
        return $response;
    }
}
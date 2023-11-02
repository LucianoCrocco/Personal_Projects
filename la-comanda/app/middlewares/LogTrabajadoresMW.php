<?php
require_once "./utils/JwtUtil.php";

use Psr\Http\Message\ServerRequestInterface as Request;
use Psr\Http\Server\RequestHandlerInterface as RequestHandler;
use Slim\Psr7\Response;


class LogTrabajadoresMW
{
    public static function RegistrarAccion(Request $request, RequestHandler $handler)
    {
        $sector = json_decode($request->getAttribute("dataToken"))->tipo;
        $dni = json_decode($request->getAttribute("dataToken"))->dni;
        $tiempo = date("Y-m-d H:i:s");
        $endpoint = explode("/", $request->getRequestTarget())[2];
        LogsTrabajadores::RegistrarAccion($dni, $sector, $tiempo, $endpoint);
        $response = $handler->handle($request);
        return $response;
    }
}
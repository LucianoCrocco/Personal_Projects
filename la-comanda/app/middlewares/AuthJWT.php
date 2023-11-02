<?php
require_once "./utils/JwtUtil.php";

use Firebase\JWT\JWT;
use Psr\Http\Message\ServerRequestInterface as Request;
use Psr\Http\Server\RequestHandlerInterface as RequestHandler;
use Slim\Psr7\Response;


class AuthJWT
{
    public static function VerificarTokenValido(Request $request, RequestHandler $handler)
    {
        $header = $request->getHeaderLine('Authorization');
        if (!$header) {
            $payload = json_encode(array("Error" => "Debe proporcionar el token de autenticacion"));
            $response = new Response();
            $response->getBody()->write($payload);
            return $response->withHeader('Content-Type', 'application/json')->withStatus(404);
        }
        $token = trim(explode("Bearer", $header)[1]);

        try {
            JwtUtil::VerificarToken($token);
            $data = JwtUtil::ObtenerData($token);
            $request = $request->withAttribute("dataToken", json_encode($data));
            $response = $handler->handle($request);
            return $response;
        } catch (Exception $err) {
            $payload = json_encode(array("Error" => $err->getMessage()));
            $response = new Response();
            $response->getBody()->write($payload);
            return $response->withHeader('Content-Type', 'application/json')->withStatus(404);
        }
    }
    public static function VerificarSocioToken(Request $request, RequestHandler $handler)
    {
        $tokenType = json_decode($request->getAttribute("dataToken"))->tipo;
        if ($tokenType != "socio") {
            $payload = json_encode(array("Error" => "Usted no es socio"));
            $response = new Response();
            $response->getBody()->write($payload);
            return $response->withHeader('Content-Type', 'application/json')->withStatus(403);
        }
        $response = $handler->handle($request);
        return $response;
    }

    public static function VerificarEmpleadoToken(Request $request, RequestHandler $handler)
    {
        $tokenType = json_decode($request->getAttribute("dataToken"))->tipo;
        $endpoint = explode("/", $request->getRequestTarget())[1];

        if ($tokenType != $endpoint && $tokenType != 'socio') {
            $payload = json_encode(array("Error" => "Usted no puede acceder a esta ruta"));
            $response = new Response();
            $response->getBody()->write($payload);
            return $response->withHeader('Content-Type', 'application/json')->withStatus(403);
        }

        $response = $handler->handle($request);
        return $response;
    }
}
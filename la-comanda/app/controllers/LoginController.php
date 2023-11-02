<?php

use Slim\Psr7\Response;
use Psr\Http\Message\ServerRequestInterface as Request;

class LoginController
{

    public function Login(Request $request, Response $response, $args)
    {
        $parametros = $request->getParsedBody();
        $dni = $parametros['dni'];
        $clave = $parametros['clave'];
        $tipo = strtolower($parametros['tipo']);

        switch ($tipo) {
            case 'trabajador':
                $usuario = Trabajador::TraerUno($dni, $clave);
                break;
            case 'socio':
                $usuario = Socio::TraerUno($dni, $clave);
                break;
        }

        if (!$usuario) {
            $data = "No existe el usuario";
            $response = $response->withStatus(404);
        } else {
            $tipo == 'socio' ? $data = JwtUtil::CrearTokenSocio($usuario) : $data = JwtUtil::CrearToken($usuario);
            $response = $response->withStatus(200);
        }
        $payload = json_encode(array("Datos usuario" => $data));
        $response->getBody()->write($payload);
        return $response->withHeader('Content-Type', 'application/json');
    }

}
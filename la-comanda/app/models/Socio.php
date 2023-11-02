<?php
class Socio
{
    private $id;
    public $nombre;
    public $apellido;
    public $dni;
    private $codigo_login;

    public static function AltaSocio($nombre, $apellido, $dni, $codigo_login)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("INSERT INTO socios (nombre, apellido, dni, codigo_login) VALUES (:nombre, :apellido, :dni, :codigo_login)");
        $consulta->bindValue(':nombre', $nombre, PDO::PARAM_STR);
        $consulta->bindValue(':apellido', $apellido, PDO::PARAM_STR);
        $consulta->bindValue(':dni', $dni, PDO::PARAM_INT);
        $consulta->execute();

        return $consulta->fetchObject('Socio');
    }

    public static function TraerTodos()
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT nombre_apellido, dni FROM socios");
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_ASSOC);
    }
    public static function TraerUno($dni, $codigo_login)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT nombre, apellido, dni FROM socios WHERE dni = :dni AND codigo_login = :codigo_login");
        $consulta->bindValue(':dni', $dni, PDO::PARAM_INT);
        $consulta->bindValue(':codigo_login', $codigo_login, PDO::PARAM_STR);
        $consulta->execute();

        return $consulta->fetch(PDO::FETCH_OBJ);
    }
}
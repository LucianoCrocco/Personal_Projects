<?php
class LogsTrabajadores
{
    private $id;
    public $dni_empleado;
    public $sector;
    public $tiempo;
    public $endpoint;


    public static function RegistrarAccion($dni, $sector, $tiempo, $endpoint)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("INSERT INTO log_trabajadores (dni, sector, tiempo, endpoint) VALUES (:dni, :sector, :tiempo, :endpoint)");
        $consulta->bindValue(':dni', $dni);
        $consulta->bindValue(':sector', $sector);
        $consulta->bindValue(':tiempo', $tiempo);
        $consulta->bindValue(':endpoint', $endpoint);
        return $consulta->execute();
    }
    public static function TraerTodos()
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT dni, sector, tiempo, endpoint FROM log_trabajadores");
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_ASSOC);
    }

}
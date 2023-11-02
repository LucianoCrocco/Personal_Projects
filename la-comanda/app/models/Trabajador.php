<?php
class Trabajador
{
    private $id;
    public $nombre;
    public $apellido;
    public $estado_laboral;
    public $tipo;
    public $dni;
    private $codigo_login;
    public $edad;

    public static function AltaTrabajador($nombre, $apellido, $estado_laboral, $tipo, $dni, $codigo_login, $edad)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("INSERT INTO trabajadores (nombre, apellido, estado_laboral, tipo, dni, codigo_login, edad) VALUES (:nombre, :apellido, :estado_laboral, :tipo, :dni, :codigo_login, :edad)");
        $consulta->bindValue(':nombre', $nombre, PDO::PARAM_STR);
        $consulta->bindValue(':apellido', $apellido, PDO::PARAM_STR);
        $consulta->bindValue(':estado_laboral', $estado_laboral, PDO::PARAM_STR);
        $consulta->bindValue(':tipo', $tipo, PDO::PARAM_STR);
        $consulta->bindValue(':dni', $dni, PDO::PARAM_INT);
        $consulta->bindValue(':codigo_login', $codigo_login, PDO::PARAM_STR);
        $consulta->bindValue(':edad', $edad, PDO::PARAM_INT);
        return $consulta->execute();

    }
    public static function AltaFichaTrabajador($dni, $tipo, $fecha_alta, $fecha_baja)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("INSERT INTO fichas_laborales (dni_trabajador, tipo, fecha_alta, fecha_baja) VALUES (:dni, :tipo, :fecha_alta, :fecha_baja)");
        $consulta->bindValue(':dni', $dni, PDO::PARAM_INT);
        $consulta->bindValue(':tipo', $tipo, PDO::PARAM_STR);
        $consulta->bindValue(':fecha_alta', $fecha_alta);
        $consulta->bindValue(':fecha_baja', $fecha_baja);
        return $consulta->execute();
    }

    public static function TraerId($dni)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT id FROM trabajadores WHERE dni = :dni");
        $consulta->bindValue(':dni', $dni, PDO::PARAM_INT);
        $consulta->execute();

        return $consulta->fetch();

    }
    public static function TraerUno($dni, $codigo_login)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT nombre, apellido, dni, tipo FROM trabajadores WHERE dni = :dni AND codigo_login = :codigo_login AND trabajadores.estado_laboral != 'suspendido' AND trabajadores.estado_laboral != 'baja'");
        $consulta->bindValue(':dni', $dni, PDO::PARAM_INT);
        $consulta->bindValue(':codigo_login', $codigo_login, PDO::PARAM_STR);
        $consulta->execute();

        return $consulta->fetch(PDO::FETCH_OBJ);
    }
    public static function TraerTodos()
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT nombre, apellido, estado_laboral, tipo, dni, edad FROM trabajadores");
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_ASSOC);
    }
    public static function ActualizarEstadoEmpleado($dni, $estado)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("UPDATE trabajadores SET trabajadores.estado_laboral = :estado WHERE trabajadores.dni= :dni");
        $consulta->bindValue(':dni', $dni);
        $consulta->bindValue(':estado', $estado);
        return $consulta->execute();
    }
    public static function RegistrarSuspensionTrabajador($dni, $sector, $comienzo, $motivo)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("INSERT INTO fichas_suspensiones (dni, sector, comienzo, motivo) VALUES (:dni, :sector, :comienzo, :motivo)");
        $consulta->bindValue(':dni', $dni);
        $consulta->bindValue(':sector', $sector);
        $consulta->bindValue(':comienzo', $comienzo);
        $consulta->bindValue(':motivo', $motivo);
        return $consulta->execute();
    }
    public static function IdFichaSuspensionSinTerminar($dni)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT id FROM fichas_suspensiones WHERE fichas_suspensiones.dni = :dni AND fichas_suspensiones.fin IS NULL");
        $consulta->bindValue(':dni', $dni);
        $consulta->execute();

        return $consulta->fetchColumn();
    }
    public static function BajaTrabajador($dni, $fecha_baja)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("UPDATE fichas_laborales SET fichas_laborales.fecha_baja = :fecha_baja WHERE fichas_laborales.dni_trabajador = :dni");
        $consulta->bindValue(':dni', $dni);
        $consulta->bindValue(':fecha_baja', $fecha_baja);
        return $consulta->execute();
    }
    public static function TerminarSuspensionTrabajador($dni, $fin, $id)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("UPDATE fichas_suspensiones SET fichas_suspensiones.fin = :fin WHERE fichas_suspensiones.dni = :dni AND fichas_suspensiones.id = :id");
        $consulta->bindValue(':dni', $dni);
        $consulta->bindValue(':fin', $fin);
        $consulta->bindValue(':id', $id);
        return $consulta->execute();
    }
}
<?php
class Mesa
{
    private $id;
    public $estado;
    public $codigo_alfanumerico;

    public static function AltaMesa($estado, $codigo_alfanumerico)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("INSERT INTO mesas (estado, codigo_alfanumerico) VALUES (:estado, :codigo_alfanumerico)");
        $consulta->bindValue(':estado', $estado, PDO::PARAM_STR);
        $consulta->bindValue(':codigo_alfanumerico', $codigo_alfanumerico);
        return $consulta->execute();

    }

    public static function TraerTodos()
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT estado, codigo_alfanumerico FROM mesas");
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_ASSOC);
    }

    public static function BuscarMesaVacia()
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT id, codigo_alfanumerico FROM mesas WHERE estado = 'vacia' LIMIT 1");
        $consulta->execute();

        return $consulta->fetch(PDO::FETCH_ASSOC);
    }
    public static function ActualizarEstadoMesa($estado, $codigo_alfanumerico)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("UPDATE mesas SET estado = :estado WHERE codigo_alfanumerico = :codigo_alfanumerico");
        $consulta->bindValue(':estado', $estado, PDO::PARAM_STR);
        $consulta->bindValue(':codigo_alfanumerico', $codigo_alfanumerico);
        return $consulta->execute();
    }
    public static function ActualizarHorarioMesa($horario, $codigo_alfanumerico)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("UPDATE mesas SET tiempo_esperando = :horario WHERE codigo_alfanumerico = :codigo_alfanumerico");
        $consulta->bindValue(':horario', $horario);
        $consulta->bindValue(':codigo_alfanumerico', $codigo_alfanumerico);
        return $consulta->execute();
    }
    public static function BuscarMesaMozo()
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT id, codigo_alfanumerico FROM mesas WHERE estado = 'ocupada' ORDER BY tiempo_esperando DESC LIMIT 1");
        $consulta->execute();

        return $consulta->fetch(PDO::FETCH_ASSOC);
    }

    public static function AsignarMozo($dni, $codigo_alfanumerico)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("UPDATE mesas SET dni_mesero = :dni WHERE codigo_alfanumerico = :codigo_alfanumerico");
        $consulta->bindValue(':dni', $dni, PDO::PARAM_STR);
        $consulta->bindValue(':codigo_alfanumerico', $codigo_alfanumerico);
        return $consulta->execute();
    }
    public static function TotalAPagar($codigo_alfanumerico)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT SUM(pedidos.total_a_pagar) FROM pedidos INNER JOIN mesas ON pedidos.codigo_mesa = mesas.codigo_alfanumerico WHERE mesas.codigo_alfanumerico = :codigo_alfanumerico");
        $consulta->bindValue(':codigo_alfanumerico', $codigo_alfanumerico);
        $consulta->execute();

        return $consulta->fetchColumn();
    }

    public static function TraerEstadoTodosPedidosMesa($codigo_alfanumerico)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT estado FROM pedidos WHERE pedidos.codigo_mesa = :codigo_alfanumerico");
        $consulta->bindValue(':codigo_alfanumerico', $codigo_alfanumerico);
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_ASSOC);
    }

}
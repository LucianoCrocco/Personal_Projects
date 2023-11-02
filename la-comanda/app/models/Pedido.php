<?php
class Pedido
{
    public $id;
    public $codigo_alfanumerico;
    public $codigo_mesa;
    public $dni_mesero;
    public $estado;
    public $tiempo_orden;
    public $tiempo_maximo;
    public $tiempo_entrega;

    public static function AltaPedido($codigo_mesa, $codigo_pedido, $dni_mesero, $estado, $tiempo_orden, $tiempo_maximo, $tiempo_entrega, $total_a_pagar)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("INSERT INTO pedidos (codigo_mesa, codigo_pedido, dni_mesero, estado, tiempo_orden, tiempo_maximo, tiempo_entrega, total_a_pagar) VALUES (:codigo_mesa, :codigo_pedido, :dni_mesero, :estado, :tiempo_orden, :tiempo_maximo, :tiempo_entrega, :total_a_pagar)");
        $consulta->bindValue(':codigo_mesa', $codigo_mesa, PDO::PARAM_STR);
        $consulta->bindValue(':codigo_pedido', $codigo_pedido, PDO::PARAM_STR);
        $consulta->bindValue(':dni_mesero', $dni_mesero);
        $consulta->bindValue(':estado', $estado, PDO::PARAM_STR);
        $consulta->bindValue(':tiempo_orden', $tiempo_orden);
        $consulta->bindValue(':tiempo_maximo', $tiempo_maximo);
        $consulta->bindValue(':tiempo_entrega', $tiempo_entrega);
        $consulta->bindValue(':total_a_pagar', $total_a_pagar);
        $consulta->execute();

        return $consulta->fetch(PDO::FETCH_ASSOC);
    }
    public static function TraerTodos()
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT * FROM pedidos");
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_ASSOC);
    }
    public static function ActualizarEstadoPedido($codigo_pedido, $estado)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("UPDATE pedidos SET pedidos.estado = :estado WHERE pedidos.codigo_pedido= :codigo_pedido");
        $consulta->bindValue(':codigo_pedido', $codigo_pedido, PDO::PARAM_STR);
        $consulta->bindValue(':estado', $estado, PDO::PARAM_STR);
        $consulta->execute();
        return $consulta->fetchAll();
    }
    public static function ActualizarHorarioPedido($codigo_pedido, $tiempo_entrega)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("UPDATE pedidos SET pedidos.tiempo_entrega = :tiempo_entrega WHERE pedidos.codigo_pedido= :codigo_pedido");
        $consulta->bindValue(':tiempo_entrega', $tiempo_entrega, PDO::PARAM_STR);
        $consulta->bindValue(':codigo_pedido', $codigo_pedido, PDO::PARAM_STR);
        $consulta->execute();
        return $consulta->fetchAll();
    }

    public static function TraerTodosProductosPedido($codigo_pedido)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT pedidos_detalle.id,  pedidos_detalle.id_producto, productos.nombre, pedidos_detalle.estado, pedidos_detalle.cantidad FROM pedidos_detalle INNER JOIN productos ON productos.id = pedidos_detalle.id_producto WHERE :codigo_pedido = pedidos_detalle.codigo_pedido");
        $consulta->bindValue(':codigo_pedido', $codigo_pedido);
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_ASSOC);
    }
    public static function TiempoMaximoPedido($codigo_pedido, $codigo_mesa)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT pedidos.tiempo_maximo FROM pedidos WHERE :codigo_pedido = pedidos.codigo_pedido AND :codigo_mesa = pedidos.codigo_mesa");
        $consulta->bindValue(':codigo_pedido', $codigo_pedido);
        $consulta->bindValue(':codigo_mesa', $codigo_mesa);
        $consulta->execute();

        return $consulta->fetchColumn();
    }
}
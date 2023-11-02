<?php
include_once './models/Trabajador.php';
class Mozo extends Trabajador
{

    public static function ProductosListosParaServir($dni, $estado)
    {
        //* MOSTRAR MESA, NOMBRE PRODUCTO, ID PRODUCTO, CANTIDAD,
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT pedidos_detalle.id, productos.nombre, pedidos_detalle.cantidad, pedidos.codigo_mesa, mesas.id, pedidos.codigo_pedido FROM productos INNER JOIN pedidos_detalle ON pedidos_detalle.id = productos.id INNER JOIN pedidos ON pedidos_detalle.codigo_pedido = pedidos.codigo_pedido INNER JOIN mesas ON mesas.codigo_alfanumerico = pedidos.codigo_mesa WHERE pedidos.dni_mesero = :dni AND pedidos_detalle.estado = :estado");
        $consulta->bindValue(':dni', $dni);
        $consulta->bindValue(':estado', $estado);
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_NAMED);
    }
}
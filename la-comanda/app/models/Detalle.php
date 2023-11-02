<?php
class Detalle
{
    public $id;
    public $codigo_pedido;
    public $id_producto;
    public $cantidad;
    public $estado;
    public $dni_trabajador_asignado;

    public static function AltaDetalle($id_producto, $codigo_pedido, $cantidad, $estado)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("INSERT INTO pedidos_detalle (id_producto, codigo_pedido, cantidad, estado) VALUES (:id_producto, :codigo_pedido, :cantidad, :estado)");
        $consulta->bindValue(':id_producto', $id_producto, PDO::PARAM_INT);
        $consulta->bindValue(':codigo_pedido', $codigo_pedido, PDO::PARAM_INT);
        $consulta->bindValue(':cantidad', $cantidad, PDO::PARAM_INT);
        $consulta->bindValue(':estado', $estado, PDO::PARAM_STR);
        return $consulta->execute();
    }

    public static function TraerUnoId($id_producto)
    {

        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT pedidos_detalle.id, productos.nombre, productos.sector FROM pedidos_detalle INNER JOIN productos ON pedidos_detalle.id_producto = productos.id WHERE pedidos_detalle.id = :idProducto");
        $consulta->bindValue(':idProducto', $id_producto, PDO::PARAM_INT);
        $consulta->execute();

        return $consulta->fetch();
    }


    public static function ActualizarEstadoDetalle($id_detalle_producto, $estado)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("UPDATE pedidos_detalle SET pedidos_detalle.estado = :estado WHERE pedidos_detalle.id = :id_detalle_producto");
        $consulta->bindValue(':id_detalle_producto', $id_detalle_producto, PDO::PARAM_INT);
        $consulta->bindValue(':estado', $estado, PDO::PARAM_STR);
        return $consulta->execute();
    }

    public static function ListarEstadoDetalle($sector, $estado)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT pedidos_detalle.id, productos.nombre, productos.tiempo_elaboracion, pedidos_detalle.codigo_pedido FROM pedidos_detalle INNER JOIN productos ON productos.id = pedidos_detalle.id_producto JOIN pedidos ON pedidos.codigo_pedido = pedidos_detalle.codigo_pedido WHERE productos.sector = :sector AND pedidos_detalle.estado = :estado ORDER BY pedidos.tiempo_orden DESC");
        $consulta->bindValue(':estado', $estado, PDO::PARAM_INT);
        $consulta->bindValue(':sector', $sector, PDO::PARAM_INT);
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_ASSOC);
    }
    public static function VerificarEstadoDetalle($id, $estado)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT pedidos_detalle.id, productos.nombre FROM productos INNER JOIN pedidos_detalle ON pedidos_detalle.id = productos.id WHERE pedidos_detalle.id = :id AND pedidos_detalle.estado = :estado");
        $consulta->bindValue(':id', $id);
        $consulta->bindValue(':estado', $estado);
        $consulta->execute();

        return $consulta->fetchObject();
    }
    public static function AsignarTrabajadorDetalle($id_detalle_producto, $dni_trabajador)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("UPDATE pedidos_detalle SET pedidos_detalle.dni_trabajador_asignado = :dni_trabajador WHERE pedidos_detalle.id = :id_pedido_detalle");
        $consulta->bindValue(':dni_trabajador', $dni_trabajador, PDO::PARAM_INT);
        $consulta->bindValue(':id_pedido_detalle', $id_detalle_producto, PDO::PARAM_INT);
        return $consulta->execute();
    }

}
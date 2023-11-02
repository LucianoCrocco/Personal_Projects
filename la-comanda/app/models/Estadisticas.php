<?php
class Estadisticas
{
    public static function PedidoMaximoDinero($tiempoHoy, $treintaDias)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT MAX(pedidos.total_a_pagar) FROM pedidos WHERE pedidos.tiempo_orden <= :tiempoHoy AND pedidos.tiempo_orden >= :treintaDias");
        $consulta->bindValue(':tiempoHoy', $tiempoHoy);
        $consulta->bindValue(':treintaDias', $treintaDias);
        $consulta->execute();

        return $consulta->fetchColumn();
    }
    public static function PedidoMinimoDinero($tiempoHoy, $treintaDias)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT MIN(pedidos.total_a_pagar) FROM pedidos WHERE pedidos.tiempo_orden <= :tiempoHoy AND pedidos.tiempo_orden >= :treintaDias");
        $consulta->bindValue(':tiempoHoy', $tiempoHoy);
        $consulta->bindValue(':treintaDias', $treintaDias);
        $consulta->execute();

        return $consulta->fetchColumn();
    }
    public static function ProductoMasVendido($tiempoHoy, $treintaDias)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT productos.nombre, SUM(pedidos_detalle.cantidad) as valor FROM productos INNER JOIN pedidos_detalle ON pedidos_detalle.id_producto = productos.id INNER JOIN pedidos ON pedidos_detalle.codigo_pedido = pedidos.codigo_pedido WHERE pedidos.tiempo_orden <= :tiempoHoy AND pedidos.tiempo_orden >= :treintaDias GROUP BY pedidos_detalle.id_producto ORDER BY valor DESC LIMIT 1");
        $consulta->bindValue(':tiempoHoy', $tiempoHoy);
        $consulta->bindValue(':treintaDias', $treintaDias);
        $consulta->execute();

        return $consulta->fetchObject();
    }
    public static function ProductoMenosVendido($tiempoHoy, $treintaDias)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT productos.nombre, SUM(pedidos_detalle.cantidad) as valor FROM productos INNER JOIN pedidos_detalle ON pedidos_detalle.id_producto = productos.id INNER JOIN pedidos ON pedidos_detalle.codigo_pedido = pedidos.codigo_pedido WHERE pedidos.tiempo_orden <= :tiempoHoy AND pedidos.tiempo_orden >= :treintaDias GROUP BY pedidos_detalle.id_producto ORDER BY valor ASC LIMIT 1");
        $consulta->bindValue(':tiempoHoy', $tiempoHoy);
        $consulta->bindValue(':treintaDias', $treintaDias);
        $consulta->execute();

        return $consulta->fetchObject();
    }
    public static function PedidoMayorTiempoEspera($tiempoHoy, $treintaDias)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT tiempo_maximo FROM pedidos  WHERE pedidos.tiempo_orden <= :tiempoHoy AND pedidos.tiempo_orden >= :treintaDias ORDER BY tiempo_maximo DESC LIMIT 1");
        $consulta->bindValue(':tiempoHoy', $tiempoHoy);
        $consulta->bindValue(':treintaDias', $treintaDias);
        $consulta->execute();

        return $consulta->fetchColumn();
    }
    public static function PedidoMenorTiempoEspera($tiempoHoy, $treintaDias)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT tiempo_maximo FROM pedidos  WHERE pedidos.tiempo_orden <= :tiempoHoy AND pedidos.tiempo_orden >= :treintaDias ORDER BY tiempo_maximo ASC LIMIT 1");
        $consulta->bindValue(':tiempoHoy', $tiempoHoy);
        $consulta->bindValue(':treintaDias', $treintaDias);
        $consulta->execute();

        return $consulta->fetchColumn();
    }
    public static function TiempoEstipuladoPedido()
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT pedidos.codigo_pedido, pedidos.tiempo_maximo, pedidos.tiempo_orden, pedidos.tiempo_entrega FROM pedidos");
        $consulta->execute();
        return $consulta->fetchAll(PDO::FETCH_ASSOC);
    }

}
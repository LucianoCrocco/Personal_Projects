<?php
class Producto
{
    public $id;
    public $nombre;
    public $sector;
    public $tiempo_elaboracion;
    public $precio;

    public static function AltaProducto($nombre, $sector, $tiempo_elaboracion, $precio)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("INSERT INTO productos (nombre, sector, tiempo_elaboracion, precio) VALUES (:nombre, :sector, :tiempo_elaboracion, :precio)");
        $consulta->bindValue(':nombre', $nombre, PDO::PARAM_STR);
        $consulta->bindValue(':sector', $sector, PDO::PARAM_STR);
        $consulta->bindValue(':tiempo_elaboracion', $tiempo_elaboracion);
        $consulta->bindValue(':precio', $precio);
        return $consulta->execute();
    }

    public static function TraerTodos()
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT * FROM productos");
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_ASSOC);
    }
    public static function ProductoPrecio($id)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT precio FROM productos WHERE productos.id = :id");
        $consulta->bindValue(':id', $id);
        $consulta->execute();
        return $consulta->fetchColumn();
    }
    public static function ProductoTiempoElaboracion($id)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta("SELECT tiempo_elaboracion FROM productos WHERE productos.id = :id");
        $consulta->bindValue(':id', $id);
        $consulta->execute();
        return $consulta->fetchColumn();
    }
    public static function DescargaProductosCSV($productos)
    {
        if (is_array($productos)) {
            $archivo = fopen("./csv/dataProductos.csv", "w");
            if ($archivo != FALSE) {
                fputs($archivo, 'nombre,sector,tiempo_elaboracion,precio' . PHP_EOL);
                foreach ($productos as $v) {
                    fputs($archivo, $v["nombre"] . "," . $v["sector"] . "," . $v["tiempo_elaboracion"] . "," . $v["precio"] . PHP_EOL);
                }
                fclose($archivo);
            }
        }
    }

    public static function CargarProductosCSV($filePath)
    {
        $flagHeader = 0;
        $archivo = fopen($filePath, "r");
        if ($archivo != FALSE) {
            while (!feof($archivo)) {
                $mensaje = fgets($archivo);
                if (!empty($mensaje) && $flagHeader) {
                    $mensaje = str_replace("\n", "", $mensaje);
                    //$mensaje = str_replace("\"", "", $mensaje);
                    $auxArray = explode(",", $mensaje);
                    //echo $auxArray[0] . " " . $auxArray[1] . " " . $auxArray[2] . " " . $auxArray[3] . PHP_EOL;

                    Producto::AltaProducto($auxArray[0], $auxArray[1], $auxArray[2], $auxArray[3]);
                }
                $flagHeader++;
            }
        }
    }
}
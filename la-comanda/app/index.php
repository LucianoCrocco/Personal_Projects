<?php
use Illuminate\Contracts\Support\Responsable;

date_default_timezone_set('America/Argentina/Buenos_Aires');
// Error Handling
error_reporting(-1);
ini_set('display_errors', 1);

use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Psr\Http\Server\RequestHandlerInterface;
use Slim\Factory\AppFactory;
use Slim\Routing\RouteCollectorProxy;
use Slim\Routing\RouteContext;

require __DIR__ . '/../vendor/autoload.php';

require_once './db/AccesoDatos.php';

require_once './controllers/SocioController.php';
require_once './controllers/NegocioController.php';
require_once './controllers/ClienteController.php';
require_once './controllers/LoginController.php';
require_once './controllers/MozoController.php';
require_once './controllers/CocineroController.php';
require_once './controllers/BartenderController.php';
require_once './controllers/CerveceroController.php';
require_once './controllers/PedidoController.php';

include_once './utils/JwtUtil.php';

include_once './models/Mesa.php';
include_once './models/Trabajador.php';
include_once './models/Mozo.php';
include_once './models/Producto.php';
include_once './models/Pedido.php';
include_once './models/Detalle.php';
include_once './models/Socio.php';
include_once './models/LogsTrabajadores.php';
include_once './models/Estadisticas.php';

require_once './middlewares/AuthJWT.php';
require_once './middlewares/LogTrabajadoresMW.php';
require_once './middlewares/ValidarAccionTrabajadorMW.php';

// Load ENV
$dotenv = Dotenv\Dotenv::createImmutable(__DIR__);
$dotenv->safeLoad();

// Instantiate App
$app = AppFactory::create();

// Add error middleware
$app->addErrorMiddleware(true, true, true);

// Add parse body
$app->addBodyParsingMiddleware();

// Routes
$app->post("/login", \LoginController::class . ':Login');

$app->group("/socio", function (RouteCollectorProxy $group) {
    //* ALTAS 
    $group->post("/altaproducto[/]", \SocioController::class . ':AltaProducto');
    $group->post("/altatrabajador[/]", \SocioController::class . ':AltaTrabajador');
    $group->post("/altamesa[/]", \SocioController::class . ':AltaMesa');
    //* Cerrar Mesa
    $group->post("/cerrarmesa[/]", \SocioController::class . ':CerrarMesa');
    //* CSV de productos
    $group->post("/csv/productos[/]", \SocioController::class . ':CargarProductosCSV');
    $group->get("/csv/productos[/]", \SocioController::class . ':DescargaProductosCSV');
    //* Manejo estado de un empleado (baja y modificacion);
    $group->post("/suspendertrabajador[/]", \SocioController::class . ':SuspenderTrabajador');
    $group->post("/terminarsuspension[/]", \SocioController::class . ':TerminarSuspension');
    $group->post("/bajatrabajador[/]", \SocioController::class . ':BajaTrabajador');

    //* Estadisticas de los pedidos (ultimos 30 dias) en PDF.
    $group->get("/logspedidos[/]", \SocioController::class . ':EstadisticasPedidos');

    //* Seguimiento acciones de los empleados en PDF. 
    $group->get("/logs[/]", \SocioController::class . ':TodosLogsTrabajadoresPDF');

})->add(\AuthJWT::class . ':VerificarSocioToken')->add(\AuthJWT::class . ':VerificarTokenValido');
//* HECHO HASTA AHORA: CLIENTE SE LE ASIGNA MESA, MOZO TOMA UNA MESA, CLIENTE LE HACE UN PEDIDO AL MOZO Y ESTE DA DE ALTA EL PEDIDO.


$app->group("/negocio", function (RouteCollectorProxy $group) {
    $group->get("/listarproductos[/]", \NegocioController::class . ':ListarProductos');
    $group->get("/listartrabajadores[/]", \NegocioController::class . ':ListarTrabajadores');
    $group->get("/listarmesas[/]", \NegocioController::class . ':ListarMesas');
    $group->get("/listarpedidos[/]", \NegocioController::class . ':ListarPedidos');
})->add(\AuthJWT::class . ':VerificarTokenValido');


$app->group("/pedidos", function (RouteCollectorProxy $group) {
    $group->get("/listarpedidospendientes[/]", \NegocioController::class . ':ListarPendientes'); // Dependiendo del tipo muestra pedidos pendientes y su correspondiente producto que puede tomar
})->add(\AuthJWT::class . ':VerificarTokenValido');


$app->group("/mesero", function (RouteCollectorProxy $group) {
    $group->get("/asignarmesa[/]", \MozoController::class . ':AsignarMesa')->add(\LogTrabajadoresMW::class . ':RegistrarAccion');
    $group->post("/{codigo_mesa}/altapedido[/]", \MozoController::class . ':AltaPedido')->add(\LogTrabajadoresMW::class . ':RegistrarAccion');
    $group->get("/listarpedidos[/]", \MozoController::class . ':ListarPedidosListos');
    $group->put("/servirpedido[/]", \MozoController::class . ':ActualizarPedidoDetalle')->add(\LogTrabajadoresMW::class . ':RegistrarAccion');
    $group->post("/cobrarmesa[/]", \MozoController::class . ':CobrarMesa')->add(\LogTrabajadoresMW::class . ':RegistrarAccion');
    $group->post("/liberarmesa[/]", \MozoController::class . ':LiberarMesa')->add(\LogTrabajadoresMW::class . ':RegistrarAccion');
    //*CANDY BAR
    $group->get("/mostrarencola[/]", \MozoController::class . ':MostrarDetalleEnCola');
    $group->post("/prepararpedido[/]", \PedidoController::class . ':PrepararPedidoDetalle')->add(\LogTrabajadoresMW::class . ':RegistrarAccion')->add(\ValidarAccionTrabajadorMW::class . ':ValidarAccion');
    $group->put("/prepararpedido[/]", \PedidoController::class . ':ListoPedidoDetalle')->add(\LogTrabajadoresMW::class . ':RegistrarAccion')->add(\ValidarAccionTrabajadorMW::class . ':ValidarAccion');
})->add(\AuthJWT::class . ':VerificarEmpleadoToken')->add(\AuthJWT::class . ':VerificarTokenValido');

$app->group("/cocinero", function (RouteCollectorProxy $group) {
    $group->get("/mostrarencola[/]", \CocineroController::class . ':MostrarDetalleEnCola');
    $group->post("/prepararpedido[/]", \PedidoController::class . ':PrepararPedidoDetalle')->add(\LogTrabajadoresMW::class . ':RegistrarAccion')->add(\ValidarAccionTrabajadorMW::class . ':ValidarAccion');
    $group->put("/prepararpedido[/]", \PedidoController::class . ':ListoPedidoDetalle')->add(\LogTrabajadoresMW::class . ':RegistrarAccion')->add(\ValidarAccionTrabajadorMW::class . ':ValidarAccion');
})->add(\AuthJWT::class . ':VerificarEmpleadoToken')->add(\AuthJWT::class . ':VerificarTokenValido');

$app->group("/cervecero", function (RouteCollectorProxy $group) {
    $group->get("/mostrarencola[/]", \CerveceroController::class . ':MostrarDetalleEnCola');
    $group->post("/prepararpedido[/]", \PedidoController::class . ':PrepararPedidoDetalle')->add(\LogTrabajadoresMW::class . ':RegistrarAccion')->add(\ValidarAccionTrabajadorMW::class . ':ValidarAccion');
    $group->put("/prepararpedido[/]", \PedidoController::class . ':ListoPedidoDetalle')->add(\LogTrabajadoresMW::class . ':RegistrarAccion')->add(\ValidarAccionTrabajadorMW::class . ':ValidarAccion');
})->add(\AuthJWT::class . ':VerificarEmpleadoToken')->add(\AuthJWT::class . ':VerificarTokenValido');

$app->group("/bartender", function (RouteCollectorProxy $group) {
    $group->get("/mostrarencola[/]", \BartenderController::class . ':MostrarDetalleEnCola');
    $group->post("/prepararpedido[/]", \PedidoController::class . ':PrepararPedidoDetalle')->add(\LogTrabajadoresMW::class . ':RegistrarAccion')->add(\ValidarAccionTrabajadorMW::class . ':ValidarAccion');
    $group->put("/prepararpedido[/]", \PedidoController::class . ':ListoPedidoDetalle')->add(\LogTrabajadoresMW::class . ':RegistrarAccion')->add(\ValidarAccionTrabajadorMW::class . ':ValidarAccion');
})->add(\AuthJWT::class . ':VerificarEmpleadoToken')->add(\AuthJWT::class . ':VerificarTokenValido');

$app->group("/cliente", function (RouteCollectorProxy $group) {
    $group->get("/asignarmesa[/]", \ClienteController::class . ':AsignarMesa');
    $group->get("/totalapagar/{codigo_mesa}[/]", \ClienteController::class . ':TotalAPagar');
    $group->get("/codigo/{codigo_pedido}[/]", \ClienteController::class . ':EstadoPedido');
    $group->get("/codigo/{codigo_pedido}/{codigo_mesa}[/]", \ClienteController::class . ':TiempoMaximoPedido');
});

$app->run();
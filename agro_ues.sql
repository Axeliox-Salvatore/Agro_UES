-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 26-06-2025 a las 23:42:20
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `agro_ues`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `aprobaciones`
--

CREATE TABLE `aprobaciones` (
  `id_aprobacion` int(11) NOT NULL,
  `tipo_proceso` enum('devolucion','ajuste','otro') NOT NULL,
  `descripcion` text DEFAULT NULL,
  `estado` enum('pendiente','aprobado','rechazado') DEFAULT 'pendiente',
  `usuario_id` int(11) NOT NULL,
  `nombre_usuario_aprueba` varchar(100) DEFAULT NULL,
  `fecha_hora` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categorias`
--

CREATE TABLE `categorias` (
  `id_categoria` int(11) NOT NULL,
  `nombre_categoria` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `categorias`
--

INSERT INTO `categorias` (`id_categoria`, `nombre_categoria`) VALUES
(1, 'Fertilizantes'),
(2, 'Herramientas'),
(3, 'Semillas');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `compras`
--

CREATE TABLE `compras` (
  `id_compra` int(11) NOT NULL,
  `proveedor_id` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `fecha_compra` datetime DEFAULT current_timestamp(),
  `total` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalle_compras`
--

CREATE TABLE `detalle_compras` (
  `id_detalle` int(11) NOT NULL,
  `compra_id` int(11) NOT NULL,
  `producto_id` int(11) NOT NULL,
  `nombre_producto` varchar(100) DEFAULT NULL,
  `cantidad` int(11) NOT NULL,
  `precio_unitario` decimal(10,2) NOT NULL,
  `subtotal` decimal(10,2) GENERATED ALWAYS AS (`cantidad` * `precio_unitario`) STORED
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `detalle_ventas`
--

CREATE TABLE `detalle_ventas` (
  `id_detalle` int(11) NOT NULL,
  `venta_id` int(11) NOT NULL,
  `producto_id` int(11) NOT NULL,
  `nombre_producto` varchar(100) DEFAULT NULL,
  `cantidad` int(11) NOT NULL,
  `precio_unitario` decimal(10,2) NOT NULL,
  `subtotal` decimal(10,2) GENERATED ALWAYS AS (`cantidad` * `precio_unitario`) STORED
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `historial_acciones`
--

CREATE TABLE `historial_acciones` (
  `id_historial` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `nombre_usuario` varchar(100) DEFAULT NULL,
  `accion` text NOT NULL,
  `fecha_hora` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `historial_acciones`
--

INSERT INTO `historial_acciones` (`id_historial`, `usuario_id`, `nombre_usuario`, `accion`, `fecha_hora`) VALUES
(1, 1, 'Admin', 'Cambio de contraseña', '2025-06-22 18:45:10'),
(2, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-22 18:56:25'),
(3, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 07:23:18'),
(4, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 07:24:25'),
(5, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 07:25:18'),
(6, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 07:32:10'),
(7, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 09:32:09'),
(8, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 09:32:16'),
(9, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 09:32:48'),
(10, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 09:39:26'),
(11, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 09:42:24'),
(12, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 09:47:22'),
(13, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 09:58:06'),
(14, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 09:59:39'),
(15, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 10:29:46'),
(16, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 10:32:02'),
(17, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 10:33:22'),
(18, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 10:47:40'),
(19, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 11:52:59'),
(20, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 12:06:02'),
(21, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 12:07:19'),
(22, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 12:15:23'),
(23, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 13:03:51'),
(24, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 13:17:05'),
(25, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 22:56:22'),
(26, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 23:01:51'),
(27, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 23:08:34'),
(28, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 23:12:34'),
(29, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-24 23:14:40'),
(30, 1, 'Admin', 'Registro nuevo usuario: Josue Carlos', '2025-06-24 23:15:13'),
(31, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 00:49:20'),
(32, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 01:07:01'),
(33, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 01:10:43'),
(34, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 01:11:34'),
(35, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 02:35:45'),
(36, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 02:36:39'),
(37, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 02:42:49'),
(38, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 02:44:15'),
(39, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 02:54:42'),
(40, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 02:56:38'),
(41, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 02:59:24'),
(42, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 03:02:20'),
(43, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 03:02:46'),
(44, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 03:04:57'),
(45, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 03:14:37'),
(46, 1, 'Admin', 'Generó reporte: Productos (18/06/2025 - 25/06/2025)', '2025-06-25 03:14:55'),
(47, 1, 'Admin', 'Generó respaldo de la base de datos', '2025-06-25 03:15:52'),
(48, 1, 'Admin', 'Generó respaldo de la base de datos', '2025-06-25 03:16:50'),
(49, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 03:21:09'),
(50, 1, 'Admin', 'Generó respaldo de la base de datos', '2025-06-25 03:21:11'),
(51, 1, 'Admin', 'Generó respaldo de la base de datos', '2025-06-25 03:21:49'),
(52, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 03:25:29'),
(53, 1, 'Admin', 'Genero respaldo de la base de datos', '2025-06-25 03:25:32'),
(54, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 03:37:26'),
(55, 1, 'Admin', 'Generó respaldo de la base de datos', '2025-06-25 03:38:06'),
(56, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 03:39:18'),
(57, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-25 03:40:19'),
(58, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-26 11:11:09'),
(59, 1, 'Admin', 'Generó respaldo de la base de datos', '2025-06-26 11:12:37'),
(60, 1, 'Admin', 'Inicio de sesión en el sistema', '2025-06-26 15:38:45'),
(61, 1, 'Admin', 'Registro nuevo usuario: Juan Carlos', '2025-06-26 15:39:32'),
(62, 10, 'Juan Carlos', 'Inicio de sesión en el sistema', '2025-06-26 15:40:39');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `permisos`
--

CREATE TABLE `permisos` (
  `id_permiso` int(11) NOT NULL,
  `nombre_permiso` varchar(100) NOT NULL,
  `descripcion` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `id_producto` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `descripcion` text DEFAULT NULL,
  `categoria_id` int(11) NOT NULL,
  `precio` decimal(10,2) NOT NULL,
  `stock` int(11) NOT NULL DEFAULT 0,
  `fecha_vencimiento` date DEFAULT NULL,
  `alerta_bajo_stock` tinyint(1) DEFAULT 0,
  `ruta_imagen` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`id_producto`, `nombre`, `descripcion`, `categoria_id`, `precio`, `stock`, `fecha_vencimiento`, `alerta_bajo_stock`, `ruta_imagen`) VALUES
(1, 'Urea 46%', 'Fertilizante nitrogenado', 1, 25.50, 50, NULL, 0, NULL),
(2, 'Azadón', 'Herramienta para labranza', 2, 13.75, 20, NULL, 0, NULL),
(3, 'Maíz H-59', 'Semilla híbrida de maíz', 3, 7.90, 100, NULL, 0, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedores`
--

CREATE TABLE `proveedores` (
  `id_proveedor` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `contacto` varchar(100) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `direccion` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `recuperacion_password`
--

CREATE TABLE `recuperacion_password` (
  `id` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `codigo` varchar(10) NOT NULL,
  `fecha_solicitud` datetime NOT NULL,
  `usado` tinyint(1) DEFAULT 0,
  `usuario_modifico` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `recuperacion_password`
--

INSERT INTO `recuperacion_password` (`id`, `usuario_id`, `codigo`, `fecha_solicitud`, `usado`, `usuario_modifico`) VALUES
(1, 1, '995449', '2025-06-22 18:09:40', 0, NULL),
(2, 1, '474219', '2025-06-22 18:43:53', 1, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `respaldos`
--

CREATE TABLE `respaldos` (
  `id_respaldo` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `ruta_archivo` varchar(255) NOT NULL,
  `fecha_hora` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `roles`
--

CREATE TABLE `roles` (
  `id_rol` int(11) NOT NULL,
  `nombre_rol` varchar(50) NOT NULL,
  `descripcion` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `roles`
--

INSERT INTO `roles` (`id_rol`, `nombre_rol`, `descripcion`) VALUES
(1, 'Super Administrador', 'Acceso total al sistema'),
(2, 'Gerente', 'Gestión de reportes y aprobaciones'),
(3, 'Cajero', 'Realiza ventas'),
(4, 'Encargado de Almacen', 'Gestiona productos y stock');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rol_permisos`
--

CREATE TABLE `rol_permisos` (
  `id` int(11) NOT NULL,
  `rol_id` int(11) NOT NULL,
  `permiso_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `id_usuario` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `correo` varchar(100) NOT NULL,
  `contraseña_hash` varchar(255) NOT NULL,
  `rol_id` int(11) NOT NULL,
  `fecha_registro` datetime DEFAULT current_timestamp(),
  `estado` enum('activo','inactivo') DEFAULT 'activo'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`id_usuario`, `nombre`, `correo`, `contraseña_hash`, `rol_id`, `fecha_registro`, `estado`) VALUES
(1, 'Admin', 'hm23052@ues.edu.sv', '9af15b336e6a9619928537df30b2e6a2376569fcf9d7e773eccede65606529a0', 1, '2025-06-22 15:39:12', 'activo'),
(2, 'Gerente', 'gerente@agro.com', '98ec4ee87e461aa980d5ef58d68042c4a5b9b1d957bd04eac40f8b2fc582816a', 2, '2025-06-22 15:39:12', 'activo'),
(3, 'Almacen', 'almacen@agro.com', 'c21bcb25ea64255e7e09e04b9284805717a116b5cafbf7e3257b47b0cc7607c1', 4, '2025-06-22 15:39:12', 'activo'),
(4, 'Cajero', 'cajero@agro.com', 'd6a2cfcc09db01a0bc824ead5b03d12b6e8e3478480d34afefcf69a1c756478e', 3, '2025-06-22 15:39:12', 'activo'),
(9, 'Josue Carlos', 'Carlos@agro.com', '84b2a5d834daee2fff7eb5e31f44ba68eb860d86d2cf8e37606a26fa775cf23b', 3, '2025-06-24 23:15:13', 'activo'),
(10, 'Juan Carlos', 'dsadas@gmail.com', 'cbfad02f9ed2a8d1e08d8f74f5303e9eb93637d47f82ab6f1c15871cf8dd0481', 3, '2025-06-26 15:39:32', 'activo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ventas`
--

CREATE TABLE `ventas` (
  `id_venta` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `fecha_venta` datetime DEFAULT current_timestamp(),
  `total` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `aprobaciones`
--
ALTER TABLE `aprobaciones`
  ADD PRIMARY KEY (`id_aprobacion`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `categorias`
--
ALTER TABLE `categorias`
  ADD PRIMARY KEY (`id_categoria`);

--
-- Indices de la tabla `compras`
--
ALTER TABLE `compras`
  ADD PRIMARY KEY (`id_compra`),
  ADD KEY `proveedor_id` (`proveedor_id`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `detalle_compras`
--
ALTER TABLE `detalle_compras`
  ADD PRIMARY KEY (`id_detalle`),
  ADD KEY `compra_id` (`compra_id`),
  ADD KEY `producto_id` (`producto_id`);

--
-- Indices de la tabla `detalle_ventas`
--
ALTER TABLE `detalle_ventas`
  ADD PRIMARY KEY (`id_detalle`),
  ADD KEY `venta_id` (`venta_id`),
  ADD KEY `producto_id` (`producto_id`);

--
-- Indices de la tabla `historial_acciones`
--
ALTER TABLE `historial_acciones`
  ADD PRIMARY KEY (`id_historial`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `permisos`
--
ALTER TABLE `permisos`
  ADD PRIMARY KEY (`id_permiso`);

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`id_producto`),
  ADD KEY `categoria_id` (`categoria_id`);

--
-- Indices de la tabla `proveedores`
--
ALTER TABLE `proveedores`
  ADD PRIMARY KEY (`id_proveedor`);

--
-- Indices de la tabla `recuperacion_password`
--
ALTER TABLE `recuperacion_password`
  ADD PRIMARY KEY (`id`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `respaldos`
--
ALTER TABLE `respaldos`
  ADD PRIMARY KEY (`id_respaldo`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- Indices de la tabla `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id_rol`);

--
-- Indices de la tabla `rol_permisos`
--
ALTER TABLE `rol_permisos`
  ADD PRIMARY KEY (`id`),
  ADD KEY `rol_id` (`rol_id`),
  ADD KEY `permiso_id` (`permiso_id`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id_usuario`),
  ADD UNIQUE KEY `correo` (`correo`),
  ADD KEY `rol_id` (`rol_id`);

--
-- Indices de la tabla `ventas`
--
ALTER TABLE `ventas`
  ADD PRIMARY KEY (`id_venta`),
  ADD KEY `usuario_id` (`usuario_id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `aprobaciones`
--
ALTER TABLE `aprobaciones`
  MODIFY `id_aprobacion` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `categorias`
--
ALTER TABLE `categorias`
  MODIFY `id_categoria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `compras`
--
ALTER TABLE `compras`
  MODIFY `id_compra` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `detalle_compras`
--
ALTER TABLE `detalle_compras`
  MODIFY `id_detalle` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `detalle_ventas`
--
ALTER TABLE `detalle_ventas`
  MODIFY `id_detalle` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `historial_acciones`
--
ALTER TABLE `historial_acciones`
  MODIFY `id_historial` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=63;

--
-- AUTO_INCREMENT de la tabla `permisos`
--
ALTER TABLE `permisos`
  MODIFY `id_permiso` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `productos`
--
ALTER TABLE `productos`
  MODIFY `id_producto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `proveedores`
--
ALTER TABLE `proveedores`
  MODIFY `id_proveedor` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `recuperacion_password`
--
ALTER TABLE `recuperacion_password`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `respaldos`
--
ALTER TABLE `respaldos`
  MODIFY `id_respaldo` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `roles`
--
ALTER TABLE `roles`
  MODIFY `id_rol` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `rol_permisos`
--
ALTER TABLE `rol_permisos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id_usuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `ventas`
--
ALTER TABLE `ventas`
  MODIFY `id_venta` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `aprobaciones`
--
ALTER TABLE `aprobaciones`
  ADD CONSTRAINT `aprobaciones_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id_usuario`);

--
-- Filtros para la tabla `compras`
--
ALTER TABLE `compras`
  ADD CONSTRAINT `compras_ibfk_1` FOREIGN KEY (`proveedor_id`) REFERENCES `proveedores` (`id_proveedor`),
  ADD CONSTRAINT `compras_ibfk_2` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id_usuario`);

--
-- Filtros para la tabla `detalle_compras`
--
ALTER TABLE `detalle_compras`
  ADD CONSTRAINT `detalle_compras_ibfk_1` FOREIGN KEY (`compra_id`) REFERENCES `compras` (`id_compra`),
  ADD CONSTRAINT `detalle_compras_ibfk_2` FOREIGN KEY (`producto_id`) REFERENCES `productos` (`id_producto`);

--
-- Filtros para la tabla `detalle_ventas`
--
ALTER TABLE `detalle_ventas`
  ADD CONSTRAINT `detalle_ventas_ibfk_1` FOREIGN KEY (`venta_id`) REFERENCES `ventas` (`id_venta`),
  ADD CONSTRAINT `detalle_ventas_ibfk_2` FOREIGN KEY (`producto_id`) REFERENCES `productos` (`id_producto`);

--
-- Filtros para la tabla `historial_acciones`
--
ALTER TABLE `historial_acciones`
  ADD CONSTRAINT `historial_acciones_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id_usuario`);

--
-- Filtros para la tabla `productos`
--
ALTER TABLE `productos`
  ADD CONSTRAINT `productos_ibfk_1` FOREIGN KEY (`categoria_id`) REFERENCES `categorias` (`id_categoria`);

--
-- Filtros para la tabla `recuperacion_password`
--
ALTER TABLE `recuperacion_password`
  ADD CONSTRAINT `recuperacion_password_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id_usuario`);

--
-- Filtros para la tabla `respaldos`
--
ALTER TABLE `respaldos`
  ADD CONSTRAINT `respaldos_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id_usuario`);

--
-- Filtros para la tabla `rol_permisos`
--
ALTER TABLE `rol_permisos`
  ADD CONSTRAINT `rol_permisos_ibfk_1` FOREIGN KEY (`rol_id`) REFERENCES `roles` (`id_rol`),
  ADD CONSTRAINT `rol_permisos_ibfk_2` FOREIGN KEY (`permiso_id`) REFERENCES `permisos` (`id_permiso`);

--
-- Filtros para la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`rol_id`) REFERENCES `roles` (`id_rol`);

--
-- Filtros para la tabla `ventas`
--
ALTER TABLE `ventas`
  ADD CONSTRAINT `ventas_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id_usuario`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

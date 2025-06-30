-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 30-06-2025 a las 04:48:31
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
-- Estructura de tabla para la tabla `aprobaciones_almacen`
--

CREATE TABLE `aprobaciones_almacen` (
  `id_aprobacion` int(11) NOT NULL,
  `id_producto` int(11) NOT NULL,
  `descripcion` text NOT NULL,
  `precio` decimal(10,2) NOT NULL,
  `stock` int(11) NOT NULL,
  `fecha_vencimiento` date DEFAULT NULL,
  `estado` enum('Pendiente','Aprobada','Rechazada') DEFAULT 'Pendiente',
  `usuario_solicita` int(11) NOT NULL,
  `nombre_solicita` varchar(100) DEFAULT NULL,
  `fecha_solicita` datetime DEFAULT current_timestamp(),
  `usuario_responde` int(11) DEFAULT NULL,
  `nombre_responde` varchar(100) DEFAULT NULL,
  `fecha_respuesta` datetime DEFAULT NULL,
  `observacion` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `aprobaciones_almacen`
--

INSERT INTO `aprobaciones_almacen` (`id_aprobacion`, `id_producto`, `descripcion`, `precio`, `stock`, `fecha_vencimiento`, `estado`, `usuario_solicita`, `nombre_solicita`, `fecha_solicita`, `usuario_responde`, `nombre_responde`, `fecha_respuesta`, `observacion`) VALUES
(1, 2, 'Herramienta para labranza', 13.75, 17, '2060-04-12', 'Aprobada', 3, 'Almacen', '2025-06-29 18:59:32', 2, 'Gerente', '2025-06-29 20:35:59', NULL),
(10, 1, 'Cambio de descripción para producto 1', 4.25, 20, '2025-12-01', 'Pendiente', 3, 'Almacen', '2025-06-29 20:48:05', NULL, NULL, NULL, NULL),
(11, 2, 'Actualización de precio para producto 2', 9.90, 15, '2025-10-15', 'Pendiente', 3, 'Almacen', '2025-06-29 20:48:05', NULL, NULL, NULL, NULL),
(12, 3, 'Corrección de fecha de vencimiento', 6.40, 10, '2026-01-01', 'Pendiente', 3, 'Almacen', '2025-06-29 20:48:05', NULL, NULL, NULL, NULL),
(13, 4, 'Stock corregido después de ajuste físico', 2.80, 35, '2025-11-10', 'Pendiente', 3, 'Almacen', '2025-06-29 20:48:05', NULL, NULL, NULL, NULL),
(14, 1, 'Reetiquetado y nuevo precio sugerido', 7.50, 5, '2026-03-20', 'Pendiente', 3, 'Almacen', '2025-06-29 20:48:05', NULL, NULL, NULL, NULL),
(15, 2, 'Modificación por error de carga original', 3.15, 8, '2025-09-05', 'Pendiente', 3, 'Almacen', '2025-06-29 20:48:05', NULL, NULL, NULL, NULL),
(16, 3, 'Producto con promoción especial', 1.99, 50, '2025-12-31', 'Pendiente', 3, 'Almacen', '2025-06-29 20:48:05', NULL, NULL, NULL, NULL),
(17, 4, 'Revisión de caducidad y stock por rotación', 5.60, 12, '2026-02-14', 'Pendiente', 3, 'Almacen', '2025-06-29 20:48:05', NULL, NULL, NULL, NULL);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `aprobaciones_almacen`
--
ALTER TABLE `aprobaciones_almacen`
  ADD PRIMARY KEY (`id_aprobacion`),
  ADD KEY `id_producto` (`id_producto`),
  ADD KEY `usuario_solicita` (`usuario_solicita`),
  ADD KEY `usuario_responde` (`usuario_responde`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `aprobaciones_almacen`
--
ALTER TABLE `aprobaciones_almacen`
  MODIFY `id_aprobacion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `aprobaciones_almacen`
--
ALTER TABLE `aprobaciones_almacen`
  ADD CONSTRAINT `aprobaciones_almacen_ibfk_1` FOREIGN KEY (`id_producto`) REFERENCES `productos` (`id_producto`),
  ADD CONSTRAINT `aprobaciones_almacen_ibfk_2` FOREIGN KEY (`usuario_solicita`) REFERENCES `usuarios` (`id_usuario`),
  ADD CONSTRAINT `aprobaciones_almacen_ibfk_3` FOREIGN KEY (`usuario_responde`) REFERENCES `usuarios` (`id_usuario`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

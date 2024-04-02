-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 27-03-2024 a las 03:14:53
-- Versión del servidor: 10.4.24-MariaDB
-- Versión de PHP: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `tpinmobiliaria`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contrato`
--

CREATE TABLE `contrato` (
  `id_contrato` int(11) NOT NULL,
  `desde` date DEFAULT NULL,
  `hasta` date DEFAULT NULL,
  `detalle` varchar(50) DEFAULT NULL,
  `finalizacion_anticipada` date DEFAULT NULL,
  `monto` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inmueble`
--

CREATE TABLE `inmueble` (
  `id_inmueble` int(11) NOT NULL,
  `tipo` varchar(50) DEFAULT NULL,
  `ubicacion` varchar(50) DEFAULT NULL,
  `condicion` varchar(50) DEFAULT NULL,
  `costo` double DEFAULT NULL,
  `detalle` varchar(100) DEFAULT NULL,
  `estado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inquilino`
--

CREATE TABLE `inquilino` (
  `id_inquilino` int(30) NOT NULL,
  `dni` int(30) NOT NULL,
  `apellido` varchar(30) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `telefono` int(30) NOT NULL,
  `email` varchar(30) NOT NULL,
  `estado` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pagos`
--

CREATE TABLE `pagos` (
  `id_pagos` int(11) NOT NULL,
  `mes` int(11) DEFAULT NULL,
  `importe` double DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `multa` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `propietario`
--

CREATE TABLE `propietario` (
  `id_propietario` int(20) NOT NULL,
  `dni` int(30) NOT NULL,
  `apellido` varchar(30) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `telefono` int(30) NOT NULL,
  `email` varchar(30) NOT NULL,
  `estado` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `propietario`
--

INSERT INTO `propietario` (`id_propietario`, `dni`, `apellido`, `nombre`, `telefono`, `email`, `estado`) VALUES
(2, 12345678, 'González', 'María', 123456789, 'maria@example.com', 1),
(3, 98765432, 'Rodríguez', 'Juan', 987654321, 'juan@example.com', 0),
(4, 34567890, 'López', 'Ana', 345678901, 'ana@example.com', 1),
(5, 56789012, 'Martínez', 'Pedro', 567890123, 'pedro@example.com', 0),
(6, 90123456, 'Sánchez', 'Laura', 901234567, 'laura@example.com', 1),
(7, 23456789, 'Gómez', 'Carlos', 234567890, 'carlos@example.com', 0),
(8, 45678901, 'Fernández', 'Sofía', 456789012, 'sofia@example.com', 1),
(9, 78901234, 'Díaz', 'Luis', 789012345, 'luis@example.com', 0),
(10, 1234567, 'Pérez', 'Julia', 12345678, 'julia@example.com', 1),
(11, 54321098, 'Ramírez', 'Diego', 543210987, 'diego@example.com', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipo_inmueble`
--

CREATE TABLE `tipo_inmueble` (
  `id_tipo_inmueble` int(30) NOT NULL,
  `uso` varchar(30) NOT NULL,
  `tipo` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD PRIMARY KEY (`id_contrato`);

--
-- Indices de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  ADD PRIMARY KEY (`id_inmueble`);

--
-- Indices de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  ADD PRIMARY KEY (`id_inquilino`);

--
-- Indices de la tabla `pagos`
--
ALTER TABLE `pagos`
  ADD PRIMARY KEY (`id_pagos`);

--
-- Indices de la tabla `propietario`
--
ALTER TABLE `propietario`
  ADD PRIMARY KEY (`id_propietario`);

--
-- Indices de la tabla `tipo_inmueble`
--
ALTER TABLE `tipo_inmueble`
  ADD PRIMARY KEY (`id_tipo_inmueble`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  MODIFY `id_inquilino` int(30) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `propietario`
--
ALTER TABLE `propietario`
  MODIFY `id_propietario` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `tipo_inmueble`
--
ALTER TABLE `tipo_inmueble`
  MODIFY `id_tipo_inmueble` int(30) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD CONSTRAINT `contrato_ibfk_1` FOREIGN KEY (`id_contrato`) REFERENCES `inquilino` (`id_inquilino`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `inmueble`
--
ALTER TABLE `inmueble`
  ADD CONSTRAINT `inmueble_ibfk_1` FOREIGN KEY (`id_inmueble`) REFERENCES `inquilino` (`id_inquilino`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `pagos`
--
ALTER TABLE `pagos`
  ADD CONSTRAINT `pagos_ibfk_1` FOREIGN KEY (`id_pagos`) REFERENCES `contrato` (`id_contrato`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `tipo_inmueble`
--
ALTER TABLE `tipo_inmueble`
  ADD CONSTRAINT `tipo_inmueble_ibfk_1` FOREIGN KEY (`id_tipo_inmueble`) REFERENCES `inmueble` (`id_inmueble`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

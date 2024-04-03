-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 03-04-2024 a las 00:35:09
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
-- Base de datos: `inmotest`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contrato`
--

CREATE TABLE `contrato` (
  `id_contato` int(11) NOT NULL,
  `desde` date NOT NULL,
  `hasta` date NOT NULL,
  `detalle` varchar(50) NOT NULL,
  `finalizacionAnticipada` date NOT NULL,
  `monto` double NOT NULL,
  `multa` double NOT NULL,
  `id_inquilino` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inmueble`
--

CREATE TABLE `inmueble` (
  `id_inmueble` int(11) NOT NULL,
  `tipoDebien` varchar(50) NOT NULL,
  `tipoDeUso` varchar(50) NOT NULL,
  `ubicacion` varchar(100) NOT NULL,
  `condicion` varchar(50) NOT NULL,
  `costo` double NOT NULL,
  `detalle` text NOT NULL,
  `estado` int(11) NOT NULL,
  `id_propietario` int(11) NOT NULL,
  `id_inquilino` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inquilino`
--

CREATE TABLE `inquilino` (
  `id` int(11) NOT NULL,
  `dni` int(11) NOT NULL,
  `apellido` varchar(30) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `telefono` int(11) NOT NULL,
  `email` varchar(30) NOT NULL,
  `estado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inquilino`
--

INSERT INTO `inquilino` (`id`, `dni`, `apellido`, `nombre`, `telefono`, `email`, `estado`) VALUES
(1, 12345678, 'García', 'Juan', 555123456, 'juan.garcia@example.com', 1),
(2, 23456789, 'Martínez', 'María', 555234567, 'maria.martinez@example.com', 0),
(3, 34567890, 'López', 'José', 555345678, 'jose.lopez@example.com', 1),
(4, 45678901, 'Rodríguez', 'Ana', 555456789, 'ana.rodriguez@example.com', 0),
(5, 56789012, 'Pérez', 'Luis', 555567890, 'luis.perez@example.com', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pago`
--

CREATE TABLE `pago` (
  `id_pago` int(11) NOT NULL,
  `importe` double NOT NULL,
  `fecha` date NOT NULL,
  `id_contrato` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `propietario`
--

CREATE TABLE `propietario` (
  `id_propietario` int(11) NOT NULL,
  `dni` int(11) DEFAULT NULL,
  `apellido` varchar(50) DEFAULT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `estado` int(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `propietario`
--

INSERT INTO `propietario` (`id_propietario`, `dni`, `apellido`, `nombre`, `telefono`, `email`, `estado`) VALUES
(1, 12345678, 'García', 'Juan', '5551234', 'juan.garcia@example.com', 0),
(2, 23456789, 'Martínez', 'María', '5555678', 'maria.martinez@example.com', 0),
(3, 34567890, 'López', 'José', '5559012', 'jose.lopez@example.com', 0),
(4, 45678901, 'Rodríguez', 'Ana', '5553456', 'ana.rodriguez@example.com', 0),
(5, 56789012, 'Pérez', 'Luis', '5556789', 'luis.perez@example.com', 0),
(6, 67890123, 'Sánchez', 'Laura', '5557890', 'laura.sanchez@example.com', 0),
(7, 78901234, 'González', 'Carlos', '5552345', 'carlos.gonzalez@example.com', 0),
(8, 89012345, 'Fernández', 'Martín', '5554567', 'martin.fernandez@example.com', 0),
(9, 90123456, 'Gómez', 'Paula', '5556789', 'paula.gomez@example.com', 0),
(10, 1234567, 'Díaz', 'Sofía', '5558901', 'sofia.diaz@example.com', 0);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD PRIMARY KEY (`id_contato`),
  ADD UNIQUE KEY `id_inquilino` (`id_inquilino`);

--
-- Indices de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  ADD PRIMARY KEY (`id_inmueble`),
  ADD KEY `id_propietario` (`id_propietario`),
  ADD KEY `id_inquilino` (`id_inquilino`);

--
-- Indices de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `pago`
--
ALTER TABLE `pago`
  ADD PRIMARY KEY (`id_pago`),
  ADD KEY `pago_ibfk_1` (`id_contrato`);

--
-- Indices de la tabla `propietario`
--
ALTER TABLE `propietario`
  ADD PRIMARY KEY (`id_propietario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `contrato`
--
ALTER TABLE `contrato`
  MODIFY `id_contato` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  MODIFY `id_inmueble` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `pago`
--
ALTER TABLE `pago`
  MODIFY `id_pago` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD CONSTRAINT `contrato_ibfk_1` FOREIGN KEY (`id_inquilino`) REFERENCES `inquilino` (`id`);

--
-- Filtros para la tabla `inmueble`
--
ALTER TABLE `inmueble`
  ADD CONSTRAINT `inmueble_ibfk_1` FOREIGN KEY (`id_propietario`) REFERENCES `propietario` (`id_propietario`),
  ADD CONSTRAINT `inmueble_ibfk_2` FOREIGN KEY (`id_inquilino`) REFERENCES `inquilino` (`id`);

--
-- Filtros para la tabla `pago`
--
ALTER TABLE `pago`
  ADD CONSTRAINT `pago_ibfk_1` FOREIGN KEY (`id_contrato`) REFERENCES `contrato` (`id_contato`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

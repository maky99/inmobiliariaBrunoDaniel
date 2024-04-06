-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 06-04-2024 a las 16:23:48
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
  `id_contrato` int(11) NOT NULL,
  `desde` date NOT NULL,
  `meses` int(20) NOT NULL,
  `hasta` date NOT NULL,
  `detalle` varchar(50) NOT NULL,
  `finalizacionAnticipada` date NOT NULL,
  `monto` double NOT NULL,
  `multa` double NOT NULL,
  `estado` int(20) NOT NULL,
  `id_inquilino` int(11) NOT NULL,
  `id_inmueble` int(11) DEFAULT NULL
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
  `id_propietario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inquilino`
--

CREATE TABLE `inquilino` (
  `id_inquilino` int(11) NOT NULL,
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

INSERT INTO `inquilino` (`id_inquilino`, `dni`, `apellido`, `nombre`, `telefono`, `email`, `estado`) VALUES
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
  `concepto` varchar(255) NOT NULL,
  `importe` double NOT NULL,
  `fecha` date NOT NULL,
  `estado` int(20) NOT NULL,
  `id_contrato` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `propietario`
--

CREATE TABLE `propietario` (
  `id_propietario` int(11) NOT NULL,
  `dni` int(11) DEFAULT NULL,
  `apellido` varchar(255) DEFAULT NULL,
  `nombre` varchar(255) DEFAULT NULL,
  `telefono` int(11) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `estado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `propietario`
--

INSERT INTO `propietario` (`id_propietario`, `dni`, `apellido`, `nombre`, `telefono`, `email`, `estado`) VALUES
(1, 76789870, 'Pig', 'Pepa', 13326, 'pepa@mala.com', 0),
(12, 12345678, 'López', 'Juan', 11223344, 'juan.lopez@example.com', 1),
(13, 23456789, 'Martínez', 'María', 22334455, 'maria.martinez@example.com', 1),
(14, 34567890, 'García', 'Carlos', 33445566, 'carlos.garcia@example.com', 1),
(15, 45678901, 'Rodríguez', 'Laura', 44556677, 'laura.rodriguez@example.com', 1),
(16, 56789012, 'González', 'Pedro', 55667788, 'pedro.gonzalez@example.com', 1),
(17, 67890123, 'Sánchez', 'Ana', 66778899, 'ana.sanchez@example.com', 1),
(18, 78901234, 'Pérez', 'Luis', 77889900, 'luis.perez@example.com', 1),
(19, 89012345, 'Gómez', 'Marta', 88990011, 'marta.gomez@example.com', 1),
(20, 90123456, 'Martín', 'David', 99001122, 'david.martin@example.com', 1),
(21, 1234567, 'Fernández', 'Julia', 11223344, 'julia.fernandez@example.com', 1),
(22, 76789870, 'Pig', 'Pepa', 9899654, 'pepa@mala.com', 0),
(23, 1234423, 'Pig', 'Jeorch', 8888888, 'jor@pepa.com', 0),
(24, 34543, 'Alfonzo', 'Daniel', 543345, 'asapo@gmail.com', 0),
(25, 76789870, 'Alfonzo', 'Daniel', 3453, 'asapo@gmail.com', 0);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD PRIMARY KEY (`id_contrato`),
  ADD UNIQUE KEY `id_inquilino` (`id_inquilino`),
  ADD KEY `fk_contrato_inmueble` (`id_inmueble`);

--
-- Indices de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  ADD PRIMARY KEY (`id_inmueble`),
  ADD KEY `id_propietario` (`id_propietario`);

--
-- Indices de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  ADD PRIMARY KEY (`id_inquilino`);

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
  MODIFY `id_contrato` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  MODIFY `id_inmueble` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  MODIFY `id_inquilino` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `pago`
--
ALTER TABLE `pago`
  MODIFY `id_pago` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `propietario`
--
ALTER TABLE `propietario`
  MODIFY `id_propietario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD CONSTRAINT `contrato_ibfk_1` FOREIGN KEY (`id_inquilino`) REFERENCES `inquilino` (`id_inquilino`),
  ADD CONSTRAINT `fk_contrato_inmueble` FOREIGN KEY (`id_inmueble`) REFERENCES `inmueble` (`id_inmueble`);

--
-- Filtros para la tabla `inmueble`
--
ALTER TABLE `inmueble`
  ADD CONSTRAINT `inmueble_ibfk_1` FOREIGN KEY (`id_propietario`) REFERENCES `propietario` (`id_propietario`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `pago`
--
ALTER TABLE `pago`
  ADD CONSTRAINT `pago_ibfk_1` FOREIGN KEY (`id_contrato`) REFERENCES `contrato` (`id_contrato`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

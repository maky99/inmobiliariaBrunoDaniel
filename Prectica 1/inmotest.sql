-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 18-04-2024 a las 16:59:50
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
  `finalizacionAnticipada` date DEFAULT NULL,
  `monto` double NOT NULL,
  `multa` double DEFAULT NULL,
  `estado` int(20) NOT NULL,
  `id_inquilino` int(11) NOT NULL,
  `id_inmueble` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `contrato`
--

INSERT INTO `contrato` (`id_contrato`, `desde`, `meses`, `hasta`, `detalle`, `finalizacionAnticipada`, `monto`, `multa`, `estado`, `id_inquilino`, `id_inmueble`) VALUES
(34, '2024-04-01', 4, '2024-07-31', 'no se que iba ak', '2024-04-13', 3500, 7000, 0, 32, 93),
(35, '2024-04-13', 6, '2024-10-12', 'sin cerrar', '2024-04-13', 69000, 138000, 0, 30, 94),
(36, '2024-04-13', 8, '2024-12-12', 'Terreno aptoj', NULL, 78000, 0, 0, 38, 96),
(37, '2024-04-29', 4, '2024-08-28', 'sin piso', '2024-04-13', 6090, 12180, 0, 31, 97);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inmueble`
--

CREATE TABLE `inmueble` (
  `id_inmueble` int(11) NOT NULL,
  `tipoDebien` varchar(50) NOT NULL,
  `tipoDeUso` varchar(50) NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `condicion` varchar(50) NOT NULL,
  `costo` double NOT NULL,
  `ambiente` int(11) NOT NULL,
  `estado` int(11) NOT NULL,
  `id_propietario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inmueble`
--

INSERT INTO `inmueble` (`id_inmueble`, `tipoDebien`, `tipoDeUso`, `direccion`, `condicion`, `costo`, `ambiente`, `estado`, `id_propietario`) VALUES
(93, 'Terreno', 'Residencial', 'Calle 1234', 'Buena', 1000, 2, 1, 26),
(94, 'Edificio', 'Comercial', 'Avenida Principal 567', 'Excelente', 1200, 3, 1, 27),
(95, 'Apartamento', 'Industrial', 'Calle Central 890', 'Regular', 1500, 4, 1, 28),
(96, 'Casa', 'Educativo', 'Avenida Central 1111', 'Muy Buena', 2000, 2, 1, 29),
(97, 'Fábrica', 'Salud', 'Calle Principal 2222', 'Buena', 1800, 3, 1, 30),
(98, 'Local', 'Recreacional', 'Avenida Norte 3333', 'Regular', 2200, 2, 1, 31),
(99, 'Mina', 'Hotelero/Turístico', 'Calle Sur 4444', 'Excelente', 1700, 4, 1, 32),
(100, 'Parcela', 'Religioso', 'Avenida Oeste 5555', 'Muy Buena', 1900, 2, 1, 33),
(101, 'Terreno', 'Agrícola', 'Calle Este 6666', 'Buena', 2100, 3, 1, 34),
(102, 'Edificio', 'Gobierno/Administrativo', 'Avenida Este 7777', 'Regular', 2300, 2, 1, 35),
(103, 'Terreno', 'Residencial', 'Calle 8 8888', 'Muy Buena', 2400, 4, 1, 26),
(104, 'Edificio', 'Comercial', 'Avenida 9 9999', 'Excelente', 2600, 3, 1, 27),
(105, 'Apartamento', 'Industrial', 'Calle 10 10101', 'Buena', 2800, 2, 1, 28),
(106, 'Casa', 'Educativo', 'Avenida 11 11111', 'Regular', 3000, 4, 1, 29),
(107, 'Fábrica', 'Salud', 'Calle 12 12121', 'Muy Buena', 3200, 3, 1, 30),
(108, 'Local', 'Recreacional', 'Avenida 13 13131', 'Buena', 3500, 2, 1, 31),
(109, 'Mina', 'Hotelero/Turístico', 'Calle 14 14141', 'Regular', 3300, 4, 1, 32),
(110, 'Parcela', 'Religioso', 'Avenida 15 15151', 'Muy Buena', 3600, 3, 1, 33),
(111, 'Terreno', 'Agrícola', 'Calle 16 16161', 'Buena', 3800, 2, 1, 34),
(112, 'Edificio', 'Gobierno/Administrativo', 'Avenida 17 17171', 'Excelente', 4000, 4, 1, 35);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inquilino`
--

CREATE TABLE `inquilino` (
  `id_inquilino` int(11) NOT NULL,
  `dni` int(11) NOT NULL,
  `apellido` varchar(30) NOT NULL,
  `nombre` varchar(30) NOT NULL,
  `telefono` varchar(255) NOT NULL,
  `email` varchar(30) NOT NULL,
  `estado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inquilino`
--

INSERT INTO `inquilino` (`id_inquilino`, `dni`, `apellido`, `nombre`, `telefono`, `email`, `estado`) VALUES
(30, 12345678, 'González', 'María', '11111111', 'maria@example.com', 1),
(31, 23456789, 'Rodríguez', 'Juan', '22222222', 'juan@example.com', 1),
(32, 34567890, 'López', 'Luis', '33333333', 'luis@example.com', 1),
(33, 45678901, 'Martínez', 'Ana', '44444444', 'ana@example.com', 1),
(34, 56789012, 'Pérez', 'Diego', '55555555', 'diego@example.com', 1),
(35, 67890123, 'Gómez', 'Laura', '66666666', 'laura@example.com', 1),
(36, 78901234, 'Sánchez', 'Pedro', '77777777', 'pedro@example.com', 1),
(37, 89012345, 'Romero', 'Lucía', '88888888', 'lucia@example.com', 1),
(38, 90123456, 'Díaz', 'Carlos', '99999999', 'carlos@example.com', 1),
(39, 11223344, 'Fernández', 'Marta', '10101010', 'marta@example.com', 1);

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

--
-- Volcado de datos para la tabla `pago`
--

INSERT INTO `pago` (`id_pago`, `concepto`, `importe`, `fecha`, `estado`, `id_contrato`) VALUES
(5, 'me en curso', 3500, '2024-05-01', 2, 34),
(11, 'popo', 3500, '2024-04-18', 2, 34),
(12, 'sabado', 3500, '2024-04-13', 1, 34),
(13, 'pedro', 3500, '2024-04-13', 1, 34),
(14, 'Curso', 69000, '2024-04-13', 1, 35),
(22, 'alguno', 6090, '2024-04-13', 1, 37),
(23, 'posible', 6090, '2024-04-13', 1, 37),
(24, 'popo', 3500, '2024-04-13', 1, 34),
(25, 'enero', 3500, '2024-04-14', 1, 34),
(26, 'nuevo ', 3500, '2024-04-17', 1, 34);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `propietario`
--

CREATE TABLE `propietario` (
  `id_propietario` int(11) NOT NULL,
  `dni` int(11) DEFAULT NULL,
  `apellido` varchar(255) DEFAULT NULL,
  `nombre` varchar(255) DEFAULT NULL,
  `telefono` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `estado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `propietario`
--

INSERT INTO `propietario` (`id_propietario`, `dni`, `apellido`, `nombre`, `telefono`, `email`, `estado`) VALUES
(26, 12345678, 'López', 'Juan', '11111111', 'juan@example.com', 1),
(27, 23456789, 'Martínez', 'María', '22222222', 'maria@example.com', 1),
(28, 34567890, 'González', 'Pedro', '33333333', 'pedro@example.com', 1),
(29, 45678901, 'Fernández', 'Laura', '44444444', 'laura@example.com', 1),
(30, 56789012, 'Rodríguez', 'Diego', '55555555', 'diego@example.com', 1),
(31, 67890123, 'Pérez', 'Ana', '66666666', 'ana@example.com', 1),
(32, 78901234, 'Sánchez', 'Lucía', '77777777', 'lucia@example.com', 1),
(33, 89012345, 'Díaz', 'Carlos', '88888888', 'carlos@example.com', 1),
(34, 90123456, 'Romero', 'Marta', '99999999', 'marta@example.com', 1),
(35, 11223344, 'Gómez', 'Pablo', '10101010', 'pablo@example.com', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `Id` int(11) NOT NULL,
  `Nombre` varchar(255) NOT NULL,
  `Apellido` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `Clave` varchar(255) NOT NULL,
  `Rol` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`Id`, `Nombre`, `Apellido`, `Email`, `Clave`, `Rol`) VALUES
(2, 'daniel', 'alfonso', 'alfon@gmail.com', '123', 2),
(3, 'Bruno', 'Cerutti', 'bruno@gmail.com', 'esr2747jDxsp8sKjmyMpvw==.PNrE1WeNM1vYJZz0qjfJeTXrfMDVwCmPlMGdpaU1O1Q=', 1),
(4, 'pepe', 'alfonso', 'alfonpepe@gmail.com', 'r3XV8Bkr+dEwd1Y7h1nY8w==.fIvgxuiGfpQgO6ppEPffBAnQgCIkZRDgGHqGSmu6+vk=', 2),
(6, 'pepa', 'sapo', 'elSapo@pepe.com', 'B0D6vEWGpWb8DYzfKhNQrBPc5e340XdyeMqjtEB/5JY=', 1),
(7, 'Bruno', 'Bruno', 'Bruno@bruno.com', 'dxtD2eQ/4Sj5pGnPqCTiuL6jns5apO1OHkTaJC9DTzw=', 1);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD PRIMARY KEY (`id_contrato`),
  ADD KEY `fk_contrato_inmueble` (`id_inmueble`),
  ADD KEY `id_inquilino_2` (`id_inquilino`);

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
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `contrato`
--
ALTER TABLE `contrato`
  MODIFY `id_contrato` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- AUTO_INCREMENT de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  MODIFY `id_inmueble` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=113;

--
-- AUTO_INCREMENT de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  MODIFY `id_inquilino` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT de la tabla `pago`
--
ALTER TABLE `pago`
  MODIFY `id_pago` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT de la tabla `propietario`
--
ALTER TABLE `propietario`
  MODIFY `id_propietario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD CONSTRAINT `contrato_ibfk_1` FOREIGN KEY (`id_inquilino`) REFERENCES `inquilino` (`id_inquilino`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_contrato_inmueble` FOREIGN KEY (`id_inmueble`) REFERENCES `inmueble` (`id_inmueble`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `inmueble`
--
ALTER TABLE `inmueble`
  ADD CONSTRAINT `inmueble_ibfk_1` FOREIGN KEY (`id_propietario`) REFERENCES `propietario` (`id_propietario`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `pago`
--
ALTER TABLE `pago`
  ADD CONSTRAINT `pago_ibfk_1` FOREIGN KEY (`id_contrato`) REFERENCES `contrato` (`id_contrato`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

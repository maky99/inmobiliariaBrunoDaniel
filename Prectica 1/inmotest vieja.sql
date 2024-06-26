-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 12-04-2024 a las 20:47:48
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
(6, '2024-04-07', 2, '2024-06-06', 'Terreno aptoj', '2024-04-01', 21, 12, 0, 11, 37),
(21, '2024-04-19', 4, '2024-08-18', 'minas antiguas ', NULL, 654, NULL, 0, 14, 40);

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
(37, 'Terreno', 'Residencial', 'La Carolina', 'Regular', 800000, 1, 3, 17),
(38, 'Terreno', 'Educativo', 'San Luis', 'Buena', 500000, 1, 3, 20),
(39, 'Casa', 'Residencial', 'Calle Principal 123', 'Buena', 150000, 4, 1, 12),
(40, 'Apartamento', 'Residencial', 'Avenida Central 456', 'Excelente', 120000, 0, 0, 13),
(41, 'Terreno', 'Comercial', 'Avenida Comercial 789', 'Regular', 80000, 2, 0, 14),
(42, '', 'Comercial', 'Plaza Principal', 'Excelente', 200000, 1, 2, 15),
(43, 'Oficina', 'Comercial', 'Centro Empresarial 101', 'Buena', 100000, 5, 0, 16),
(44, 'Casa', 'Residencial', 'Calle Secundaria 234', 'Regular', 90000, 0, 2, 17),
(45, 'Apartamento', 'Residencial', 'Avenida Principal 567', 'Buena', 110000, 2, 0, 18),
(46, 'Terreno', 'Residencial', 'Avenida Residencial 890', 'Excelente', 180000, 0, 1, 19),
(47, 'Local comercial', 'Comercial', 'Centro Comercial', 'Regular', 50000, 0, 1, 20),
(48, 'Oficina', 'Comercial', 'Torre Empresarial', 'Buena', 80000, 0, 1, 21),
(49, 'Casa', 'Residencial', 'Calle Tranquila 345', 'Regular', 95000, 6, 0, 22),
(50, 'Apartamento', 'Residencial', 'Calle Privada 678', 'Excelente', 130000, 0, 1, 23),
(51, 'Terreno', 'Residencial', 'Avenida Tranquila 901', 'Buena', 75000, 0, 0, 24),
(52, 'Local comercial', 'Comercial', 'Calle Comercial', 'Regular', 60000, 4, 0, 25);

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
(11, 76789870, 'Big Pig', 'Pepa', '5555', 'pepa@malapig.com', 0),
(12, 123, 'Cerutti', 'Bruno', '22222', 'brunocerutti88@gmail.com', 1),
(13, 333, 'Senna', 'Ayrton', '121212', 'senna@gmail.com', 1),
(14, 888, 'perez', 'josefina', '343', 'j@gmail.com', 0),
(15, 12345678, 'García', 'Juan', '123-456-7890', 'juan.garcia@example.com', 1),
(16, 23456789, 'Martínez', 'Ana', '234-567-8901', 'ana.martinez@example.com', 1),
(17, 34567890, 'López', 'María', '345-678-9012', 'maria.lopez@example.com', 1),
(18, 45678901, 'Rodríguez', 'Luis', '456-789-0123', 'luis.rodriguez@example.com', 1),
(19, 56789012, 'Sánchez', 'Laura', '567-890-1234', 'laura.sanchez@example.com', 1),
(20, 67890123, 'Pérez', 'Carlos', '678-901-2345', 'carlos.perez@example.com', 1),
(21, 78901234, 'Gómez', 'Andrea', '789-012-3456', 'andrea.gomez@example.com', 1),
(22, 89012345, 'Díaz', 'Pablo', '890-123-4567', 'pablo.diaz@example.com', 1),
(23, 90123456, 'Fernández', 'Marta', '901-234-5678', 'marta.fernandez@example.com', 1),
(24, 1234567, 'Ruiz', 'Javier', '012-345-6789', 'javier.ruiz@example.com', 1);

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
(1, 'fsd', 44, '2024-04-12', 1, 21);

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
(1, 76789870, 'Pig', 'Pepa', '13326', 'pepa@mala.com', 1),
(12, 12345678, 'López', 'Juan', '11223344', 'juan.lopez@example.com', 1),
(13, 23456789, 'Martínez', 'María', '22334455', 'maria.martinez@example.com', 1),
(14, 34567890, 'García', 'Carlos', '33445566', 'carlos.garcia@example.com', 0),
(15, 45678901, 'Rodríguez', 'Laura', '44556677', 'laura.rodriguez@example.com', 1),
(16, 56789012, 'González', 'Pedro', '55667788', 'pedro.gonzalez@example.com', 1),
(17, 67890123, 'Sánchez', 'Ana', '66778899', 'ana.sanchez@example.com', 1),
(18, 78901234, 'Pérez', 'Luis', '77889900', 'luis.perez@example.com', 1),
(19, 89012345, 'Gómez', 'Marta', '88990011', 'marta.gomez@example.com', 0),
(20, 90123456, 'Martín', 'David', '99001122', 'david.martin@example.com', 1),
(21, 1234567, 'Fernández', 'Julia', '11223344', 'julia.fernandez@example.com', 0),
(22, 76789870, 'Pig', 'Pepa', '9899654', 'pepa@mala.com', 0),
(23, 1234423, 'Pig', 'Jeorch', '8888888', 'jor@pepa.com', 0),
(24, 34543, 'Alfonzo', 'Daniel', '543345', 'asapo@gmail.com', 0),
(25, 76789870, 'Alfonzo', 'Daniel', '3453', 'asapo@gmail.com', 0);

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
(4, 'pepe', 'alfonso', 'alfonpepe@gmail.com', 'r3XV8Bkr+dEwd1Y7h1nY8w==.fIvgxuiGfpQgO6ppEPffBAnQgCIkZRDgGHqGSmu6+vk=', 2);

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
  MODIFY `id_contrato` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  MODIFY `id_inmueble` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=53;

--
-- AUTO_INCREMENT de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  MODIFY `id_inquilino` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT de la tabla `pago`
--
ALTER TABLE `pago`
  MODIFY `id_pago` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `propietario`
--
ALTER TABLE `propietario`
  MODIFY `id_propietario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

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
  ADD CONSTRAINT `pago_ibfk_1` FOREIGN KEY (`id_contrato`) REFERENCES `contrato` (`id_contrato`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 09-04-2024 a las 16:47:43
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
  `id_contrato` int(100) NOT NULL,
  `desde` date NOT NULL,
  `meses` int(20) NOT NULL,
  `hasta` date NOT NULL,
  `detalle` varchar(50) NOT NULL,
  `finalizacionAnticipada` date DEFAULT NULL,
  `monto` double NOT NULL,
  `multa` double DEFAULT NULL,
  `estado` int(20) NOT NULL,
  `id_inquilino` int(100) NOT NULL,
  `id_inmueble` int(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `contrato`
--

INSERT INTO `contrato` (`id_contrato`, `desde`, `meses`, `hasta`, `detalle`, `finalizacionAnticipada`, `monto`, `multa`, `estado`, `id_inquilino`, `id_inmueble`) VALUES
(6, '2024-04-07', 2, '2024-06-06', 'Terreno aptoj', NULL, 21, NULL, 0, 11, 37),
(21, '2024-04-02', 5, '2024-09-01', 'ak hay un detalle en contrato', NULL, 90909, NULL, 0, 11, 37);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inmueble`
--

CREATE TABLE `inmueble` (
  `id_inmueble` int(100) NOT NULL,
  `tipoDebien` varchar(50) NOT NULL,
  `tipoDeUso` varchar(50) NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `condicion` varchar(50) NOT NULL,
  `costo` double NOT NULL,
  `detalle` text NOT NULL,
  `estado` int(11) NOT NULL,
  `id_propietario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `inmueble`
--

INSERT INTO `inmueble` (`id_inmueble`, `tipoDebien`, `tipoDeUso`, `direccion`, `condicion`, `costo`, `detalle`, `estado`, `id_propietario`) VALUES
(37, 'Terreno', 'Residencial', 'La Carolina', 'Regular', 800000, 'sin cerrar', 0, 17),
(38, 'Terreno', 'Educativo', 'San Luis', 'Buena', 500000, 'Terreno aptoj', 1, 20),
(39, 'Casa', 'Residencial', 'Calle Principal 123', 'Buena', 150000, 'Casa de dos pisos con jardín', 1, 12),
(40, 'Apartamento', 'Residencial', 'Avenida Central 456', 'Excelente', 120000, 'Apartamento de un dormitorio con balcón', 0, 13),
(41, 'Terreno', 'Comercial', 'Avenida Comercial 789', 'Regular', 80000, 'Terreno plano de 500m²', 0, 14),
(42, 'Local comercial', 'Comercial', 'Plaza Principal', 'Excelente', 200000, 'Local amplio en zona comercial', 2, 15),
(43, 'Oficina', 'Comercial', 'Centro Empresarial 101', 'Buena', 100000, 'Oficina con vista panorámica', 0, 16),
(44, 'Casa', 'Residencial', 'Calle Secundaria 234', 'Regular', 90000, 'Casa con patio trasero', 2, 17),
(45, 'Apartamento', 'Residencial', 'Avenida Principal 567', 'Buena', 110000, 'Apartamento de dos dormitorios con piscina', 0, 18),
(46, 'Terreno', 'Residencial', 'Avenida Residencial 890', 'Excelente', 180000, 'Terreno con vista al mar', 1, 19),
(47, 'Local comercial', 'Comercial', 'Centro Comercial', 'Regular', 50000, 'Local pequeño en planta baja', 1, 20),
(48, 'Oficina', 'Comercial', 'Torre Empresarial', 'Buena', 80000, 'Oficina en piso alto con vista', 1, 21),
(49, 'Casa', 'Residencial', 'Calle Tranquila 345', 'Regular', 95000, 'Casa con jardín y garaje', 0, 22),
(50, 'Apartamento', 'Residencial', 'Calle Privada 678', 'Excelente', 130000, 'Apartamento con terraza y piscina comunitaria', 1, 23),
(51, 'Terreno', 'Residencial', 'Avenida Tranquila 901', 'Buena', 75000, 'Terreno con arboles frutales', 0, 24),
(52, 'Local comercial', 'Comercial', 'Calle Comercial', 'Regular', 60000, 'Local en esquina con buena visibilidad', 0, 25);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inquilino`
--

CREATE TABLE `inquilino` (
  `id_inquilino` int(100) NOT NULL,
  `dni` int(100) NOT NULL,
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
(11, 76789870, 'Pig', 'Pepa', '3232', 'pepa@mala.com', 1),
(12, 123456789, 'García', 'Juan', '5551234567', 'juan.garcia@example.com', 1),
(13, 987654321, 'López', 'María', '5559876543', 'maria.lopez@example.com', 1),
(14, 456789123, 'Rodríguez', 'Carlos', '5554567890', 'carlos.rodriguez@example.com', 0),
(15, 789123456, 'Martínez', 'Laura', '5557891234', 'laura.martinez@example.com', 1),
(16, 321654987, 'Sánchez', 'Diego', '5553216549', 'diego.sanchez@example.com', 0),
(17, 654987321, 'Pérez', 'Ana', '5556549876', 'ana.perez@example.com', 1),
(18, 147258369, 'González', 'Andrés', '5551472583', 'andres.gonzalez@example.com', 0),
(19, 258369147, 'Ruiz', 'Sofía', '5552583691', 'sofia.ruiz@example.com', 1),
(20, 369147258, 'Castro', 'Luisa', '5553691472', 'luisa.castro@example.com', 0),
(21, 741852963, 'Fernández', 'Pablo', '5557418529', 'pablo.fernandez@example.com', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pago`
--

CREATE TABLE `pago` (
  `id_pago` int(100) NOT NULL,
  `concepto` varchar(255) NOT NULL,
  `importe` double NOT NULL,
  `fecha` date NOT NULL,
  `estado` int(20) NOT NULL,
  `id_contrato` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `propietario`
--

CREATE TABLE `propietario` (
  `id_propietario` int(100) NOT NULL,
  `dni` int(100) DEFAULT NULL,
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
(1, 76789870, 'Pig', 'Pepa', '13326', 'pepa@mala.com', 0),
(12, 12345678, 'López', 'Juan', '11223344', 'juan.lopez@example.com', 1),
(13, 23456789, 'Martínez', 'María', '22334455', 'maria.martinez@example.com', 1),
(14, 34567890, 'García', 'Carlos', '33445566', 'carlos.garcia@example.com', 1),
(15, 45678901, 'Rodríguez', 'Laura', '44556677', 'laura.rodriguez@example.com', 1),
(16, 56789012, 'González', 'Pedro', '55667788', 'pedro.gonzalez@example.com', 1),
(17, 67890123, 'Sánchez', 'Ana', '66778899', 'ana.sanchez@example.com', 1),
(18, 78901234, 'Pérez', 'Luis', '77889900', 'luis.perez@example.com', 1),
(19, 89012345, 'Gómez', 'Marta', '88990011', 'marta.gomez@example.com', 1),
(20, 90123456, 'Martín', 'David', '99001122', 'david.martin@example.com', 1),
(21, 1234567, 'Fernández', 'Julia', '11223344', 'julia.fernandez@example.com', 1),
(22, 76789870, 'Pig', 'Pepa', '9899654', 'pepa@mala.com', 0),
(23, 1234423, 'Pig', 'Jeorch', '8888888', 'jor@pepa.com', 0),
(24, 34543, 'Alfonzo', 'Daniel', '543345', 'asapo@gmail.com', 0),
(25, 76789870, 'Alfonzo', 'Daniel', '3453', 'asapo@gmail.com', 0);

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
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `contrato`
--
ALTER TABLE `contrato`
  MODIFY `id_contrato` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de la tabla `inmueble`
--
ALTER TABLE `inmueble`
  MODIFY `id_inmueble` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=53;

--
-- AUTO_INCREMENT de la tabla `inquilino`
--
ALTER TABLE `inquilino`
  MODIFY `id_inquilino` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT de la tabla `pago`
--
ALTER TABLE `pago`
  MODIFY `id_pago` int(100) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `propietario`
--
ALTER TABLE `propietario`
  MODIFY `id_propietario` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

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

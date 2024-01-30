-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 30, 2024 at 02:25 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hotel`
--

-- --------------------------------------------------------

--
-- Table structure for table `kamar`
--

CREATE TABLE `kamar` (
  `id_kamar` int(10) NOT NULL,
  `kamar` varchar(10) NOT NULL,
  `id_tipekamar` int(10) NOT NULL,
  `harga` int(10) NOT NULL,
  `status` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `kamar`
--

INSERT INTO `kamar` (`id_kamar`, `kamar`, `id_tipekamar`, `harga`, `status`) VALUES
(14, 'B001', 0, 500000, ''),
(15, 'B009', 0, 600000, ''),
(16, 'A005', 0, 200000, ''),
(17, 'B200', 4, 400000, ''),
(18, 'B001', 0, 200000, ''),
(19, 'A001', 5, 400000, ''),
(20, 'A001', 1, 200000, '');

-- --------------------------------------------------------

--
-- Table structure for table `tipe_kamar`
--

CREATE TABLE `tipe_kamar` (
  `id_tipekamar` int(10) NOT NULL,
  `tipe_kamar` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tipe_kamar`
--

INSERT INTO `tipe_kamar` (`id_tipekamar`, `tipe_kamar`) VALUES
(1, 'Single Room (1 hingga 2 Orang)'),
(2, 'Twin Room (1 hingga 4 Orang)'),
(4, 'Family Room (6 Orang)'),
(5, 'VIP Room (2 Orang)');

-- --------------------------------------------------------

--
-- Table structure for table `t_reservasi`
--

CREATE TABLE `t_reservasi` (
  `id_customer` int(10) NOT NULL,
  `id_kamar` int(10) NOT NULL,
  `nama` varchar(120) NOT NULL,
  `email` varchar(50) NOT NULL,
  `nohp` varchar(15) NOT NULL,
  `checkin` varchar(50) NOT NULL,
  `checkout` varchar(50) NOT NULL,
  `total` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `t_reservasi`
--

INSERT INTO `t_reservasi` (`id_customer`, `id_kamar`, `nama`, `email`, `nohp`, `checkin`, `checkout`, `total`) VALUES
(1, 17, 'Bargana Kukuh Raditya', 'bargana@gmail.com', '082938475829', '23/01/2024', '24/01/2024', 0),
(2, 17, 'Alfian Benardo Rusli', 'alfian@gmail.com', '029384892039', '10/01/2024', '30/01/2024', 0),
(3, 19, 'qinthar', 'qinthar@gmail.com', '0987654321', '02/01/2024', '04/01/2024', 0),
(4, 19, 'gilang', 'gilang@gmail.com', '0987654321', '11/01/2024', '13/01/2024', 0),
(5, 19, 'RUTH', 'ruth@gmal.com', '1092883774', '01/01/2024', '05/01/2024', 0),
(6, 19, 'adzka', 'adzka@gmail.com', '0987654321', '10/01/2024', '30/01/2024', 0),
(7, 0, 'ayala', 'ayala@g.com', '09124309758', '23/01/2024', '24/01/2024', 0);

-- --------------------------------------------------------

--
-- Table structure for table `t_user`
--

CREATE TABLE `t_user` (
  `id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `t_user`
--

INSERT INTO `t_user` (`id`, `username`, `password`) VALUES
(1, 'admin', 'admin');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `kamar`
--
ALTER TABLE `kamar`
  ADD PRIMARY KEY (`id_kamar`);

--
-- Indexes for table `tipe_kamar`
--
ALTER TABLE `tipe_kamar`
  ADD PRIMARY KEY (`id_tipekamar`);

--
-- Indexes for table `t_reservasi`
--
ALTER TABLE `t_reservasi`
  ADD PRIMARY KEY (`id_customer`);

--
-- Indexes for table `t_user`
--
ALTER TABLE `t_user`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `kamar`
--
ALTER TABLE `kamar`
  MODIFY `id_kamar` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT for table `tipe_kamar`
--
ALTER TABLE `tipe_kamar`
  MODIFY `id_tipekamar` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `t_reservasi`
--
ALTER TABLE `t_reservasi`
  MODIFY `id_customer` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `t_user`
--
ALTER TABLE `t_user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

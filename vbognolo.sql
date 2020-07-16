-- phpMyAdmin SQL Dump
-- version 4.2.12deb2+deb8u8
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Jul 15, 2020 at 09:57 PM
-- Server version: 5.5.62-0+deb8u1
-- PHP Version: 5.6.40-0+deb8u8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `vbognolo`
--

-- --------------------------------------------------------

--
-- Table structure for table `Dashboard`
--

CREATE TABLE IF NOT EXISTS `Dashboard` (
`ID_dashboard` int(11) NOT NULL,
  `note` varchar(500) NOT NULL,
  `date` date NOT NULL,
  `ID_prijava` int(11) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Dashboard`
--

INSERT INTO `Dashboard` (`ID_dashboard`, `note`, `date`, `ID_prijava`) VALUES
(22, 'Prva obavijest', '2020-07-01', 1),
(27, 'Super obavijest', '2020-07-03', 1),
(29, 'Da bi obavijest bila prikazana, potrebno je obavijest i napisati.', '2020-07-10', 2),
(30, 'Donesena je nova kemikalija,  1 komada Sumporasta kiselina u Lab1', '2020-07-10', 2),
(31, 'Donesena je nova kemikalija,  1 komada Modra galica u Lab1', '2020-07-10', 2),
(32, 'Preneseno je 1 komada Kalijev permanganat u Lab2 ', '2020-07-10', 2),
(34, 'Preneseno je 2 komada Sumporna kiselina u Lab1 ', '2020-07-14', 2),
(35, 'Dodano je novih 1 kom. Sumporna kiselina', '2020-07-14', 1),
(36, 'Preneseno je 1 komada Modra galica u Lab1 ', '2020-07-15', 1),
(37, 'Dodano je novih 3 kom. Modra galica u Lab1', '2020-07-15', 1),
(38, 'Dodano je novih 1 kom. Sumporasta kiselina u Lab1', '2020-07-15', 1),
(39, 'Admin Admin je uzeo/la 4 kom. Natrijev klorid', '2020-07-15', 1),
(40, 'Preneseno je 2 komada Sumporna kiselina u Lab1 ', '2020-07-15', 1),
(41, 'Valentina Bognolo je uzeo/la 4 kom. Kalijev permanganat iz Lab1', '2020-07-15', 2),
(42, 'Dodano je novih 1 kom. Natrijev klorid u Lab1', '2020-07-15', 2),
(43, 'Dodano je novih 2 kom. Sumporasta kiselina u Lab1', '2020-07-15', 2),
(44, 'Dodano je novih 3 kom. Sumporasta kiselina u Lab1', '2020-07-15', 2),
(45, 'Dodano je novih 1 kom. Sumporna kiselina u Lab2', '2020-07-15', 2);

-- --------------------------------------------------------

--
-- Table structure for table `Lab1`
--

CREATE TABLE IF NOT EXISTS `Lab1` (
  `ID_prijava` int(11) NOT NULL,
  `ID_chemical` int(11) NOT NULL,
  `transferDate` date NOT NULL,
  `quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Lab1`
--

INSERT INTO `Lab1` (`ID_prijava`, `ID_chemical`, `transferDate`, `quantity`) VALUES
(2, 1, '2020-07-06', 2),
(1, 2, '2020-07-09', 3),
(2, 5, '2020-07-10', 5),
(2, 7, '2020-07-10', 4),
(2, 8, '2020-07-10', 4),
(2, 9, '2020-07-10', 5);

-- --------------------------------------------------------

--
-- Table structure for table `Lab2`
--

CREATE TABLE IF NOT EXISTS `Lab2` (
  `ID_chemical` int(11) NOT NULL,
  `ID_prijava` int(11) NOT NULL,
  `transferDate` date NOT NULL,
  `quantity` int(11) NOT NULL,
  `free` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Lab2`
--

INSERT INTO `Lab2` (`ID_chemical`, `ID_prijava`, `transferDate`, `quantity`, `free`) VALUES
(2, 3, '2020-07-03', 5, 0),
(5, 2, '2020-07-08', 2, 1),
(5, 2, '2020-07-08', 2, 1);

-- --------------------------------------------------------

--
-- Table structure for table `Laboratorij`
--

CREATE TABLE IF NOT EXISTS `Laboratorij` (
`ID_laboratorij` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `free` tinyint(1) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Laboratorij`
--

INSERT INTO `Laboratorij` (`ID_laboratorij`, `name`, `free`) VALUES
(1, 'Lab1', 1),
(2, 'Lab2', 1);

-- --------------------------------------------------------

--
-- Table structure for table `Prijava`
--

CREATE TABLE IF NOT EXISTS `Prijava` (
`ID_prijava` int(3) NOT NULL,
  `username` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL,
  `ime` varchar(50) NOT NULL,
  `prezime` varchar(50) NOT NULL,
  `admin` tinyint(1) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Prijava`
--

INSERT INTO `Prijava` (`ID_prijava`, `username`, `password`, `ime`, `prezime`, `admin`) VALUES
(1, 'admin', 'admin', 'Admin', 'Admin', 1),
(2, 'vbognolo', 'iooa', 'Valentina', 'Bognolo', 1),
(3, 'valebog', 'vale', 'Vale', 'Bog', 0),
(6, 'username', 'password', 'User', 'Name', 0);

-- --------------------------------------------------------

--
-- Table structure for table `Skladiste`
--

CREATE TABLE IF NOT EXISTS `Skladiste` (
`ID_chemical` int(11) NOT NULL,
  `chemName` varchar(50) NOT NULL,
  `quantity` int(11) NOT NULL,
  `description` varchar(250) NOT NULL,
  `expDate` date NOT NULL,
  `recDate` date NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Skladiste`
--

INSERT INTO `Skladiste` (`ID_chemical`, `chemName`, `quantity`, `description`, `expDate`, `recDate`) VALUES
(1, 'Natrijev klorid', 2, 'Opis natrijevog klorida', '2020-08-15', '2020-07-05'),
(2, 'Kalijev permanganat', 1, 'Opis kalijevog permanganata', '2021-04-20', '2020-07-05'),
(5, 'Sumporna kiselina', 4, 'Opis sumporne kiseline', '2021-09-15', '2020-07-08'),
(7, 'Sumporasta kiselina', 4, 'Opis sumporaste kiseline', '2020-11-20', '2020-07-02'),
(8, 'Modra galica', 4, 'Opis modre galice', '2020-09-18', '2020-07-06'),
(9, 'Voda', 4, 'Opis vode', '2020-07-17', '2020-07-10');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Dashboard`
--
ALTER TABLE `Dashboard`
 ADD PRIMARY KEY (`ID_dashboard`), ADD KEY `ID_prijava` (`ID_prijava`);

--
-- Indexes for table `Lab1`
--
ALTER TABLE `Lab1`
 ADD KEY `ID_chemical` (`ID_chemical`), ADD KEY `ID_prijava` (`ID_prijava`);

--
-- Indexes for table `Lab2`
--
ALTER TABLE `Lab2`
 ADD KEY `ID_chemical` (`ID_chemical`,`ID_prijava`), ADD KEY `ID_prijava` (`ID_prijava`);

--
-- Indexes for table `Laboratorij`
--
ALTER TABLE `Laboratorij`
 ADD PRIMARY KEY (`ID_laboratorij`);

--
-- Indexes for table `Prijava`
--
ALTER TABLE `Prijava`
 ADD PRIMARY KEY (`ID_prijava`);

--
-- Indexes for table `Skladiste`
--
ALTER TABLE `Skladiste`
 ADD PRIMARY KEY (`ID_chemical`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Dashboard`
--
ALTER TABLE `Dashboard`
MODIFY `ID_dashboard` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=46;
--
-- AUTO_INCREMENT for table `Laboratorij`
--
ALTER TABLE `Laboratorij`
MODIFY `ID_laboratorij` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `Prijava`
--
ALTER TABLE `Prijava`
MODIFY `ID_prijava` int(3) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `Skladiste`
--
ALTER TABLE `Skladiste`
MODIFY `ID_chemical` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=10;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `Dashboard`
--
ALTER TABLE `Dashboard`
ADD CONSTRAINT `FK_user` FOREIGN KEY (`ID_prijava`) REFERENCES `Prijava` (`ID_prijava`) ON UPDATE CASCADE;

--
-- Constraints for table `Lab1`
--
ALTER TABLE `Lab1`
ADD CONSTRAINT `FK_ID_chem` FOREIGN KEY (`ID_chemical`) REFERENCES `Skladiste` (`ID_chemical`) ON UPDATE CASCADE,
ADD CONSTRAINT `FK_ID_login` FOREIGN KEY (`ID_prijava`) REFERENCES `Prijava` (`ID_prijava`) ON UPDATE CASCADE;

--
-- Constraints for table `Lab2`
--
ALTER TABLE `Lab2`
ADD CONSTRAINT `FK_ID_chemical` FOREIGN KEY (`ID_chemical`) REFERENCES `Skladiste` (`ID_chemical`) ON UPDATE CASCADE,
ADD CONSTRAINT `FK_ID_prijava` FOREIGN KEY (`ID_prijava`) REFERENCES `Prijava` (`ID_prijava`) ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

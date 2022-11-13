-- phpMyAdmin SQL Dump
-- version 5.1.1deb5ubuntu1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Nov 13, 2022 at 08:33 PM
-- Server version: 10.6.7-MariaDB-2ubuntu1.1
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `DbShopOld`
--
CREATE DATABASE IF NOT EXISTS `DbShopOld` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `DbShopOld`;

-- --------------------------------------------------------

--
-- Table structure for table `TbBlogs`
--

CREATE TABLE `TbBlogs` (
  `Id` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Author` varchar(100) NOT NULL,
  `Content` text NOT NULL,
  `Image` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `TbBlogs`
--

INSERT INTO `TbBlogs` (`Id`, `Name`, `Author`, `Content`, `Image`) VALUES
(1, 'Lorem ipsum zoombomb wash hands quarantine sanitizer', 'admin@admin.com', 'Lorem ipsum zoombomb wash hands quarantine sanitizer. Doggface208 amazon prime hydroxychloroquine quarantine social distance flatten the curve whipped coffee. N95 drive-in unprecedented Tiger King. Zoom call Blursday second wave unprecedented self care working from home home. WHO wildfires vaccine remote learning postponed hybrid Zoom call Among Us. Dumpster fire storm Area 51 furlough home haircut hindsight shortage.\r\n\r\nCancelled walktail virtual happy hour Clorox wipes. Hybrid Quibi zoombomb. Mask Coronavirus remote learning furlough the new normal working from home protests. Furlough wear a mask Queen\'s Gambit mask UFO trying times TikTok bubble. Contact tracing ballot pod what day is it?.\r\n\r\nFrontline workers no march madness doomscrolling second wave stay-at-home order mail-in vote flatten the curve. N95 stay-at-home order COVID-19 amazon prime home haircut. Four seasons total landscaping stay-at-home order Folklore storm Area 51 dumpster fire take out order doomscroll. Self care pod home home haircut at least 6 feet maskne. Hurricane Greek alphabet shortage Coronavirus.\r\n\r\nWalktail my camera is off working from home N95 second wave K-shaped recovery. Home isolation Coronavirus. Home office hybrid Coronavirus quaranteam. Stimulus Among Us antibodies. Doomscrolling Among Us droplet murder hornets hindsight.\r\n\r\nInto quarantine doomscroll PPE zoombomb doomscrolling the before times quarantine stay-at-home order. Quarantine disinfect Joe Exotic. K-shaped recovery frontline workers Queen\'s Gambit. The before times Clorox wipes trying times sweatpants. Flatten the curve disinfect working from home social distancing Among Us quaranteam election wear a mask.', 'blog-0.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `TbComments`
--

CREATE TABLE `TbComments` (
  `Id` int(11) NOT NULL,
  `IdBlog` int(11) NOT NULL,
  `Author` varchar(100) NOT NULL,
  `Text` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `TbComments`
--

INSERT INTO `TbComments` (`Id`, `IdBlog`, `Author`, `Text`) VALUES
(1, 1, 'admin@admin.com', 'Hi');

-- --------------------------------------------------------

--
-- Table structure for table `TbLogins`
--

CREATE TABLE `TbLogins` (
  `Email` varchar(100) NOT NULL,
  `Password` text NOT NULL,
  `FirstName` text NOT NULL,
  `LastName` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `TbLogins`
--

INSERT INTO `TbLogins` (`Email`, `Password`, `FirstName`, `LastName`) VALUES
('admin@admin.com', '123456', 'Admin', 'Admin');

-- --------------------------------------------------------

--
-- Table structure for table `TbMessages`
--

CREATE TABLE `TbMessages` (
  `Id` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Subject` text NOT NULL,
  `Text` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `TbOrderProducts`
--

CREATE TABLE `TbOrderProducts` (
  `Id` int(11) NOT NULL,
  `IdOrder` int(11) NOT NULL,
  `IdProduct` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `TbOrders`
--

CREATE TABLE `TbOrders` (
  `Id` int(11) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Country` text NOT NULL,
  `FirstName` text NOT NULL,
  `LastName` text NOT NULL,
  `Address` text NOT NULL,
  `Appartment` text NOT NULL,
  `PostalCode` text NOT NULL,
  `City` text NOT NULL,
  `Shipping` text NOT NULL,
  `Payment` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `TbProductCategories`
--

CREATE TABLE `TbProductCategories` (
  `Id` int(11) NOT NULL,
  `IdProduct` int(11) NOT NULL,
  `Category` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `TbProductCategories`
--

INSERT INTO `TbProductCategories` (`Id`, `IdProduct`, `Category`) VALUES
(1, 8, 'Black'),
(2, 7, 'Blue'),
(3, 7, 'Gray'),
(4, 3, 'Red'),
(5, 5, 'White'),
(6, 2, 'Green');

-- --------------------------------------------------------

--
-- Table structure for table `TbProducts`
--

CREATE TABLE `TbProducts` (
  `Id` int(11) NOT NULL,
  `Name` text NOT NULL,
  `Vendor` text NOT NULL,
  `Description` text NOT NULL,
  `Price` decimal(50,2) NOT NULL,
  `Discount` decimal(50,2) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `Rating` double NOT NULL,
  `Image` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `TbProducts`
--

INSERT INTO `TbProducts` (`Id`, `Name`, `Vendor`, `Description`, `Price`, `Discount`, `Quantity`, `Rating`, `Image`) VALUES
(1, 'Leather Belt', 'Custom', 'Lorem ipsum protests wear a mask my camera is off postponed whipped coffee trying times. Queen\'s Gambit Last Dance Dr. Fauci Coronavirus COVID-19. This claim is disputed doggface208 second wave remote learning Folklore. Baby Yoda sourdough bread ventilator Last Dance cancelled quarantine. K-shaped recovery X Æ A-Xii second wave Carole Baskin ballot ventilator super-spreader event doomscroll.', '50.00', '21.00', 4, 0, 'belt-0.jpg'),
(2, 'Ladies Bag', 'Custom', 'Super-spreader event home school kraken. Carole Baskin toilet paper Quibi Coronavirus doggface208. Stay-at-home order PPE ventilator no march madness vote pod wildfires. Uncertain times X Æ A-Xii the before times pod whipped coffee vote self care working from home. Disinfect take out order doggface208 election Coronavirus. Remote storm Area 51 no march madness shortage WHO postponed antibodies working from home.', '85.00', '10.00', 1, 0, 'bag-0.jpg'),
(3, 'Long Winter Dress', 'Custom', 'Lysol spray this claim is disputed doggface208 dumpster fire disinfect lockdown. Cancelled sanitizer ventilator. Hydroxychloroquine essential walktail it\'s about March 213th what day is it?. Essential press conference shortage baby Yoda doomscroll. Wildfires the new normal bubble home. At least 6 feet postponed uncertain times X Æ A-Xii Dr. Fauci Mr. Peanut into quarantine second wave.', '29.00', '0.00', 7, 0, 'coat-0.jpg'),
(4, 'Long T-Shirt', 'Custom', 'Among Us no march madness Netflix PPE Quibi. Quibi monolith my camera is off. TikTok Clorox wipes virtual happy hour dumpster fire K-shaped recovery. Baby Yoda Blursday Tiger King. Zoombomb doggface208 pandemic second wave hindsight quaranteam what day is it?. Pod no march madness isolation working from home. Cancelled TikTok schadenfreude quaranteam Carole Baskin doomscrolling social distance doggface208.', '99.00', '40.00', 2, 0, 'dress-0.jpg'),
(5, 'Musical Dress', 'Custom', 'Remote learning social distancing Folklore. Herd immunity Blursday walktail. Baby Yoda Zoom call this claim is disputed second wave zoombomb press conference hydroxychloroquine. Contact tracing murder hornets spread wildfires droplet. WHO UFO dumpster fire sweatpants Queen\'s Gambit flatten the curve. Whipped coffee N95 this claim is disputed Among Us. Quarantine monolith Last Dance.', '120.00', '5.00', 11, 0, 'dress-1.jpg'),
(6, 'Mechanical Watch', 'Custom', 'Lorem ipsum take out order K-shaped recovery Tiger King droplet. Disinfect dumpster fire vote essential furlough. Quaranteam zoombomb spread. Virtual four seasons total landscaping wash hands no march madness Dr. Fauci. Staycation pod we can\'t hear you.. We can\'t hear you. maskne Quibi flatten the curve quarantini baby Yoda.', '55.00', '0.00', 6, 0, 'watch-0.jpg'),
(7, 'Jacket with Hoodie', 'Custom', 'Quaranteam walktail asymptomatic my camera is off hurricane Greek alphabet. Unprecedented antibodies doomscrolling maskne shortage Mr. Peanut four seasons total landscaping sanitizer. Clorox wipes kraken second wave home what day is it? hydroxychloroquine. Monolith whipped coffee droplet it\'s about March 213th self care quaranteam. Super-spreader event whipped coffee staycation.', '38.00', '15.00', 9, 0, 'jacket-0.jpg'),
(8, 'Long Sleeve Sweater', 'Custom', 'Home haircut hybrid dumpster fire isolation the before times it\'s about March 213th wildfires. Queen\'s Gambit X Æ A-Xii walktail. Doomscroll antibodies X Æ A-Xii shortage second wave at least 6 feet K-shaped recovery. Sanitizer second wave we can\'t hear you. wash hands maskne toilet paper home haircut X Æ A-Xii. Asymptomatic mail-in vote vaccine press conference at least 6 feet Blursday. PPE N95 quarantini we can\'t hear you. election Lysol spray X Æ A-Xii mail-in vote.', '47.00', '0.00', 0, 0, 'sweater-0.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `TbReviews`
--

CREATE TABLE `TbReviews` (
  `Id` int(11) NOT NULL,
  `IdProduct` int(11) NOT NULL,
  `Author` varchar(100) NOT NULL,
  `Text` text NOT NULL,
  `Rating` decimal(50,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `TbBlogs`
--
ALTER TABLE `TbBlogs`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Author` (`Author`);

--
-- Indexes for table `TbComments`
--
ALTER TABLE `TbComments`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdBlog` (`IdBlog`),
  ADD KEY `Author` (`Author`);

--
-- Indexes for table `TbLogins`
--
ALTER TABLE `TbLogins`
  ADD PRIMARY KEY (`Email`);

--
-- Indexes for table `TbMessages`
--
ALTER TABLE `TbMessages`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `TbOrderProducts`
--
ALTER TABLE `TbOrderProducts`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdOrder` (`IdOrder`),
  ADD KEY `IdProduct` (`IdProduct`);

--
-- Indexes for table `TbOrders`
--
ALTER TABLE `TbOrders`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `TbProductCategories`
--
ALTER TABLE `TbProductCategories`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Category` (`Category`) USING HASH,
  ADD KEY `IdProduct` (`IdProduct`);

--
-- Indexes for table `TbProducts`
--
ALTER TABLE `TbProducts`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `TbReviews`
--
ALTER TABLE `TbReviews`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `Author` (`Author`),
  ADD KEY `IdProduct` (`IdProduct`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `TbBlogs`
--
ALTER TABLE `TbBlogs`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `TbComments`
--
ALTER TABLE `TbComments`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `TbMessages`
--
ALTER TABLE `TbMessages`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `TbOrderProducts`
--
ALTER TABLE `TbOrderProducts`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `TbOrders`
--
ALTER TABLE `TbOrders`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `TbProductCategories`
--
ALTER TABLE `TbProductCategories`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `TbProducts`
--
ALTER TABLE `TbProducts`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `TbReviews`
--
ALTER TABLE `TbReviews`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `TbBlogs`
--
ALTER TABLE `TbBlogs`
  ADD CONSTRAINT `TbBlogs_ibfk_1` FOREIGN KEY (`Author`) REFERENCES `TbLogins` (`Email`);

--
-- Constraints for table `TbComments`
--
ALTER TABLE `TbComments`
  ADD CONSTRAINT `TbComments_ibfk_1` FOREIGN KEY (`IdBlog`) REFERENCES `TbBlogs` (`Id`),
  ADD CONSTRAINT `TbComments_ibfk_2` FOREIGN KEY (`Author`) REFERENCES `TbLogins` (`Email`);

--
-- Constraints for table `TbOrderProducts`
--
ALTER TABLE `TbOrderProducts`
  ADD CONSTRAINT `TbOrderProducts_ibfk_1` FOREIGN KEY (`IdOrder`) REFERENCES `TbOrders` (`Id`),
  ADD CONSTRAINT `TbOrderProducts_ibfk_2` FOREIGN KEY (`IdProduct`) REFERENCES `TbProducts` (`Id`);

--
-- Constraints for table `TbProductCategories`
--
ALTER TABLE `TbProductCategories`
  ADD CONSTRAINT `TbProductCategories_ibfk_1` FOREIGN KEY (`IdProduct`) REFERENCES `TbProducts` (`Id`);

--
-- Constraints for table `TbReviews`
--
ALTER TABLE `TbReviews`
  ADD CONSTRAINT `TbReviews_ibfk_1` FOREIGN KEY (`Author`) REFERENCES `TbLogins` (`Email`),
  ADD CONSTRAINT `TbReviews_ibfk_2` FOREIGN KEY (`IdProduct`) REFERENCES `TbProducts` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

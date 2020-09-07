-- --------------------------------------------------------
-- Host:                         balittanahpelayanan.mysql.database.azure.com
-- Server version:               5.6.44-log - MySQL Community Server (GPL)
-- Server OS:                    Win64
-- HeidiSQL Version:             10.2.0.5599
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for smlpob
DROP DATABASE IF EXISTS `smlpob`;
CREATE DATABASE IF NOT EXISTS `smlpob` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `smlpob`;

-- Dumping structure for table smlpob.accounttbl
DROP TABLE IF EXISTS `accounttbl`;
CREATE TABLE IF NOT EXISTS `accounttbl` (
  `accountNo` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `roleName` varchar(255) DEFAULT NULL,
  `isEmailVerified` char(1) DEFAULT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`accountNo`),
  KEY `AccountTbltoRoleTbl` (`roleName`),
  CONSTRAINT `AccountTbltoRoleTbl` FOREIGN KEY (`roleName`) REFERENCES `roletbl` (`roleName`)
) ENGINE=InnoDB AUTO_INCREMENT=1182 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.accounttbl: ~32 rows (approximately)
DELETE FROM `accounttbl`;
/*!40000 ALTER TABLE `accounttbl` DISABLE KEYS */;
INSERT INTO `accounttbl` (`accountNo`, `username`, `password`, `roleName`, `isEmailVerified`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	(1, 'galih', '123', 'pelanggan', '1', NULL, NULL, NULL, NULL),
	(1115, 'asep@gmail.com', 'UYxJp1F6c6U=', 'pelanggan', '1', '', '2019-08-24 18:01:16', NULL, NULL),
	(1116, 'ujang@gmail.com', 'dAYGe9hCGlU=', 'pelanggan', '0', '', '2019-08-24 18:02:41', '', '2019-08-24 18:08:42'),
	(1117, 'jeje@gmail.com', 'UYxJp1F6c6U=', 'pelanggan', '1', 'registration system', '2019-08-24 18:16:01', NULL, NULL),
	(1118, 'anna@gmail.com', 'UYxJp1F6c6U=', 'pelanggan', '1', 'registration system', '2019-08-24 18:22:37', NULL, NULL),
	(1120, 'testpenyelia@gmail.com', 'UYxJp1F6c6U=', 'penyelia', '0', '', '2019-08-26 13:02:45', NULL, NULL),
	(1145, 'teguh@gmail.com', 'QpOo4tN8e5s=', 'pelanggan', '0', 'registration system', '2019-08-28 08:59:54', NULL, NULL),
	(1147, 'acuaca00@gmail.com', '2VuSprnOob31TmAFZYCrpA==', 'pelanggan', '0', 'registration system', '2019-08-28 09:11:30', NULL, NULL),
	(1148, 'mifmasterz@gmail.com', 'UYxJp1F6c6U=', 'pelanggan', '1', '', '2019-08-28 09:48:18', NULL, NULL),
	(1149, 'mifmasterz@yahoo.com', 'UYxJp1F6c6U=', 'pelanggan', '1', 'anonymous', '2019-08-28 10:12:29', NULL, NULL),
	(1151, 'fariz@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'pelanggan', '0', 'anonymous', '2019-08-29 13:36:37', NULL, NULL),
	(1152, 'mstokev@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'pelanggan', '1', 'anonymous', '2019-08-30 14:19:53', NULL, NULL),
	(1153, 'mifmasterz@outlook.com', 'UYxJp1F6c6U=', 'pelanggan', '1', 'anonymous', '2019-08-30 19:28:43', NULL, NULL),
	(1154, 'cu1@gmail.com', 'UYxJp1F6c6U=', 'pelanggan', '1', 'registration system', '2019-08-30 19:28:43', NULL, NULL),
	(1160, 'galihyprtm@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'pelanggan', '1', 'anonymous', '2019-09-02 09:45:21', NULL, NULL),
	(1161, 'manager1@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'manajer teknis', '1', '', '2019-09-02 09:58:05', NULL, NULL),
	(1162, 'analis1@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-09-02 09:59:35', NULL, NULL),
	(1163, 'evaluator1@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'evaluator', '1', '', '2019-09-02 10:04:32', NULL, NULL),
	(1164, 'kasir1@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'kasir', '1', '', '2019-09-02 10:06:52', NULL, NULL),
	(1165, 'cs1@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'cs', '1', '', '2019-09-02 10:07:53', NULL, NULL),
	(1166, 'penyelia1@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'penyelia', '1', '', '2019-09-02 10:44:53', NULL, NULL),
	(1167, 'guntur.fitrano@mhsw.pnj.ac.id', 'aE4D0W0BconPbLcB3rVW8Q==', 'pelanggan', '0', 'anonymous', '2019-09-04 13:36:45', NULL, NULL),
	(1168, 'guntur.fitrano.tik16@mhsw.pnj.ac.id', 'zpzUuvOKbDu1sxHlYL9fSA==', 'pelanggan', '0', 'anonymous', '2019-09-04 13:38:38', NULL, NULL),
	(1169, 'umaraaa234@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'pelanggan', '0', 'anonymous', '2019-09-04 13:41:57', NULL, NULL),
	(1170, 'guntur.januar30@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'pelanggan', '1', 'anonymous', '2019-09-06 14:28:04', NULL, NULL),
	(1173, 'acuaca00@gmail.com', '2VuSprnOob31TmAFZYCrpA==', 'pelanggan', '0', 'anonymous', '2019-09-09 09:03:50', NULL, NULL),
	(1176, 'teguhprayoga94@gmail.com', 'UYxJp1F6c6U=', 'pelanggan', '1', 'anonymous', '2019-09-09 14:49:09', NULL, NULL),
	(1178, 'agriezmann408@gmail.com', 'UYxJp1F6c6U=', 'pelanggan', '1', 'anonymous', '2019-09-09 15:58:49', NULL, NULL),
	(1179, 'rizkyansyah031398@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'pelanggan', '1', 'anonymous', '2019-09-16 12:42:12', NULL, NULL),
	(1180, 'Iwanfals25@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'pelanggan', '0', 'anonymous', '2019-09-25 08:58:51', NULL, NULL),
	(1181, 'dontworry02051998@gmail.com', 'd8FaM1B3Hf+ejEL58J76Cw==', 'pelanggan', '1', 'anonymous', '2019-09-25 09:18:58', NULL, NULL);
/*!40000 ALTER TABLE `accounttbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.analysistypetbl
DROP TABLE IF EXISTS `analysistypetbl`;
CREATE TABLE IF NOT EXISTS `analysistypetbl` (
  `analysisTypeName` varchar(255) NOT NULL,
  `description` text,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`analysisTypeName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.analysistypetbl: ~3 rows (approximately)
DELETE FROM `analysistypetbl`;
/*!40000 ALTER TABLE `analysistypetbl` DISABLE KEYS */;
INSERT INTO `analysistypetbl` (`analysisTypeName`, `description`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	('Biologi\r\n', 'analisis di lab biologi', NULL, NULL, NULL, NULL),
	('Fisika\r\n', 'analisis di lab fisika\r\n', NULL, NULL, NULL, NULL),
	('Kimia', 'analisis dilakukan di lab kimia', NULL, NULL, NULL, NULL);
/*!40000 ALTER TABLE `analysistypetbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.autonumbertbl
DROP TABLE IF EXISTS `autonumbertbl`;
CREATE TABLE IF NOT EXISTS `autonumbertbl` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NameSet` varchar(10) NOT NULL DEFAULT 'General',
  `LastCounter` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.autonumbertbl: ~2 rows (approximately)
DELETE FROM `autonumbertbl`;
/*!40000 ALTER TABLE `autonumbertbl` DISABLE KEYS */;
INSERT INTO `autonumbertbl` (`Id`, `NameSet`, `LastCounter`) VALUES
	(1, 'BALITTANAH', 24),
	(2, 'SAMPEL', 20);
/*!40000 ALTER TABLE `autonumbertbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.comoditytbl
DROP TABLE IF EXISTS `comoditytbl`;
CREATE TABLE IF NOT EXISTS `comoditytbl` (
  `comodityNo` int(11) NOT NULL AUTO_INCREMENT,
  `comodityName` varchar(255) DEFAULT NULL,
  `derivativeTo` int(11) DEFAULT NULL,
  `description` text,
  `code` varchar(10) DEFAULT NULL,
  `notes` text,
  `isPackage` varchar(1) DEFAULT '0',
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  `isGenusAvailable` char(1) DEFAULT NULL,
  `priceGenusPerSample` decimal(12,2) DEFAULT NULL,
  `isHeavyMetalAvailable` char(1) DEFAULT NULL,
  `limitDoseForFreeOfHeavyMetal` decimal(5,0) DEFAULT NULL,
  `priceHeavyMetalPerSample` decimal(12,2) DEFAULT NULL,
  PRIMARY KEY (`comodityNo`),
  UNIQUE KEY `comodityName` (`comodityName`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.comoditytbl: ~22 rows (approximately)
DELETE FROM `comoditytbl`;
/*!40000 ALTER TABLE `comoditytbl` DISABLE KEYS */;
INSERT INTO `comoditytbl` (`comodityNo`, `comodityName`, `derivativeTo`, `description`, `code`, `notes`, `isPackage`, `creaBy`, `creaDate`, `modBy`, `modDate`, `isGenusAvailable`, `priceGenusPerSample`, `isHeavyMetalAvailable`, `limitDoseForFreeOfHeavyMetal`, `priceHeavyMetalPerSample`) VALUES
	(1, 'ASAM HUMAT PADAT ', -1, '', 'AHP', '', '1', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(2, 'ASAM HUMAT Cair', -1, '', 'AHC', '', '1', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(3, 'PUPUK MAKRO TUNGGAL PADAT', -1, '', 'PMTD', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(4, 'PUPUK MAKRO TUNGGAL CAIR', -1, '', 'PMTC', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(5, 'PUPUK MAKRO MAJEMUK PADAT', -1, '', 'PMMD', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(6, 'PUPUK MAKRO MAJEMUK CAIR', -1, '', 'PMMC', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(7, 'PUPUK MIKRO TUNGGAL PADAT', -1, '', 'PMTP', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(8, 'PUPUK MIKRO TUNGGAL CAIR', -1, '', 'PMTC', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(9, 'PUPUK MIKRO MAJEMUK PADAT', -1, '', 'PMMP', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(10, 'PUPUK MIKRO MAJEMUK CAIR', -1, '', 'PMMC', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(11, 'PUPUK CAMPURAN MAKRO-MIKRO PADAT', -1, '', 'PCMMP', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(12, 'PUPUK CAMPURAN MAKRO-MIKRO CAIR', -1, '', 'PCMMC', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(13, 'PUPUK ORGANIK PADAT (SNI 7763:2018)  (TANPA DIPERKAYA MIKROBA)', -1, '', 'POPT', '', '1', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(14, 'PUPUK ORGANIK PADAT (Kepmentan 261/KPTS/SR.310/M/4/2019) (DIPERKAYA MIKROBA)', -1, '', 'POPD', '', '1', NULL, NULL, NULL, NULL, '1', 125000.00, '0', NULL, NULL),
	(15, 'PUPUK ORGANIK CAIR (Kepmentan 261/KPTS/SR.310/M/4/2019)', -1, '', 'POC', '', '1', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(16, 'PUPUK HAYATI TUNGGAL PADAT DAN CAIR', -1, 'Uji Logam berat pilihan tergantung dosis pupuk hayati tunggal, bila dosis lebih besar sama dengan 50 kg/ha atau lebih besar sama dengan 50 L/ha maka uji logam berat (As, Hg, Pb, Cd, Hg, As, Cr, Ni) wajib dilakukan sehingga biaya per sampel akan ditambahkan sebesar Rp.382.000,- (termasuk persiapan, uji kadar air, dan ekstrak total) sehingga menjadi a + Rp.382.000,- dan Total Biaya=(a+Rp. 382.000,-) x b', 'PHTPDC', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '1', 50, 382000.00),
	(17, 'Pupuk Hayati Tunggal Endomikoriza Arbuskular (Kepmentan 261/KPTS/SR.310/M/4/2019)', -1, 'Uji Logam berat pilihan tergantung dosis pupuk hayati tunggal, bila dosis lebih besar sama dengan 50 kg/ha atau lebih besar sama dengan 50 L/ha maka uji logam berat (As, Hg, Pb, Cd, Hg, As, Cr, Ni) wajib dilakukan sehingga biaya per sampel akan ditambahkan sebesar Rp.382.000,- (termasuk persiapan, uji kadar air, dan ekstrak total) sehingga menjadi a + Rp.382.000,- dan Total Biaya=(a+Rp. 382.000,-) x b', 'PHTEA', '', '1', NULL, NULL, NULL, NULL, '0', 0.00, '1', 50, 382000.00),
	(18, 'Pupuk Hayati Tunggal Ektomikoriza (Kepmentan 261/KPTS/SR.310/M/4/2019)', -1, 'Uji Logam berat pilihan tergantung dosis pupuk hayati tunggal, bila dosis lebih besar sama dengan 50 kg/ha atau lebih besar sama dengan 50 L/ha maka uji logam berat (As, Hg, Pb, Cd, Hg, As, Cr, Ni) wajib dilakukan sehingga biaya per sampel akan ditambahkan sebesar Rp.382.000,- (termasuk persiapan, uji kadar air, dan ekstrak total) sehingga menjadi a + Rp.382.000,- dan Total Biaya=(a+Rp. 382.000,-) x b', 'PHTE', '', '1', NULL, NULL, NULL, NULL, '0', 0.00, '1', 50, 382000.00),
	(19, 'PUPUK HAYATI MAJEMUK PADAT DAN CAIR UNTUK 2 GENUS (Kepmentan 261/KPTS/SR.310/M/4/2019)', -1, '', 'PHMPDC2', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(20, 'PUPUK HAYATI MAJEMUK PADAT DAN CAIR UNTUK >2 GENUS (Kepmentan 261/KPTS/SR.310/M/4/2019)', -1, '', 'PHMPDCN', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(21, 'Tanah Rutin', -1, '', 'TR', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(22, 'Tanah Khusus', -1, '', 'TK', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL);
/*!40000 ALTER TABLE `comoditytbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.customertbl
DROP TABLE IF EXISTS `customertbl`;
CREATE TABLE IF NOT EXISTS `customertbl` (
  `customerNo` int(11) NOT NULL AUTO_INCREMENT,
  `customerName` varchar(255) DEFAULT NULL,
  `customerEmail` varchar(255) DEFAULT NULL,
  `companyName` varchar(255) DEFAULT NULL,
  `companyAddress` text,
  `companyPhone` varchar(25) DEFAULT NULL,
  `companyEmail` varchar(255) DEFAULT NULL,
  `accountNo` int(11) DEFAULT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`customerNo`),
  KEY `CustomerTblAccountTbl` (`accountNo`),
  CONSTRAINT `CustomerTblAccountTbl` FOREIGN KEY (`accountNo`) REFERENCES `accounttbl` (`accountNo`)
) ENGINE=InnoDB AUTO_INCREMENT=1166 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.customertbl: ~21 rows (approximately)
DELETE FROM `customertbl`;
/*!40000 ALTER TABLE `customertbl` DISABLE KEYS */;
INSERT INTO `customertbl` (`customerNo`, `customerName`, `customerEmail`, `companyName`, `companyAddress`, `companyPhone`, `companyEmail`, `accountNo`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	(1113, 'jeje', 'jeje@gmail.com', 'jejecorp', 'bogor', '081212121212', 'jejecorp@gmail.com', 1117, 'registration system', '2019-08-24 18:16:01', NULL, NULL),
	(1114, 'anna', 'anna@gmail.com', 'annacorp', 'bogor', '0928190382190', 'annacorp@gmail.com', 1118, 'registration system', '2019-08-24 18:23:05', NULL, NULL),
	(1139, 'galih', 'galih@galih.com', 'gravicode', 'bogor', '021', 'admin@gravicode.com', 1, '', '2019-08-27 16:54:09', NULL, NULL),
	(1140, 'Uji Coba', 'teguh@gmail.com', 'Gravicode', 'bgr', '0896212399999', 'dude@gmail.com', 1145, 'registration system', '2019-08-28 08:59:54', NULL, NULL),
	(1143, 'onon', 'mifmasterz@gmail.com', 'bogor ujung', 'bogor ujung', '123321423564654', 'mifmasterz@gmail.com', 1148, '', '2019-08-28 09:48:18', NULL, NULL),
	(1144, 'onon2', 'mifmasterz@yahoo.com', 'bogor ujung 2', 'bogor ujung 2', '123321423564654', 'mifmasterz@yahoo.com', 1149, 'anonymous', '2019-08-28 10:12:30', NULL, NULL),
	(1146, 'fariz', 'fariz@gmail.com', 'Balittanah', 'Jln.Soekarno Kec.Ciampea', '081292501474', 'farizbalit@gmail.com', 1151, 'anonymous', '2019-08-29 13:36:37', NULL, NULL),
	(1147, 'udin sedunia', 'mstokev@gmail.com', 'awak putu', 'papua ku cinta', '918274098237', 'mstokev@gmail.com', 1152, 'anonymous', '2019-08-30 14:19:54', NULL, NULL),
	(1148, 'sukria', 'mifmasterz@outlook.com', 'PT ASEP', 'JL ANYER', '08123546546', 'mifmasterz@outlook.com', 1153, 'anonymous', '2019-08-30 19:28:43', NULL, NULL),
	(1149, 'cus1', 'cu1@gmail.com', 'PT Orca', 'jakarta selatan', '08968776566', 'cu1@gmail.com', 1154, 'registration system', '2019-08-30 19:28:43', NULL, NULL),
	(1150, 'galihyp', 'galihyprtm@gmail.com', 'gravicode', 'bogor', '08726123621278', 'galihyprtm@gravicode.com', 1160, 'anonymous', '2019-09-02 09:45:21', NULL, NULL),
	(1151, 'Zilong', 'guntur.fitrano@mhsw.pnj.ac.id', 'Gravicode', 'Bogor', '0897879868767', 'gravicode@gmail.com', 1167, 'anonymous', '2019-09-04 13:36:45', NULL, NULL),
	(1152, 'Zilong', 'guntur.fitrano.tik16@mhsw.pnj.ac.id', 'Gravicode', 'Bogor', '09898989898', 'gravicode@gmail.com', 1168, 'anonymous', '2019-09-04 13:38:38', NULL, NULL),
	(1153, 'Ramadhan', 'umaraaa234@gmail.com', 'Gravicode', 'Bogor', '09898989898', 'gravicode@gmail.com', 1169, 'anonymous', '2019-09-04 13:41:57', NULL, NULL),
	(1154, 'Guntur', 'guntur.januar30@gmail.com', 'Gravicode', 'Tanah Sereal, Bogor', '089656518334', 'gravicode@gmail.com', 1170, 'anonymous', '2019-09-06 14:28:04', NULL, NULL),
	(1157, 'awa', 'acuaca00@gmail.com', 'bogor', 'bogor', '081292501212', 'acuaca00@gmail.com', 1147, 'anonymous', '2019-09-09 09:03:50', NULL, NULL),
	(1160, 'Teguh', 'teguhprayoga94@gmail.com', 'Gravicode', 'Bogor', '081242313132', 'gravicode@gmail.com', 1176, 'anonymous', '2019-09-09 14:49:09', NULL, NULL),
	(1162, 'Griezmann', 'agriezmann408@gmail.com', 'Gravicode', 'Bogor', '08123412412421', 'gravicode@gmail.com', 1178, 'anonymous', '2019-09-09 15:58:49', NULL, NULL),
	(1163, 'Rizky', 'rizkyansyah031398@gmail.com', 'Gravicode', 'Bogor', '089898989898', 'gravicode@gmail.com', 1179, 'anonymous', '2019-09-16 12:42:12', NULL, NULL),
	(1164, 'Iwan fals', 'Iwanfals25@gmail.com', 'PT.Ayam Geprek', 'Taman Cimanggu,Bogor Kec.Cimanggu', '081292502522', 'Iwanfals25@gmail.com', 1180, 'anonymous', '2019-09-25 08:58:51', NULL, NULL),
	(1165, 'dontworry', 'dontworry02051998@gmail.com', 'PT.cinta sejati tidak ada dua', 'JL.jalan jalan mulu ngopi napa', '081546253224', 'dontworry02051998@gmail.com', 1181, 'anonymous', '2019-09-25 09:18:58', NULL, NULL);
/*!40000 ALTER TABLE `customertbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.elementservicehistorytbl
DROP TABLE IF EXISTS `elementservicehistorytbl`;
CREATE TABLE IF NOT EXISTS `elementservicehistorytbl` (
  `elementHistoryNo` int(11) NOT NULL AUTO_INCREMENT,
  `activeDate` datetime DEFAULT NULL,
  `expiredDate` datetime DEFAULT NULL,
  `elementId` int(11) NOT NULL,
  `serviceRate` decimal(12,2) DEFAULT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  PRIMARY KEY (`elementHistoryNo`),
  KEY `ElementServiceHistoryTbltoElementServicesTbl` (`elementId`),
  CONSTRAINT `ElementServiceHistoryTbltoElementServicesTbl` FOREIGN KEY (`elementId`) REFERENCES `elementservicestbl` (`elementid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.elementservicehistorytbl: ~0 rows (approximately)
DELETE FROM `elementservicehistorytbl`;
/*!40000 ALTER TABLE `elementservicehistorytbl` DISABLE KEYS */;
/*!40000 ALTER TABLE `elementservicehistorytbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.elementservicestbl
DROP TABLE IF EXISTS `elementservicestbl`;
CREATE TABLE IF NOT EXISTS `elementservicestbl` (
  `elementid` int(11) NOT NULL AUTO_INCREMENT,
  `elementCode` varchar(255) NOT NULL,
  `comodityNo` int(11) NOT NULL,
  `analysisTypeName` varchar(255) NOT NULL,
  `valueUnit` varchar(255) DEFAULT NULL,
  `serviceGroup` varchar(255) DEFAULT NULL,
  `serviceRate` decimal(12,2) NOT NULL,
  `serviceStatus` varchar(255) DEFAULT NULL,
  `category` varchar(255) DEFAULT 'General',
  `sortedNo` int(11) DEFAULT '0',
  `isMandatory` char(1) DEFAULT '0',
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`elementid`),
  KEY `ElementServicesTbltoAnalysisTypeTbl` (`analysisTypeName`),
  CONSTRAINT `ElementServicesTbltoAnalysisTypeTbl` FOREIGN KEY (`analysisTypeName`) REFERENCES `analysistypetbl` (`analysisTypeName`)
) ENGINE=InnoDB AUTO_INCREMENT=286 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.elementservicestbl: ~285 rows (approximately)
DELETE FROM `elementservicestbl`;
/*!40000 ALTER TABLE `elementservicestbl` DISABLE KEYS */;
INSERT INTO `elementservicestbl` (`elementid`, `elementCode`, `comodityNo`, `analysisTypeName`, `valueUnit`, `serviceGroup`, `serviceRate`, `serviceStatus`, `category`, `sortedNo`, `isMandatory`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	(1, 'Senyawa Humat', 1, 'Kimia', '%', '-', 0.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(2, 'Kelarutan dalam air', 1, 'Kimia', '%', '', 0.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(3, 'Kadar air', 1, 'Kimia', '% (w/w)', '', 0.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(4, 'Natrium', 1, 'Kimia', '%', '', 0.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(5, 'pH', 1, 'Kimia', '-', '', 0.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(6, 'As', 1, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam Berat', 6, '0', NULL, NULL, NULL, NULL),
	(7, 'Hg', 1, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam Berat', 6, '0', NULL, NULL, NULL, NULL),
	(8, 'Pb', 1, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam Berat', 6, '0', NULL, NULL, NULL, NULL),
	(9, 'Cd', 1, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam Berat', 6, '0', NULL, NULL, NULL, NULL),
	(10, 'Cr', 1, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam Berat', 6, '0', NULL, NULL, NULL, NULL),
	(11, 'Ni', 1, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam Berat', 6, '0', NULL, NULL, NULL, NULL),
	(12, 'Senyawa Humat', 2, 'Kimia', '%', '', 0.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(13, 'Natrium', 2, 'Kimia', '%', '', 0.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(14, 'pH', 2, 'Kimia', '-', '', 0.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(15, 'As', 2, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam Berat', 4, '0', NULL, NULL, NULL, NULL),
	(16, 'Hg', 2, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam Berat', 4, '0', NULL, NULL, NULL, NULL),
	(17, 'Pb', 2, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam Berat', 4, '0', NULL, NULL, NULL, NULL),
	(18, 'Cd', 2, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam Berat', 4, '0', NULL, NULL, NULL, NULL),
	(19, 'Cr', 2, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam Berat', 4, '0', NULL, NULL, NULL, NULL),
	(20, 'Ni', 2, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam Berat', 4, '0', NULL, NULL, NULL, NULL),
	(21, 'N', 3, 'Kimia', 'ppm', '', 251000.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(22, 'P', 3, 'Kimia', '-', '', 306000.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(23, 'K', 3, 'Kimia', '-', '', 126000.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(24, 'Ca', 3, 'Kimia', '-', '', 342000.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(25, 'Mg', 3, 'Kimia', '-', '', 342000.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(26, 'S', 3, 'Kimia', '-', '', 342000.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(27, 'Si', 3, 'Kimia', '-', '', 299400.00, 'Tersedia', 'General', 7, '0', NULL, NULL, NULL, NULL),
	(28, 'N', 4, 'Kimia', '-', '', 181000.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(29, 'P', 4, 'Kimia', '-', '', 160000.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(30, 'K', 4, 'Kimia', '-', '', 161000.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(31, 'Ca', 4, 'Kimia', '-', '', 157000.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(32, 'Mg', 4, 'Kimia', '-', '', 157000.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(33, 'S', 4, 'Kimia', '-', '', 160000.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(34, 'Si', 4, 'Kimia', '-', '', 247000.00, 'Tersedia', 'General', 7, '0', NULL, NULL, NULL, NULL),
	(35, 'N', 5, 'Kimia', '-', '', 105000.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(36, 'P', 5, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(37, 'K', 5, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(38, 'Ca', 5, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(39, 'Mg', 5, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(40, 'S', 5, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(41, 'Si', 5, 'Kimia', '-', '', 59400.00, 'Tersedia', 'General', 7, '0', NULL, NULL, NULL, NULL),
	(42, 'Pb', 5, 'Kimia', '-', '', 35000.00, 'Tersedia', 'General', 8, '1', NULL, NULL, NULL, NULL),
	(43, 'Cd', 5, 'Kimia', '-', '', 35000.00, 'Tersedia', 'General', 9, '1', NULL, NULL, NULL, NULL),
	(44, 'Hg', 5, 'Kimia', '-', '', 70000.00, 'Tersedia', 'General', 10, '1', NULL, NULL, NULL, NULL),
	(45, 'As', 5, 'Kimia', '-', '', 70000.00, 'Tersedia', 'General', 11, '1', NULL, NULL, NULL, NULL),
	(46, 'Persiapan, Kadar Air, dan Ekstrak Total', 5, 'Kimia', '-', '', 102000.00, 'Tersedia', 'General', 12, '1', NULL, NULL, NULL, NULL),
	(47, 'N', 6, 'Kimia', '-', '', 39000.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(48, 'P', 6, 'Kimia', '-', '', 18000.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(49, 'K', 6, 'Kimia', '-', '', 19000.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(50, 'Ca', 6, 'Kimia', '-', '', 15000.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(51, 'Mg', 6, 'Kimia', '-', '', 15000.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(52, 'S', 6, 'Kimia', '-', '', 18000.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(53, 'Si', 6, 'Kimia', '-', '', 105000.00, 'Tersedia', 'General', 7, '0', NULL, NULL, NULL, NULL),
	(54, 'Pb', 6, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 8, '1', NULL, NULL, NULL, NULL),
	(55, 'Cd', 6, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 9, '1', NULL, NULL, NULL, NULL),
	(56, 'Hg', 6, 'Kimia', '-', '', 70000.00, 'Tersedia', 'General', 10, '1', NULL, NULL, NULL, NULL),
	(57, 'As', 6, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 11, '1', NULL, NULL, NULL, NULL),
	(58, 'Zn', 7, 'Kimia', '-', '', 366000.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(59, 'B', 7, 'Kimia', '-', '', 377000.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(60, 'Mn', 7, 'Kimia', '-', '', 366000.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(61, 'Cu', 7, 'Kimia', '-', '', 366000.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(62, 'Mo', 7, 'Kimia', '-', '', 377000.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(63, 'Co', 7, 'Kimia', '-', '', 377000.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(64, 'Fe', 7, 'Kimia', '-', '', 366000.00, 'Tersedia', 'General', 7, '0', NULL, NULL, NULL, NULL),
	(65, 'Zn', 8, 'Kimia', '-', '', 161000.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(66, 'B', 8, 'Kimia', '-', '', 166000.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(67, 'Mn', 8, 'Kimia', '-', '', 161000.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(68, 'Cu', 8, 'Kimia', '-', '', 161000.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(69, 'Mo', 8, 'Kimia', '-', '', 166000.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(70, 'Co', 8, 'Kimia', '-', '', 166000.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(71, 'Fe', 8, 'Kimia', '-', '', 161000.00, 'Tersedia', 'General', 7, '0', NULL, NULL, NULL, NULL),
	(72, 'Zn', 9, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(73, 'B', 9, 'Kimia', '-', '', 35000.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(74, 'Mn', 9, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(75, 'Cu', 9, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(76, 'Mo', 9, 'Kimia', '-', '', 35000.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(77, 'Co', 9, 'Kimia', '-', '', 35000.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(78, 'Fe', 9, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 7, '0', NULL, NULL, NULL, NULL),
	(79, 'Pb', 9, 'Kimia', '-', '', 35000.00, 'Tersedia', 'General', 8, '1', NULL, NULL, NULL, NULL),
	(80, 'Cd', 9, 'Kimia', '-', '', 35000.00, 'Tersedia', 'General', 9, '1', NULL, NULL, NULL, NULL),
	(81, 'Hg', 9, 'Kimia', '-', '', 70000.00, 'Tersedia', 'General', 10, '1', NULL, NULL, NULL, NULL),
	(82, 'As', 9, 'Kimia', '-', '', 70000.00, 'Tersedia', 'General', 11, '1', NULL, NULL, NULL, NULL),
	(83, 'Persiapan, Kadar Air, dan Ekstrak Total', 9, 'Kimia', '-', '', 102000.00, 'Tersedia', 'General', 12, '1', NULL, NULL, NULL, NULL),
	(84, 'Zn', 10, 'Kimia', '-', '', 18000.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(85, 'B', 10, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(86, 'Mn', 10, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(87, 'Cu', 10, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(88, 'Mo', 10, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(89, 'Co', 10, 'Kimia', '-', '', 26400.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(90, 'Fe', 10, 'Kimia', '-', '', 35000.00, 'Tersedia', 'General', 7, '0', NULL, NULL, NULL, NULL),
	(91, 'Pb', 10, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 8, '1', NULL, NULL, NULL, NULL),
	(92, 'Cd', 10, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 9, '1', NULL, NULL, NULL, NULL),
	(93, 'Hg', 10, 'Kimia', '-', '', 70000.00, 'Tersedia', 'General', 10, '1', NULL, NULL, NULL, NULL),
	(94, 'As', 10, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 11, '1', NULL, NULL, NULL, NULL),
	(95, 'N ', 11, 'Kimia', '-', '', 105000.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(96, 'P', 11, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(97, 'K', 11, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(98, 'Ca', 11, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(99, 'Mg', 11, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(100, 'S', 11, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(101, 'Si', 11, 'Kimia', '-', '', 59400.00, 'Tersedia', 'General', 7, '0', NULL, NULL, NULL, NULL),
	(102, 'Zn', 11, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 8, '0', NULL, NULL, NULL, NULL),
	(103, 'B', 11, 'Kimia', '-', '', 35000.00, 'Tersedia', 'General', 9, '0', NULL, NULL, NULL, NULL),
	(104, 'Mn', 11, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 10, '0', NULL, NULL, NULL, NULL),
	(105, 'Cu', 11, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 11, '0', NULL, NULL, NULL, NULL),
	(106, 'Mo', 11, 'Kimia', '-', '', 35000.00, 'Tersedia', 'General', 12, '0', NULL, NULL, NULL, NULL),
	(107, 'Co', 11, 'Kimia', '-', '', 35000.00, 'Tersedia', 'General', 13, '0', NULL, NULL, NULL, NULL),
	(108, 'Fe', 11, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 14, '0', NULL, NULL, NULL, NULL),
	(109, 'Pb', 11, 'Kimia', '-', '', 35000.00, 'Tersedia', 'General', 15, '1', NULL, NULL, NULL, NULL),
	(110, 'Cd', 11, 'Kimia', '-', '', 35000.00, 'Tersedia', 'General', 16, '1', NULL, NULL, NULL, NULL),
	(111, 'Hg', 11, 'Kimia', '-', '', 70000.00, 'Tersedia', 'General', 17, '1', NULL, NULL, NULL, NULL),
	(112, 'As', 11, 'Kimia', '-', '', 70000.00, 'Tersedia', 'General', 18, '1', NULL, NULL, NULL, NULL),
	(113, 'Persiapan, Kadar Air, dan Ekstrak Total', 11, 'Kimia', '-', '', 102000.00, 'Tersedia', 'General', 19, '1', NULL, NULL, NULL, NULL),
	(114, 'N ', 12, 'Kimia', '-', '', 39000.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(115, 'P', 12, 'Kimia', '-', '', 18000.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(116, 'K', 12, 'Kimia', '-', '', 19000.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(117, 'Ca', 12, 'Kimia', '-', '', 15000.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(118, 'Mg', 12, 'Kimia', '-', '', 15000.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(119, 'S', 12, 'Kimia', '-', '', 18000.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(120, 'Si', 12, 'Kimia', '-', '', 105000.00, 'Tersedia', 'General', 7, '0', NULL, NULL, NULL, NULL),
	(121, 'Zn', 12, 'Kimia', '-', '', 19000.00, 'Tersedia', 'General', 8, '0', NULL, NULL, NULL, NULL),
	(122, 'B', 12, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 9, '0', NULL, NULL, NULL, NULL),
	(123, 'Mn', 12, 'Kimia', '-', '', 19000.00, 'Tersedia', 'General', 10, '0', NULL, NULL, NULL, NULL),
	(124, 'Cu', 12, 'Kimia', '-', '', 19000.00, 'Tersedia', 'General', 11, '0', NULL, NULL, NULL, NULL),
	(125, 'Mo', 12, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 12, '0', NULL, NULL, NULL, NULL),
	(126, 'Co', 12, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 13, '0', NULL, NULL, NULL, NULL),
	(127, 'Fe', 12, 'Kimia', '-', '', 19000.00, 'Tersedia', 'General', 14, '0', NULL, NULL, NULL, NULL),
	(128, 'Pb', 12, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 15, '1', NULL, NULL, NULL, NULL),
	(129, 'Cd', 12, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 16, '1', NULL, NULL, NULL, NULL),
	(130, 'Hg', 12, 'Kimia', '-', '', 70000.00, 'Tersedia', 'General', 17, '1', NULL, NULL, NULL, NULL),
	(131, 'As', 12, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 18, '1', NULL, NULL, NULL, NULL),
	(132, 'Bakteri(Rhizobium/Bradyrhizobium/Azospirillum)', 16, 'Kimia', 'cfu/g atau cfu/ml', '', 150000.00, 'Tersedia', 'Total Sel Hidup', 1, '0', NULL, NULL, NULL, NULL),
	(133, 'Lainnya', 16, 'Kimia', 'cfu/g atau cfu/ml', '', 125000.00, 'Tersedia', 'Total Sel Hidup', 1, '0', NULL, NULL, NULL, NULL),
	(134, 'Actinomicet ', 16, 'Kimia', 'cfu/g atau cfu/ml', '', 125000.00, 'Tersedia', 'Total Sel Hidup', 1, '0', NULL, NULL, NULL, NULL),
	(135, 'Fungi', 16, 'Kimia', '-', '', 125000.00, 'Tersedia', 'Total Sel Hidup', 1, '0', NULL, NULL, NULL, NULL),
	(136, 'Penambat N', 16, 'Kimia', '-', '', 125000.00, 'Tersedia', 'Uji Fungsional  ', 2, '1', NULL, NULL, NULL, NULL),
	(137, 'Pelarut P', 16, 'Kimia', '-', '', 125000.00, 'Tersedia', 'Uji Fungsional', 2, '1', NULL, NULL, NULL, NULL),
	(138, 'Pelarut unsur hara lain', 16, 'Kimia', '-', '', 125000.00, 'Tersedia', 'Uji Fungsional', 2, '1', NULL, NULL, NULL, NULL),
	(139, 'Perombak bahan organik', 16, 'Kimia', '-', '', 125000.00, 'Tersedia', 'Uji Fungsional', 2, '1', NULL, NULL, NULL, NULL),
	(140, 'Pembentuk bintil akar', 16, 'Kimia', '-', '', 150000.00, 'Tersedia', 'Uji Fungsional', 2, '1', NULL, NULL, NULL, NULL),
	(141, 'Patogenitas pada tanaman', 16, 'Kimia', '-', '', 150000.00, 'Tersedia', 'General', 3, '1', NULL, NULL, NULL, NULL),
	(142, 'E.coli', 16, 'Kimia', '-', '', 150000.00, 'Tersedia', 'General', 4, '1', NULL, NULL, NULL, NULL),
	(143, 'Salmonella sp', 16, 'Kimia', 'cfu atau MPN/g atau ml', '', 150000.00, 'Tersedia', 'General', 4, '1', NULL, NULL, NULL, NULL),
	(144, 'As', 16, 'Kimia', 'cfu atau MPN/g atau ml', '', 70000.00, 'Tersedia', 'Logam berat ', 5, '0', NULL, NULL, NULL, NULL),
	(145, 'Hg', 16, 'Kimia', 'ppm', '', 70000.00, 'Tersedia', 'Logam berat ', 5, '0', NULL, NULL, NULL, NULL),
	(146, 'Pb', 16, 'Kimia', 'ppm', '', 35000.00, 'Tersedia', 'Logam berat ', 5, '0', NULL, NULL, NULL, NULL),
	(147, 'Cd', 16, 'Kimia', 'ppm', '', 35000.00, 'Tersedia', 'Logam berat ', 5, '0', NULL, NULL, NULL, NULL),
	(148, 'Cr', 16, 'Kimia', 'ppm', '', 35000.00, 'Tersedia', 'Logam berat ', 5, '0', NULL, NULL, NULL, NULL),
	(149, 'Ni', 16, 'Kimia', 'ppm', '', 35000.00, 'Tersedia', 'Logam berat ', 5, '0', NULL, NULL, NULL, NULL),
	(150, 'Jumlah propagul hidup', 17, 'Kimia', 'cfu/g bobot kering contoh', '', 0.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(151, 'Infeksi pada akar tanaman jagung (%) dengan Pewarnaan Fuchsin', 17, 'Kimia', '%', '', 0.00, 'Tersedia', 'Fungsional:', 2, '0', NULL, NULL, NULL, NULL),
	(152, 'E.coli', 17, 'Kimia', 'cfu atau MPN/g', '', 0.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(153, 'Salmonella sp.', 17, 'Kimia', 'cfu atau MPN/g', '', 0.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(154, 'As', 17, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat ', 4, '0', NULL, NULL, NULL, NULL),
	(155, 'Hg', 17, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat ', 4, '0', NULL, NULL, NULL, NULL),
	(156, 'Pb', 17, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 4, '0', NULL, NULL, NULL, NULL),
	(157, 'Cd', 17, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 4, '0', NULL, NULL, NULL, NULL),
	(158, 'Cr', 17, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 4, '0', NULL, NULL, NULL, NULL),
	(159, 'Ni', 17, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 4, '0', NULL, NULL, NULL, NULL),
	(160, 'Total Fungi (Genus)', 18, 'Kimia', 'cfu/g bobot kering contoh', '', 0.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(161, 'E.coli', 18, 'Kimia', 'cfu atau MPN/g', '', 0.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(162, 'Salmonella sp.', 18, 'Kimia', 'cfu atau MPN/g', '', 0.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(163, 'As', 18, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat:', 3, '0', NULL, NULL, NULL, NULL),
	(164, 'Hg', 18, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat:', 3, '0', NULL, NULL, NULL, NULL),
	(165, 'Pb', 18, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat:', 3, '0', NULL, NULL, NULL, NULL),
	(166, 'Cd', 18, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat:', 3, '0', NULL, NULL, NULL, NULL),
	(167, 'Cr', 18, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat:', 3, '0', NULL, NULL, NULL, NULL),
	(168, 'Ni', 18, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat:', 3, '0', NULL, NULL, NULL, NULL),
	(169, 'Bakteri Rhizobium/Bradyrhizobium/Azospirillum', 19, 'Kimia', 'Cfu/g bobot kering contoh', '', 150000.00, 'Tersedia', 'Genus pertama', 1, '0', NULL, NULL, NULL, NULL),
	(170, 'Lainnya', 19, 'Kimia', 'Cfu/g bobot kering contoh', '', 125000.00, 'Tersedia', 'Genus pertama', 1, '0', NULL, NULL, NULL, NULL),
	(171, 'Aktinomesets', 19, 'Kimia', 'Cfu/g bobot kering contoh', '', 125000.00, 'Tersedia', 'Genus pertama', 1, '0', NULL, NULL, NULL, NULL),
	(172, 'Fungi:', 19, 'Kimia', 'Cfu/g bobot kering contoh', '', 125000.00, 'Tersedia', 'Genus pertama', 1, '0', NULL, NULL, NULL, NULL),
	(173, 'Bakteri (sebutkan genusnya):Rhizobium/Bradyrhizobium/Azospirillum', 19, 'Kimia', 'Cfu/g bobot kering contoh', '', 150000.00, 'Tersedia', 'Genus kedua ', 2, '0', NULL, NULL, NULL, NULL),
	(174, 'Lainnya', 19, 'Kimia', 'Cfu/g bobot kering contoh', '', 125000.00, 'Tersedia', 'Genus kedua', 2, '0', NULL, NULL, NULL, NULL),
	(175, 'Aktinomecets', 19, 'Kimia', 'Cfu/g bobot kering contoh', '', 125000.00, 'Tersedia', 'Genus kedua', 2, '0', NULL, NULL, NULL, NULL),
	(176, 'Fungi', 19, 'Kimia', 'Cfu/g bobot kering contoh', '', 125000.00, 'Tersedia', 'Genus kedua', 2, '0', NULL, NULL, NULL, NULL),
	(177, 'Penambat N', 19, 'Kimia', 'Positif', '', 125000.00, 'Tersedia', 'Uji Fungsional ', 2, '1', NULL, NULL, NULL, NULL),
	(178, 'Pelarut P', 19, 'Kimia', 'Positif', '', 125000.00, 'Tersedia', 'Uji Fungsional ', 2, '1', NULL, NULL, NULL, NULL),
	(179, 'Pelarut unsur hara lain', 19, 'Kimia', 'Positif', '', 125000.00, 'Tersedia', 'Uji Fungsional 2', 2, '1', NULL, NULL, NULL, NULL),
	(180, 'Perombak bahan organik', 19, 'Kimia', 'Positif', '', 125000.00, 'Tersedia', 'Uji Fungsional', 2, '1', NULL, NULL, NULL, NULL),
	(181, 'Pembentuk bintil akar', 19, 'Kimia', 'Positif', '', 125000.00, 'Tersedia', 'Uji Fungsional', 2, '1', NULL, NULL, NULL, NULL),
	(182, 'Patogenitas pada tanaman', 19, 'Kimia', 'Negatif', '', 150000.00, 'Tersedia', 'Uji Fungsional', 2, '1', NULL, NULL, NULL, NULL),
	(183, 'E.Coli', 19, 'Kimia', 'Cfu atau MPN/g atau ml', '', 150000.00, 'Tersedia', 'General', 2, '1', NULL, NULL, NULL, NULL),
	(184, 'Salmonella sp', 19, 'Kimia', 'Cfu atau MPN/g atau ml', '', 150000.00, 'Tersedia', 'General', 2, '1', NULL, NULL, NULL, NULL),
	(185, 'As', 19, 'Kimia', 'ppm', '', 70000.00, 'Tersedia', 'Logam berat', 2, '0', NULL, NULL, NULL, NULL),
	(186, 'Hg', 19, 'Kimia', 'ppm', '', 70000.00, 'Tersedia', 'Logam berat', 2, '0', NULL, NULL, NULL, NULL),
	(187, 'Pb', 19, 'Kimia', 'ppm', '', 35000.00, 'Tersedia', 'Logam berat', 2, '0', NULL, NULL, NULL, NULL),
	(188, 'Cd', 19, 'Kimia', 'ppm', '', 35000.00, 'Tersedia', 'Logam berat', 2, '0', NULL, NULL, NULL, NULL),
	(189, 'Cr', 19, 'Kimia', 'ppm', '', 35000.00, 'Tersedia', 'Logam berat', 2, '0', NULL, NULL, NULL, NULL),
	(190, 'Ni', 19, 'Kimia', 'ppm', '', 35000.00, 'Tersedia', 'Logam berat', 2, '0', NULL, NULL, NULL, NULL),
	(191, 'Bakteri', 20, 'Kimia', 'Cfu/g bobot kering contoh', '', 150000.00, 'Tersedia', 'Genus pertama ', 1, '0', NULL, NULL, NULL, NULL),
	(192, 'Lainnya', 20, 'Kimia', 'Cfu/g bobot kering contoh', '', 125000.00, 'Tersedia', 'Genus pertama ', 1, '0', NULL, NULL, NULL, NULL),
	(193, 'Aktinomiset:', 20, 'Kimia', 'Cfu/g bobot kering contoh', '', 125000.00, 'Tersedia', 'Genus pertama ', 1, '0', NULL, NULL, NULL, NULL),
	(194, 'Fungi:', 20, 'Kimia', 'Cfu/g bobot kering contoh', '', 125000.00, 'Tersedia', 'Genus pertama ', 1, '0', NULL, NULL, NULL, NULL),
	(195, 'Bakteri ', 20, 'Kimia', 'Cfu/g bobot kering contoh', '', 150000.00, 'Tersedia', 'Genus kedua ', 2, '0', NULL, NULL, NULL, NULL),
	(196, 'Lainnya', 20, 'Kimia', 'Cfu/g bobot kering contoh', '', 125000.00, 'Tersedia', 'Genus kedua ', 2, '0', NULL, NULL, NULL, NULL),
	(197, 'Aktinomiset:', 20, 'Kimia', 'Cfu/g bobot kering contoh', '', 125000.00, 'Tersedia', 'Genus kedua ', 2, '0', NULL, NULL, NULL, NULL),
	(198, 'Fungi:', 20, 'Kimia', 'Cfu/g bobot kering contoh', '', 125000.00, 'Tersedia', 'Genus kedua ', 2, '0', NULL, NULL, NULL, NULL),
	(199, 'Penambat N', 20, 'Kimia', 'Positif', '', 125000.00, 'Tersedia', 'Uji Fungsional ', 2, '1', NULL, NULL, NULL, NULL),
	(200, 'Pelarut P', 20, 'Kimia', 'Positif', '', 125000.00, 'Tersedia', 'Uji Fungsional ', 2, '1', NULL, NULL, NULL, NULL),
	(201, 'Pelarut unsur hara lain', 20, 'Kimia', 'Positif', '', 125000.00, 'Tersedia', 'Uji Fungsional ', 2, '1', NULL, NULL, NULL, NULL),
	(202, 'Perombak bahan organik', 20, 'Kimia', 'Positif', '', 125000.00, 'Tersedia', 'Uji Fungsional ', 2, '1', NULL, NULL, NULL, NULL),
	(203, 'Pembentuk bintil akar', 20, 'Kimia', 'Positif', '', 125000.00, 'Tersedia', 'Uji Fungsional ', 2, '1', NULL, NULL, NULL, NULL),
	(204, 'Patogenitas pada tanaman', 20, 'Kimia', 'Negatif', '', 150000.00, 'Tersedia', 'Uji Fungsional ', 2, '1', NULL, NULL, NULL, NULL),
	(205, 'E.Coli', 20, 'Kimia', 'Cfu atau MPN/g atau ml', '', 150000.00, 'Tersedia', 'Uji Fungsional', 2, '1', NULL, NULL, NULL, NULL),
	(206, 'Salmonella sp', 20, 'Kimia', 'Cfu atau MPN/g atau ml', '', 150000.00, 'Tersedia', 'Uji Fungsional', 2, '1', NULL, NULL, NULL, NULL),
	(207, 'C-organik', 13, 'Kimia', '%', '', 0.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(208, 'C/N', 13, 'Kimia', '-', '', 0.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(209, 'Bahan ikutan (beling/pecahan kaca, lastic, kerikil, dan logam)', 13, 'Kimia', '%', '', 0.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(210, 'Kadar air', 13, 'Kimia', '%', '', 0.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(211, 'pH', 13, 'Kimia', '-', '', 0.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(212, 'Hara makro (N+P2O5+K2O)', 13, 'Kimia', '%', '', 0.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(213, 'Hg', 13, 'Kimia', 'mg/kg', '', 0.00, 'Tersedia', 'Logam berat', 7, '0', NULL, NULL, NULL, NULL),
	(214, 'Pb', 13, 'Kimia', 'mg/kg', '', 0.00, 'Tersedia', 'Logam berat', 7, '0', NULL, NULL, NULL, NULL),
	(215, 'Cd', 13, 'Kimia', 'mg/kg', '', 0.00, 'Tersedia', 'Logam berat', 7, '0', NULL, NULL, NULL, NULL),
	(216, 'As', 13, 'Kimia', 'mg/kg', '', 0.00, 'Tersedia', 'Logam berat', 7, '0', NULL, NULL, NULL, NULL),
	(217, 'Cr', 13, 'Kimia', 'mg/kg', '', 0.00, 'Tersedia', 'Logam berat', 7, '0', NULL, NULL, NULL, NULL),
	(218, 'Ni', 13, 'Kimia', 'mg/kg', '', 0.00, 'Tersedia', 'Logam berat', 7, '0', NULL, NULL, NULL, NULL),
	(219, 'Fe total', 13, 'Kimia', 'mg/kg', '', 0.00, 'Tersedia', 'Hara mikro', 8, '0', NULL, NULL, NULL, NULL),
	(220, 'Fe tersedia', 13, 'Kimia', 'mg/kg', '', 0.00, 'Tersedia', 'Hara mikro', 8, '0', NULL, NULL, NULL, NULL),
	(221, 'Zn total', 13, 'Kimia', 'mg/kg', '', 0.00, 'Tersedia', 'Hara mikro', 8, '0', NULL, NULL, NULL, NULL),
	(222, 'Ukuran butir (2 – 4,75) mm***', 13, 'Kimia', '%', '', 0.00, 'Tersedia', 'Hara mikro', 8, '0', NULL, NULL, NULL, NULL),
	(223, 'E-coli', 13, 'Kimia', 'MPN/g', '', 0.00, 'Tersedia', 'Cemaran mikroba', 9, '0', NULL, NULL, NULL, NULL),
	(224, 'C-organik', 14, 'Kimia', '%', '', 0.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(225, 'C/N', 14, 'Kimia', '-', '', 0.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(226, 'Kadar air', 14, 'Kimia', '% (w/w)', '', 0.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(227, 'Hara makro (N+P2O5+K2O)', 14, 'Kimia', '%', '', 0.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(228, 'Fe total', 14, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Hara mikro', 5, '0', NULL, NULL, NULL, NULL),
	(229, 'Fe tersedia', 14, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Hara mikro', 5, '0', NULL, NULL, NULL, NULL),
	(230, 'Zn total', 14, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Hara mikro', 5, '0', NULL, NULL, NULL, NULL),
	(231, 'pH', 14, 'Kimia', '-', '', 0.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(232, 'Salmonella sp', 14, 'Kimia', 'cfu/g atau MPN/g', '', 0.00, 'Tersedia', 'General', 7, '0', NULL, NULL, NULL, NULL),
	(233, 'Mikroba Fungsional***', 14, 'Kimia', 'cfu/g', '', 0.00, 'Tersedia', 'General', 8, '0', NULL, NULL, NULL, NULL),
	(234, 'As', 14, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 9, '0', NULL, NULL, NULL, NULL),
	(235, 'Hg', 14, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 9, '0', NULL, NULL, NULL, NULL),
	(236, 'Pb', 14, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 9, '0', NULL, NULL, NULL, NULL),
	(237, 'Cd', 14, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 9, '0', NULL, NULL, NULL, NULL),
	(238, 'Cr', 14, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 9, '0', NULL, NULL, NULL, NULL),
	(239, 'Ni', 14, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 9, '0', NULL, NULL, NULL, NULL),
	(240, 'Ukuran butir (2 – 4,75) mm****', 14, 'Kimia', '%', '', 0.00, 'Tersedia', 'General', 10, '0', NULL, NULL, NULL, NULL),
	(241, 'Bahan ikutan (plastik, kaca, kerikil)', 14, 'Kimia', '%', '', 0.00, 'Tersedia', 'General', 11, '0', NULL, NULL, NULL, NULL),
	(242, 'Na', 14, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Unsur /senyawa lain', 12, '0', NULL, NULL, NULL, NULL),
	(243, 'Cl', 14, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Unsur /senyawa lain', 12, '0', NULL, NULL, NULL, NULL),
	(244, 'C-organik', 15, 'Kimia', '% (w/v)', '', 0.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(245, 'Hara makro (N+P2O5+K2O)', 15, 'Kimia', '% (w/v)', '', 0.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(246, 'N-organik', 15, 'Kimia', '% (w/v)', '', 0.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(247, 'Fe total', 15, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Hara mikro***', 4, '0', NULL, NULL, NULL, NULL),
	(248, 'Mn total', 15, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Hara mikro***', 4, '0', NULL, NULL, NULL, NULL),
	(249, 'Cu total', 15, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Hara mikro***', 4, '0', NULL, NULL, NULL, NULL),
	(250, 'Zn total', 15, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Hara mikro***', 4, '0', NULL, NULL, NULL, NULL),
	(251, 'B total', 15, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Hara mikro***', 4, '0', NULL, NULL, NULL, NULL),
	(252, 'Mo total', 15, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Hara mikro***', 4, '0', NULL, NULL, NULL, NULL),
	(253, 'E.coli', 14, 'Kimia', 'cfu/g atau MPN/g', '', 0.00, 'Tersedia', 'General', 7, '0', NULL, NULL, NULL, NULL),
	(254, 'pH', 15, 'Kimia', '-', '', 0.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(255, 'E.coli', 15, 'Kimia', 'cfu/g atau MPN/g', '', 0.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(256, 'Salmonella sp', 15, 'Kimia', 'cfu/g atau MPN/g', '', 0.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(257, 'As', 15, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 7, '0', NULL, NULL, NULL, NULL),
	(258, 'Hg', 15, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 7, '0', NULL, NULL, NULL, NULL),
	(259, 'Pb', 15, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 7, '0', NULL, NULL, NULL, NULL),
	(260, 'Cd', 15, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 7, '0', NULL, NULL, NULL, NULL),
	(261, 'Cr', 15, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 7, '0', NULL, NULL, NULL, NULL),
	(262, 'Ni', 15, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Logam berat', 7, '0', NULL, NULL, NULL, NULL),
	(263, 'Na', 15, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Unsur /senyawa lain', 8, '0', NULL, NULL, NULL, NULL),
	(264, 'Cl', 15, 'Kimia', 'ppm', '', 0.00, 'Tersedia', 'Unsur /senyawa lain', 8, '0', NULL, NULL, NULL, NULL),
	(265, 'Persiapan contoh ', 21, 'Kimia', '-', '', 18000.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(266, 'Tekstur 3 Fraksi (pasir, debu dan liat)', 21, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(267, 'pH - H2O dan KCl 1 M', 21, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(268, 'C- Organik', 21, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(269, 'N- Kjeldahl', 21, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(270, 'P-tersedia (Olsen atau Bray) (Ekstraksi Rp 18.000,-, ukur Rp 12.000,-)', 21, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(271, 'K-tersedia (Morgan)  (Ekstraksi Rp 18.000,-, ukur Rp 12.000,-)', 21, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 7, '0', NULL, NULL, NULL, NULL),
	(272, 'P dan K- Potensial (HCl 25%) (ekstraksi Rp 18.000,- Ukur K Rp 12.000,- dan P masing-masing Rp 18.000,-)', 21, 'Kimia', '-', '', 48000.00, 'Tersedia', 'General', 8, '0', NULL, NULL, NULL, NULL),
	(273, 'Kapasitas Tukar Kation (KTK) (ekstraksi Rp 24.000,- ukur Rp 18.000,-)', 21, 'Kimia', '-', '', 42000.00, 'Tersedia', 'General', 9, '0', NULL, NULL, NULL, NULL),
	(274, 'Kation dapat tukar (K, Na, Ca, Mg-dd) (ekstraksi Rp 18.000,- ukur K, Na Rp 12.000,- ukur Ca, Mg Rp 18.000,-)', 21, 'Kimia', '-', '', 78000.00, 'Tersedia', 'General', 10, '0', NULL, NULL, NULL, NULL),
	(275, 'Kemasaman dapat tukar (Al dan H - dd) / (ekstraksi Rp 12.000,- ukur Al dan H-dd Rp 24.000 ,-)', 21, 'Kimia', '-', '', 60000.00, 'Tersedia', 'General', 11, '0', NULL, NULL, NULL, NULL),
	(276, 'Persiapan sampel', 22, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 1, '0', NULL, NULL, NULL, NULL),
	(277, 'pH – NaF', 22, 'Kimia', '-', '', 18000.00, 'Tersedia', 'General', 2, '0', NULL, NULL, NULL, NULL),
	(278, 'CaCO3 .', 22, 'Kimia', '-', '', 18000.00, 'Tersedia', 'General', 3, '0', NULL, NULL, NULL, NULL),
	(279, 'CaSO4 (Gips) .', 22, 'Kimia', '-', '', 18000.00, 'Tersedia', 'General', 4, '0', NULL, NULL, NULL, NULL),
	(280, 'Salinitas / EC (DHL) ', 22, 'Kimia', '-', '', 12000.00, 'Tersedia', 'General', 5, '0', NULL, NULL, NULL, NULL),
	(281, 'Redoks ', 22, 'Kimia', '-', '', 18000.00, 'Tersedia', 'General', 6, '0', NULL, NULL, NULL, NULL),
	(282, 'Keasaman terekstrak (BaCl2-TEA) .', 22, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 7, '0', NULL, NULL, NULL, NULL),
	(283, 'P-Retensi (Ekstraksi Rp 12.000,- Pengukuran P Rp 18.000,-)', 22, 'Kimia', '-', '', 30000.00, 'Tersedia', 'General', 8, '0', NULL, NULL, NULL, NULL),
	(284, 'P-Sorption', 22, 'Kimia', '-', '', 108000.00, 'Tersedia', 'General', 9, '0', NULL, NULL, NULL, NULL),
	(285, 'P-CaCl2 0,01 M', 22, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 10, '0', NULL, NULL, NULL, NULL);
/*!40000 ALTER TABLE `elementservicestbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.employeetbl
DROP TABLE IF EXISTS `employeetbl`;
CREATE TABLE IF NOT EXISTS `employeetbl` (
  `employeeNo` int(11) NOT NULL AUTO_INCREMENT,
  `employeeName` varchar(255) DEFAULT NULL,
  `position` varchar(255) DEFAULT NULL,
  `employeeEmail` varchar(255) DEFAULT NULL,
  `derivativeToEmployee` int(11) DEFAULT NULL,
  `accountNo` int(11) DEFAULT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`employeeNo`),
  KEY `EmployeeTblAccountTbl` (`accountNo`),
  CONSTRAINT `EmployeeTblAccountTbl` FOREIGN KEY (`accountNo`) REFERENCES `accounttbl` (`accountNo`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.employeetbl: ~9 rows (approximately)
DELETE FROM `employeetbl`;
/*!40000 ALTER TABLE `employeetbl` DISABLE KEYS */;
INSERT INTO `employeetbl` (`employeeNo`, `employeeName`, `position`, `employeeEmail`, `derivativeToEmployee`, `accountNo`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	(2, 'Sarahh', 'Kimia', 'testpenyelia@gmail.com', -1, 1120, '', '2019-08-26 13:03:55', '', '2019-08-30 16:31:26'),
	(3, '12212', 'Fisika', '123@gmail', -1, 1120, '', '2019-08-27 16:55:39', NULL, NULL),
	(9, 'anabele', 'manajer teknis', 'manager1@gmail.com', -1, 1161, '', '2019-09-02 09:59:02', NULL, NULL),
	(10, 'analis1', 'customer service', 'analis1@gmail.com', 9, 1162, '', '2019-09-02 10:00:38', NULL, NULL),
	(11, 'evaluator1', 'evaluator', 'evaluator1@gmail.com', 9, 1163, '', '2019-09-02 10:05:33', NULL, NULL),
	(12, 'kasir1', 'kasir', 'kasir1@gmail.com', -1, 1164, '', '2019-09-02 10:07:19', '', '2019-09-02 10:07:32'),
	(13, 'cs1', 'customer service', 'cs1@gmail.com', -1, 1165, '', '2019-09-02 10:08:26', NULL, NULL),
	(14, 'penyelia1', 'penyelia', 'penyelia1@gmail.com', 9, 1166, '', '2019-09-02 10:45:19', NULL, NULL),
	(15, 'penyelia2', 'penyelia', 'penyelia2@gmail.com', 9, 1167, NULL, NULL, NULL, NULL);
/*!40000 ALTER TABLE `employeetbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.logtbl
DROP TABLE IF EXISTS `logtbl`;
CREATE TABLE IF NOT EXISTS `logtbl` (
  `logId` int(11) NOT NULL AUTO_INCREMENT,
  `source` varchar(255) DEFAULT NULL,
  `description` text,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  PRIMARY KEY (`logId`)
) ENGINE=InnoDB AUTO_INCREMENT=319 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.logtbl: ~318 rows (approximately)
DELETE FROM `logtbl`;
/*!40000 ALTER TABLE `logtbl` DISABLE KEYS */;
INSERT INTO `logtbl` (`logId`, `source`, `description`, `creaBy`, `creaDate`) VALUES
	(1, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 14:31:30'),
	(2, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 14:46:03'),
	(3, 'ASP.pages_public_login_aspx', 'Login error:Unable to read data from the transport connection: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.', 'anonymous', '2019-09-10 14:47:00'),
	(4, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 14:47:31'),
	(5, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 14:55:48'),
	(6, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 14:55:49'),
	(7, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 14:55:55'),
	(8, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 14:55:58'),
	(9, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 15:10:19'),
	(10, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 15:11:04'),
	(11, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 15:11:04'),
	(12, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 15:11:09'),
	(13, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 15:11:09'),
	(14, 'OrderDetailControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 15:11:13'),
	(15, 'SampleControls', 'The underlying provider failed on Open.', '', '2019-09-10 15:10:58'),
	(16, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 15:11:35'),
	(17, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 15:11:38'),
	(18, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 15:19:42'),
	(19, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 15:20:07'),
	(20, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 15:36:26'),
	(21, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 15:37:42'),
	(22, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 15:40:51'),
	(23, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-10 15:42:11'),
	(24, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 07:27:36'),
	(25, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 07:28:01'),
	(26, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 09:14:23'),
	(27, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 09:14:43'),
	(28, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 09:37:26'),
	(29, 'PesananCustomerControls', 'An error occurred while executing the command definition. See the inner exception for details.', 'anna@gmail.com', '2019-09-11 09:39:22'),
	(30, 'PesananCustomerControls', 'An error occurred while executing the command definition. See the inner exception for details.', 'anna@gmail.com', '2019-09-11 09:39:28'),
	(31, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 10:15:39'),
	(32, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 10:15:39'),
	(33, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 10:38:52'),
	(34, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 10:38:52'),
	(35, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 10:42:11'),
	(36, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 10:42:46'),
	(37, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 10:42:56'),
	(38, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 10:58:21'),
	(39, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 10:58:21'),
	(40, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 11:07:26'),
	(41, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 11:09:36'),
	(42, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 11:09:53'),
	(43, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 11:09:56'),
	(44, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 11:10:00'),
	(45, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 11:10:54'),
	(46, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 11:11:11'),
	(47, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 11:11:20'),
	(48, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 11:11:22'),
	(49, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 11:58:55'),
	(50, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 14:33:43'),
	(51, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 15:54:50'),
	(52, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 15:54:56'),
	(53, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 15:55:01'),
	(54, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 15:55:05'),
	(55, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 19:50:05'),
	(56, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 19:50:21'),
	(57, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 19:50:28'),
	(58, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 19:50:36'),
	(59, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 19:50:38'),
	(60, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 19:50:39'),
	(61, 'PesananCustomerControls', 'An error occurred while executing the command definition. See the inner exception for details.', 'galihyprtm@gmail.com', '2019-09-11 20:00:38'),
	(62, 'PesananCustomerControls', 'An error occurred while executing the command definition. See the inner exception for details.', 'galihyprtm@gmail.com', '2019-09-11 20:00:57'),
	(63, 'PesananCustomerControls', 'An error occurred while executing the command definition. See the inner exception for details.', 'galihyprtm@gmail.com', '2019-09-11 20:14:34'),
	(64, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 20:23:03'),
	(65, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 21:02:13'),
	(66, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 21:34:56'),
	(67, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 21:35:00'),
	(68, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 21:35:05'),
	(69, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 21:46:45'),
	(70, 'PesananCustomerControls', 'An error occurred while executing the command definition. See the inner exception for details.', 'anna@gmail.com', '2019-09-11 21:47:03'),
	(71, 'PesananCustomerControls', 'An error occurred while executing the command definition. See the inner exception for details.', 'anna@gmail.com', '2019-09-11 21:47:23'),
	(72, 'PesananCustomerControls', 'An error occurred while executing the command definition. See the inner exception for details.', 'anna@gmail.com', '2019-09-11 21:47:29'),
	(73, 'PesananCustomerControls', 'An error occurred while executing the command definition. See the inner exception for details.', 'anna@gmail.com', '2019-09-11 21:47:33'),
	(74, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 21:49:48'),
	(75, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 21:49:58'),
	(76, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 21:50:01'),
	(77, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-11 21:50:06'),
	(78, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-11 23:04:48'),
	(79, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-11 23:29:48'),
	(80, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-11 23:36:15'),
	(81, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-11 23:36:31'),
	(82, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-11 23:56:33'),
	(83, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-11 23:57:05'),
	(84, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-11 23:57:27'),
	(85, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-11 23:59:27'),
	(86, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-11 23:59:41'),
	(87, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-11 23:59:53'),
	(88, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-12 00:00:26'),
	(89, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-12 00:01:13'),
	(90, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-12 00:02:14'),
	(91, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-12 00:08:42'),
	(92, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-12 00:09:07'),
	(93, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-12 00:11:40'),
	(94, 'SampleControls', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordersampletbl\' does not declare a navigation property with the name \'customertbl\'.', '', '2019-09-12 06:08:11'),
	(95, 'SampleControls', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordersampletbl\' does not declare a navigation property with the name \'customertbl\'.', '', '2019-09-12 06:10:12'),
	(96, 'SampleControls', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordersampletbl\' does not declare a navigation property with the name \'customertbl\'.', '', '2019-09-12 06:13:11'),
	(97, 'SampleControls', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordersampletbl\' does not declare a navigation property with the name \'customertbl\'.', '', '2019-09-12 06:19:14'),
	(98, 'SampleControls', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordersampletbl\' does not declare a navigation property with the name \'customertbl\'.', '', '2019-09-12 06:19:21'),
	(99, 'SampleControls', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordersampletbl\' does not declare a navigation property with the name \'customertbl\'.', '', '2019-09-12 06:19:24'),
	(100, 'SampleControls', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordersampletbl\' does not declare a navigation property with the name \'customertbl\'.', '', '2019-09-12 06:19:48'),
	(101, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:27:43'),
	(102, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:27:45'),
	(103, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:27:45'),
	(104, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:27:50'),
	(105, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:27:51'),
	(106, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:27:52'),
	(107, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:27:54'),
	(108, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:27:54'),
	(109, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:27:54'),
	(110, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:30:47'),
	(111, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:30:47'),
	(112, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:30:47'),
	(113, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:35:24'),
	(114, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:35:25'),
	(115, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:35:25'),
	(116, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:38:40'),
	(117, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:38:41'),
	(118, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:38:41'),
	(119, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:50:39'),
	(120, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:50:40'),
	(121, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 06:50:40'),
	(122, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 13:10:31'),
	(123, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 13:10:34'),
	(124, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 13:10:34'),
	(125, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 13:10:48'),
	(126, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 13:10:49'),
	(127, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 13:10:49'),
	(128, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 13:12:19'),
	(129, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 13:14:42'),
	(130, 'PesananCustomerControls', 'An error occurred while updating the entries. See the inner exception for details.', 'anna@gmail.com', '2019-09-12 13:53:13'),
	(131, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-12 14:04:54'),
	(132, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-12 14:06:31'),
	(133, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-12 14:07:40'),
	(134, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-12 14:10:07'),
	(135, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-12 14:12:25'),
	(136, 'OrderMasterControls', 'The underlying provider failed on Open.', '', '2019-09-12 14:54:15'),
	(137, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:48:29'),
	(138, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:48:30'),
	(139, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:48:30'),
	(140, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:49:18'),
	(141, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:49:18'),
	(142, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:49:18'),
	(143, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:49:35'),
	(144, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:49:55'),
	(145, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:54:48'),
	(146, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:55:03'),
	(147, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:55:05'),
	(148, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:55:07'),
	(149, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:55:10'),
	(150, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:55:55'),
	(151, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:56:01'),
	(152, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:56:03'),
	(153, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:56:05'),
	(154, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:57:03'),
	(155, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:57:12'),
	(156, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 15:58:50'),
	(157, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 16:00:26'),
	(158, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 16:01:05'),
	(159, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 16:04:35'),
	(160, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 16:05:13'),
	(161, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 16:06:06'),
	(162, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 16:08:18'),
	(163, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 16:10:24'),
	(164, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 16:10:45'),
	(165, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 16:10:48'),
	(166, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 16:25:26'),
	(167, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 16:25:32'),
	(168, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 17:15:01'),
	(169, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 17:16:05'),
	(170, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 17:16:42'),
	(171, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 17:18:29'),
	(172, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 17:18:43'),
	(173, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 17:18:49'),
	(174, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 17:18:56'),
	(175, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 17:19:41'),
	(176, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 17:23:41'),
	(177, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 17:35:47'),
	(178, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 17:36:38'),
	(179, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 17:36:41'),
	(180, 'SampleControls', 'The underlying provider failed on Open.', '', '2019-09-12 17:37:56'),
	(181, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-12 17:42:55'),
	(182, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 08:51:05'),
	(183, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 08:53:22'),
	(184, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 08:53:32'),
	(185, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 08:56:18'),
	(186, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-13 08:58:17'),
	(187, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-13 09:11:38'),
	(188, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-13 09:14:04'),
	(189, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 09:23:32'),
	(190, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 09:23:32'),
	(191, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 09:24:15'),
	(192, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 09:24:43'),
	(193, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 09:29:55'),
	(194, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 09:34:41'),
	(195, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 09:34:46'),
	(196, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-13 09:55:22'),
	(197, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-13 10:02:01'),
	(198, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 10:30:18'),
	(199, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Object reference not set to an instance of an object.', 'evaluator1@gmail.com', '2019-09-13 10:30:20'),
	(200, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 10:35:23'),
	(201, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Object reference not set to an instance of an object.', 'evaluator1@gmail.com', '2019-09-13 10:35:24'),
	(202, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 11:06:41'),
	(203, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 11:06:50'),
	(204, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 11:22:44'),
	(205, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 11:23:29'),
	(206, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 11:23:36'),
	(207, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 11:23:38'),
	(208, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 11:24:37'),
	(209, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 11:24:42'),
	(210, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 11:24:54'),
	(211, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 11:24:58'),
	(212, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-13 11:25:46'),
	(213, 'ListGridMaster', 'A specified Include path is not valid. The EntityType \'BalitTanahPelayanan.Models.ordermastertbl\' does not declare a navigation property with the name \'ordersampletbl\'.', '', '2019-09-16 10:58:05'),
	(214, 'ListGridMaster', 'The method \'First\' can only be used as a final query operation. Consider using the method \'FirstOrDefault\' in this instance instead.', '', '2019-09-16 11:34:20'),
	(215, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-16 12:21:42'),
	(216, 'ASP.pages_public_registerform_aspx', 'fail to register user:Thread was being aborted.', 'anonymous', '2019-09-16 12:42:15'),
	(217, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-16 14:18:33'),
	(218, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-16 14:21:49'),
	(219, 'PesananCustomerControls', 'An error occurred while updating the entries. See the inner exception for details.', 'anna@gmail.com', '2019-09-16 15:10:35'),
	(220, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-16 16:39:05'),
	(221, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-16 16:39:28'),
	(222, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-16 16:49:57'),
	(223, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-16 16:51:35'),
	(224, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-16 17:02:33'),
	(225, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-16 17:05:44'),
	(226, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-16 17:05:52'),
	(227, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-16 17:06:21'),
	(228, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-16 17:09:51'),
	(229, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-16 17:17:27'),
	(230, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-16 17:21:52'),
	(231, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-17 09:45:20'),
	(232, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-17 09:46:36'),
	(233, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-17 09:47:07'),
	(234, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-17 09:47:22'),
	(235, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-17 09:59:33'),
	(236, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-17 10:07:12'),
	(237, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-17 10:07:14'),
	(238, 'OrderListControls', 'The underlying provider failed on Open.', '', '2019-09-18 09:14:47'),
	(239, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-18 10:41:23'),
	(240, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-18 10:41:39'),
	(241, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-18 10:46:37'),
	(242, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-18 10:48:13'),
	(243, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-18 10:48:58'),
	(244, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-18 10:49:06'),
	(245, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-18 10:51:18'),
	(246, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-18 10:52:31'),
	(247, 'OrderListControls', 'An error occurred while reading from the store provider\'s data reader. See the inner exception for details.', '', '2019-09-18 10:53:57'),
	(248, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-19 09:11:04'),
	(249, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-19 09:11:38'),
	(250, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-19 09:17:13'),
	(251, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-19 09:18:02'),
	(252, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-19 09:34:35'),
	(253, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-19 09:34:58'),
	(254, 'PesananCustomerControls', 'An error occurred while updating the entries. See the inner exception for details.', 'anna@gmail.com', '2019-09-19 10:03:38'),
	(255, 'PesananCustomerControls', 'An error occurred while updating the entries. See the inner exception for details.', 'anna@gmail.com', '2019-09-19 10:03:50'),
	(256, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-22 18:13:51'),
	(257, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-22 18:14:33'),
	(258, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-23 08:42:11'),
	(259, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-23 08:43:26'),
	(260, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-23 08:45:21'),
	(261, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-23 08:45:42'),
	(262, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-23 08:48:29'),
	(263, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-23 08:49:06'),
	(264, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-23 08:50:24'),
	(265, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-23 08:51:00'),
	(266, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-23 13:30:02'),
	(267, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-23 13:33:59'),
	(268, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-23 14:39:42'),
	(269, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-23 14:40:41'),
	(270, 'ASP.pages_private_analis_inputparameter_aspx', 'failed to post input parameter:An error occurred while executing the command definition. See the inner exception for details.', 'analis1@gmail.com', '2019-09-23 14:43:22'),
	(271, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-23 14:46:57'),
	(272, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-23 14:47:37'),
	(273, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-23 14:47:56'),
	(274, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-23 14:49:03'),
	(275, 'ASP.pages_public_login_aspx', 'Login error:Timeout in IO operation', 'anonymous', '2019-09-23 14:50:08'),
	(276, 'ASP.pages_public_login_aspx', 'Login error:The underlying provider failed on Open.', 'anna@gmail.com', '2019-09-24 11:13:15'),
	(277, 'PesananCustomerControls', 'Input string was not in a correct format.', '', '2019-09-24 16:02:16'),
	(278, 'PesananCustomerControls', 'Input string was not in a correct format.', '', '2019-09-24 16:04:46'),
	(279, 'PesananCustomerControls', 'Input string was not in a correct format.', '', '2019-09-24 16:09:17'),
	(280, 'PesananCustomerControls', 'Input string was not in a correct format.', '', '2019-09-24 16:09:20'),
	(281, 'PesananCustomerControls', 'Input string was not in a correct format.', '', '2019-09-24 16:26:07'),
	(282, 'PesananCustomerControls', 'Input string was not in a correct format.', '', '2019-09-24 16:29:53'),
	(283, 'PesananCustomerControls', 'Input string was not in a correct format.', '', '2019-09-24 16:31:31'),
	(284, 'PesananCustomerControls', 'Input string was not in a correct format.', '', '2019-09-24 16:33:17'),
	(285, 'PesananCustomerControls', 'Input string was not in a correct format.', '', '2019-09-24 16:33:22'),
	(286, 'PesananCustomerControls', 'Input string was not in a correct format.', '', '2019-09-24 16:33:52'),
	(287, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-25 08:14:20'),
	(288, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-25 08:15:41'),
	(289, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-25 08:19:11'),
	(290, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-25 08:19:28'),
	(291, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-25 08:20:26'),
	(292, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-25 08:47:52'),
	(293, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-25 08:55:30'),
	(294, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-25 08:57:27'),
	(295, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-25 08:57:29'),
	(296, 'ASP.pages_public_registerform_aspx', 'fail to register user:Thread was being aborted.', 'anonymous', '2019-09-25 08:58:53'),
	(297, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-25 09:01:11'),
	(298, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-25 09:09:33'),
	(299, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-25 09:09:46'),
	(300, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-25 09:09:58'),
	(301, 'ASP.pages_public_registerform_aspx', 'fail to register user:Thread was being aborted.', 'anonymous', '2019-09-25 09:18:59'),
	(302, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-25 09:30:47'),
	(303, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-25 09:31:38'),
	(304, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-25 09:32:53'),
	(305, 'OrderListControls', 'The underlying provider failed on Open.', '', '2019-09-25 09:52:40'),
	(306, 'ListGridMaster', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-09-25 09:59:04'),
	(307, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-25 10:01:26'),
	(308, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-25 10:02:11'),
	(309, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-25 10:02:42'),
	(310, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-09-25 10:02:52'),
	(311, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-25 10:23:20'),
	(312, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-09-25 10:23:49'),
	(313, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-09-25 10:25:10'),
	(314, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-25 10:37:57'),
	(315, 'OrderListControls', 'The underlying provider failed on Open.', '', '2019-09-25 11:21:41'),
	(316, 'OrderListControls', 'The underlying provider failed on Open.', '', '2019-09-25 11:22:04'),
	(317, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-09-25 15:39:19'),
	(318, 'OrderListControls', 'The underlying provider failed on Open.', '', '2019-09-25 15:57:09');
/*!40000 ALTER TABLE `logtbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.mysql_membership
DROP TABLE IF EXISTS `mysql_membership`;
CREATE TABLE IF NOT EXISTS `mysql_membership` (
  `PKID` varchar(36) NOT NULL,
  `Username` varchar(255) NOT NULL,
  `ApplicationName` varchar(255) NOT NULL,
  `Email` varchar(128) DEFAULT NULL,
  `Comment` varchar(255) DEFAULT NULL,
  `Password` varchar(128) NOT NULL,
  `PasswordKey` char(32) DEFAULT NULL,
  `PasswordFormat` tinyint(4) DEFAULT NULL,
  `PasswordQuestion` varchar(255) DEFAULT NULL,
  `PasswordAnswer` varchar(255) DEFAULT NULL,
  `IsApproved` tinyint(1) DEFAULT NULL,
  `LastActivityDate` datetime DEFAULT NULL,
  `LastLoginDate` datetime DEFAULT NULL,
  `LastPasswordChangedDate` datetime DEFAULT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `IsOnline` tinyint(1) DEFAULT NULL,
  `IsLockedOut` tinyint(1) DEFAULT NULL,
  `LastLockedOutDate` datetime DEFAULT NULL,
  `FailedPasswordAttemptCount` int(10) unsigned DEFAULT NULL,
  `FailedPasswordAttemptWindowStart` datetime DEFAULT NULL,
  `FailedPasswordAnswerAttemptCount` int(10) unsigned DEFAULT NULL,
  `FailedPasswordAnswerAttemptWindowStart` datetime DEFAULT NULL,
  PRIMARY KEY (`PKID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='2';

-- Dumping data for table smlpob.mysql_membership: ~0 rows (approximately)
DELETE FROM `mysql_membership`;
/*!40000 ALTER TABLE `mysql_membership` DISABLE KEYS */;
/*!40000 ALTER TABLE `mysql_membership` ENABLE KEYS */;

-- Dumping structure for table smlpob.my_aspnet_applications
DROP TABLE IF EXISTS `my_aspnet_applications`;
CREATE TABLE IF NOT EXISTS `my_aspnet_applications` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(256) DEFAULT NULL,
  `description` varchar(256) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_applications: ~0 rows (approximately)
DELETE FROM `my_aspnet_applications`;
/*!40000 ALTER TABLE `my_aspnet_applications` DISABLE KEYS */;
INSERT INTO `my_aspnet_applications` (`id`, `name`, `description`) VALUES
	(1, 'SILPO', 'MySQL default application');
/*!40000 ALTER TABLE `my_aspnet_applications` ENABLE KEYS */;

-- Dumping structure for table smlpob.my_aspnet_membership
DROP TABLE IF EXISTS `my_aspnet_membership`;
CREATE TABLE IF NOT EXISTS `my_aspnet_membership` (
  `userId` int(11) NOT NULL,
  `Email` varchar(128) DEFAULT NULL,
  `Comment` varchar(255) DEFAULT NULL,
  `Password` varchar(128) NOT NULL,
  `PasswordKey` char(32) DEFAULT NULL,
  `PasswordFormat` tinyint(4) DEFAULT NULL,
  `PasswordQuestion` varchar(255) DEFAULT NULL,
  `PasswordAnswer` varchar(255) DEFAULT NULL,
  `IsApproved` tinyint(1) DEFAULT NULL,
  `LastActivityDate` datetime DEFAULT NULL,
  `LastLoginDate` datetime DEFAULT NULL,
  `LastPasswordChangedDate` datetime DEFAULT NULL,
  `CreationDate` datetime DEFAULT NULL,
  `IsLockedOut` tinyint(1) DEFAULT NULL,
  `LastLockedOutDate` datetime DEFAULT NULL,
  `FailedPasswordAttemptCount` int(10) unsigned DEFAULT NULL,
  `FailedPasswordAttemptWindowStart` datetime DEFAULT NULL,
  `FailedPasswordAnswerAttemptCount` int(10) unsigned DEFAULT NULL,
  `FailedPasswordAnswerAttemptWindowStart` datetime DEFAULT NULL,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='2';

-- Dumping data for table smlpob.my_aspnet_membership: ~28 rows (approximately)
DELETE FROM `my_aspnet_membership`;
/*!40000 ALTER TABLE `my_aspnet_membership` DISABLE KEYS */;
INSERT INTO `my_aspnet_membership` (`userId`, `Email`, `Comment`, `Password`, `PasswordKey`, `PasswordFormat`, `PasswordQuestion`, `PasswordAnswer`, `IsApproved`, `LastActivityDate`, `LastLoginDate`, `LastPasswordChangedDate`, `CreationDate`, `IsLockedOut`, `LastLockedOutDate`, `FailedPasswordAttemptCount`, `FailedPasswordAttemptWindowStart`, `FailedPasswordAnswerAttemptCount`, `FailedPasswordAnswerAttemptWindowStart`) VALUES
	(1, NULL, '', '123qweasd', 'Ye3cjkYgWjH2qs7DJ/xSMw==', 0, NULL, NULL, 1, '2019-08-16 21:41:13', '2019-08-16 21:41:13', '2019-08-16 21:41:13', '2019-08-16 21:41:13', 0, '2019-08-16 21:41:13', 0, '2019-08-16 21:41:13', 0, '2019-08-16 21:41:13'),
	(2, 'zilong@gmail.com', '', '123qweasd', 'ZZG/P08b29f4jh3kCJhmaA==', 0, NULL, NULL, 1, '2019-08-27 15:42:40', '2019-08-27 15:42:34', '2019-08-24 15:40:03', '2019-08-24 15:40:03', 0, '2019-08-27 15:42:33', 0, '2019-08-24 15:40:03', 0, '2019-08-24 15:40:03'),
	(3, 'asep@gmail.com', '', '123qwe', 'ejcHzO1D2JWdK5JO+7NU6g==', 0, NULL, NULL, 1, '2019-09-04 10:32:06', '2019-09-04 10:32:06', '2019-08-24 18:01:22', '2019-08-24 18:01:22', 0, '2019-08-29 10:16:47', 6, '2019-09-11 12:49:03', 0, '2019-08-24 18:01:22'),
	(4, 'ujang@gmail.com', '', '123123', '+k9WpP40JQLhHGfOjmHtVQ==', 0, NULL, NULL, 1, '2019-08-24 18:08:44', '2019-08-24 18:08:44', '2019-08-24 18:08:44', '2019-08-24 18:03:10', 0, '2019-08-29 10:17:16', 1, '2019-08-29 10:17:17', 0, '2019-08-24 18:03:10'),
	(5, 'jeje@gmail.com', '', '123qwe', 'bJzuyXSye7uDmIt1TPJPHw==', 0, NULL, NULL, 1, '2019-08-27 15:12:44', '2019-08-27 15:12:44', '2019-08-24 18:16:01', '2019-08-24 18:16:01', 0, '2019-08-27 15:50:26', 1, '2019-08-27 15:50:28', 0, '2019-08-24 18:16:01'),
	(6, 'anna@gmail.com', '', '123qwe', 'K0ubfarzs4WCaENN4ISGUQ==', 0, NULL, NULL, 1, '2019-09-26 11:49:49', '2019-09-26 11:45:46', '2019-08-24 18:23:18', '2019-08-24 18:23:18', 0, '2019-08-28 08:50:22', 2, '2019-09-26 10:42:45', 0, '2019-08-24 18:23:18'),
	(8, 'testpenyelia@gmail.com', '', '123qwe', 'w8UwUP5hEzq4a4yA7Xl8Pg==', 0, NULL, NULL, 1, '2019-08-26 13:02:46', '2019-08-26 13:02:46', '2019-08-26 13:02:46', '2019-08-26 13:02:46', 0, '2019-08-26 13:02:46', 0, '2019-08-26 13:02:46', 0, '2019-08-26 13:02:46'),
	(31, 'teguh@gmail.com', '', 'asd', 'U3UZhFJr1YUseEhoh7khFg==', 0, NULL, NULL, 1, '2019-09-09 09:08:28', '2019-09-09 09:08:28', '2019-08-28 08:59:58', '2019-08-28 08:59:58', 0, '2019-08-28 09:03:53', 2, '2019-08-28 18:00:13', 0, '2019-08-28 08:59:58'),
	(34, 'mifmasterz@gmail.com', '', 'sOry3;z=', 'HHCRNljlr16isLP7u9N5eg==', 0, NULL, NULL, 1, '2019-08-28 10:54:57', '2019-08-28 10:54:54', '2019-08-28 10:48:09', '2019-08-28 09:48:19', 0, '2019-08-28 10:54:53', 2, '2019-08-28 10:52:10', 0, '2019-08-28 09:48:19'),
	(35, 'mifmasterz@yahoo.com', '', '123qwe', 'DpsknvTeOt4FXS7qne4Pvw==', 0, NULL, NULL, 1, '2019-09-09 11:57:45', '2019-09-09 10:15:04', '2019-08-28 10:12:29', '2019-08-28 10:12:29', 0, '2019-08-29 10:15:48', 6, '2019-09-02 02:48:44', 0, '2019-08-28 10:12:29'),
	(37, 'fariz@gmail.com', '', '123qweasd', 'divGUp0fFvBR4TU0KkXHNA==', 0, NULL, NULL, 1, '2019-08-29 13:40:37', '2019-08-29 13:40:37', '2019-08-29 13:36:37', '2019-08-29 13:36:37', 0, '2019-08-29 13:36:37', 0, '2019-08-29 13:36:37', 0, '2019-08-29 13:36:37'),
	(38, 'mstokev@gmail.com', '', '123qweasd', 'agIVG2BwP3DyZ3MSE/uuWA==', 0, NULL, NULL, 1, '2019-09-11 14:49:48', '2019-09-11 14:49:48', '2019-08-30 14:19:48', '2019-08-30 14:19:48', 0, '2019-08-30 14:19:48', 0, '2019-08-30 14:19:48', 0, '2019-08-30 14:19:48'),
	(39, 'mifmasterz@outlook.com', '', '123qwe', '7OhKLyhxfkZv7npP1yVcQA==', 0, NULL, NULL, 1, '2019-09-02 16:32:33', '2019-09-02 16:32:33', '2019-08-30 12:28:43', '2019-08-30 12:28:43', 0, '2019-08-30 12:29:53', 0, '2019-08-30 12:28:43', 0, '2019-08-30 12:28:43'),
	(40, 'galihyprtm@gmail.com', '', '123qweasd', 'Codi9jv62jQnFay+25uKSg==', 0, NULL, NULL, 1, '2019-09-12 08:06:04', '2019-09-12 01:03:14', '2019-09-02 02:45:21', '2019-09-02 02:45:21', 0, '2019-09-02 02:58:59', 4, '2019-09-03 09:04:19', 0, '2019-09-02 02:45:21'),
	(41, 'manager1@gmail.com', '', '123qweasd', 'U4PgSeRTQnmUgh4dOEv+tQ==', 0, NULL, NULL, 1, '2019-09-26 10:15:23', '2019-09-26 10:15:23', '2019-09-02 02:58:06', '2019-09-02 02:58:06', 0, '2019-09-02 02:58:06', 2, '2019-09-25 08:14:51', 0, '2019-09-02 02:58:06'),
	(42, 'analis1@gmail.com', '', '123qweasd', '4e+6/+eIubtLztJJa+kfqw==', 0, NULL, NULL, 1, '2019-09-26 10:03:09', '2019-09-26 10:03:09', '2019-09-02 02:59:36', '2019-09-02 02:59:36', 0, '2019-09-02 02:59:36', 2, '2019-09-25 08:16:29', 0, '2019-09-02 02:59:36'),
	(43, 'evaluator1@gmail.com', '', '123qweasd', '3M+yKOmFAZT1Cjhudvn4Vg==', 0, NULL, NULL, 1, '2019-09-25 06:01:37', '2019-09-25 06:01:37', '2019-09-02 03:04:32', '2019-09-02 03:04:32', 0, '2019-09-02 03:04:32', 2, '2019-09-16 01:53:48', 0, '2019-09-02 03:04:32'),
	(44, 'kasir1@gmail.com', '', '123qweasd', 'oFSYm2v6u/2C+f/iRt+w0g==', 0, NULL, NULL, 1, '2019-09-26 11:52:58', '2019-09-26 11:52:58', '2019-09-02 03:06:52', '2019-09-02 03:06:52', 0, '2019-09-02 03:06:52', 2, '2019-09-05 16:45:44', 0, '2019-09-02 03:06:52'),
	(45, 'cs1@gmail.com', '', '123qweasd', 'zDlNVErmrU4twWMK1MVeOw==', 0, NULL, NULL, 1, '2019-09-26 10:13:40', '2019-09-26 10:13:40', '2019-09-02 03:07:53', '2019-09-02 03:07:53', 0, '2019-09-02 03:07:53', 2, '2019-09-25 10:20:54', 0, '2019-09-02 03:07:53'),
	(46, 'penyelia1@gmail.com', '', '123qweasd', 'wVaDj6mGAYA7g35Jw6NONA==', 0, NULL, NULL, 1, '2019-09-26 10:13:13', '2019-09-26 10:13:13', '2019-09-02 03:44:53', '2019-09-02 03:44:53', 0, '2019-09-02 03:44:53', 2, '2019-09-16 01:53:43', 0, '2019-09-02 03:44:53'),
	(47, 'guntur.fitrano@mhsw.pnj.ac.id', '', 'asadasa123', 'qDbiAbK8ecMXWL8qWRv1dg==', 0, NULL, NULL, 1, '2019-09-04 06:36:45', '2019-09-04 06:36:45', '2019-09-04 06:36:45', '2019-09-04 06:36:45', 0, '2019-09-04 06:36:45', 0, '2019-09-04 06:36:45', 0, '2019-09-04 06:36:45'),
	(48, 'guntur.fitrano.tik16@mhsw.pnj.ac.id', '', '123qweasd', 'RCwpdVp2qy612GaDKoehDA==', 0, NULL, NULL, 1, '2019-09-09 09:10:13', '2019-09-09 09:10:13', '2019-09-04 06:38:38', '2019-09-04 06:38:38', 0, '2019-09-04 06:38:38', 0, '2019-09-04 06:38:38', 0, '2019-09-04 06:38:38'),
	(49, 'umaraaa234@gmail.com', '', '123qweasd', 'PTU5TpDezF7e2uJp7PHKfg==', 0, NULL, NULL, 1, '2019-09-05 09:16:41', '2019-09-05 09:16:41', '2019-09-04 06:41:57', '2019-09-04 06:41:57', 0, '2019-09-04 06:41:57', 0, '2019-09-04 06:41:57', 0, '2019-09-04 06:41:57'),
	(56, 'teguhprayoga94@gmail.com', '', '123qwe', 'DAXyDz9DWn3u3MWaJ3TukQ==', 0, NULL, NULL, 1, '2019-09-23 14:55:20', '2019-09-23 14:55:20', '2019-09-09 07:49:08', '2019-09-09 07:49:08', 0, '2019-09-09 10:54:22', 2, '2019-09-09 15:11:33', 0, '2019-09-09 07:49:08'),
	(58, 'agriezmann408@gmail.com', '', '123qwe', 'v/Br3vCyksh1O+0QkZUUIQ==', 0, NULL, NULL, 1, '2019-09-12 14:37:07', '2019-09-12 14:33:56', '2019-09-09 08:58:49', '2019-09-09 08:58:49', 0, '2019-09-09 11:08:35', 2, '2019-09-09 09:36:31', 0, '2019-09-09 08:58:49'),
	(59, 'rizkyansyah031398@gmail.com', '', '123qweasd', 'FawX2ueuEWK1OPxfPfVzpQ==', 0, NULL, NULL, 1, '2019-09-16 05:47:42', '2019-09-16 05:43:24', '2019-09-16 05:42:12', '2019-09-16 05:42:12', 0, '2019-09-16 05:42:12', 0, '2019-09-16 05:42:12', 0, '2019-09-16 05:42:12'),
	(60, 'Iwanfals25@gmail.com', '', '123qweasd', '7N+rjhjtiizDzcsxG1wPKA==', 0, NULL, NULL, 1, '2019-09-25 01:59:26', '2019-09-25 01:59:26', '2019-09-25 01:58:51', '2019-09-25 01:58:51', 0, '2019-09-25 01:58:51', 0, '2019-09-25 01:58:51', 0, '2019-09-25 01:58:51'),
	(61, 'dontworry02051998@gmail.com', '', 'aittonyq1910', 'yZMiDwFoeI2+rtvCVBiWrw==', 0, NULL, NULL, 1, '2019-09-26 02:05:01', '2019-09-26 02:05:01', '2019-09-25 02:18:58', '2019-09-25 02:18:58', 0, '2019-09-25 02:33:12', 0, '2019-09-25 02:18:58', 0, '2019-09-25 02:18:58');
/*!40000 ALTER TABLE `my_aspnet_membership` ENABLE KEYS */;

-- Dumping structure for table smlpob.my_aspnet_paths
DROP TABLE IF EXISTS `my_aspnet_paths`;
CREATE TABLE IF NOT EXISTS `my_aspnet_paths` (
  `applicationId` int(11) NOT NULL,
  `pathId` varchar(36) NOT NULL,
  `path` varchar(256) NOT NULL,
  `loweredPath` varchar(256) NOT NULL,
  PRIMARY KEY (`pathId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_paths: ~0 rows (approximately)
DELETE FROM `my_aspnet_paths`;
/*!40000 ALTER TABLE `my_aspnet_paths` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_paths` ENABLE KEYS */;

-- Dumping structure for table smlpob.my_aspnet_personalizationallusers
DROP TABLE IF EXISTS `my_aspnet_personalizationallusers`;
CREATE TABLE IF NOT EXISTS `my_aspnet_personalizationallusers` (
  `pathId` varchar(36) NOT NULL,
  `pageSettings` blob NOT NULL,
  `lastUpdatedDate` datetime NOT NULL,
  PRIMARY KEY (`pathId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_personalizationallusers: ~0 rows (approximately)
DELETE FROM `my_aspnet_personalizationallusers`;
/*!40000 ALTER TABLE `my_aspnet_personalizationallusers` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_personalizationallusers` ENABLE KEYS */;

-- Dumping structure for table smlpob.my_aspnet_personalizationperuser
DROP TABLE IF EXISTS `my_aspnet_personalizationperuser`;
CREATE TABLE IF NOT EXISTS `my_aspnet_personalizationperuser` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `applicationId` int(11) NOT NULL,
  `pathId` varchar(36) DEFAULT NULL,
  `userId` int(11) DEFAULT NULL,
  `pageSettings` blob NOT NULL,
  `lastUpdatedDate` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_personalizationperuser: ~0 rows (approximately)
DELETE FROM `my_aspnet_personalizationperuser`;
/*!40000 ALTER TABLE `my_aspnet_personalizationperuser` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_personalizationperuser` ENABLE KEYS */;

-- Dumping structure for table smlpob.my_aspnet_profiles
DROP TABLE IF EXISTS `my_aspnet_profiles`;
CREATE TABLE IF NOT EXISTS `my_aspnet_profiles` (
  `userId` int(11) NOT NULL,
  `valueindex` longtext,
  `stringdata` longtext,
  `binarydata` longblob,
  `lastUpdatedDate` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`userId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_profiles: ~0 rows (approximately)
DELETE FROM `my_aspnet_profiles`;
/*!40000 ALTER TABLE `my_aspnet_profiles` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_profiles` ENABLE KEYS */;

-- Dumping structure for table smlpob.my_aspnet_roles
DROP TABLE IF EXISTS `my_aspnet_roles`;
CREATE TABLE IF NOT EXISTS `my_aspnet_roles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `applicationId` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_roles: ~6 rows (approximately)
DELETE FROM `my_aspnet_roles`;
/*!40000 ALTER TABLE `my_aspnet_roles` DISABLE KEYS */;
INSERT INTO `my_aspnet_roles` (`id`, `applicationId`, `name`) VALUES
	(1, 1, 'admin'),
	(3, 1, 'pelanggan'),
	(4, 1, 'penyelia'),
	(5, 1, 'manajer teknis'),
	(6, 1, 'evaluator'),
	(7, 1, 'analis');
/*!40000 ALTER TABLE `my_aspnet_roles` ENABLE KEYS */;

-- Dumping structure for table smlpob.my_aspnet_schemaversion
DROP TABLE IF EXISTS `my_aspnet_schemaversion`;
CREATE TABLE IF NOT EXISTS `my_aspnet_schemaversion` (
  `version` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_schemaversion: ~0 rows (approximately)
DELETE FROM `my_aspnet_schemaversion`;
/*!40000 ALTER TABLE `my_aspnet_schemaversion` DISABLE KEYS */;
INSERT INTO `my_aspnet_schemaversion` (`version`) VALUES
	(10);
/*!40000 ALTER TABLE `my_aspnet_schemaversion` ENABLE KEYS */;

-- Dumping structure for table smlpob.my_aspnet_sessioncleanup
DROP TABLE IF EXISTS `my_aspnet_sessioncleanup`;
CREATE TABLE IF NOT EXISTS `my_aspnet_sessioncleanup` (
  `LastRun` datetime NOT NULL,
  `IntervalMinutes` int(11) NOT NULL,
  `ApplicationId` int(11) NOT NULL,
  PRIMARY KEY (`ApplicationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_sessioncleanup: ~0 rows (approximately)
DELETE FROM `my_aspnet_sessioncleanup`;
/*!40000 ALTER TABLE `my_aspnet_sessioncleanup` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_sessioncleanup` ENABLE KEYS */;

-- Dumping structure for table smlpob.my_aspnet_sessions
DROP TABLE IF EXISTS `my_aspnet_sessions`;
CREATE TABLE IF NOT EXISTS `my_aspnet_sessions` (
  `SessionId` varchar(191) NOT NULL,
  `ApplicationId` int(11) NOT NULL,
  `Created` datetime NOT NULL,
  `Expires` datetime NOT NULL,
  `LockDate` datetime NOT NULL,
  `LockId` int(11) NOT NULL,
  `Timeout` int(11) NOT NULL,
  `Locked` tinyint(1) NOT NULL,
  `SessionItems` longblob,
  `Flags` int(11) NOT NULL,
  PRIMARY KEY (`SessionId`,`ApplicationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_sessions: ~0 rows (approximately)
DELETE FROM `my_aspnet_sessions`;
/*!40000 ALTER TABLE `my_aspnet_sessions` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_sessions` ENABLE KEYS */;

-- Dumping structure for table smlpob.my_aspnet_sitemap
DROP TABLE IF EXISTS `my_aspnet_sitemap`;
CREATE TABLE IF NOT EXISTS `my_aspnet_sitemap` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(50) DEFAULT NULL,
  `Description` varchar(512) DEFAULT NULL,
  `Url` varchar(512) DEFAULT NULL,
  `Roles` varchar(1000) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_sitemap: ~0 rows (approximately)
DELETE FROM `my_aspnet_sitemap`;
/*!40000 ALTER TABLE `my_aspnet_sitemap` DISABLE KEYS */;
/*!40000 ALTER TABLE `my_aspnet_sitemap` ENABLE KEYS */;

-- Dumping structure for table smlpob.my_aspnet_users
DROP TABLE IF EXISTS `my_aspnet_users`;
CREATE TABLE IF NOT EXISTS `my_aspnet_users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `applicationId` int(11) NOT NULL,
  `name` varchar(256) NOT NULL,
  `isAnonymous` tinyint(1) NOT NULL DEFAULT '1',
  `lastActivityDate` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_users: ~28 rows (approximately)
DELETE FROM `my_aspnet_users`;
/*!40000 ALTER TABLE `my_aspnet_users` DISABLE KEYS */;
INSERT INTO `my_aspnet_users` (`id`, `applicationId`, `name`, `isAnonymous`, `lastActivityDate`) VALUES
	(2, 1, 'zilong@gmail.com', 0, '2019-08-27 15:42:40'),
	(3, 1, 'asep@gmail.com', 0, '2019-09-04 10:32:06'),
	(4, 1, 'ujang@gmail.com', 0, '2019-08-24 18:08:44'),
	(5, 1, 'jeje@gmail.com', 0, '2019-08-27 15:12:44'),
	(6, 1, 'anna@gmail.com', 0, '2019-09-26 11:49:49'),
	(8, 1, 'testpenyelia', 0, '2019-08-26 06:02:46'),
	(31, 1, 'teguh@gmail.com', 0, '2019-09-09 09:08:28'),
	(34, 1, 'mifmasterz@gmail.com', 0, '2019-08-28 10:54:57'),
	(35, 1, 'mifmasterz@yahoo.com', 0, '2019-09-09 11:57:45'),
	(37, 1, 'fariz@gmail.com', 0, '2019-08-29 13:40:37'),
	(38, 1, 'mstokev@gmail.com', 0, '2019-09-11 14:49:48'),
	(39, 1, 'mifmasterz@outlook.com', 0, '2019-09-02 16:32:33'),
	(40, 1, 'galihyprtm@gmail.com', 0, '2019-09-12 08:06:04'),
	(41, 1, 'manager1@gmail.com', 0, '2019-09-26 10:15:23'),
	(42, 1, 'analis1@gmail.com', 0, '2019-09-26 10:03:09'),
	(43, 1, 'evaluator1@gmail.com', 0, '2019-09-25 06:01:37'),
	(44, 1, 'kasir1@gmail.com', 0, '2019-09-26 11:52:58'),
	(45, 1, 'cs1@gmail.com', 0, '2019-09-26 10:13:40'),
	(46, 1, 'penyelia1@gmail.com', 0, '2019-09-26 10:13:13'),
	(47, 1, 'guntur.fitrano@mhsw.pnj.ac.id', 0, '2019-09-04 06:36:44'),
	(48, 1, 'guntur.fitrano.tik16@mhsw.pnj.ac.id', 0, '2019-09-09 09:10:13'),
	(49, 1, 'umaraaa234@gmail.com', 0, '2019-09-05 09:16:41'),
	(53, 1, 'acuaca00@gmail.com', 0, '2019-09-09 09:07:34'),
	(56, 1, 'teguhprayoga94@gmail.com', 0, '2019-09-23 14:55:20'),
	(58, 1, 'agriezmann408@gmail.com', 0, '2019-09-12 14:37:07'),
	(59, 1, 'rizkyansyah031398@gmail.com', 0, '2019-09-16 05:47:42'),
	(60, 1, 'Iwanfals25@gmail.com', 0, '2019-09-25 01:59:26'),
	(61, 1, 'dontworry02051998@gmail.com', 0, '2019-09-26 02:05:01');
/*!40000 ALTER TABLE `my_aspnet_users` ENABLE KEYS */;

-- Dumping structure for table smlpob.my_aspnet_usersinroles
DROP TABLE IF EXISTS `my_aspnet_usersinroles`;
CREATE TABLE IF NOT EXISTS `my_aspnet_usersinroles` (
  `userId` int(11) NOT NULL,
  `roleId` int(11) NOT NULL,
  PRIMARY KEY (`userId`,`roleId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_usersinroles: ~42 rows (approximately)
DELETE FROM `my_aspnet_usersinroles`;
/*!40000 ALTER TABLE `my_aspnet_usersinroles` DISABLE KEYS */;
INSERT INTO `my_aspnet_usersinroles` (`userId`, `roleId`) VALUES
	(3, 3),
	(4, 3),
	(5, 3),
	(6, 3),
	(7, 3),
	(8, 4),
	(9, 3),
	(10, 3),
	(11, 3),
	(12, 3),
	(14, 3),
	(15, 3),
	(16, 3),
	(17, 3),
	(18, 3),
	(19, 3),
	(21, 3),
	(22, 3),
	(23, 3),
	(24, 3),
	(25, 3),
	(26, 3),
	(27, 3),
	(28, 3),
	(29, 3),
	(31, 3),
	(32, 3),
	(33, 3),
	(34, 3),
	(35, 3),
	(36, 3),
	(37, 3),
	(38, 3),
	(39, 3),
	(40, 3),
	(41, 5),
	(42, 7),
	(43, 6),
	(44, 3),
	(45, 3),
	(46, 4),
	(47, 3),
	(48, 3),
	(49, 3),
	(50, 3),
	(51, 3),
	(52, 3),
	(54, 3),
	(55, 3),
	(56, 3),
	(57, 3),
	(58, 3),
	(59, 3),
	(60, 3),
	(61, 3);
/*!40000 ALTER TABLE `my_aspnet_usersinroles` ENABLE KEYS */;

-- Dumping structure for table smlpob.orderanalysisdetailtbl
DROP TABLE IF EXISTS `orderanalysisdetailtbl`;
CREATE TABLE IF NOT EXISTS `orderanalysisdetailtbl` (
  `orderDetailNo` int(11) NOT NULL AUTO_INCREMENT,
  `orderNo` varchar(30) NOT NULL,
  `sampleNo` varchar(25) NOT NULL,
  `elementId` int(11) NOT NULL,
  `parametersNo` int(11) DEFAULT NULL,
  `elementValue` varchar(255) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `recalculate` char(1) DEFAULT NULL,
  `pic` int(11) DEFAULT NULL,
  `fileAttachmentUrl` text,
  `fileName` varchar(255) DEFAULT NULL,
  `LabToolAttachmentUrl` text,
  `LabToolFileName` varchar(255) DEFAULT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`orderDetailNo`),
  KEY `OrderAnalysisDetailTbltoOrderMaster` (`orderNo`),
  KEY `OrderAnalysisDetailTbltoOrderSampleTbl` (`sampleNo`),
  KEY `OrderAnalysisDetailTbltoElementServicesTbl` (`elementId`),
  KEY `OrderAnalysisDetailTbltoParametersTbl` (`parametersNo`),
  KEY `OrderAnalysisDetailTbltoEmployeeTbl` (`pic`),
  CONSTRAINT `OrderAnalysisDetailTbltoElementServicesTbl` FOREIGN KEY (`elementId`) REFERENCES `elementservicestbl` (`elementid`),
  CONSTRAINT `OrderAnalysisDetailTbltoEmployeeTbl` FOREIGN KEY (`pic`) REFERENCES `employeetbl` (`employeeNo`),
  CONSTRAINT `OrderAnalysisDetailTbltoOrderMaster` FOREIGN KEY (`orderNo`) REFERENCES `ordermastertbl` (`orderNo`),
  CONSTRAINT `OrderAnalysisDetailTbltoOrderSampleTbl` FOREIGN KEY (`sampleNo`) REFERENCES `ordersampletbl` (`noBalittanah`),
  CONSTRAINT `OrderAnalysisDetailTbltoParametersTbl` FOREIGN KEY (`parametersNo`) REFERENCES `parameterstbl` (`parametersNo`)
) ENGINE=InnoDB AUTO_INCREMENT=142 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.orderanalysisdetailtbl: ~78 rows (approximately)
DELETE FROM `orderanalysisdetailtbl`;
/*!40000 ALTER TABLE `orderanalysisdetailtbl` DISABLE KEYS */;
INSERT INTO `orderanalysisdetailtbl` (`orderDetailNo`, `orderNo`, `sampleNo`, `elementId`, `parametersNo`, `elementValue`, `status`, `recalculate`, `pic`, `fileAttachmentUrl`, `fileName`, `LabToolAttachmentUrl`, `LabToolFileName`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	(1, '0001/LP Balittanah/09/2019', '19.09.1 K.P. 1', 21, NULL, NULL, 'Menunggu', '0', 14, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-22 18:11:57', NULL, NULL),
	(2, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 207, NULL, NULL, 'Diproses', '0', 14, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_23Sep2019_ypM0TLhRn8Xhxx.xlsx', 'manual_analis1@gmail.com_23Sep2019_ypM0TLhRn8Xhxx.xlsx', NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', 'analis1@gmail.com', '2019-09-23 08:44:24'),
	(3, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 208, NULL, NULL, 'Diproses', '0', NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_23Sep2019_yVYLkd9cm4MoM.xlsx', 'manual_analis1@gmail.com_23Sep2019_yVYLkd9cm4MoM.xlsx', NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', 'analis1@gmail.com', '2019-09-23 08:46:15'),
	(4, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 209, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(5, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 210, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(6, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 211, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(7, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 212, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(8, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 213, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(9, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 214, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(10, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 215, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(11, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 216, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(12, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 217, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(13, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 218, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(14, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 219, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(15, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 220, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(16, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 221, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(17, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 222, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(18, '0002/LP Balittanah/09/2019', '19.09.2 K.P. 2', 223, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', NULL, NULL),
	(19, '0003/LP Balittanah/09/2019', '19.09.3 K.P. 3', 24, NULL, NULL, 'Diproses', '0', 14, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_23Sep2019_oOOKaCHM3.xlsx', 'manual_analis1@gmail.com_23Sep2019_oOOKaCHM3.xlsx', NULL, NULL, 'anna@gmail.com', '2019-09-23 08:47:32', 'analis1@gmail.com', '2019-09-23 08:49:32'),
	(20, '0004/LP Balittanah/09/2019', '19.09.4 K.P. 4', 51, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 09:33:58', NULL, NULL),
	(21, '0004/LP Balittanah/09/2019', '19.09.4 K.P. 4', 54, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 09:33:58', NULL, NULL),
	(22, '0004/LP Balittanah/09/2019', '19.09.4 K.P. 4', 55, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 09:33:58', NULL, NULL),
	(23, '0004/LP Balittanah/09/2019', '19.09.4 K.P. 4', 56, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 09:33:58', NULL, NULL),
	(24, '0004/LP Balittanah/09/2019', '19.09.4 K.P. 4', 57, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 09:33:58', NULL, NULL),
	(25, '0005/LP Balittanah/09/2019', '19.09.5 K.P. 5', 1, NULL, NULL, 'Diproses', '0', 14, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_23Sep2019_AhwbRU38QDl.xlsx', 'manual_analis1@gmail.com_23Sep2019_AhwbRU38QDl.xlsx', NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:28:31', 'analis1@gmail.com', '2019-09-23 14:41:46'),
	(26, '0005/LP Balittanah/09/2019', '19.09.5 K.P. 5', 2, NULL, NULL, 'Diproses', '0', NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_23Sep2019_FUUthcc11.xls', 'manual_analis1@gmail.com_23Sep2019_FUUthcc11.xls', NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:28:31', 'analis1@gmail.com', '2019-09-23 14:42:20'),
	(27, '0005/LP Balittanah/09/2019', '19.09.5 K.P. 5', 3, NULL, NULL, 'Diproses', '0', NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_23Sep2019_qaTMra9mzG.xls', 'manual_analis1@gmail.com_23Sep2019_qaTMra9mzG.xls', NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:28:31', 'analis1@gmail.com', '2019-09-23 14:43:37'),
	(28, '0005/LP Balittanah/09/2019', '19.09.5 K.P. 5', 4, NULL, NULL, 'Diproses', '0', NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_23Sep2019_bW9dn91.xlsx', 'manual_analis1@gmail.com_23Sep2019_bW9dn91.xlsx', NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:28:31', 'analis1@gmail.com', '2019-09-23 14:43:54'),
	(29, '0005/LP Balittanah/09/2019', '19.09.5 K.P. 5', 5, NULL, NULL, 'Diproses', '0', NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_23Sep2019_SwX8SVvM.xls', 'manual_analis1@gmail.com_23Sep2019_SwX8SVvM.xls', NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:28:31', 'analis1@gmail.com', '2019-09-23 14:44:09'),
	(30, '0005/LP Balittanah/09/2019', '19.09.5 K.P. 5', 6, NULL, NULL, 'Diproses', '0', NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_23Sep2019_JsCBP82wreE29.xls', 'manual_analis1@gmail.com_23Sep2019_JsCBP82wreE29.xls', NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:28:31', 'analis1@gmail.com', '2019-09-23 14:44:24'),
	(31, '0005/LP Balittanah/09/2019', '19.09.5 K.P. 5', 7, NULL, NULL, 'Diproses', '0', NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_23Sep2019_dMoE8Vq4dmR.xls', 'manual_analis1@gmail.com_23Sep2019_dMoE8Vq4dmR.xls', NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:28:31', 'analis1@gmail.com', '2019-09-23 14:44:40'),
	(32, '0005/LP Balittanah/09/2019', '19.09.5 K.P. 5', 8, NULL, NULL, 'Diproses', '0', NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_23Sep2019_fCbb15x.xls', 'manual_analis1@gmail.com_23Sep2019_fCbb15x.xls', NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:28:31', 'analis1@gmail.com', '2019-09-23 14:44:59'),
	(33, '0005/LP Balittanah/09/2019', '19.09.5 K.P. 5', 9, NULL, NULL, 'Diproses', '0', NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_23Sep2019_MgeNwXhR.xls', 'manual_analis1@gmail.com_23Sep2019_MgeNwXhR.xls', NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:28:31', 'analis1@gmail.com', '2019-09-23 14:45:16'),
	(34, '0005/LP Balittanah/09/2019', '19.09.5 K.P. 5', 10, NULL, NULL, 'Diproses', '0', NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_23Sep2019_5wrT1TvEsx1KOp.xls', 'manual_analis1@gmail.com_23Sep2019_5wrT1TvEsx1KOp.xls', NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:28:31', 'analis1@gmail.com', '2019-09-23 14:45:44'),
	(35, '0005/LP Balittanah/09/2019', '19.09.5 K.P. 5', 11, NULL, NULL, 'Diproses', '0', NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_23Sep2019_SH3AuqoIE.xls', 'manual_analis1@gmail.com_23Sep2019_SH3AuqoIE.xls', NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:28:31', 'analis1@gmail.com', '2019-09-23 14:45:58'),
	(36, '0006/LP Balittanah/09/2019', '19.09.6 K.P. 6', 1, NULL, NULL, 'Menunggu', '0', 14, NULL, NULL, NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:33:08', NULL, NULL),
	(37, '0006/LP Balittanah/09/2019', '19.09.6 K.P. 6', 2, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:33:08', NULL, NULL),
	(38, '0006/LP Balittanah/09/2019', '19.09.6 K.P. 6', 3, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:33:08', NULL, NULL),
	(39, '0006/LP Balittanah/09/2019', '19.09.6 K.P. 6', 4, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:33:08', NULL, NULL),
	(40, '0006/LP Balittanah/09/2019', '19.09.6 K.P. 6', 5, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:33:08', NULL, NULL),
	(41, '0006/LP Balittanah/09/2019', '19.09.6 K.P. 6', 6, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:33:08', NULL, NULL),
	(42, '0006/LP Balittanah/09/2019', '19.09.6 K.P. 6', 7, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:33:08', NULL, NULL),
	(43, '0006/LP Balittanah/09/2019', '19.09.6 K.P. 6', 8, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:33:08', NULL, NULL),
	(44, '0006/LP Balittanah/09/2019', '19.09.6 K.P. 6', 9, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:33:08', NULL, NULL),
	(45, '0006/LP Balittanah/09/2019', '19.09.6 K.P. 6', 10, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:33:08', NULL, NULL),
	(46, '0006/LP Balittanah/09/2019', '19.09.6 K.P. 6', 11, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:33:08', NULL, NULL),
	(47, '0007/LP Balittanah/09/2019', '19.09.7 K.P. 7', 21, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 13:55:42', NULL, NULL),
	(48, '0008/LP Balittanah/09/2019', '19.09.8 K.P. 8', 24, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 13:59:05', NULL, NULL),
	(49, '0014/LP Balittanah/09/2019', '19.09.14 K.P. 10', 265, NULL, NULL, 'Diproses', '0', 14, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_25Sep2019_bA728kVEF.csv', 'manual_analis1@gmail.com_25Sep2019_bA728kVEF.csv', 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/alat_analis1@gmail.com_25Sep2019_TI9Y3trd.xls', 'alat_analis1@gmail.com_25Sep2019_TI9Y3trd.xls', 'anna@gmail.com', '2019-09-25 08:08:38', 'analis1@gmail.com', '2019-09-25 08:17:00'),
	(50, '0014/LP Balittanah/09/2019', '19.09.14 K.P. 10', 268, NULL, NULL, 'Diproses', '0', NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_25Sep2019_oWYxsryOzpJaE.xlsx', 'manual_analis1@gmail.com_25Sep2019_oWYxsryOzpJaE.xlsx', 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/alat_analis1@gmail.com_25Sep2019_tGeJNU61.xls', 'alat_analis1@gmail.com_25Sep2019_tGeJNU61.xls', 'anna@gmail.com', '2019-09-25 08:08:38', 'analis1@gmail.com', '2019-09-25 08:17:14'),
	(51, '0015/LP Balittanah/09/2019', '19.09.15 K.P. 11', 21, NULL, NULL, 'Diproses', '0', 14, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_25Sep2019_Sw3nNP0.xlsx', 'manual_analis1@gmail.com_25Sep2019_Sw3nNP0.xlsx', NULL, NULL, 'anna@gmail.com', '2019-09-25 08:53:46', 'analis1@gmail.com', '2019-09-25 09:00:00'),
	(52, '0016/LP Balittanah/09/2019', '19.09.16 K.P. 12', 21, NULL, NULL, 'Diproses', '0', 14, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_25Sep2019_qB0aJqOdJMT.xlsx', 'manual_analis1@gmail.com_25Sep2019_qB0aJqOdJMT.xlsx', NULL, NULL, 'anna@gmail.com', '2019-09-25 09:28:20', 'analis1@gmail.com', '2019-09-25 09:32:05'),
	(53, '0017/LP Balittanah/09/2019', '19.09.17 K.P. 13', 26, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 09:42:15', NULL, NULL),
	(54, '0018/LP Balittanah/09/2019', '19.09.18 K.P. 14', 27, NULL, NULL, 'Diproses', '0', 14, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_25Sep2019_bkbIxFw.xlsx', 'manual_analis1@gmail.com_25Sep2019_bkbIxFw.xlsx', NULL, NULL, 'anna@gmail.com', '2019-09-25 10:22:37', 'analis1@gmail.com', '2019-09-25 10:24:14'),
	(55, '0019/LP Balittanah/09/2019', '19.09.19 K.P. 15', 21, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 10:36:44', NULL, NULL),
	(56, '0020/LP Balittanah/09/2019', '19.09.20 K.P. 16', 279, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 13:41:59', NULL, NULL),
	(57, '0020/LP Balittanah/09/2019', '19.09.20 K.P. 16', 280, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 13:41:59', NULL, NULL),
	(58, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 224, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(59, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 225, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(60, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 226, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(61, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 227, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(62, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 228, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(63, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 229, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(64, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 230, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(65, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 231, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(66, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 232, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(67, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 233, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(68, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 234, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(69, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 235, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(70, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 236, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(71, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 237, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(72, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 238, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(73, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 239, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(74, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 240, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(75, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 241, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(76, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 242, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(77, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 243, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(78, '0021/LP Balittanah/09/2019', '19.09.21 K.P. 17', 253, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', NULL, NULL),
	(79, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 224, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(80, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 225, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(81, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 226, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(82, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 227, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(83, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 228, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(84, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 229, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(85, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 230, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(86, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 231, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(87, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 232, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(88, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 233, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(89, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 234, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(90, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 235, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(91, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 236, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(92, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 237, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(93, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 238, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(94, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 239, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(95, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 240, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(96, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 241, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(97, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 242, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(98, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 243, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(99, '0022/LP Balittanah/09/2019', '19.09.22 K.P. 18', 253, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', NULL, NULL),
	(100, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 224, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(101, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 225, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(102, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 226, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(103, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 227, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(104, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 228, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(105, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 229, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(106, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 230, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(107, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 231, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(108, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 232, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(109, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 233, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(110, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 234, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(111, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 235, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(112, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 236, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(113, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 237, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(114, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 238, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(115, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 239, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(116, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 240, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(117, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 241, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(118, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 242, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(119, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 243, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(120, '0023/LP Balittanah/09/2019', '19.09.23 K.P. 19', 253, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', NULL, NULL),
	(121, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 224, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(122, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 225, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(123, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 226, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(124, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 227, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(125, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 228, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(126, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 229, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(127, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 230, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(128, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 231, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(129, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 232, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(130, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 233, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(131, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 234, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(132, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 235, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(133, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 236, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(134, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 237, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(135, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 238, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(136, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 239, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(137, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 240, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(138, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 241, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(139, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 242, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(140, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 243, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL),
	(141, '0024/LP Balittanah/09/2019', '19.09.24 K.P. 20', 253, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', NULL, NULL);
/*!40000 ALTER TABLE `orderanalysisdetailtbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.ordermastertbl
DROP TABLE IF EXISTS `ordermastertbl`;
CREATE TABLE IF NOT EXISTS `ordermastertbl` (
  `orderNo` varchar(30) NOT NULL,
  `customerNo` int(11) NOT NULL,
  `comodityNo` int(11) NOT NULL,
  `analysisType` varchar(255) DEFAULT NULL,
  `sampleTotal` int(11) DEFAULT NULL,
  `priceTotal` decimal(12,2) DEFAULT NULL,
  `statusType` varchar(255) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  `paymentStatus` varchar(255) DEFAULT NULL,
  `ppn` decimal(12,2) DEFAULT NULL,
  `receiptDate` datetime DEFAULT NULL,
  `isPaid` char(1) NOT NULL,
  `paymentDate` datetime DEFAULT NULL,
  `pic` int(11) DEFAULT NULL,
  `isOnLab` char(1) DEFAULT NULL,
  `ApprPenyelia` char(1) DEFAULT NULL,
  `ApprEvaluator` char(1) DEFAULT NULL,
  `ApprManagerTeknis` char(1) DEFAULT NULL,
  `LHPAttachmentUrl` text,
  `LHPFileName` varchar(255) DEFAULT NULL,
  `EvaluationFileUrl` text,
  `EvaluationFileName` varchar(255) DEFAULT NULL,
  `isRecalculate` char(1) DEFAULT NULL,
  `isReviewing` char(1) DEFAULT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  `packageName` varchar(255) DEFAULT NULL,
  `additionalPrice1` decimal(12,2) DEFAULT NULL,
  `additionalPrice2` decimal(12,2) DEFAULT NULL,
  `totalGenus` int(11) DEFAULT NULL,
  `dosePerHectare` decimal(5,0) DEFAULT NULL,
  PRIMARY KEY (`orderNo`),
  KEY `OrderMasterTbltoCustomerTbl` (`customerNo`),
  KEY `OrderMasterTbltoComodityTbl` (`comodityNo`),
  KEY `OrderMasterTbltoEmployeeTbl` (`pic`),
  KEY `OrderMasterTbltoAnalysisTypeTbl` (`analysisType`),
  CONSTRAINT `OrderMasterTbltoAnalysisTypeTbl` FOREIGN KEY (`analysisType`) REFERENCES `analysistypetbl` (`analysisTypeName`),
  CONSTRAINT `OrderMasterTbltoComodityTbl` FOREIGN KEY (`comodityNo`) REFERENCES `comoditytbl` (`comodityNo`),
  CONSTRAINT `OrderMasterTbltoCustomerTbl` FOREIGN KEY (`customerNo`) REFERENCES `customertbl` (`customerNo`),
  CONSTRAINT `OrderMasterTbltoEmployeeTbl` FOREIGN KEY (`pic`) REFERENCES `employeetbl` (`employeeNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.ordermastertbl: ~16 rows (approximately)
DELETE FROM `ordermastertbl`;
/*!40000 ALTER TABLE `ordermastertbl` DISABLE KEYS */;
INSERT INTO `ordermastertbl` (`orderNo`, `customerNo`, `comodityNo`, `analysisType`, `sampleTotal`, `priceTotal`, `statusType`, `status`, `paymentStatus`, `ppn`, `receiptDate`, `isPaid`, `paymentDate`, `pic`, `isOnLab`, `ApprPenyelia`, `ApprEvaluator`, `ApprManagerTeknis`, `LHPAttachmentUrl`, `LHPFileName`, `EvaluationFileUrl`, `EvaluationFileName`, `isRecalculate`, `isReviewing`, `creaBy`, `creaDate`, `modBy`, `modDate`, `packageName`, `additionalPrice1`, `additionalPrice2`, `totalGenus`, `dosePerHectare`) VALUES
	('0001/LP Balittanah/09/2019', 1114, 3, 'Kimia', 1, 0.00, 'Komersial', 'LHP keluar', 'Sudah dibayar', 25.10, '2019-09-22 00:00:00', '1', NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-22 18:11:57', 'anna@gmail.com', '2019-09-22 18:11:57', NULL, NULL, NULL, NULL, NULL),
	('0002/LP Balittanah/09/2019', 1114, 13, 'Kimia', 1, 0.00, 'Komersial', 'Menunggu Approval', 'Sudah dibayar', 0.10, '2019-09-23 00:00:00', '1', NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:38:55', 'anna@gmail.com', '2019-09-23 08:38:55', 'PUPUK ORGANIK PADAT (SNI 7763:2018)  (TANPA DIPERKAYA MIKROBA)', NULL, NULL, NULL, NULL),
	('0003/LP Balittanah/09/2019', 1114, 3, 'Kimia', 1, 0.00, 'Komersial', 'LHP keluar', 'Sudah dibayar', 34.20, '2019-09-23 00:00:00', '1', NULL, 14, NULL, NULL, NULL, NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/LHP_penyelia1@gmail.com_23Sep2019_xaQx0gbotbvY.xlsx', 'LHP_penyelia1@gmail.com_23Sep2019_xaQx0gbotbvY.xlsx', NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 08:47:32', 'anna@gmail.com', '2019-09-23 08:47:32', NULL, NULL, NULL, NULL, NULL),
	('0004/LP Balittanah/09/2019', 1114, 6, 'Kimia', 1, 157000.00, 'Komersial', 'Pesanan Baru', 'Belum dibayar', 15700.00, '2019-09-23 00:00:00', '0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 09:33:58', 'anna@gmail.com', '2019-09-23 09:33:58', NULL, NULL, NULL, NULL, NULL),
	('0005/LP Balittanah/09/2019', 1160, 1, 'Kimia', 1, 0.00, 'Komersial', 'LHP keluar', 'Sudah dibayar', 56.80, '2019-09-23 00:00:00', '1', NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:28:31', 'teguhprayoga94@gmail.com', '2019-09-23 13:28:31', 'ASAM HUMAT PADAT ', NULL, NULL, NULL, NULL),
	('0006/LP Balittanah/09/2019', 1160, 1, 'Kimia', 1, 0.00, 'Komersial', 'Proses Lab', 'Sudah dibayar', 56.80, '2019-09-23 00:00:00', '1', NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'teguhprayoga94@gmail.com', '2019-09-23 13:33:08', 'teguhprayoga94@gmail.com', '2019-09-23 13:33:08', 'ASAM HUMAT PADAT ', NULL, NULL, NULL, NULL),
	('0007/LP Balittanah/09/2019', 1114, 3, 'Kimia', 1, 251000.00, 'Komersial', 'Pesanan Baru', 'Belum dibayar', 25100.00, '2019-09-23 00:00:00', '0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 13:55:42', 'anna@gmail.com', '2019-09-23 13:55:42', NULL, NULL, NULL, NULL, NULL),
	('0008/LP Balittanah/09/2019', 1114, 3, 'Kimia', 1, 342000.00, 'Komersial', 'Pesanan Baru', 'Belum dibayar', 34200.00, '2019-09-23 00:00:00', '0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-23 13:59:05', 'anna@gmail.com', '2019-09-23 13:59:05', NULL, NULL, NULL, NULL, NULL),
	('0014/LP Balittanah/09/2019', 1114, 21, 'Kimia', 1, 0.00, 'Komersial', 'LHP keluar', 'Sudah dibayar', 4.20, '2019-09-25 00:00:00', '1', NULL, 14, NULL, NULL, NULL, NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/LHP_penyelia1@gmail.com_25Sep2019_etucSCqDAABU.csv', 'LHP_penyelia1@gmail.com_25Sep2019_etucSCqDAABU.csv', NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 08:08:38', 'anna@gmail.com', '2019-09-25 08:08:38', NULL, NULL, NULL, NULL, NULL),
	('0015/LP Balittanah/09/2019', 1114, 3, 'Kimia', 1, 251000.00, 'Komersial', 'LHP keluar', 'Sudah dibayar', 25100.00, '2019-09-25 00:00:00', '1', NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 08:53:46', 'anna@gmail.com', '2019-09-25 08:53:46', NULL, NULL, NULL, NULL, NULL),
	('0016/LP Balittanah/09/2019', 1114, 3, 'Kimia', 1, 0.00, 'Komersial', 'LHP keluar', 'Sudah dibayar', 25.10, '2019-09-25 00:00:00', '1', NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 09:28:20', 'anna@gmail.com', '2019-09-25 09:28:20', NULL, NULL, NULL, NULL, NULL),
	('0017/LP Balittanah/09/2019', 1114, 3, 'Kimia', 1, 0.00, 'Komersial', 'Pesanan Baru', 'Belum dibayar', 34.20, '2019-09-25 00:00:00', '0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 09:42:15', 'anna@gmail.com', '2019-09-25 09:42:15', NULL, NULL, NULL, NULL, NULL),
	('0018/LP Balittanah/09/2019', 1114, 3, 'Kimia', 1, 0.00, 'Komersial', 'LHP keluar', 'Sudah dibayar', 29.90, '2019-09-25 00:00:00', '1', NULL, 14, NULL, NULL, NULL, NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/LHP_penyelia1@gmail.com_25Sep2019_QsTg8Vded3w.xlsx', 'LHP_penyelia1@gmail.com_25Sep2019_QsTg8Vded3w.xlsx', NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 10:22:37', 'anna@gmail.com', '2019-09-25 10:22:37', NULL, NULL, NULL, NULL, NULL),
	('0019/LP Balittanah/09/2019', 1114, 3, 'Kimia', 1, 251000.00, 'Komersial', 'Pilih Penyelia', 'Sudah dibayar', 25100.00, '2019-09-25 00:00:00', '1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 10:36:44', 'anna@gmail.com', '2019-09-25 10:36:44', NULL, NULL, NULL, NULL, NULL),
	('0020/LP Balittanah/09/2019', 1114, 22, 'Kimia', 1, 30000.00, 'Komersial', 'Barcode Sampel', 'DP', 3000.00, '2019-09-25 00:00:00', '1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 13:41:59', 'anna@gmail.com', '2019-09-25 13:41:59', NULL, NULL, NULL, NULL, NULL),
	('0021/LP Balittanah/09/2019', 1114, 14, 'Kimia', 1, 1221000.00, 'Komersial', 'Barcode Sampel', 'Sudah dibayar', 122100.00, '2019-09-25 00:00:00', '1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-25 16:44:52', 'anna@gmail.com', '2019-09-25 16:44:52', 'PUPUK ORGANIK PADAT (Kepmentan 261/KPTS/SR.310/M/4/2019) (DIPERKAYA MIKROBA)', NULL, NULL, NULL, NULL),
	('0022/LP Balittanah/09/2019', 1114, 14, 'Kimia', 1, 0.00, 'Komersial', 'Pesanan Baru', 'Belum dibayar', 0.10, '2019-09-26 00:00:00', '0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:38:18', 'anna@gmail.com', '2019-09-26 11:38:18', 'PUPUK ORGANIK PADAT (Kepmentan 261/KPTS/SR.310/M/4/2019) (DIPERKAYA MIKROBA)', NULL, NULL, NULL, NULL),
	('0023/LP Balittanah/09/2019', 1114, 14, 'Kimia', 1, 0.00, 'Komersial', 'Pesanan Baru', 'Belum dibayar', 0.10, '2019-09-26 00:00:00', '0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:41:46', 'anna@gmail.com', '2019-09-26 11:41:46', 'PUPUK ORGANIK PADAT (Kepmentan 261/KPTS/SR.310/M/4/2019) (DIPERKAYA MIKROBA)', NULL, NULL, NULL, NULL),
	('0024/LP Balittanah/09/2019', 1114, 14, 'Kimia', 1, 1221000.00, 'Komersial', 'Pesanan Baru', 'Belum dibayar', 122100.00, '2019-09-26 00:00:00', '0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'anna@gmail.com', '2019-09-26 11:49:50', 'anna@gmail.com', '2019-09-26 11:49:50', 'PUPUK ORGANIK PADAT (Kepmentan 261/KPTS/SR.310/M/4/2019) (DIPERKAYA MIKROBA)', NULL, NULL, NULL, NULL);
/*!40000 ALTER TABLE `ordermastertbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.ordernavigationtbl
DROP TABLE IF EXISTS `ordernavigationtbl`;
CREATE TABLE IF NOT EXISTS `ordernavigationtbl` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(150) NOT NULL DEFAULT '0',
  `parentId` int(11) NOT NULL DEFAULT '0',
  `isLeaf` varchar(1) NOT NULL DEFAULT '0',
  `commodityNo` int(11) NOT NULL DEFAULT '0',
  `orderNo` int(11) NOT NULL DEFAULT '0',
  `isVisible` varchar(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.ordernavigationtbl: ~63 rows (approximately)
DELETE FROM `ordernavigationtbl`;
/*!40000 ALTER TABLE `ordernavigationtbl` DISABLE KEYS */;
INSERT INTO `ordernavigationtbl` (`id`, `name`, `parentId`, `isLeaf`, `commodityNo`, `orderNo`, `isVisible`) VALUES
	(1, 'Lab Kimia', -1, '0', 0, 0, '1'),
	(2, 'Lab Fisika', -1, '0', 0, 1, '1'),
	(3, 'Lab Biologi', -1, '0', 0, 2, '1'),
	(4, 'tanah', 1, '0', 0, 0, '1'),
	(5, 'air', 1, '0', 0, 1, '1'),
	(6, 'tanaman', 1, '0', 0, 2, '1'),
	(7, 'pupuk & pembenah tanah', 1, '0', 0, 3, '1'),
	(8, 'tanah rutin', 4, '1', 21, 0, '1'),
	(9, 'tanah khusus', 4, '1', 22, 1, '1'),
	(10, 'pupuk organik', 7, '0', 0, 0, '1'),
	(11, 'pupuk hayati', 7, '0', 0, 0, '1'),
	(12, 'pupuk anorganik', 7, '0', 0, 0, '1'),
	(13, 'pembenah tanah', 7, '0', 0, 0, '1'),
	(14, 'humat', 7, '0', 0, 0, '1'),
	(15, 'PO Padat tanpa diperkaya mikroba', 10, '0', 0, 0, '1'),
	(16, 'PO Padat diperkaya mikroba', 10, '0', 0, 1, '1'),
	(17, 'PO Cair', 10, '0', 0, 2, '1'),
	(18, 'SNI 7763:2018', 15, '1', 13, 0, '1'),
	(19, 'Permentan 01/2019, Kep. Mentan 261/2019', 16, '1', 14, 0, '1'),
	(20, 'Permentan 01/2019 dan Kep. Mentan 261/2019', 17, '1', 15, 0, '1'),
	(21, 'PA Makro Tunggal', 12, '0', 0, 0, '1'),
	(22, 'PA Makro Majemuk', 12, '0', 0, 1, '1'),
	(23, 'PA Mikro Tunggal', 12, '0', 0, 2, '1'),
	(24, 'PA Mikro Majemuk', 12, '0', 0, 3, '1'),
	(25, 'PA Campuran Makro dan Mikro', 12, '0', 0, 4, '1'),
	(26, 'Padat', 21, '1', 3, 0, '1'),
	(27, 'Cair', 21, '1', 4, 1, '1'),
	(28, 'Padat', 22, '1', 5, 0, '1'),
	(29, 'Cair', 22, '1', 6, 1, '1'),
	(30, 'Padat', 23, '1', 7, 0, '1'),
	(31, 'Cair', 23, '1', 8, 1, '1'),
	(32, 'Padat', 24, '1', 9, 0, '1'),
	(33, 'Cair', 24, '1', 10, 1, '1'),
	(34, 'Padat', 25, '1', 11, 0, '1'),
	(35, 'Cair', 25, '1', 12, 1, '1'),
	(36, 'Organik', 13, '0', 0, 0, '1'),
	(37, 'Fungsi Khusus', 13, '0', 0, 1, '1'),
	(38, 'Hayati', 13, '0', 0, 2, '1'),
	(39, 'Padat', 36, '1', 13, 0, '1'),
	(40, 'Cair', 36, '1', 15, 0, '1'),
	(41, 'Peningkatan KTK', 37, '0', 0, 0, '1'),
	(42, 'Penstabil Tanah Organik', 37, '0', 0, 1, '1'),
	(43, 'Kemampuan WHC', 37, '0', 0, 2, '1'),
	(44, 'Zeolit', 41, '1', 0, 0, '1'),
	(45, 'Non Zeolit', 41, '1', 0, 1, '1'),
	(46, 'Curah/Remah', 42, '1', 0, 0, '1'),
	(47, 'Granul', 42, '1', 0, 1, '1'),
	(48, 'Peningkatan C Tanah', 43, '1', 0, 0, '1'),
	(49, 'Penetralisis Kemasaman Tanah', 43, '1', 0, 1, '1'),
	(50, 'Penetralisir Logam Berat', 38, '1', 0, 0, '1'),
	(51, 'Stabilitas Tanah / Agregasi', 38, '1', 0, 1, '1'),
	(52, 'Humat Padat', 14, '1', 1, 0, '1'),
	(53, 'Humat Cair', 14, '1', 2, 1, '1'),
	(54, 'Pupuk hayati Tunggal', 11, '0', 16, 0, '1'),
	(55, 'Pupuk hayati Majemuk', 11, '0', 19, 1, '1'),
	(56, 'Bakteri', 54, '1', 0, 0, '1'),
	(57, 'Actinomycetes', 54, '1', 0, 1, '1'),
	(58, 'Fungi', 54, '1', 0, 2, '1'),
	(59, 'Endokimoriza arbuskulars', 54, '1', 17, 3, '1'),
	(60, 'Ektomikoriza', 54, '1', 18, 4, '1'),
	(61, 'Bakteri', 55, '1', 0, 0, '1'),
	(62, 'Aktinomycetes', 55, '1', 0, 0, '1'),
	(63, 'Fungi', 55, '1', 0, 0, '1');
/*!40000 ALTER TABLE `ordernavigationtbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.orderpricedetailtbl
DROP TABLE IF EXISTS `orderpricedetailtbl`;
CREATE TABLE IF NOT EXISTS `orderpricedetailtbl` (
  `orderPriceDetailNo` int(11) NOT NULL AUTO_INCREMENT,
  `orderNo` varchar(30) DEFAULT NULL,
  `elementId` int(11) DEFAULT NULL,
  `price` decimal(12,2) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `TotalPrice` decimal(22,2) DEFAULT NULL,
  PRIMARY KEY (`orderPriceDetailNo`),
  KEY `OrderPriceDetailTbltoOrderMasterTbl` (`orderNo`),
  KEY `OrderPriceDetailtoElementServicesTbl` (`elementId`),
  CONSTRAINT `OrderPriceDetailTbltoOrderMasterTbl` FOREIGN KEY (`orderNo`) REFERENCES `ordermastertbl` (`orderNo`),
  CONSTRAINT `OrderPriceDetailtoElementServicesTbl` FOREIGN KEY (`elementId`) REFERENCES `elementservicestbl` (`elementid`)
) ENGINE=InnoDB AUTO_INCREMENT=369 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.orderpricedetailtbl: ~78 rows (approximately)
DELETE FROM `orderpricedetailtbl`;
/*!40000 ALTER TABLE `orderpricedetailtbl` DISABLE KEYS */;
INSERT INTO `orderpricedetailtbl` (`orderPriceDetailNo`, `orderNo`, `elementId`, `price`, `quantity`, `TotalPrice`) VALUES
	(228, '0001/LP Balittanah/09/2019', 21, 251000.00, 1, 251000.00),
	(229, '0002/LP Balittanah/09/2019', 207, 0.00, 1, 0.00),
	(230, '0002/LP Balittanah/09/2019', 208, 0.00, 1, 0.00),
	(231, '0002/LP Balittanah/09/2019', 209, 0.00, 1, 0.00),
	(232, '0002/LP Balittanah/09/2019', 210, 0.00, 1, 0.00),
	(233, '0002/LP Balittanah/09/2019', 211, 0.00, 1, 0.00),
	(234, '0002/LP Balittanah/09/2019', 212, 0.00, 1, 0.00),
	(235, '0002/LP Balittanah/09/2019', 213, 0.00, 1, 0.00),
	(236, '0002/LP Balittanah/09/2019', 214, 0.00, 1, 0.00),
	(237, '0002/LP Balittanah/09/2019', 215, 0.00, 1, 0.00),
	(238, '0002/LP Balittanah/09/2019', 216, 0.00, 1, 0.00),
	(239, '0002/LP Balittanah/09/2019', 217, 0.00, 1, 0.00),
	(240, '0002/LP Balittanah/09/2019', 218, 0.00, 1, 0.00),
	(241, '0002/LP Balittanah/09/2019', 219, 0.00, 1, 0.00),
	(242, '0002/LP Balittanah/09/2019', 220, 0.00, 1, 0.00),
	(243, '0002/LP Balittanah/09/2019', 221, 0.00, 1, 0.00),
	(244, '0002/LP Balittanah/09/2019', 222, 0.00, 1, 0.00),
	(245, '0002/LP Balittanah/09/2019', 223, 0.00, 1, 0.00),
	(246, '0003/LP Balittanah/09/2019', 24, 342000.00, 1, 342000.00),
	(247, '0004/LP Balittanah/09/2019', 51, 15000.00, 1, 15000.00),
	(248, '0004/LP Balittanah/09/2019', 54, 24000.00, 1, 24000.00),
	(249, '0004/LP Balittanah/09/2019', 55, 24000.00, 1, 24000.00),
	(250, '0004/LP Balittanah/09/2019', 56, 70000.00, 1, 70000.00),
	(251, '0004/LP Balittanah/09/2019', 57, 24000.00, 1, 24000.00),
	(252, '0005/LP Balittanah/09/2019', 1, 0.00, 1, 0.00),
	(253, '0005/LP Balittanah/09/2019', 2, 0.00, 1, 0.00),
	(254, '0005/LP Balittanah/09/2019', 3, 0.00, 1, 0.00),
	(255, '0005/LP Balittanah/09/2019', 4, 0.00, 1, 0.00),
	(256, '0005/LP Balittanah/09/2019', 5, 0.00, 1, 0.00),
	(257, '0005/LP Balittanah/09/2019', 6, 0.00, 1, 0.00),
	(258, '0005/LP Balittanah/09/2019', 7, 0.00, 1, 0.00),
	(259, '0005/LP Balittanah/09/2019', 8, 0.00, 1, 0.00),
	(260, '0005/LP Balittanah/09/2019', 9, 0.00, 1, 0.00),
	(261, '0005/LP Balittanah/09/2019', 10, 0.00, 1, 0.00),
	(262, '0005/LP Balittanah/09/2019', 11, 0.00, 1, 0.00),
	(263, '0006/LP Balittanah/09/2019', 1, 0.00, 1, 0.00),
	(264, '0006/LP Balittanah/09/2019', 2, 0.00, 1, 0.00),
	(265, '0006/LP Balittanah/09/2019', 3, 0.00, 1, 0.00),
	(266, '0006/LP Balittanah/09/2019', 4, 0.00, 1, 0.00),
	(267, '0006/LP Balittanah/09/2019', 5, 0.00, 1, 0.00),
	(268, '0006/LP Balittanah/09/2019', 6, 0.00, 1, 0.00),
	(269, '0006/LP Balittanah/09/2019', 7, 0.00, 1, 0.00),
	(270, '0006/LP Balittanah/09/2019', 8, 0.00, 1, 0.00),
	(271, '0006/LP Balittanah/09/2019', 9, 0.00, 1, 0.00),
	(272, '0006/LP Balittanah/09/2019', 10, 0.00, 1, 0.00),
	(273, '0006/LP Balittanah/09/2019', 11, 0.00, 1, 0.00),
	(274, '0007/LP Balittanah/09/2019', 21, 251000.00, 1, 251000.00),
	(275, '0008/LP Balittanah/09/2019', 24, 342000.00, 1, 342000.00),
	(276, '0014/LP Balittanah/09/2019', 265, 18000.00, 1, 18000.00),
	(277, '0014/LP Balittanah/09/2019', 268, 24000.00, 1, 24000.00),
	(278, '0015/LP Balittanah/09/2019', 21, 251000.00, 1, 251000.00),
	(279, '0016/LP Balittanah/09/2019', 21, 251000.00, 1, 251000.00),
	(280, '0017/LP Balittanah/09/2019', 26, 342000.00, 1, 342000.00),
	(281, '0018/LP Balittanah/09/2019', 27, 299400.00, 1, 299400.00),
	(282, '0019/LP Balittanah/09/2019', 21, 251000.00, 1, 251000.00),
	(283, '0020/LP Balittanah/09/2019', 279, 18000.00, 1, 18000.00),
	(284, '0020/LP Balittanah/09/2019', 280, 12000.00, 1, 12000.00),
	(285, '0021/LP Balittanah/09/2019', 224, 0.00, 1, 0.00),
	(286, '0021/LP Balittanah/09/2019', 225, 0.00, 1, 0.00),
	(287, '0021/LP Balittanah/09/2019', 226, 0.00, 1, 0.00),
	(288, '0021/LP Balittanah/09/2019', 227, 0.00, 1, 0.00),
	(289, '0021/LP Balittanah/09/2019', 228, 0.00, 1, 0.00),
	(290, '0021/LP Balittanah/09/2019', 229, 0.00, 1, 0.00),
	(291, '0021/LP Balittanah/09/2019', 230, 0.00, 1, 0.00),
	(292, '0021/LP Balittanah/09/2019', 231, 0.00, 1, 0.00),
	(293, '0021/LP Balittanah/09/2019', 232, 0.00, 1, 0.00),
	(294, '0021/LP Balittanah/09/2019', 233, 0.00, 1, 0.00),
	(295, '0021/LP Balittanah/09/2019', 234, 0.00, 1, 0.00),
	(296, '0021/LP Balittanah/09/2019', 235, 0.00, 1, 0.00),
	(297, '0021/LP Balittanah/09/2019', 236, 0.00, 1, 0.00),
	(298, '0021/LP Balittanah/09/2019', 237, 0.00, 1, 0.00),
	(299, '0021/LP Balittanah/09/2019', 238, 0.00, 1, 0.00),
	(300, '0021/LP Balittanah/09/2019', 239, 0.00, 1, 0.00),
	(301, '0021/LP Balittanah/09/2019', 240, 0.00, 1, 0.00),
	(302, '0021/LP Balittanah/09/2019', 241, 0.00, 1, 0.00),
	(303, '0021/LP Balittanah/09/2019', 242, 0.00, 1, 0.00),
	(304, '0021/LP Balittanah/09/2019', 243, 0.00, 1, 0.00),
	(305, '0021/LP Balittanah/09/2019', 253, 0.00, 1, 0.00),
	(306, '0022/LP Balittanah/09/2019', 224, 0.00, 1, 0.00),
	(307, '0022/LP Balittanah/09/2019', 225, 0.00, 1, 0.00),
	(308, '0022/LP Balittanah/09/2019', 226, 0.00, 1, 0.00),
	(309, '0022/LP Balittanah/09/2019', 227, 0.00, 1, 0.00),
	(310, '0022/LP Balittanah/09/2019', 228, 0.00, 1, 0.00),
	(311, '0022/LP Balittanah/09/2019', 229, 0.00, 1, 0.00),
	(312, '0022/LP Balittanah/09/2019', 230, 0.00, 1, 0.00),
	(313, '0022/LP Balittanah/09/2019', 231, 0.00, 1, 0.00),
	(314, '0022/LP Balittanah/09/2019', 232, 0.00, 1, 0.00),
	(315, '0022/LP Balittanah/09/2019', 233, 0.00, 1, 0.00),
	(316, '0022/LP Balittanah/09/2019', 234, 0.00, 1, 0.00),
	(317, '0022/LP Balittanah/09/2019', 235, 0.00, 1, 0.00),
	(318, '0022/LP Balittanah/09/2019', 236, 0.00, 1, 0.00),
	(319, '0022/LP Balittanah/09/2019', 237, 0.00, 1, 0.00),
	(320, '0022/LP Balittanah/09/2019', 238, 0.00, 1, 0.00),
	(321, '0022/LP Balittanah/09/2019', 239, 0.00, 1, 0.00),
	(322, '0022/LP Balittanah/09/2019', 240, 0.00, 1, 0.00),
	(323, '0022/LP Balittanah/09/2019', 241, 0.00, 1, 0.00),
	(324, '0022/LP Balittanah/09/2019', 242, 0.00, 1, 0.00),
	(325, '0022/LP Balittanah/09/2019', 243, 0.00, 1, 0.00),
	(326, '0022/LP Balittanah/09/2019', 253, 0.00, 1, 0.00),
	(327, '0023/LP Balittanah/09/2019', 224, 0.00, 1, 0.00),
	(328, '0023/LP Balittanah/09/2019', 225, 0.00, 1, 0.00),
	(329, '0023/LP Balittanah/09/2019', 226, 0.00, 1, 0.00),
	(330, '0023/LP Balittanah/09/2019', 227, 0.00, 1, 0.00),
	(331, '0023/LP Balittanah/09/2019', 228, 0.00, 1, 0.00),
	(332, '0023/LP Balittanah/09/2019', 229, 0.00, 1, 0.00),
	(333, '0023/LP Balittanah/09/2019', 230, 0.00, 1, 0.00),
	(334, '0023/LP Balittanah/09/2019', 231, 0.00, 1, 0.00),
	(335, '0023/LP Balittanah/09/2019', 232, 0.00, 1, 0.00),
	(336, '0023/LP Balittanah/09/2019', 233, 0.00, 1, 0.00),
	(337, '0023/LP Balittanah/09/2019', 234, 0.00, 1, 0.00),
	(338, '0023/LP Balittanah/09/2019', 235, 0.00, 1, 0.00),
	(339, '0023/LP Balittanah/09/2019', 236, 0.00, 1, 0.00),
	(340, '0023/LP Balittanah/09/2019', 237, 0.00, 1, 0.00),
	(341, '0023/LP Balittanah/09/2019', 238, 0.00, 1, 0.00),
	(342, '0023/LP Balittanah/09/2019', 239, 0.00, 1, 0.00),
	(343, '0023/LP Balittanah/09/2019', 240, 0.00, 1, 0.00),
	(344, '0023/LP Balittanah/09/2019', 241, 0.00, 1, 0.00),
	(345, '0023/LP Balittanah/09/2019', 242, 0.00, 1, 0.00),
	(346, '0023/LP Balittanah/09/2019', 243, 0.00, 1, 0.00),
	(347, '0023/LP Balittanah/09/2019', 253, 0.00, 1, 0.00),
	(348, '0024/LP Balittanah/09/2019', 224, 0.00, 1, 0.00),
	(349, '0024/LP Balittanah/09/2019', 225, 0.00, 1, 0.00),
	(350, '0024/LP Balittanah/09/2019', 226, 0.00, 1, 0.00),
	(351, '0024/LP Balittanah/09/2019', 227, 0.00, 1, 0.00),
	(352, '0024/LP Balittanah/09/2019', 228, 0.00, 1, 0.00),
	(353, '0024/LP Balittanah/09/2019', 229, 0.00, 1, 0.00),
	(354, '0024/LP Balittanah/09/2019', 230, 0.00, 1, 0.00),
	(355, '0024/LP Balittanah/09/2019', 231, 0.00, 1, 0.00),
	(356, '0024/LP Balittanah/09/2019', 232, 0.00, 1, 0.00),
	(357, '0024/LP Balittanah/09/2019', 233, 0.00, 1, 0.00),
	(358, '0024/LP Balittanah/09/2019', 234, 0.00, 1, 0.00),
	(359, '0024/LP Balittanah/09/2019', 235, 0.00, 1, 0.00),
	(360, '0024/LP Balittanah/09/2019', 236, 0.00, 1, 0.00),
	(361, '0024/LP Balittanah/09/2019', 237, 0.00, 1, 0.00),
	(362, '0024/LP Balittanah/09/2019', 238, 0.00, 1, 0.00),
	(363, '0024/LP Balittanah/09/2019', 239, 0.00, 1, 0.00),
	(364, '0024/LP Balittanah/09/2019', 240, 0.00, 1, 0.00),
	(365, '0024/LP Balittanah/09/2019', 241, 0.00, 1, 0.00),
	(366, '0024/LP Balittanah/09/2019', 242, 0.00, 1, 0.00),
	(367, '0024/LP Balittanah/09/2019', 243, 0.00, 1, 0.00),
	(368, '0024/LP Balittanah/09/2019', 253, 0.00, 1, 0.00);
/*!40000 ALTER TABLE `orderpricedetailtbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.ordersampletbl
DROP TABLE IF EXISTS `ordersampletbl`;
CREATE TABLE IF NOT EXISTS `ordersampletbl` (
  `noBalittanah` varchar(25) NOT NULL,
  `orderNo` varchar(30) NOT NULL,
  `countNumber` int(11) DEFAULT NULL,
  `sampleCode` varchar(255) NOT NULL,
  `sampleDescription` text,
  `samplingDate` datetime DEFAULT NULL,
  `village` varchar(255) DEFAULT NULL,
  `subDistrict` varchar(255) DEFAULT NULL,
  `district` varchar(255) DEFAULT NULL,
  `province` varchar(255) DEFAULT NULL,
  `longitude` varchar(255) DEFAULT NULL,
  `latitude` varchar(255) DEFAULT NULL,
  `landUse` varchar(255) DEFAULT NULL,
  `isReceived` char(1) DEFAULT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`noBalittanah`),
  KEY `OrderSampleTbltoOrderMasterTbl` (`orderNo`),
  CONSTRAINT `OrderSampleTbltoOrderMasterTbl` FOREIGN KEY (`orderNo`) REFERENCES `ordermastertbl` (`orderNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.ordersampletbl: ~16 rows (approximately)
DELETE FROM `ordersampletbl`;
/*!40000 ALTER TABLE `ordersampletbl` DISABLE KEYS */;
INSERT INTO `ordersampletbl` (`noBalittanah`, `orderNo`, `countNumber`, `sampleCode`, `sampleDescription`, `samplingDate`, `village`, `subDistrict`, `district`, `province`, `longitude`, `latitude`, `landUse`, `isReceived`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	('19.09.1 K.P. 1', '0001/LP Balittanah/09/2019', 1, 'Sample/001/PT XYZ', 'ok', '2019-09-22 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'anna@gmail.com', '2019-09-22 18:09:45', 'anna@gmail.com', '2019-09-22 18:09:45'),
	('19.09.14 K.P. 10', '0014/LP Balittanah/09/2019', 1, 'SAMPLE/001/PT ABC', 'ok', '2019-09-25 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'anna@gmail.com', '2019-09-25 08:08:26', 'anna@gmail.com', '2019-09-25 08:08:26'),
	('19.09.15 K.P. 11', '0015/LP Balittanah/09/2019', 1, '11', '', '2019-09-25 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'anna@gmail.com', '2019-09-25 08:53:32', 'anna@gmail.com', '2019-09-25 08:53:32'),
	('19.09.16 K.P. 12', '0016/LP Balittanah/09/2019', 1, '65', '', '2019-09-25 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'anna@gmail.com', '2019-09-25 09:27:55', 'anna@gmail.com', '2019-09-25 09:27:55'),
	('19.09.17 K.P. 13', '0017/LP Balittanah/09/2019', 1, '4', '', '2019-09-25 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '0', 'anna@gmail.com', '2019-09-25 09:42:05', 'anna@gmail.com', '2019-09-25 09:42:05'),
	('19.09.18 K.P. 14', '0018/LP Balittanah/09/2019', 1, '41', '', '2019-09-25 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'anna@gmail.com', '2019-09-25 10:22:27', 'anna@gmail.com', '2019-09-25 10:22:27'),
	('19.09.19 K.P. 15', '0019/LP Balittanah/09/2019', 1, '909', '', '2019-09-25 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'anna@gmail.com', '2019-09-25 10:35:53', 'anna@gmail.com', '2019-09-25 10:35:53'),
	('19.09.2 K.P. 2', '0002/LP Balittanah/09/2019', 1, '12', '', '2019-09-23 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'anna@gmail.com', '2019-09-23 08:37:34', 'anna@gmail.com', '2019-09-23 08:37:34'),
	('19.09.20 K.P. 16', '0020/LP Balittanah/09/2019', 1, 'SAMPLE0020', 'tes', '2019-09-25 00:00:00', 'PENDOWOREJO', 'KEC. GIRIMULYO', 'KAB. KULON PROGO', 'PROV. D.I. YOGYAKARTA', '0', '0', 'Lahan Sawah', '1', 'anna@gmail.com', '2019-09-25 13:41:24', 'anna@gmail.com', '2019-09-25 13:41:24'),
	('19.09.21 K.P. 17', '0021/LP Balittanah/09/2019', 1, '121', '1', '2019-09-25 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '0', 'anna@gmail.com', '2019-09-25 16:44:36', 'anna@gmail.com', '2019-09-25 16:44:36'),
	('19.09.22 K.P. 18', '0022/LP Balittanah/09/2019', 1, '8446', 'pk', '2019-09-26 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '354', '64', 'Lahan Sawah', '0', 'anna@gmail.com', '2019-09-26 11:36:50', 'anna@gmail.com', '2019-09-26 11:36:50'),
	('19.09.23 K.P. 19', '0023/LP Balittanah/09/2019', 1, '1', '1', '2019-09-11 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '0', 'anna@gmail.com', '2019-09-26 11:41:32', 'anna@gmail.com', '2019-09-26 11:41:32'),
	('19.09.24 K.P. 20', '0024/LP Balittanah/09/2019', 1, 'SAMPLE/001/GVC', 'ok', '2019-09-26 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '0', 'anna@gmail.com', '2019-09-26 11:48:38', 'anna@gmail.com', '2019-09-26 11:48:38'),
	('19.09.3 K.P. 3', '0003/LP Balittanah/09/2019', 1, '13', '', '2019-09-23 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'anna@gmail.com', '2019-09-23 08:47:21', 'anna@gmail.com', '2019-09-23 08:47:21'),
	('19.09.4 K.P. 4', '0004/LP Balittanah/09/2019', 1, '7', 'cotoh data', '2019-09-23 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '0', 'anna@gmail.com', '2019-09-23 09:31:32', 'anna@gmail.com', '2019-09-23 09:31:32'),
	('19.09.5 K.P. 5', '0005/LP Balittanah/09/2019', 1, '7', '', '2019-09-23 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'teguhprayoga94@gmail.com', '2019-09-23 13:27:37', 'teguhprayoga94@gmail.com', '2019-09-23 13:27:37'),
	('19.09.6 K.P. 6', '0006/LP Balittanah/09/2019', 1, '7', 'data sample', '2019-09-23 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'teguhprayoga94@gmail.com', '2019-09-23 13:32:46', 'teguhprayoga94@gmail.com', '2019-09-23 13:32:46'),
	('19.09.7 K.P. 7', '0007/LP Balittanah/09/2019', 1, '12345', 'contoh sample', '2019-09-23 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '1751', '12415', 'Lahan Sawah', '0', 'anna@gmail.com', '2019-09-23 13:55:04', 'anna@gmail.com', '2019-09-23 13:55:04'),
	('19.09.8 K.P. 8', '0008/LP Balittanah/09/2019', 1, '5321', 'data sample', '2019-09-23 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '1513', '15242', 'Lahan Sawah', '0', 'anna@gmail.com', '2019-09-23 13:58:43', 'anna@gmail.com', '2019-09-23 13:58:43');
/*!40000 ALTER TABLE `ordersampletbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.packagedetailtbl
DROP TABLE IF EXISTS `packagedetailtbl`;
CREATE TABLE IF NOT EXISTS `packagedetailtbl` (
  `PackageDetailTbl` int(11) NOT NULL AUTO_INCREMENT,
  `packageName` varchar(255) DEFAULT NULL,
  `elementId` int(11) DEFAULT NULL,
  `compulsive` char(1) DEFAULT NULL,
  PRIMARY KEY (`PackageDetailTbl`),
  KEY `PackageDetailTbltoPackageTbl` (`packageName`),
  KEY `PackageDetailTbltoElementServicesTbl` (`elementId`),
  CONSTRAINT `PackageDetailTbltoElementServicesTbl` FOREIGN KEY (`elementId`) REFERENCES `elementservicestbl` (`elementid`),
  CONSTRAINT `PackageDetailTbltoPackageTbl` FOREIGN KEY (`packageName`) REFERENCES `packagetbl` (`packageName`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.packagedetailtbl: ~0 rows (approximately)
DELETE FROM `packagedetailtbl`;
/*!40000 ALTER TABLE `packagedetailtbl` DISABLE KEYS */;
/*!40000 ALTER TABLE `packagedetailtbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.packagetbl
DROP TABLE IF EXISTS `packagetbl`;
CREATE TABLE IF NOT EXISTS `packagetbl` (
  `packageName` varchar(255) NOT NULL,
  `comodityNo` int(11) DEFAULT NULL,
  `analysisTypeName` varchar(255) DEFAULT NULL,
  `multipleSelectedItem` char(1) DEFAULT NULL,
  `bundlePrice` decimal(12,2) DEFAULT NULL,
  `additionalPrice1` decimal(12,2) DEFAULT NULL,
  `additionalPrice2` decimal(12,2) DEFAULT NULL,
  `additionalPriceDesc1` varchar(255) DEFAULT NULL,
  `additionalPriceDesc2` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`packageName`),
  KEY `PackageTbltoComodityTbl` (`comodityNo`),
  KEY `PackageTbltoAnalysisTypeTbl` (`analysisTypeName`),
  CONSTRAINT `PackageTbltoAnalysisTypeTbl` FOREIGN KEY (`analysisTypeName`) REFERENCES `analysistypetbl` (`analysisTypeName`),
  CONSTRAINT `PackageTbltoComodityTbl` FOREIGN KEY (`comodityNo`) REFERENCES `comoditytbl` (`comodityNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.packagetbl: ~7 rows (approximately)
DELETE FROM `packagetbl`;
/*!40000 ALTER TABLE `packagetbl` DISABLE KEYS */;
INSERT INTO `packagetbl` (`packageName`, `comodityNo`, `analysisTypeName`, `multipleSelectedItem`, `bundlePrice`, `additionalPrice1`, `additionalPrice2`, `additionalPriceDesc1`, `additionalPriceDesc2`) VALUES
	('ASAM HUMAT Cair', 2, 'Kimia', '1', 454000.00, NULL, NULL, NULL, NULL),
	('ASAM HUMAT PADAT ', 1, 'Kimia', '1', 568000.00, NULL, NULL, NULL, NULL),
	('Pupuk Hayati Tunggal Ektomikoriza (Kepmentan 261/KPTS/SR.310/M/4/2019)', 18, 'Kimia', '1', 425000.00, NULL, NULL, NULL, NULL),
	('Pupuk Hayati Tunggal Endomikoriza Arbuskular (Kepmentan 261/KPTS/SR.310/M/4/2019)', 17, 'Kimia', '1', 575000.00, NULL, NULL, NULL, NULL),
	('PUPUK ORGANIK CAIR (Kepmentan 261/KPTS/SR.310/M/4/2019)', 15, 'Kimia', '1', 1150000.00, NULL, NULL, NULL, NULL),
	('PUPUK ORGANIK PADAT (Kepmentan 261/KPTS/SR.310/M/4/2019) (DIPERKAYA MIKROBA)', 14, 'Kimia', '1', 1096000.00, NULL, NULL, NULL, NULL),
	('PUPUK ORGANIK PADAT (SNI 7763:2018)  (TANPA DIPERKAYA MIKROBA)', 13, 'Kimia', '1', 1024000.00, NULL, NULL, NULL, NULL);
/*!40000 ALTER TABLE `packagetbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.parameterstbl
DROP TABLE IF EXISTS `parameterstbl`;
CREATE TABLE IF NOT EXISTS `parameterstbl` (
  `parametersNo` int(11) NOT NULL AUTO_INCREMENT,
  `string0` varchar(255) DEFAULT NULL,
  `string1` varchar(255) DEFAULT NULL,
  `string2` varchar(255) DEFAULT NULL,
  `string3` varchar(255) DEFAULT NULL,
  `string4` varchar(255) DEFAULT NULL,
  `string5` varchar(255) DEFAULT NULL,
  `string6` varchar(255) DEFAULT NULL,
  `string7` varchar(255) DEFAULT NULL,
  `string8` varchar(255) DEFAULT NULL,
  `string9` varchar(255) DEFAULT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`parametersNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.parameterstbl: ~0 rows (approximately)
DELETE FROM `parameterstbl`;
/*!40000 ALTER TABLE `parameterstbl` DISABLE KEYS */;
/*!40000 ALTER TABLE `parameterstbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.resulttbl
DROP TABLE IF EXISTS `resulttbl`;
CREATE TABLE IF NOT EXISTS `resulttbl` (
  `resultNo` int(11) NOT NULL AUTO_INCREMENT,
  `orderNo` varchar(30) NOT NULL,
  `reviewingNo` int(11) DEFAULT NULL,
  `url` text,
  `fileName` varchar(255) DEFAULT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`resultNo`),
  KEY `ResultTbltoOrderMasterTbl` (`orderNo`),
  KEY `ResultTbltoReviewingTbl` (`reviewingNo`),
  CONSTRAINT `ResultTbltoOrderMasterTbl` FOREIGN KEY (`orderNo`) REFERENCES `ordermastertbl` (`orderNo`),
  CONSTRAINT `ResultTbltoReviewingTbl` FOREIGN KEY (`reviewingNo`) REFERENCES `reviewingtbl` (`reviewingNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.resulttbl: ~0 rows (approximately)
DELETE FROM `resulttbl`;
/*!40000 ALTER TABLE `resulttbl` DISABLE KEYS */;
/*!40000 ALTER TABLE `resulttbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.reviewingtbl
DROP TABLE IF EXISTS `reviewingtbl`;
CREATE TABLE IF NOT EXISTS `reviewingtbl` (
  `reviewingNo` int(11) NOT NULL AUTO_INCREMENT,
  `orderNo` varchar(30) NOT NULL,
  `elementCodeList` text,
  `reviewingDate` datetime DEFAULT NULL,
  `isLabUtilitySurfficient` char(1) DEFAULT NULL,
  `isHumanResourceSurfficient` char(1) DEFAULT NULL,
  `isChemicalMaterialSurfficent` char(1) DEFAULT NULL,
  `isVolumeCorrect` char(1) DEFAULT NULL,
  `workdays` int(11) DEFAULT NULL,
  `isMethode` char(1) DEFAULT NULL,
  `isQualityStandard` char(1) DEFAULT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`reviewingNo`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.reviewingtbl: ~0 rows (approximately)
DELETE FROM `reviewingtbl`;
/*!40000 ALTER TABLE `reviewingtbl` DISABLE KEYS */;
/*!40000 ALTER TABLE `reviewingtbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.roletbl
DROP TABLE IF EXISTS `roletbl`;
CREATE TABLE IF NOT EXISTS `roletbl` (
  `roleName` varchar(255) NOT NULL,
  `description` text,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`roleName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.roletbl: ~8 rows (approximately)
DELETE FROM `roletbl`;
/*!40000 ALTER TABLE `roletbl` DISABLE KEYS */;
INSERT INTO `roletbl` (`roleName`, `description`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	('admin', 'hak akses untuk akun admin', '', '2019-08-24 17:02:59', '', '2019-08-27 17:03:19'),
	('analis', 'hak akses untuk analis', '', '2019-08-24 17:23:39', NULL, NULL),
	('cs', 'hak akses untuk cs', ' ', '2019-08-24 17:22:20', NULL, NULL),
	('evaluator', 'hak akses untuk evaluator', '', '2019-08-24 17:23:13', NULL, NULL),
	('kasir', 'hak akses untuk kasir', ' ', '2019-08-24 17:22:20', NULL, NULL),
	('manajer teknis', 'hak akses untuk manajer teknis', '', '2019-08-24 17:22:56', NULL, NULL),
	('pelanggan', 'hak akses untuk pelanggan', '', '2019-08-24 17:21:58', NULL, NULL),
	('penyelia', 'hak akses untuk penyelia', '', '2019-08-24 17:22:20', NULL, NULL);
/*!40000 ALTER TABLE `roletbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.standarddetailtbl
DROP TABLE IF EXISTS `standarddetailtbl`;
CREATE TABLE IF NOT EXISTS `standarddetailtbl` (
  `stdDetailId` int(11) NOT NULL AUTO_INCREMENT,
  `stdId` int(11) NOT NULL,
  `elementId` int(11) NOT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`stdDetailId`),
  KEY `StandardDetailTbltoStandardTbl` (`stdId`),
  KEY `StandardDetailTbltoElementServicesTbl` (`elementId`),
  CONSTRAINT `StandardDetailTbltoElementServicesTbl` FOREIGN KEY (`elementId`) REFERENCES `elementservicestbl` (`elementid`),
  CONSTRAINT `StandardDetailTbltoStandardTbl` FOREIGN KEY (`stdId`) REFERENCES `standardtbl` (`stdId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.standarddetailtbl: ~0 rows (approximately)
DELETE FROM `standarddetailtbl`;
/*!40000 ALTER TABLE `standarddetailtbl` DISABLE KEYS */;
/*!40000 ALTER TABLE `standarddetailtbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.standardtbl
DROP TABLE IF EXISTS `standardtbl`;
CREATE TABLE IF NOT EXISTS `standardtbl` (
  `stdId` int(11) NOT NULL AUTO_INCREMENT,
  `stdNo` varchar(255) NOT NULL,
  `comodityNo` int(11) DEFAULT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`stdId`),
  KEY `StandartdTbltoComodityTbl` (`comodityNo`),
  CONSTRAINT `StandartdTbltoComodityTbl` FOREIGN KEY (`comodityNo`) REFERENCES `comoditytbl` (`comodityNo`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.standardtbl: ~0 rows (approximately)
DELETE FROM `standardtbl`;
/*!40000 ALTER TABLE `standardtbl` DISABLE KEYS */;
/*!40000 ALTER TABLE `standardtbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.workflowlogtbl
DROP TABLE IF EXISTS `workflowlogtbl`;
CREATE TABLE IF NOT EXISTS `workflowlogtbl` (
  `workflowLogNo` int(11) NOT NULL AUTO_INCREMENT,
  `resourceNo` varchar(30) NOT NULL,
  `task` varchar(255) DEFAULT NULL,
  `taskDesctiption` text,
  `lastStatus` varchar(255) DEFAULT NULL,
  `message` varchar(255) DEFAULT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  PRIMARY KEY (`workflowLogNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.workflowlogtbl: ~0 rows (approximately)
DELETE FROM `workflowlogtbl`;
/*!40000 ALTER TABLE `workflowlogtbl` DISABLE KEYS */;
/*!40000 ALTER TABLE `workflowlogtbl` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;

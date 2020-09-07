-- --------------------------------------------------------
-- Host:                         balittanahpelayanan.mysql.database.azure.com
-- Server version:               5.6.45-log - MySQL Community Server (GPL)
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
) ENGINE=InnoDB AUTO_INCREMENT=1276 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.accounttbl: ~62 rows (approximately)
DELETE FROM `accounttbl`;
/*!40000 ALTER TABLE `accounttbl` DISABLE KEYS */;
INSERT INTO `accounttbl` (`accountNo`, `username`, `password`, `roleName`, `isEmailVerified`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	(1161, 'manager1@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'manajer teknis', '1', '', '2019-09-02 09:58:05', NULL, NULL),
	(1162, 'analis1@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-09-02 09:59:35', NULL, NULL),
	(1163, 'evaluator1@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'evaluator', '1', '', '2019-09-02 10:04:32', NULL, NULL),
	(1164, 'kasir1@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'kasir', '1', '', '2019-09-02 10:06:52', NULL, NULL),
	(1165, 'cs1@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'cs', '1', '', '2019-09-02 10:07:53', NULL, NULL),
	(1166, 'penyelia1@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'penyelia', '1', '', '2019-09-02 10:44:53', NULL, NULL),
	(1187, 'administrator@pertanian.go.id', 'zpzUuvOKbDu1sxHlYL9fSA==', 'admin', '1', '', '2019-12-10 05:44:55', NULL, NULL),
	(1202, 'erny_yuniarti@yahoo.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'manajer teknis', '1', '', '2019-12-10 11:36:08', NULL, NULL),
	(1203, 'elsantianti21@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'penyelia', '1', '', '2019-12-10 11:43:21', NULL, NULL),
	(1204, 'eepsyaiful64@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-10 11:57:59', NULL, NULL),
	(1205, 'Jjumena17@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-10 12:00:36', NULL, NULL),
	(1206, 'aramadh3@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-10 12:01:41', NULL, NULL),
	(1207, 'ratri.ariani@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'manajer teknis', '1', '', '2019-12-10 12:03:50', NULL, NULL),
	(1208, 'arifbudiyantobudiyanto@yahoo.co.id', 'zpzUuvOKbDu1sxHlYL9fSA==', 'penyelia', '1', '', '2019-12-10 12:31:48', NULL, NULL),
	(1209, 'atinkurdiana@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-10 12:33:36', NULL, NULL),
	(1210, 'gatiyogasuripto@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-10 12:34:24', NULL, NULL),
	(1211, 'musrahman36153@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-10 12:35:40', NULL, NULL),
	(1212, 'jamaldul4634@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-10 12:36:24', NULL, NULL),
	(1213, 'leanfa.la3ll@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'admin', '1', '', '2019-12-10 12:37:55', NULL, NULL),
	(1214, 'firman_geo11@yahoo.co.id', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-10 12:38:42', NULL, NULL),
	(1217, 'land_nn@yahoo.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'manajer teknis', '1', '', '2019-12-12 13:59:02', NULL, NULL),
	(1219, 'hestiekatantika@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'penyelia', '1', '', '2019-12-12 14:02:16', NULL, NULL),
	(1220, 'pujiningrum@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'penyelia', '1', '', '2019-12-12 14:03:41', NULL, NULL),
	(1221, 'iindwisurhati85@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'penyelia', '1', '', '2019-12-12 14:04:53', NULL, NULL),
	(1222, 'usman_randika@yahoo.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'penyelia', '1', '', '2019-12-12 14:07:22', NULL, NULL),
	(1223, 'margi.hastuti@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 14:10:14', NULL, NULL),
	(1224, 'ekaindrasetiaman2425@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 14:23:42', NULL, NULL),
	(1225, 'fajarachmad.2009@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 14:27:17', NULL, NULL),
	(1226, 'analis_iindwisurhati85@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 14:32:16', NULL, NULL),
	(1227, 'awp1146@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 14:45:42', NULL, NULL),
	(1228, 'yadialamtirta@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 14:52:36', NULL, NULL),
	(1229, 'lintang.candra27@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 15:00:17', NULL, NULL),
	(1230, 'audilanandisya@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 15:07:22', NULL, NULL),
	(1231, 'analis_pujiningrum@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 15:34:34', NULL, NULL),
	(1232, 'zulfikarp24@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 15:35:38', NULL, NULL),
	(1234, 'firnas.muldiansyah@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 15:36:45', NULL, NULL),
	(1235, 'marisyakurniasari@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 15:37:39', NULL, NULL),
	(1236, 'debbynuksm@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 15:38:21', NULL, NULL),
	(1237, 'sunarya.sr@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 15:39:23', NULL, NULL),
	(1238, 'ramafadli20@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 15:42:31', NULL, NULL),
	(1239, 'rini.prihatini.rp@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 15:43:52', NULL, NULL),
	(1241, 'anggrainirenyta@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 15:44:35', NULL, NULL),
	(1242, 'godrealm971@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'pelanggan', '1', 'anonymous', '2019-12-12 16:04:37', NULL, NULL),
	(1243, 'novie.ekaps@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 16:08:25', NULL, NULL),
	(1244, 'marig.hastuti@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 16:09:28', NULL, NULL),
	(1245, 'ikhwan.labkim@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 16:12:54', NULL, NULL),
	(1246, 'roni.labkim@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 16:13:46', NULL, NULL),
	(1247, 'prayudi.labkim@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 16:15:23', NULL, NULL),
	(1251, 'midahpratama@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'cs', '1', '', '2019-12-12 16:30:34', NULL, NULL),
	(1252, 'didik.suristyo@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'cs', '1', '', '2019-12-12 16:36:34', NULL, NULL),
	(1253, 'ikamardikas@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'cs', '1', '', '2019-12-12 16:38:27', NULL, NULL),
	(1256, 'auliarisma102@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'kasir', '1', '', '2019-12-12 16:42:00', NULL, NULL),
	(1257, 'idede1465@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 16:45:54', NULL, NULL),
	(1259, 'dedisu931@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 16:47:38', NULL, NULL),
	(1260, 'supriadiadi320@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 16:49:30', NULL, NULL),
	(1261, 'andiandi666666666@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '1', '', '2019-12-12 16:51:32', NULL, NULL),
	(1263, 'galihyprtm@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'pelanggan', '1', 'godrealm971@gmail.com', '2019-12-12 17:00:29', NULL, NULL),
	(1264, 'scarletwitchd28@gmail.com', 'v7l12H6PQQWMtfFg0EmGDg==', 'pelanggan', '1', 'anonymous', '2019-12-12 19:54:54', NULL, NULL),
	(1265, 'customer1@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'pelanggan', '1', 'anonymous', '2019-12-12 20:02:27', NULL, NULL),
	(1266, 'haisany@outlook.com', 'v7l12H6PQQWMtfFg0EmGDg==', 'pelanggan', '1', 'anonymous', '2019-12-13 09:34:49', NULL, NULL),
	(1267, 'kustomer1@outlook.co.id', 'zpzUuvOKbDu1sxHlYL9fSA==', 'pelanggan', '1', 'anonymous', '2019-12-13 10:04:14', NULL, NULL),
	(1268, 'markusandas@yahoo.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'manajer teknis', '0', '', '2019-12-13 11:27:31', NULL, NULL),
	(1269, 'tentremtiti42@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'penyelia', '0', '', '2019-12-13 11:32:34', NULL, NULL),
	(1270, 'yacehidayat@pertanian.go.id', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '0', '', '2019-12-13 11:34:13', NULL, NULL),
	(1271, 'antoniusfrasisco@pertanian.go.id', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '0', '', '2019-12-13 11:36:15', NULL, NULL),
	(1272, 'a.abubakar@pertanian.go.id', 'zpzUuvOKbDu1sxHlYL9fSA==', 'analis', '0', '', '2019-12-13 11:37:02', NULL, NULL),
	(1273, 'sukristyohastono@yahoo.co.uk', 'UM0Swg00mdmMtfFg0EmGDg==', 'pelanggan', '0', 'anonymous', '2019-12-16 13:58:42', NULL, NULL),
	(1274, 'umara234@gmail.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'pelanggan', '0', 'anonymous', '2019-12-16 13:58:53', NULL, NULL),
	(1275, 'januartharamadhan@yahoo.com', 'zpzUuvOKbDu1sxHlYL9fSA==', 'pelanggan', '0', 'anonymous', '2019-12-16 14:09:53', NULL, NULL);
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

-- Dumping data for table smlpob.analysistypetbl: ~4 rows (approximately)
DELETE FROM `analysistypetbl`;
/*!40000 ALTER TABLE `analysistypetbl` DISABLE KEYS */;
INSERT INTO `analysistypetbl` (`analysisTypeName`, `description`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	('Biologi', 'analisis di lab biologi', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	('Fisika', 'analisis di lab fisika\r\n', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	('Kimia', 'analisis dilakukan di lab kimia', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	('Mineralogi', 'analisis di lab mineralogi', 'admin', '2019-12-10 10:34:47', NULL, NULL);
/*!40000 ALTER TABLE `analysistypetbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.autonumbertbl
DROP TABLE IF EXISTS `autonumbertbl`;
CREATE TABLE IF NOT EXISTS `autonumbertbl` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `NameSet` varchar(10) NOT NULL DEFAULT 'General',
  `LastCounter` bigint(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.autonumbertbl: ~2 rows (approximately)
DELETE FROM `autonumbertbl`;
/*!40000 ALTER TABLE `autonumbertbl` DISABLE KEYS */;
INSERT INTO `autonumbertbl` (`Id`, `NameSet`, `LastCounter`) VALUES
	(1, 'BALITTANAH', 97),
	(2, 'SAMPEL', 108),
	(3, 'BATCHNO', 14);
/*!40000 ALTER TABLE `autonumbertbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.batchtbl
DROP TABLE IF EXISTS `batchtbl`;
CREATE TABLE IF NOT EXISTS `batchtbl` (
  `batchId` varchar(15) NOT NULL,
  `filename` varchar(255) DEFAULT NULL,
  `status` varchar(255) DEFAULT 'Menunggu',
  `fileurl` text,
  `pic_analis` int(11) DEFAULT NULL,
  `pic_penyelia` int(11) DEFAULT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`batchId`),
  KEY `BatchTblToEmployeeTbl` (`pic_analis`),
  KEY `FK_batchtbl_employeetbl` (`pic_penyelia`),
  CONSTRAINT `BatchTblToEmployeeTbl` FOREIGN KEY (`pic_analis`) REFERENCES `employeetbl` (`employeeNo`),
  CONSTRAINT `FK_batchtbl_employeetbl` FOREIGN KEY (`pic_penyelia`) REFERENCES `employeetbl` (`employeeNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.batchtbl: ~0 rows (approximately)
DELETE FROM `batchtbl`;
/*!40000 ALTER TABLE `batchtbl` DISABLE KEYS */;
INSERT INTO `batchtbl` (`batchId`, `filename`, `status`, `fileurl`, `pic_analis`, `pic_penyelia`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	('B-00013/12/2019', 'batch_analis1@gmail.com_13Des2019_Mc9JTIvlg9.xlsx', 'Selesai', 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/batch_analis1@gmail.com_13Des2019_Mc9JTIvlg9.xlsx', 10, 14, 'penyelia1@gmail.com', '2019-12-13 09:38:40', 'penyelia1@gmail.com', '2019-12-13 09:38:40');
/*!40000 ALTER TABLE `batchtbl` ENABLE KEYS */;

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
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.comoditytbl: ~28 rows (approximately)
DELETE FROM `comoditytbl`;
/*!40000 ALTER TABLE `comoditytbl` DISABLE KEYS */;
INSERT INTO `comoditytbl` (`comodityNo`, `comodityName`, `derivativeTo`, `description`, `code`, `notes`, `isPackage`, `creaBy`, `creaDate`, `modBy`, `modDate`, `isGenusAvailable`, `priceGenusPerSample`, `isHeavyMetalAvailable`, `limitDoseForFreeOfHeavyMetal`, `priceHeavyMetalPerSample`) VALUES
	(1, 'ASAM HUMAT PADAT ', -1, '', 'K.P.', '', '1', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(2, 'ASAM HUMAT CAIR', -1, '', 'K.P.', '', '1', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(3, 'PUPUK MAKRO TUNGGAL PADAT', -1, '', 'K.P.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(4, 'PUPUK MAKRO TUNGGAL CAIR', -1, '', 'K.P.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(5, 'PUPUK MAKRO MAJEMUK PADAT', -1, '', 'K.P.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(6, 'PUPUK MAKRO MAJEMUK CAIR', -1, '', 'K.P.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(7, 'PUPUK MIKRO TUNGGAL PADAT', -1, '', 'K.P.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(8, 'PUPUK MIKRO TUNGGAL CAIR', -1, '', 'K.P.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(9, 'PUPUK MIKRO MAJEMUK PADAT', -1, '', 'K.P.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(10, 'PUPUK MIKRO MAJEMUK CAIR', -1, '', 'K.P.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(11, 'PUPUK CAMPURAN MAKRO-MIKRO PADAT', -1, '', 'K.P.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(12, 'PUPUK CAMPURAN MAKRO-MIKRO CAIR', -1, '', 'K.P.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(13, 'PUPUK ORGANIK PADAT (SNI 7763:2018)  (TANPA DIPERKAYA MIKROBA)', -1, '', 'K.P.', '', '1', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(14, 'PUPUK ORGANIK PADAT (Kepmentan 261/KPTS/SR.310/M/4/2019) (DIPERKAYA MIKROBA)', -1, '', 'K.P.', '', '1', NULL, NULL, NULL, NULL, '1', 125000.00, '0', NULL, NULL),
	(15, 'PUPUK ORGANIK CAIR (Kepmentan 261/KPTS/SR.310/M/4/2019)', -1, '', 'K.P.', '', '1', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(16, 'PUPUK HAYATI TUNGGAL PADAT DAN CAIR', -1, 'Uji Logam berat pilihan tergantung dosis pupuk hayati tunggal, bila dosis lebih besar sama dengan 50 kg/ha atau lebih besar sama dengan 50 L/ha maka uji logam berat (As, Hg, Pb, Cd, Hg, As, Cr, Ni) wajib dilakukan sehingga biaya per sampel akan ditambahkan sebesar Rp.382.000,- (termasuk persiapan, uji kadar air, dan ekstrak total) sehingga menjadi a + Rp.382.000,- dan Total Biaya=(a+Rp. 382.000,-) x b', 'K.P.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '1', 50, 382000.00),
	(17, 'Pupuk Hayati Tunggal Endomikoriza Arbuskular (Kepmentan 261/KPTS/SR.310/M/4/2019)', -1, 'Uji Logam berat pilihan tergantung dosis pupuk hayati tunggal, bila dosis lebih besar sama dengan 50 kg/ha atau lebih besar sama dengan 50 L/ha maka uji logam berat (As, Hg, Pb, Cd, Hg, As, Cr, Ni) wajib dilakukan sehingga biaya per sampel akan ditambahkan sebesar Rp.382.000,- (termasuk persiapan, uji kadar air, dan ekstrak total) sehingga menjadi a + Rp.382.000,- dan Total Biaya=(a+Rp. 382.000,-) x b', 'K.P.', '', '1', NULL, NULL, NULL, NULL, '0', 0.00, '1', 50, 382000.00),
	(18, 'Pupuk Hayati Tunggal Ektomikoriza (Kepmentan 261/KPTS/SR.310/M/4/2019)', -1, 'Uji Logam berat pilihan tergantung dosis pupuk hayati tunggal, bila dosis lebih besar sama dengan 50 kg/ha atau lebih besar sama dengan 50 L/ha maka uji logam berat (As, Hg, Pb, Cd, Hg, As, Cr, Ni) wajib dilakukan sehingga biaya per sampel akan ditambahkan sebesar Rp.382.000,- (termasuk persiapan, uji kadar air, dan ekstrak total) sehingga menjadi a + Rp.382.000,- dan Total Biaya=(a+Rp. 382.000,-) x b', 'K.P.', '', '1', NULL, NULL, NULL, NULL, '0', 0.00, '1', 50, 382000.00),
	(19, 'PUPUK HAYATI MAJEMUK PADAT DAN CAIR UNTUK 2 GENUS (Kepmentan 261/KPTS/SR.310/M/4/2019)', -1, '', 'K.P.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(20, 'PUPUK HAYATI MAJEMUK PADAT DAN CAIR UNTUK >2 GENUS (Kepmentan 261/KPTS/SR.310/M/4/2019)', -1, '', 'K.P.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(21, 'Tanah Rutin', -1, '', 'K.Th.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(22, 'Tanah Khusus', -1, '', 'K.Th.', '', '0', NULL, NULL, NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(23, 'CONTOH TANAH', -1, NULL, 'B.Th.', ' ', '0', 'admin', '2019-12-10 00:00:00', NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(24, 'CONTOH PUPUK HAYATI', -1, NULL, 'B.P.', NULL, '0', 'admin', '2019-12-10 00:00:00', NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(25, 'PEMBENAH TANAH', -1, NULL, 'B.Th.', NULL, '0', 'admin', '2019-12-10 00:00:00', NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(26, 'MINERAL TANAH', -1, NULL, 'M.Th.', NULL, '0', 'admin', '2019-12-10 00:00:00', NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(27, 'FISIKA TANAH', -1, NULL, 'F.Th.', NULL, '0', 'admin', '2019-12-10 00:00:00', NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(28, 'TANAMAN', -1, NULL, 'K.T.', NULL, '0', 'admin', '2019-12-10 00:00:00', NULL, NULL, '0', 0.00, '0', NULL, NULL),
	(29, 'AIR', -1, NULL, 'K.A', NULL, '0', 'admin', '2019-12-10 00:00:00', NULL, NULL, '0', 0.00, '0', NULL, NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=1187 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.customertbl: ~8 rows (approximately)
DELETE FROM `customertbl`;
/*!40000 ALTER TABLE `customertbl` DISABLE KEYS */;
INSERT INTO `customertbl` (`customerNo`, `customerName`, `customerEmail`, `companyName`, `companyAddress`, `companyPhone`, `companyEmail`, `accountNo`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	(1179, 'galihyprtm', 'galihyprtm@gmail.com', 'gravicode', 'jl melati', '08712345678', 'galih.gvc@gmail.com', 1263, 'godrealm971@gmail.com', '2019-12-12 17:00:29', NULL, NULL),
	(1180, 'sany', 'scarletwitchd28@gmail.com', 'neotech', 'nowhere', '089603563536', 'scarletwitchd28@gmail.com', 1264, 'anonymous', '2019-12-12 19:54:54', NULL, NULL),
	(1181, 'customer1', 'customer1@gmail.com', 'gvc', 'bogor', '089123123123', 'customer1@office.com', 1265, 'anonymous', '2019-12-12 20:02:27', NULL, NULL),
	(1182, 'sanysunny', 'haisany@outlook.com', 'sunnycorp', 'sunnycorp', '085715386857', 'haisany@outlook.com', 1266, 'anonymous', '2019-12-13 09:34:49', NULL, NULL),
	(1183, 'Asep Surmadi', 'kustomer1@outlook.co.id', 'PT Pupuk Asin', 'Jl Asem Garem Bumi Ayu Kertanegara', '08174810345', 'kustomer1@outlook.co.id', 1267, 'anonymous', '2019-12-13 10:04:14', NULL, NULL),
	(1184, 'didik', 'sukristyohastono@yahoo.co.uk', 'PT.Maju Mundur Jaya', 'tentara Pelajar', '081575927021', 'sukristyohastono@yahoo.co.uk', 1273, 'anonymous', '2019-12-16 13:58:42', NULL, NULL),
	(1185, 'kustomer9', 'umara234@gmail.com', 'company', 'bogor', '081123123789', 'umara234@comp.com', 1274, 'anonymous', '2019-12-16 13:58:53', NULL, NULL),
	(1186, 'jeje', 'januartharamadhan@yahoo.com', 'company', 'bogor', '087123456712', 'januartharamadhan@comp.com', 1275, 'anonymous', '2019-12-16 14:09:53', NULL, NULL);
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
  `elementCode` varchar(500) NOT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=403 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.elementservicestbl: ~378 rows (approximately)
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
	(285, 'P-CaCl2 0,01 M', 22, 'Kimia', '-', '', 24000.00, 'Tersedia', 'General', 10, '0', NULL, NULL, NULL, NULL),
	(286, 'Jumlah Nematoda', 23, 'Biologi', '-', 'MESOFAUNA', 125000.00, 'Tersedia', 'General', 1, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(287, 'Jumlah total bakteri aerob heterotrof', 23, 'Biologi', '-', 'BAKTERI', 150000.00, 'Tersedia', 'General', 2, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(288, 'Jumlah total bakter anerob heterotrof', 23, 'Biologi', '-', 'BAKTERI', 250000.00, 'Tersedia', 'General', 3, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(289, 'Jumlah rhizobium bradirhzobium sp', 23, 'Biologi', '-', 'BAKTERI', 150000.00, 'Tersedia', 'General', 4, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(290, 'Jumlah Azospirillum sp', 23, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 5, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(291, 'Jumlah Azotobacter sp', 23, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 6, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(292, 'Jumlah Pseudomonas sp', 23, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 7, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(293, 'Jumlah Bacillus sp', 23, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 8, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(294, 'Jumlah Bakteri Penambat Nitrogen', 23, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 9, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(295, 'Jumlah Bakteri Pelarut Fosfat', 23, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 10, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(296, 'Jumlah Bakteri Selulolitik', 23, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 11, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(297, 'Jumlah Bakteri Kitinolitik', 23, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 12, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(298, 'Jumlah Bakteri Lipolitik', 23, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 13, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(299, 'Jumlah Bakteri Proteolitik', 23, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 14, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(300, 'Jumlah Bakteri Nitrobacter sp', 23, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 15, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(301, 'Jumlah Bakteri Nitrosomonas sp', 23, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 16, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(302, 'Jumlah total fungi', 23, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 17, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(303, 'Jumlah Mikoriza', 23, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 18, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(304, 'Jumlah Trichoderma sp', 23, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 19, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(305, 'Jumlah Aspergillus sp', 23, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 20, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(306, 'Jumlah Saccharomyces sp', 23, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 21, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(307, 'Jumlah Fungi Pelarut Fosfat', 23, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 22, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(308, 'Jumlah Fungi Selulolitik', 23, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 23, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(309, 'Jumlah Fungi Lipolitik', 23, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 24, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(310, 'Jumlah Fungi Proteolitik', 23, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 25, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(311, 'Jumlah Fungi Lignolitik', 23, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 26, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(312, 'Jumlah Actinomycetes', 23, 'Biologi', '-', 'AKTINOMISET', 125000.00, 'Tersedia', 'General', 27, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(313, 'Jumlah Streptomyces sp', 23, 'Biologi', '-', 'AKTINOMISET', 125000.00, 'Tersedia', 'General', 28, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(314, 'Aktivitas Reduksi Asetilen (ARA)', 23, 'Biologi', '-', 'AKTIVITAS MIKROBA', 200000.00, 'Tersedia', 'General', 29, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(315, 'Aktivitas Dehidrogenase', 23, 'Biologi', '-', 'AKTIVITAS MIKROBA', 150000.00, 'Tersedia', 'General', 30, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(316, 'Respirasi', 23, 'Biologi', '-', 'AKTIVITAS MIKROBA', 50000.00, 'Tersedia', 'General', 31, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(317, 'C-microba', 23, 'Biologi', '-', 'AKTIVITAS MIKROBA', 75000.00, 'Tersedia', 'General', 32, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(318, 'pH', 23, 'Biologi', '-', 'Kimia dan Fisik Contoh Tanah', 15000.00, 'Tersedia', 'General', 33, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(319, 'Kadar Air', 23, 'Biologi', '-', 'Kimia dan Fisik Contoh Tanah', 15000.00, 'Tersedia', 'General', 34, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(320, 'Jumlah total bakteri aerob heterotrop', 24, 'Biologi', '-', 'BAKTERI', 150000.00, 'Tersedia', 'General', 1, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(321, 'Jumlah total bakteri anerob heterotrop', 24, 'Biologi', '-', 'BAKTERI', 250000.00, 'Tersedia', 'General', 2, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(322, 'Jumlah Rhizobium/Bradirhyzobium sp', 24, 'Biologi', '-', 'BAKTERI', 150000.00, 'Tersedia', 'General', 3, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(323, 'Jumlah Azospirillum sp', 24, 'Biologi', '-', 'BAKTERI', 150000.00, 'Tersedia', 'General', 4, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(324, 'Jumlah Azotobacter sp', 24, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 5, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(325, 'Jumlah Pseudomonas sp', 24, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 6, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(326, 'Jumlah Bacillus sp', 24, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 7, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(327, 'Jumlah Lactobacillus sp', 24, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 8, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(328, 'Total Coliform (MPN)', 24, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 9, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(329, 'Jumlah E.Coli  (MPN)', 24, 'Biologi', '-', 'BAKTERI', 150000.00, 'Tersedia', 'General', 10, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(330, 'Jumlah Salmonella sp', 24, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 11, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(331, 'Jumlah Bakteri Penambat Nitrogen', 24, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 12, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(332, 'Jumlah Bakteri Pelarut Fosfat', 24, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 13, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(333, 'Jumlah Bakteri Selulolitik', 24, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 14, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(334, 'Jumlah Bakteri Kitinolitik', 24, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 15, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(335, 'Jumlah Bakteri Lipolitik', 24, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 16, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(336, 'Jumlah Bakteri Proteolitik', 24, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 17, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(337, 'Jumlah Bakteri Micrococcus sp', 24, 'Biologi', '-', 'BAKTERI', 125000.00, 'Tersedia', 'General', 18, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(338, 'Total Fungi', 24, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 19, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(339, 'Jumlah Mikoriza', 24, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 20, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(340, 'Jumlah Trichoderma sp', 24, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 21, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(341, 'Jumlah Aspergillus sp', 24, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 22, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(342, 'Jumlah Saccharomyces sp', 24, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 23, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(343, 'Jumlah Fungi Pelarut Fosfat', 24, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 24, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(344, 'Jumlah Fungi Selulolitik', 24, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 25, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(345, 'JumlahFungi Lipolitik', 24, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 26, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(346, 'Jumlah Fungi Proteolitik', 24, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 27, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(347, 'Jumlah Fungi Lignolitik', 24, 'Biologi', '-', 'FUNGI', 125000.00, 'Tersedia', 'General', 28, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(348, 'Jumlah Actinomycetes', 24, 'Biologi', '-', 'AKTINOMISET', 125000.00, 'Tersedia', 'General', 29, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(349, 'Jumlah Streptomyces sp', 24, 'Biologi', '-', 'AKTINOMISET', 125000.00, 'Tersedia', 'General', 30, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(350, 'Uji Patogenitas pada tanaman', 24, 'Biologi', '-', 'UJI PATOGENITAS', 150000.00, 'Tersedia', 'General', 31, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(351, 'Aktivitas Reduksi Asetilen ( Kuantitatif)', 24, 'Biologi', '-', 'AKTIVITAS MIKROBA', 200000.00, 'Tersedia', 'General', 32, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(352, 'Aktivitas Penambata N (Kualitatif)', 24, 'Biologi', '-', 'AKTIVITAS MIKROBA', 50000.00, 'Tersedia', 'General', 33, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(353, 'Aktivitas Pelarut Fosfat (Kuantitatif)', 24, 'Biologi', '-', 'AKTIVITAS MIKROBA', 200000.00, 'Tersedia', 'General', 34, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(354, 'Aktivitas Pelarutan Fosfat (Kualitatif)', 24, 'Biologi', '-', 'AKTIVITAS MIKROBA', 50000.00, 'Tersedia', 'General', 35, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(355, 'Produksi Fitohormon IAA (Spektrofotometer)', 24, 'Biologi', '-', 'AKTIVITAS MIKROBA', 200000.00, 'Tersedia', 'General', 36, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(356, 'Aktivitas Perombak Bahan Organik (Kualitatif)', 24, 'Biologi', '-', 'AKTIVITAS MIKROBA', 50000.00, 'Tersedia', 'General', 37, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(357, 'pH', 24, 'Biologi', '-', 'Kimia dan Fisik', 15000.00, 'Tersedia', 'General', 38, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(358, 'Kadar Air', 24, 'Biologi', '-', 'Kimia dan Fisik', 15000.00, 'Tersedia', 'General', 39, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(359, 'Jumlah mikroba penghasil Exopolisakarida', 25, 'Biologi', '-', '', 125000.00, 'Tersedia', 'General', 49, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(360, 'Produksi Exopolisakarida (kualitatif)', 25, 'Biologi', '-', '', 50000.00, 'Tersedia', 'General', 50, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(361, 'Jumlah mikroba pengakumulasi logam berat', 25, 'Biologi', '-', '', 125000.00, 'Tersedia', 'General', 51, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(362, 'Akumulasi Logam Berat (Kualitatif)', 25, 'Biologi', '-', '', 50000.00, 'Tersedia', 'General', 52, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(363, 'Fraksi Total', 26, 'Mineralogi', '-', 'TANAH MINERAL', 100000.00, 'Tersedia', 'General', 1, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(364, 'Mineral Liat', 26, 'Mineralogi', '-', 'TANAH MINERAL', 400000.00, 'Tersedia', 'General', 2, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(365, 'Persiapan contoh', 27, 'Fisika', '-', 'TANAH MINERAL', 18000.00, 'Tersedia', 'General', 1, '1', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(366, '2b. Penetapan Particle Density (PD) + Bulk Density (BD) + perhitungan Ruang Pori Total (RPT) dari contoh dalam tabung standar', 27, 'Fisika', '-', 'TANAH MINERAL', 52500.00, 'Tersedia', 'General', 2, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(367, '2a. Bulk Density (BD) parafin', 27, 'Fisika', '-', 'TANAH MINERAL', 52000.00, 'Tersedia', 'General', 2, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(368, 'Penetapan kadar air pada pF1, pF2, pF2.54, dan pF4.2  dan  perhitungan pori drainase cepat dan lambat, serta air tersedia', 27, 'Fisika', '-', 'TANAH MINERAL', 80000.00, 'Tersedia', 'General', 3, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(369, '4b. Penetapan permeabilitas, contoh tanah di dalam ring/tabung standar Balittanah', 27, 'Fisika', '-', 'TANAH MINERAL', 22500.00, 'Tersedia', 'General', 4, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(370, '4a. Contoh tanah di dalam ring/tabung tidak standar Balittanah', 27, 'Fisika', '-', 'TANAH MINERAL', 40000.00, 'Tersedia', 'General', 4, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(371, 'Penetapan permeabilitas, contoh tanah di dalam ring/tabung tidak standar Balittanah', 27, 'Fisika', '-', 'TANAH MINERAL', 25000.00, 'Tersedia', 'General', 5, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(372, '6b. Penetapan Indeks Kemantapan Agregat (IKA)', 27, 'Fisika', '-', 'TANAH MINERAL', 18000.00, 'Tersedia', 'General', 6, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(373, '6a. Water Agregat Stability', 27, 'Fisika', '-', 'TANAH MINERAL', 21000.00, 'Tersedia', 'General', 6, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(374, 'Penetapan Laju Perkolasi', 27, 'Fisika', '-', 'TANAH MINERAL', 25000.00, 'Tersedia', 'General', 7, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(375, 'Penetapan Coeficient of linear Extensibility (COLE) tanah', 27, 'Fisika', '-', 'TANAH MINERAL', 27500.00, 'Tersedia', 'General', 8, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(376, 'Penetapan Kandungan air optimum untuk pengolahan', 27, 'Fisika', '-', 'TANAH MINERAL', 13500.00, 'Tersedia', 'General', 9, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(377, 'Penetapan tekstur 3 fraksi', 27, 'Fisika', '-', 'TANAH MINERAL', 30000.00, 'Tersedia', 'General', 10, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(378, 'Penetapan tekstur 4 fraksi', 27, 'Fisika', '-', 'TANAH MINERAL', 31500.00, 'Tersedia', 'General', 11, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(379, 'Penetapan tekstur 10 fraksi', 27, 'Fisika', '-', 'TANAH MINERAL', 55000.00, 'Tersedia', 'General', 12, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(380, 'Penetapan C-organik menggunakan metode LOI (pengabuan kering)', 27, 'Fisika', '-', 'TANAH MINERAL', 15000.00, 'Tersedia', 'General', 13, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(381, 'Penetapan luas permukaan', 27, 'Fisika', '-', 'TANAH MINERAL', 90000.00, 'Tersedia', 'General', 14, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(382, 'Penetapan jumlah pori mikro', 27, 'Fisika', '-', 'TANAH MINERAL', 90000.00, 'Tersedia', 'General', 15, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(383, 'Persiapan contoh (memisahkan contoh dari kemasannya)', 27, 'Fisika', '-', 'TANAH ORGANIK/GAMBUT', 15000.00, 'Tersedia', 'General', 16, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(384, 'Penetapan berat volume', 27, 'Fisika', '-', 'TANAH ORGANIK/GAMBUT', 12500.00, 'Tersedia', 'General', 17, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(385, 'Penetapan bahan organik dengan metode LOI (pengabuan)', 27, 'Fisika', '-', 'TANAH ORGANIK/GAMBUT', 17500.00, 'Tersedia', 'General', 18, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(386, 'Penetapan kadar serat', 27, 'Fisika', '-', 'TANAH ORGANIK/GAMBUT', 12000.00, 'Tersedia', 'General', 19, '0', 'admin', '2019-12-10 10:34:47', NULL, NULL),
	(387, 'Z', 0, 'Biologi', NULL, '', 1000.00, 'Tersedia', NULL, NULL, NULL, '', '2019-12-11 11:05:26', NULL, NULL),
	(388, 'As', 0, 'Biologi', NULL, 'As', 12312.00, 'Tersedia', NULL, NULL, NULL, '', '2019-12-11 14:18:51', NULL, NULL),
	(389, 'Persiapan Contoh', 28, 'Kimia', '-', 'TANAMAN', 18000.00, 'Tersedia', 'General', 1, '1', 'admin', '2019-12-11 14:18:51', NULL, NULL),
	(390, 'C Organik', 28, 'Kimia', '-', 'TANAMAN', 24000.00, 'Tersedia', 'General', 2, '0', 'admin', '2019-12-11 14:18:51', NULL, NULL),
	(391, 'N-Kjeldahl', 28, 'Kimia', '-', 'TANAMAN', 30000.00, 'Tersedia', 'General', 3, '0', 'admin', '2019-12-11 14:18:51', NULL, NULL),
	(392, 'Ekstrak Total unsur makro dan mikro (Ekstraksi Rp 30.000,-Pengukuran P,K, Na, Fe, Mn, Cu, Zn @ Rp 12.000,- Ca, Mg, S @ Rp 18.000,- Al, B @ Rp 24.000,-)', 28, 'Kimia', '-', 'TANAMAN', 216000.00, 'Tersedia', 'General', 4, '0', 'admin', '2019-12-11 14:18:51', NULL, NULL),
	(393, 'Ekstrak Total logam berat (ppm):  (Ekstraksi Rp 35.000,- Pengukuran Pb, Cd, Co, Cr, Ni, Mo,   Ag, Sn, Se, As @ Rp  24.000,-)', 28, 'Kimia', '-', 'TANAMAN', 275000.00, 'Tersedia', 'General', 5, '0', 'admin', '2019-12-11 14:18:51', NULL, NULL),
	(394, 'Ekstrak Total logam berat (ppb) : (Ekstraksi Rp 35.000,- Pengukuran Pb, Cd, Co, Cr, Ni, Mo, Ag, Sn, Se, As, Hg @ Rp 70.000,-)', 28, 'Kimia', '-', 'TANAMAN', 827000.00, 'Tersedia', 'General', 6, '0', 'admin', '2019-12-11 14:18:51', NULL, NULL),
	(395, 'Kadar Abu dan Silikat Kasar  : (Ekstraksi Rp 12.000,- abu dan silikat @ Rp 18.000,-)', 28, 'Kimia', '-', 'TANAMAN', 48000.00, 'Tersedia', 'General', 7, '0', 'admin', '2019-12-11 14:18:51', NULL, NULL),
	(396, 'Kadar Lumpur', 29, 'Kimia', '-', 'AIR', 18000.00, 'Tersedia', 'General', 1, '0', 'admin', '2019-12-11 14:18:51', NULL, NULL),
	(397, 'pH', 29, 'Kimia', '-', 'AIR', 14000.00, 'Tersedia', 'General', 2, '0', 'admin', '2019-12-11 14:18:51', NULL, NULL),
	(398, 'Salinitas / EC (DHL)', 29, 'Kimia', '-', 'AIR', 14000.00, 'Tersedia', 'General', 3, '0', 'admin', '2019-12-11 14:18:51', NULL, NULL),
	(399, 'Kation : (K, Na, Fe, Mn, Cu, Zn @ Rp 19.000,- NH4, Ca, Mg @ Rp 15.000,-  B, Al (AAS) @ Rp 24.000,-)', 29, 'Kimia', '-', 'AIR', 216000.00, 'Tersedia', 'General', 4, '0', 'admin', '2019-12-11 14:18:51', NULL, NULL),
	(400, 'Anion : (PO4, SO4, Cl, CO3, HCO3 @ Rp 18.000,-  NO3, BO3 @ Rp 24.000,-)', 29, 'Kimia', '-', 'AIR', 138000.00, 'Tersedia', 'General', 5, '0', 'admin', '2019-12-11 14:18:51', NULL, NULL),
	(401, 'Pengukuran logam berat (ppm) : (Pb, Cd, Co, Cr, Ni, Mo, Ag, Se, Sn, As @ Rp 24.000,-)', 29, 'Kimia', '-', 'AIR', 240000.00, 'Tersedia', 'General', 6, '0', 'admin', '2019-12-11 14:18:51', NULL, NULL),
	(402, 'Pengukuran logam berat (ppb) : (Pb, Cd, Co, Cr, Ni, Mo, Ag, Se, Sn, As, Hg @ Rp 70.000,-)', 29, 'Kimia', '-', 'AIR', 770000.00, 'Tersedia', 'General', 7, '0', 'admin', '2019-12-11 14:18:51', NULL, NULL);
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
  `laboratoriumID` int(11) DEFAULT NULL,
  PRIMARY KEY (`employeeNo`),
  KEY `EmployeeTblAccountTbl` (`accountNo`),
  KEY `EmployeeTblLaboratoriumTbl` (`laboratoriumID`),
  CONSTRAINT `EmployeeTblAccountTbl` FOREIGN KEY (`accountNo`) REFERENCES `accounttbl` (`accountNo`),
  CONSTRAINT `EmployeeTblLaboratoriumTbl` FOREIGN KEY (`laboratoriumID`) REFERENCES `laboratoriumtbl` (`laboratoriumID`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=100 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.employeetbl: ~59 rows (approximately)
DELETE FROM `employeetbl`;
/*!40000 ALTER TABLE `employeetbl` DISABLE KEYS */;
INSERT INTO `employeetbl` (`employeeNo`, `employeeName`, `position`, `employeeEmail`, `derivativeToEmployee`, `accountNo`, `creaBy`, `creaDate`, `modBy`, `modDate`, `laboratoriumID`) VALUES
	(10, 'analis1', 'analis', 'analis1@gmail.com', 9, 1162, '', '2019-09-02 10:00:38', NULL, NULL, 3),
	(11, 'evaluator1', 'evaluator', 'evaluator1@gmail.com', 9, 1163, '', '2019-09-02 10:05:33', NULL, NULL, 1),
	(12, 'kasir1', 'kasir', 'kasir1@gmail.com', -1, 1164, '', '2019-09-02 10:07:19', '', '2019-09-02 10:07:32', 1),
	(13, 'cs1', 'customer service', 'cs1@gmail.com', -1, 1165, '', '2019-09-02 10:08:26', NULL, NULL, 1),
	(14, 'penyelia1', 'penyelia', 'penyelia1@gmail.com', 9, 1166, '', '2019-09-02 10:45:19', NULL, NULL, 3),
	(20, 'Erny Yuniarti', 'manajer teknis', 'erny_yuniarti@yahoo.com', -1, 1202, '', '2019-12-10 11:53:17', NULL, NULL, 2),
	(39, 'Elsanti ', 'penyelia', 'elsantianti21@gmail.com', 20, 1203, '', '2019-12-10 11:56:47', NULL, NULL, 2),
	(40, 'Eep Saefulah ', 'analis', 'eepsyaiful64@gmail.com', 39, 1204, '', '2019-12-10 12:00:11', NULL, NULL, 2),
	(41, 'Jumena', 'analis', 'Jjumena17@gmail.com', 39, 1205, '', '2019-12-10 12:01:12', NULL, NULL, 2),
	(42, 'Ari Rizki Ramadhan', 'analis', 'aramadh3@gmail.com', 39, 1206, '', '2019-12-10 12:02:07', NULL, NULL, 2),
	(43, 'Ratri Ariani, SP', 'manajer teknis', 'ratri.ariani@gmail.com', -1, 1207, '', '2019-12-10 12:04:14', NULL, NULL, 3),
	(45, 'Arif Budiyanto, S.Si', 'penyelia', 'arifbudiyantobudiyanto@yahoo.co.id', 43, 1208, '', '2019-12-10 12:32:58', NULL, NULL, 3),
	(46, 'Atin Kurdiana, SP', 'analis', 'atinkurdiana@gmail.com', 45, 1209, '', '2019-12-10 12:34:05', NULL, NULL, 3),
	(47, 'Gati Yoga S.', 'analis', 'gatiyogasuripto@gmail.com', 45, 1210, '', '2019-12-10 12:34:57', '', '2019-12-10 12:37:28', 3),
	(48, 'Musrahman', 'analis', 'musrahman36153@gmail.com', 45, 1211, '', '2019-12-10 12:36:04', '', '2019-12-10 12:37:16', 3),
	(49, 'Elang', 'analis', 'jamaldul4634@gmail.com', 45, 1212, '', '2019-12-10 12:37:04', NULL, NULL, 3),
	(50, 'Laely Nurfahmi', 'analis', 'leanfa.la3ll@gmail.com', 45, 1213, '', '2019-12-10 12:38:24', NULL, NULL, 3),
	(51, 'Firman Fermana Agung', 'analis', 'firman_geo11@yahoo.co.id', 45, 1214, '', '2019-12-10 12:39:15', NULL, NULL, 3),
	(56, 'Lenita Herawaty, M.Si', 'manajer teknis', 'land_nn@yahoo.com', -1, 1217, '', '2019-12-12 14:00:04', NULL, NULL, 1),
	(58, 'Hesti', 'penyelia', 'hestiekatantika@gmail.com', 56, 1219, '', '2019-12-12 14:03:00', NULL, NULL, 1),
	(59, 'Puji', 'penyelia', 'pujiningrum@gmail.com', 56, 1220, '', '2019-12-12 14:04:15', NULL, NULL, 1),
	(60, 'Iin', 'penyelia', 'iindwisurhati85@gmail.com', 56, 1221, '', '2019-12-12 14:05:30', NULL, NULL, 1),
	(61, 'Usman', 'penyelia', 'usman_randika@yahoo.com', 56, 1222, '', '2019-12-12 14:07:53', NULL, NULL, 1),
	(62, 'Margi', 'analis', 'margi.hastuti@gmail.com', 61, 1223, '', '2019-12-12 14:12:08', NULL, NULL, 1),
	(63, 'Eka', 'analis', 'ekaindrasetiaman2425@gmail.com', 60, 1224, '', '2019-12-12 14:24:23', NULL, NULL, 1),
	(64, 'Fajar', 'analis', 'fajarachmad.2009@gmail.com', 60, 1225, '', '2019-12-12 14:28:04', NULL, NULL, 1),
	(65, 'Iin', 'analis', 'iindwisurhati85@gmail.com', 60, 1226, '', '2019-12-12 14:31:21', '', '2019-12-12 14:32:58', 1),
	(66, 'Andhika', 'analis', 'awp1146@gmail.com', 59, 1227, '', '2019-12-12 14:46:17', NULL, '2019-12-13 10:32:12', 1),
	(67, 'Yadi', 'analis', 'yadialamtirta@gmail.com', 59, 1228, '', '2019-12-12 14:53:10', NULL, NULL, 1),
	(68, 'Lintang', 'analis', 'lintang.candra27@gmail.com', 59, 1229, '', '2019-12-12 15:01:53', NULL, NULL, 1),
	(69, 'Dila', 'analis', 'audilanandisya@gmail.com', 59, 1230, '', '2019-12-12 15:34:08', NULL, NULL, 1),
	(70, 'Puji', 'analis', 'pujiningrum@gmail.com', 59, 1231, '', '2019-12-12 15:34:57', NULL, NULL, 1),
	(71, 'Zulfikar', 'analis', 'zulfikarp24@gmail.com', 58, 1232, '', '2019-12-12 15:36:06', NULL, NULL, 1),
	(72, 'Firnas', 'analis', 'firnas.muldiansyah@gmail.com', 58, 1234, '', '2019-12-12 15:37:05', NULL, NULL, 1),
	(73, 'Marisya', 'analis', 'marisyakurniasari@gmail.com', 58, 1235, '', '2019-12-12 15:37:58', NULL, NULL, 1),
	(74, 'Deby', 'analis', 'debbynuksm@gmail.com', 58, 1236, '', '2019-12-12 15:39:00', NULL, NULL, 1),
	(75, 'Sunarya', 'analis', 'sunarya.sr@gmail.com', 58, 1237, '', '2019-12-12 15:39:48', NULL, NULL, 1),
	(76, 'Rama', 'analis', 'ramafadli20@gmail.com', 58, 1238, '', '2019-12-12 15:43:07', NULL, NULL, 1),
	(77, 'Rini', 'analis', 'rini.prihatini.rp@gmail.com', 58, 1239, '', '2019-12-12 15:44:14', NULL, NULL, 1),
	(78, 'Reni', 'analis', 'anggrainirenyta@gmail.com', 58, 1241, '', '2019-12-12 15:45:05', NULL, NULL, 1),
	(79, 'Novie', 'analsi', 'novie.ekaps@gmail.com', 58, 1243, '', '2019-12-12 16:09:11', NULL, NULL, 1),
	(80, 'Margi', 'analis', 'marig.hastuti@gmail.com', 58, 1244, '', '2019-12-12 16:09:46', NULL, NULL, 1),
	(81, 'Ikhwan', 'analis', 'ikhwan.labkim@gmail.com', 58, 1245, '', '2019-12-12 16:13:26', NULL, NULL, 1),
	(82, 'Roni', 'analis', 'roni.labkim@gmail.com', 58, 1246, '', '2019-12-12 16:14:16', NULL, NULL, 1),
	(83, 'Prayudi', 'analis', 'prayudi.labkim@gmail.com', 58, 1247, '', '2019-12-12 16:15:55', NULL, NULL, 1),
	(85, 'Jubaedah', 'cs', 'midahpratama@gmail.com', -1, 1251, '', '2019-12-12 16:31:37', NULL, NULL, NULL),
	(86, 'Didik suristyo hastono', 'cs', 'didik.suristyo@gmail.com', -1, 1252, '', '2019-12-12 16:37:26', NULL, NULL, NULL),
	(87, 'Ika mardika sari', 'cs', 'ikamardikas@gmail.com', -1, 1253, '', '2019-12-12 16:38:51', NULL, NULL, NULL),
	(88, 'suryati', 'kasir', 'auliarisma102@gmail.com', -1, 1256, '', '2019-12-12 16:42:26', NULL, NULL, NULL),
	(89, 'Dede Iskandar', 'analis', 'idede1465@gmail.com', 39, 1257, '', '2019-12-12 16:46:40', NULL, NULL, NULL),
	(90, 'Dedi supriadi', 'analis', 'dedisu931@gmail.com', 39, 1259, '', '2019-12-12 16:48:20', NULL, NULL, NULL),
	(91, 'Yadi supriadi', 'analis', 'supriadiadi320@gmail.com', 39, 1260, '', '2019-12-12 16:50:08', NULL, NULL, NULL),
	(92, 'Andi', 'analis', 'andiandi666666666@gmail.com', 39, 1261, '', '2019-12-12 16:51:56', NULL, NULL, NULL),
	(93, 'Manager Teknis Balittanah', 'Manager Teknis', 'manager1@gmail.com', 56, 1161, '', '2019-12-13 10:18:54', '', '2019-12-13 10:19:52', 3),
	(94, 'Dr. Markus Anda', 'manajer teknis', 'markusandas@yahoo.com', -1, 1268, '', '2019-12-13 11:28:36', NULL, NULL, 4),
	(95, 'Titi Tentrem', 'penyelia', 'tentremtiti42@gmail.com', 94, 1269, '', '2019-12-13 11:33:42', NULL, NULL, 4),
	(96, 'Yace Muhamad Hidayat', 'analis', 'yacehidayat@pertanian.go.id', 95, 1270, '', '2019-12-13 11:34:44', NULL, NULL, 4),
	(97, 'Antonius Fransisco Nababan', 'analis', 'antoniusfrasisco@pertanian.go.id', 95, 1271, '', '2019-12-13 11:36:43', NULL, NULL, 4),
	(98, 'A. Abubakar', 'analis', 'a.abubakar@pertanian.go.id', 95, 1272, '', '2019-12-13 11:37:27', NULL, NULL, 4);
/*!40000 ALTER TABLE `employeetbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.genustbl
DROP TABLE IF EXISTS `genustbl`;
CREATE TABLE IF NOT EXISTS `genustbl` (
  `genusId` int(11) NOT NULL AUTO_INCREMENT,
  `genusName` varchar(100) NOT NULL,
  `Cost` decimal(12,2) NOT NULL,
  `comodityNo` int(11) NOT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`genusId`),
  KEY `GenusPerComodityTbltoComodityTbl` (`comodityNo`),
  CONSTRAINT `GenusPerComodityTbltoComodityTbl` FOREIGN KEY (`comodityNo`) REFERENCES `comoditytbl` (`comodityNo`)
) ENGINE=InnoDB AUTO_INCREMENT=83 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.genustbl: ~41 rows (approximately)
DELETE FROM `genustbl`;
/*!40000 ALTER TABLE `genustbl` DISABLE KEYS */;
INSERT INTO `genustbl` (`genusId`, `genusName`, `Cost`, `comodityNo`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	(3, 'Total perhitungan cawan total (plate count) mikroba (aerob) ( Total Bakteri )', 150000.00, 19, NULL, NULL, NULL, NULL),
	(4, 'Total perhitungan cawan total (plate count) mikroba (anaerob)', 250000.00, 19, NULL, NULL, NULL, NULL),
	(24, 'Jumlah Rhizobium/Bradirhyzobium sp', 150000.00, 19, NULL, NULL, NULL, NULL),
	(25, 'Jumlah Azospirillum sp', 150000.00, 19, NULL, NULL, NULL, NULL),
	(26, 'Jumlah Azotobacter sp', 125000.00, 19, NULL, NULL, NULL, NULL),
	(27, 'Jumlah Pseudomonas sp', 125000.00, 19, NULL, NULL, NULL, NULL),
	(28, 'Jumlah Bacillus sp', 125000.00, 19, NULL, NULL, NULL, NULL),
	(29, 'Jumlah Lactobacillus sp', 125000.00, 19, NULL, NULL, NULL, NULL),
	(30, 'Total Coliform', 125000.00, 19, NULL, NULL, NULL, NULL),
	(31, 'Jumlah E.Coli', 150000.00, 19, NULL, NULL, NULL, NULL),
	(32, 'Jumlah Salmonella sp', 150000.00, 19, NULL, NULL, NULL, NULL),
	(33, 'Jumlah Bakteri Penambat Nitrogen', 125000.00, 19, NULL, NULL, NULL, NULL),
	(34, 'Jumlah Bakteri Pelarut Fosfat', 125000.00, 19, NULL, NULL, NULL, NULL),
	(35, 'Jumlah Bakteri Selulolitik', 125000.00, 19, NULL, NULL, NULL, NULL),
	(36, 'Jumlah Bakteri Kitinolitik', 125000.00, 19, NULL, NULL, NULL, NULL),
	(37, 'Jumlah Bakteri Lipolitik', 125000.00, 19, NULL, NULL, NULL, NULL),
	(38, 'Jumlah Bakteri Proteolitik', 125000.00, 19, NULL, NULL, NULL, NULL),
	(39, 'Jumlah Bakteri Cytophaga', 125000.00, 19, NULL, NULL, NULL, NULL),
	(40, 'Jumlah Bakteri Micrococcus', 125000.00, 19, NULL, NULL, NULL, NULL),
	(41, 'Total Fungi', 125000.00, 19, NULL, NULL, NULL, NULL),
	(42, 'Jumlah Mikoriza', 125000.00, 19, NULL, NULL, NULL, NULL),
	(43, 'Jumlah Trichoderma sp', 125000.00, 19, NULL, NULL, NULL, NULL),
	(44, 'Jumlah Aspergillus sp', 125000.00, 19, NULL, NULL, NULL, NULL),
	(45, 'Jumlah Saccharomyces sp', 125000.00, 19, NULL, NULL, NULL, NULL),
	(46, 'Jumlah Fungi Pelarut Fosfat', 125000.00, 19, NULL, NULL, NULL, NULL),
	(47, 'Jumlah Fungi Selulolitik', 125000.00, 19, NULL, NULL, NULL, NULL),
	(48, 'Total Fungi Lipolitik', 125000.00, 19, NULL, NULL, NULL, NULL),
	(49, 'Jumlah Fungi Proteolitik', 125000.00, 19, NULL, NULL, NULL, NULL),
	(50, 'Jumlah Fungi Lignolitik', 125000.00, 19, NULL, NULL, NULL, NULL),
	(51, 'Jumlah Actinomycetes', 125000.00, 19, NULL, NULL, NULL, NULL),
	(72, 'Jumlah Streptomyces sp', 125000.00, 19, NULL, NULL, NULL, NULL),
	(73, 'Uji Patogenitas pada tanaman', 150000.00, 19, NULL, NULL, NULL, NULL),
	(74, 'Aktivitas Reduksi Asetilen ( Kuantitatif)', 200000.00, 19, NULL, NULL, NULL, NULL),
	(75, 'Aktivitas Penambata N (Kualitatif)', 50000.00, 19, NULL, NULL, NULL, NULL),
	(76, 'Aktivitas Pelarut Fosfat (Kuantitatif)', 200000.00, 19, NULL, NULL, NULL, NULL),
	(77, 'Aktivitas Pelarutan Fosfat (Kualitatif)', 50000.00, 19, NULL, NULL, NULL, NULL),
	(78, 'Produksi Fitohormon IAA (Spektrofotometer)', 200000.00, 19, NULL, NULL, NULL, NULL),
	(79, 'Aktivitas Perombak Bahan Organik (Kualitatif)', 50000.00, 19, NULL, NULL, NULL, NULL),
	(80, 'pH', 15000.00, 19, NULL, NULL, NULL, NULL),
	(81, 'Kadar Air', 15000.00, 19, NULL, NULL, NULL, NULL),
	(82, 'Total perhitungan cawan total (plate count) mikroba (aerob) ( Total Bakteri )', 150000.00, 20, NULL, NULL, NULL, NULL);
/*!40000 ALTER TABLE `genustbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.laboratoriumtbl
DROP TABLE IF EXISTS `laboratoriumtbl`;
CREATE TABLE IF NOT EXISTS `laboratoriumtbl` (
  `laboratoriumID` int(11) NOT NULL,
  `laboratoriumName` varchar(255) NOT NULL,
  `laboratoriumStatus` char(1) NOT NULL,
  PRIMARY KEY (`laboratoriumID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.laboratoriumtbl: ~4 rows (approximately)
DELETE FROM `laboratoriumtbl`;
/*!40000 ALTER TABLE `laboratoriumtbl` DISABLE KEYS */;
INSERT INTO `laboratoriumtbl` (`laboratoriumID`, `laboratoriumName`, `laboratoriumStatus`) VALUES
	(1, 'Kimia', '1'),
	(2, 'Biologi', '1'),
	(3, 'Fisika', '1'),
	(4, 'Mineralogi', '1');
/*!40000 ALTER TABLE `laboratoriumtbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.logtbl
DROP TABLE IF EXISTS `logtbl`;
CREATE TABLE IF NOT EXISTS `logtbl` (
  `logId` int(11) NOT NULL AUTO_INCREMENT,
  `source` varchar(255) DEFAULT NULL,
  `description` text,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  PRIMARY KEY (`logId`)
) ENGINE=InnoDB AUTO_INCREMENT=681 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.logtbl: ~121 rows (approximately)
DELETE FROM `logtbl`;
/*!40000 ALTER TABLE `logtbl` DISABLE KEYS */;
INSERT INTO `logtbl` (`logId`, `source`, `description`, `creaBy`, `creaDate`) VALUES
	(560, 'AccountControls', 'An error occurred while updating the entries. See the inner exception for details.', '', '2019-12-12 12:00:59'),
	(561, 'AccountControls', 'An error occurred while updating the entries. See the inner exception for details.', '', '2019-12-12 12:13:49'),
	(562, 'AccountControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-12 13:00:44'),
	(563, 'ASP.pages_public_login_aspx', 'Login error:An exception occurred. Please check the Event Log.', 'godrealm971@gmail.com', '2019-12-12 13:03:01'),
	(564, 'ASP.pages_public_login_aspx', 'Login error:An exception occurred. Please check the Event Log.', 'godrealm971@gmail.com', '2019-12-12 13:03:30'),
	(565, 'ASP.pages_public_login_aspx', 'Login error:An exception occurred. Please check the Event Log.', 'anna@gmail.com', '2019-12-12 13:08:56'),
	(566, 'ASP.pages_public_login_aspx', 'Login error:Unable to read data from the transport connection: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.', 'anna@gmail.com', '2019-12-12 13:09:42'),
	(567, 'ASP.pages_public_login_aspx', 'Login error:An exception occurred. Please check the Event Log.', 'anna@gmail.com', '2019-12-12 13:10:27'),
	(568, 'ASP.pages_public_login_aspx', 'Login error:Connection must be valid and open to rollback transaction', 'godrealm971@gmail.com', '2019-12-12 13:33:21'),
	(569, 'ASP.pages_public_login_aspx', 'Login error:An exception occurred. Please check the Event Log.', 'godrealm971@gmail.com', '2019-12-12 13:33:54'),
	(570, 'AccountControls', 'An error occurred while updating the entries. See the inner exception for details.', '', '2019-12-12 13:34:27'),
	(571, 'AccountControls', 'An error occurred while updating the entries. See the inner exception for details.', '', '2019-12-12 13:34:51'),
	(572, 'ASP.pages_public_login_aspx', 'Login error:The underlying provider failed on Open.', 'godrealm971@gmail.com', '2019-12-12 13:38:55'),
	(573, 'AccountControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-12 13:40:35'),
	(574, 'ASP.pages_public_login_aspx', 'Login error:The underlying provider failed on Open.', 'anonymous', '2019-12-12 14:19:40'),
	(575, 'AccountControls', 'The underlying provider failed on Open.', '', '2019-12-12 14:50:03'),
	(576, 'AccountControls', 'System.IO.IOException: Unable to read data from the transport connection: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond. ---> System.Net.Sockets.SocketException: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond\r\n   at System.Net.Sockets.Socket.Receive(Byte[] buffer, Int32 offset, Int32 size, SocketFlags socketFlags)\r\n   at System.Net.Sockets.NetworkStream.Read(Byte[] buffer, Int32 offset, Int32 size)\r\n   --- End of inner exception stack trace ---\r\n   at System.Net.Sockets.NetworkStream.Read(Byte[] buffer, Int32 offset, Int32 size)\r\n   at MySql.Data.Common.MyNetworkStream.Read(Byte[] buffer, Int32 offset, Int32 count)', '', '2019-12-12 15:00:48'),
	(577, 'ASP.pages_public_registerform_aspx', 'fail to register user:Trial Version Expired!', 'anonymous', '2019-12-12 15:44:13'),
	(578, 'ASP.pages_public_registerform_aspx', 'fail to register user:Thread was being aborted.', 'anonymous', '2019-12-12 16:04:41'),
	(579, 'AccountControls', 'System.Data.Entity.Core.UpdateException: An error occurred while updating the entries. See the inner exception for details. ---> MySql.Data.MySqlClient.MySqlException: Cannot delete or update a parent row: a foreign key constraint fails ("smlpob"."employeetbl", CONSTRAINT "EmployeeTblAccountTbl" FOREIGN KEY ("accountNo") REFERENCES "accounttbl" ("accountNo"))\r\n   at MySql.Data.MySqlClient.MySqlStream.ReadPacket()\r\n   at MySql.Data.MySqlClient.NativeDriver.GetResult(Int32& affectedRow, Int64& insertedId)\r\n   at MySql.Data.MySqlClient.Driver.GetResult(Int32 statementId, Int32& affectedRows, Int64& insertedId)\r\n   at MySql.Data.MySqlClient.Driver.NextResult(Int32 statementId, Boolean force)\r\n   at MySql.Data.MySqlClient.MySqlDataReader.NextResult()\r\n   at MySql.Data.MySqlClient.MySqlCommand.ExecuteReader(CommandBehavior behavior)\r\n   at MySql.Data.MySqlClient.MySqlCommand.ExecuteNonQuery()\r\n   at MySql.Data.Entity.EFMySqlCommand.ExecuteNonQuery()\r\n   at System.Data.Common.DbCommand.ExecuteNonQueryAsync(CancellationToken cancellationToken)\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at System.Data.Entity.Utilities.TaskExtensions.CultureAwaiter`1.GetResult()\r\n   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.<ExecuteAsync>d__0.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()\r\n   --- End of inner exception stack trace ---\r\n   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at System.Data.Entity.Core.Objects.ObjectContext.<ExecuteInTransactionAsync>d__3d`1.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesToStoreAsync>d__39.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesInternalAsync>d__31.MoveNext()', '', '2019-12-12 16:27:57'),
	(580, 'AccountControls', 'System.Data.Entity.Core.UpdateException: An error occurred while updating the entries. See the inner exception for details. ---> MySql.Data.MySqlClient.MySqlException: Cannot delete or update a parent row: a foreign key constraint fails ("smlpob"."employeetbl", CONSTRAINT "EmployeeTblAccountTbl" FOREIGN KEY ("accountNo") REFERENCES "accounttbl" ("accountNo"))\r\n   at MySql.Data.MySqlClient.MySqlStream.ReadPacket()\r\n   at MySql.Data.MySqlClient.NativeDriver.GetResult(Int32& affectedRow, Int64& insertedId)\r\n   at MySql.Data.MySqlClient.Driver.GetResult(Int32 statementId, Int32& affectedRows, Int64& insertedId)\r\n   at MySql.Data.MySqlClient.Driver.NextResult(Int32 statementId, Boolean force)\r\n   at MySql.Data.MySqlClient.MySqlDataReader.NextResult()\r\n   at MySql.Data.MySqlClient.MySqlCommand.ExecuteReader(CommandBehavior behavior)\r\n   at MySql.Data.MySqlClient.MySqlCommand.ExecuteNonQuery()\r\n   at MySql.Data.Entity.EFMySqlCommand.ExecuteNonQuery()\r\n   at System.Data.Common.DbCommand.ExecuteNonQueryAsync(CancellationToken cancellationToken)\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at System.Data.Entity.Utilities.TaskExtensions.CultureAwaiter`1.GetResult()\r\n   at System.Data.Entity.Core.Mapping.Update.Internal.DynamicUpdateCommand.<ExecuteAsync>d__0.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()\r\n   --- End of inner exception stack trace ---\r\n   at System.Data.Entity.Core.Mapping.Update.Internal.UpdateTranslator.<UpdateAsync>d__0.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at System.Data.Entity.Core.Objects.ObjectContext.<ExecuteInTransactionAsync>d__3d`1.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesToStoreAsync>d__39.MoveNext()\r\n--- End of stack trace from previous location where exception was thrown ---\r\n   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)\r\n   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)\r\n   at System.Data.Entity.Core.Objects.ObjectContext.<SaveChangesInternalAsync>d__31.MoveNext()', '', '2019-12-12 16:28:08'),
	(581, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'godrealm971@gmail.com', '2019-12-12 16:28:16'),
	(582, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'godrealm971@gmail.com', '2019-12-12 16:29:06'),
	(583, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'godrealm971@gmail.com', '2019-12-12 16:29:11'),
	(584, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'godrealm971@gmail.com', '2019-12-12 16:29:47'),
	(585, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'godrealm971@gmail.com', '2019-12-12 16:29:56'),
	(586, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'godrealm971@gmail.com', '2019-12-12 16:32:24'),
	(587, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'anonymous', '2019-12-12 16:33:46'),
	(588, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'anonymous', '2019-12-12 16:34:10'),
	(589, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'anonymous', '2019-12-12 16:34:27'),
	(590, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'godrealm971@gmail.com', '2019-12-12 16:37:43'),
	(591, 'ASP.pages_public_registerform_aspx', 'fail to register user:Trial Version Expired!', 'godrealm971@gmail.com', '2019-12-12 16:41:48'),
	(592, 'ASP.pages_public_registerform_aspx', 'fail to register user:Trial Version Expired!', 'godrealm971@gmail.com', '2019-12-12 16:47:00'),
	(593, 'ASP.pages_public_registerform_aspx', 'fail to register user:Trial Version Expired!', 'godrealm971@gmail.com', '2019-12-12 16:55:31'),
	(594, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'anonymous', '2019-12-12 16:56:24'),
	(595, 'ASP.pages_public_registerform_aspx', 'fail to register user:Trial Version Expired!', 'godrealm971@gmail.com', '2019-12-12 17:00:29'),
	(596, 'StandardControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-12 18:28:14'),
	(597, 'StandardControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-12 18:36:07'),
	(598, 'StandardControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-12 19:06:51'),
	(599, 'ASP.pages_public_registerform_aspx', 'fail to register user:Trial Version Expired!', 'anonymous', '2019-12-12 19:54:55'),
	(600, 'ASP.pages_public_registerform_aspx', 'fail to register user:Thread was being aborted.', 'anonymous', '2019-12-12 20:03:04'),
	(601, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-12-12 20:52:00'),
	(602, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-12-12 21:01:38'),
	(603, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-12-13 09:34:42'),
	(604, 'ASP.pages_public_registerform_aspx', 'fail to register user:Trial Version Expired!', 'anonymous', '2019-12-13 09:34:50'),
	(605, 'ASP.pages_private_penyelia_rincian_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-13 09:48:25'),
	(606, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-12-13 09:58:05'),
	(607, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-12-13 09:58:57'),
	(608, 'ASP.pages_public_registerform_aspx', 'fail to register user:Thread was being aborted.', 'anonymous', '2019-12-13 10:04:16'),
	(609, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-12-13 10:13:25'),
	(610, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-12-13 10:31:35'),
	(611, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-13 10:48:15'),
	(612, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-13 10:48:33'),
	(613, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-13 10:48:50'),
	(614, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-13 10:49:15'),
	(615, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-13 10:50:54'),
	(616, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-13 10:51:08'),
	(617, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-13 10:52:13'),
	(618, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-13 10:53:10'),
	(619, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-12-13 10:53:46'),
	(620, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-13 10:56:38'),
	(621, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-13 10:56:43'),
	(622, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-12-13 11:02:31'),
	(623, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-13 11:23:28'),
	(624, 'ASP.pages_private_evaluator_evaluasihasildetail_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'evaluator1@gmail.com', '2019-12-13 11:23:53'),
	(625, '<BlobPostAsync>d__0', 'The specified resource does not exist.', 'System', '2019-12-15 15:43:57'),
	(626, '<BlobPostAsync>d__0', 'The specified resource does not exist.', 'System', '2019-12-15 15:44:16'),
	(627, '<BlobPostAsync>d__0', 'The specified resource does not exist.', 'System', '2019-12-15 15:45:17'),
	(628, '<BlobPostAsync>d__0', 'The specified resource does not exist.', 'System', '2019-12-15 20:26:22'),
	(629, '<BlobPostAsync>d__0', 'The specified resource does not exist.', 'System', '2019-12-15 20:26:49'),
	(630, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-12-15 20:31:00'),
	(631, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-12-15 20:37:04'),
	(632, '<BlobPostAsync>d__0', 'The specified resource does not exist.', 'System', '2019-12-15 20:38:47'),
	(633, '<BlobPostAsync>d__0', 'The specified resource does not exist.', 'System', '2019-12-15 20:38:49'),
	(634, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-15 21:10:23'),
	(635, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-15 21:12:28'),
	(636, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-15 21:13:06'),
	(637, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-15 21:13:32'),
	(638, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-15 21:17:49'),
	(639, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-15 21:18:37'),
	(640, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-15 21:19:04'),
	(641, 'ASP.pages_private_kasir_cetakinvoice_aspx', 'failed to print tanda terima kasir with the following error:An error occurred during local report processing.', 'kasir1@gmail.com', '2019-12-16 05:35:09'),
	(642, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-12-16 08:44:04'),
	(643, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-12-16 08:44:33'),
	(644, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-12-16 08:44:55'),
	(645, 'ASP.pages_private_manager_managerdetailorder_aspx', 'Error Set PIC:Thread was being aborted.', 'manager1@gmail.com', '2019-12-16 09:06:49'),
	(646, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-16 09:08:27'),
	(647, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-16 09:11:34'),
	(648, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-16 09:31:40'),
	(649, 'ASP.pages_public_login_aspx', 'Login error:Unable to read data from the transport connection: A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.', 'anonymous', '2019-12-16 10:20:57'),
	(650, 'ASP.pages_private_penyelia_rinciannonbatch_aspx', 'Terjadi kesalahan:Thread was being aborted.', 'penyelia1@gmail.com', '2019-12-16 10:39:43'),
	(651, 'ASP.pages_public_login_aspx', 'Login error:An exception occurred. Please check the Event Log.', 'penyelia1@gmail.com', '2019-12-16 11:06:38'),
	(652, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-16 11:08:28'),
	(653, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-16 11:12:43'),
	(654, 'ASP.pages_public_login_aspx', 'Login error:The underlying provider failed on Open.', 'penyelia1@gmail.com', '2019-12-16 11:14:57'),
	(655, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-16 11:15:25'),
	(656, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-16 11:16:43'),
	(657, 'ListGridMaster', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-16 11:17:10'),
	(658, 'ListGridMaster', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-16 11:18:29'),
	(659, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-16 11:20:47'),
	(660, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-16 11:21:19'),
	(661, 'ListGridMaster', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-16 11:22:37'),
	(662, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-16 11:24:39'),
	(663, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-16 11:26:26'),
	(664, 'OrderListControls', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-16 11:26:51'),
	(665, 'ListGridMaster', 'An error occurred while executing the command definition. See the inner exception for details.', '', '2019-12-16 11:27:58'),
	(666, '<BlobPostAsync>d__0', 'The specified resource does not exist.', 'System', '2019-12-16 11:45:33'),
	(667, 'ASP.pages_public_registerform_aspx', 'fail to register user:Thread was being aborted.', 'anonymous', '2019-12-16 13:58:45'),
	(668, 'ASP.pages_public_registerform_aspx', 'fail to register user:Thread was being aborted.', 'anonymous', '2019-12-16 13:58:54'),
	(669, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'anonymous', '2019-12-16 14:03:19'),
	(670, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'anonymous', '2019-12-16 14:03:44'),
	(671, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'anonymous', '2019-12-16 14:03:54'),
	(672, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'anonymous', '2019-12-16 14:04:35'),
	(673, 'ASP.pages_public_registerform_aspx', 'fail to register user:The username is already in use.', 'anonymous', '2019-12-16 14:06:18'),
	(674, 'ASP.pages_public_registerform_aspx', 'fail to register user:Thread was being aborted.', 'anonymous', '2019-12-16 14:09:55'),
	(675, '<BlobPostAsync>d__0', 'The specified resource does not exist.', 'System', '2019-12-16 14:28:46'),
	(676, '<BlobPostAsync>d__0', 'The specified resource does not exist.', 'System', '2019-12-16 14:30:04'),
	(677, '<BlobPostAsync>d__0', 'The specified resource does not exist.', 'System', '2019-12-16 14:31:57'),
	(678, 'ASP.pages_private_kasir_cetaktandaterima_aspx', 'failed to print tanda terima kasir with the following error:An error occurred during local report processing.', 'kasir1@gmail.com', '2019-12-16 14:36:56'),
	(679, 'ASP.pages_private_kasir_cetaktandaterima_aspx', 'failed to print tanda terima kasir with the following error:An error occurred during local report processing.', 'kasir1@gmail.com', '2019-12-16 14:37:37'),
	(680, 'ASP.pages_private_cs_customerservicedetail_aspx', 'Error Set Penerimaan Sampel:Thread was being aborted.', 'cs1@gmail.com', '2019-12-16 14:52:37');
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

-- Dumping data for table smlpob.my_aspnet_membership: ~89 rows (approximately)
DELETE FROM `my_aspnet_membership`;
/*!40000 ALTER TABLE `my_aspnet_membership` DISABLE KEYS */;
INSERT INTO `my_aspnet_membership` (`userId`, `Email`, `Comment`, `Password`, `PasswordKey`, `PasswordFormat`, `PasswordQuestion`, `PasswordAnswer`, `IsApproved`, `LastActivityDate`, `LastLoginDate`, `LastPasswordChangedDate`, `CreationDate`, `IsLockedOut`, `LastLockedOutDate`, `FailedPasswordAttemptCount`, `FailedPasswordAttemptWindowStart`, `FailedPasswordAnswerAttemptCount`, `FailedPasswordAnswerAttemptWindowStart`) VALUES
	(1, NULL, '', '123qweasd', 'Ye3cjkYgWjH2qs7DJ/xSMw==', 0, NULL, NULL, 1, '2019-08-16 21:41:13', '2019-08-16 21:41:13', '2019-08-16 21:41:13', '2019-08-16 21:41:13', 0, '2019-08-16 21:41:13', 0, '2019-08-16 21:41:13', 0, '2019-08-16 21:41:13'),
	(2, 'zilong@gmail.com', '', '123qweasd', 'ZZG/P08b29f4jh3kCJhmaA==', 0, NULL, NULL, 1, '2019-12-10 02:54:33', '2019-12-10 02:54:33', '2019-08-24 15:40:03', '2019-08-24 15:40:03', 0, '2019-08-27 15:42:33', 0, '2019-08-24 15:40:03', 0, '2019-08-24 15:40:03'),
	(3, 'asep@gmail.com', '', '123qwe', 'ejcHzO1D2JWdK5JO+7NU6g==', 0, NULL, NULL, 1, '2019-12-10 02:52:17', '2019-12-10 02:52:17', '2019-08-24 18:01:22', '2019-08-24 18:01:22', 0, '2019-08-29 10:16:47', 4, '2019-12-10 02:52:04', 0, '2019-08-24 18:01:22'),
	(4, 'ujang@gmail.com', '', '123123', '+k9WpP40JQLhHGfOjmHtVQ==', 0, NULL, NULL, 1, '2019-08-24 18:08:44', '2019-08-24 18:08:44', '2019-08-24 18:08:44', '2019-08-24 18:03:10', 0, '2019-08-29 10:17:16', 1, '2019-08-29 10:17:17', 0, '2019-08-24 18:03:10'),
	(5, 'jeje@gmail.com', '', '123qwe', 'bJzuyXSye7uDmIt1TPJPHw==', 0, NULL, NULL, 1, '2019-08-27 15:12:44', '2019-08-27 15:12:44', '2019-08-24 18:16:01', '2019-08-24 18:16:01', 0, '2019-08-27 15:50:26', 1, '2019-08-27 15:50:28', 0, '2019-08-24 18:16:01'),
	(8, 'testpenyelia@gmail.com', '', '123qwe', 'w8UwUP5hEzq4a4yA7Xl8Pg==', 0, NULL, NULL, 1, '2019-08-26 13:02:46', '2019-08-26 13:02:46', '2019-08-26 13:02:46', '2019-08-26 13:02:46', 0, '2019-08-26 13:02:46', 0, '2019-08-26 13:02:46', 0, '2019-08-26 13:02:46'),
	(31, 'teguh@gmail.com', '', 'asd', 'U3UZhFJr1YUseEhoh7khFg==', 0, NULL, NULL, 1, '2019-09-09 09:08:28', '2019-09-09 09:08:28', '2019-08-28 08:59:58', '2019-08-28 08:59:58', 0, '2019-08-28 09:03:53', 2, '2019-08-28 18:00:13', 0, '2019-08-28 08:59:58'),
	(34, 'mifmasterz@gmail.com', '', 'sOry3;z=', 'HHCRNljlr16isLP7u9N5eg==', 0, NULL, NULL, 1, '2019-08-28 10:54:57', '2019-08-28 10:54:54', '2019-08-28 10:48:09', '2019-08-28 09:48:19', 0, '2019-08-28 10:54:53', 2, '2019-08-28 10:52:10', 0, '2019-08-28 09:48:19'),
	(35, 'mifmasterz@yahoo.com', '', '123qwe', 'DpsknvTeOt4FXS7qne4Pvw==', 0, NULL, NULL, 1, '2019-09-09 11:57:45', '2019-09-09 10:15:04', '2019-08-28 10:12:29', '2019-08-28 10:12:29', 0, '2019-08-29 10:15:48', 6, '2019-09-02 02:48:44', 0, '2019-08-28 10:12:29'),
	(37, 'fariz@gmail.com', '', '123qweasd', 'divGUp0fFvBR4TU0KkXHNA==', 0, NULL, NULL, 1, '2019-08-29 13:40:37', '2019-08-29 13:40:37', '2019-08-29 13:36:37', '2019-08-29 13:36:37', 0, '2019-08-29 13:36:37', 0, '2019-08-29 13:36:37', 0, '2019-08-29 13:36:37'),
	(38, 'mstokev@gmail.com', '', '123qweasd', 'agIVG2BwP3DyZ3MSE/uuWA==', 0, NULL, NULL, 1, '2019-09-11 14:49:48', '2019-09-11 14:49:48', '2019-08-30 14:19:48', '2019-08-30 14:19:48', 0, '2019-08-30 14:19:48', 0, '2019-08-30 14:19:48', 0, '2019-08-30 14:19:48'),
	(39, 'mifmasterz@outlook.com', '', '123qwe', '7OhKLyhxfkZv7npP1yVcQA==', 0, NULL, NULL, 1, '2019-09-02 16:32:33', '2019-09-02 16:32:33', '2019-08-30 12:28:43', '2019-08-30 12:28:43', 0, '2019-08-30 12:29:53', 0, '2019-08-30 12:28:43', 0, '2019-08-30 12:28:43'),
	(41, 'manager1@gmail.com', '', '123qweasd', 'U4PgSeRTQnmUgh4dOEv+tQ==', 0, NULL, NULL, 1, '2019-12-16 10:24:56', '2019-12-16 10:24:56', '2019-09-02 02:58:06', '2019-09-02 02:58:06', 0, '2019-09-02 02:58:06', 2, '2019-10-28 15:31:13', 0, '2019-09-02 02:58:06'),
	(42, 'analis1@gmail.com', '', '123qweasd', '4e+6/+eIubtLztJJa+kfqw==', 0, NULL, NULL, 1, '2019-12-15 20:37:59', '2019-12-15 20:37:59', '2019-09-02 02:59:36', '2019-09-02 02:59:36', 0, '2019-09-02 02:59:36', 2, '2019-10-21 15:32:09', 0, '2019-09-02 02:59:36'),
	(43, 'evaluator1@gmail.com', '', '123qweasd', '3M+yKOmFAZT1Cjhudvn4Vg==', 0, NULL, NULL, 1, '2019-12-13 11:23:40', '2019-12-13 11:23:40', '2019-09-02 03:04:32', '2019-09-02 03:04:32', 0, '2019-09-02 03:04:32', 2, '2019-10-16 09:12:22', 0, '2019-09-02 03:04:32'),
	(44, 'kasir1@gmail.com', '', '123qweasd', 'oFSYm2v6u/2C+f/iRt+w0g==', 0, NULL, NULL, 1, '2019-12-16 18:34:03', '2019-12-16 18:34:03', '2019-09-02 03:06:52', '2019-09-02 03:06:52', 0, '2019-09-02 03:06:52', 2, '2019-12-16 07:34:18', 0, '2019-09-02 03:06:52'),
	(45, 'cs1@gmail.com', '', '123qweasd', 'zDlNVErmrU4twWMK1MVeOw==', 0, NULL, NULL, 1, '2019-12-16 07:54:07', '2019-12-16 07:54:07', '2019-09-02 03:07:53', '2019-09-02 03:07:53', 0, '2019-09-02 03:07:53', 2, '2019-10-23 13:50:13', 0, '2019-09-02 03:07:53'),
	(46, 'penyelia1@gmail.com', '', '123qweasd', 'wVaDj6mGAYA7g35Jw6NONA==', 0, NULL, NULL, 1, '2019-12-16 11:16:14', '2019-12-16 11:16:14', '2019-09-02 03:44:53', '2019-09-02 03:44:53', 0, '2019-09-02 03:44:53', 2, '2019-10-16 14:47:49', 0, '2019-09-02 03:44:53'),
	(48, 'guntur.fitrano.tik16@mhsw.pnj.ac.id', '', '123qweasd', 'RCwpdVp2qy612GaDKoehDA==', 0, NULL, NULL, 1, '2019-09-09 09:10:13', '2019-09-09 09:10:13', '2019-09-04 06:38:38', '2019-09-04 06:38:38', 0, '2019-09-04 06:38:38', 0, '2019-09-04 06:38:38', 0, '2019-09-04 06:38:38'),
	(49, 'umaraaa234@gmail.com', '', '123qweasd', 'PTU5TpDezF7e2uJp7PHKfg==', 0, NULL, NULL, 1, '2019-09-05 09:16:41', '2019-09-05 09:16:41', '2019-09-04 06:41:57', '2019-09-04 06:41:57', 0, '2019-09-04 06:41:57', 0, '2019-09-04 06:41:57', 0, '2019-09-04 06:41:57'),
	(58, 'agriezmann408@gmail.com', '', '123qwe', 'v/Br3vCyksh1O+0QkZUUIQ==', 0, NULL, NULL, 1, '2019-10-16 09:07:40', '2019-10-16 09:07:04', '2019-09-09 08:58:49', '2019-09-09 08:58:49', 0, '2019-09-09 11:08:35', 4, '2019-10-12 07:13:24', 0, '2019-09-09 08:58:49'),
	(59, 'rizkyansyah031398@gmail.com', '', '123qweasd', 'FawX2ueuEWK1OPxfPfVzpQ==', 0, NULL, NULL, 1, '2019-09-16 05:47:42', '2019-09-16 05:43:24', '2019-09-16 05:42:12', '2019-09-16 05:42:12', 0, '2019-09-16 05:42:12', 0, '2019-09-16 05:42:12', 0, '2019-09-16 05:42:12'),
	(60, 'Iwanfals25@gmail.com', '', '123qweasd', '7N+rjhjtiizDzcsxG1wPKA==', 0, NULL, NULL, 1, '2019-09-25 01:59:26', '2019-09-25 01:59:26', '2019-09-25 01:58:51', '2019-09-25 01:58:51', 0, '2019-09-25 01:58:51', 0, '2019-09-25 01:58:51', 0, '2019-09-25 01:58:51'),
	(61, 'dontworry02051998@gmail.com', '', 'aittonyq1910', 'yZMiDwFoeI2+rtvCVBiWrw==', 0, NULL, NULL, 1, '2019-09-26 02:05:01', '2019-09-26 02:05:01', '2019-09-25 02:18:58', '2019-09-25 02:18:58', 0, '2019-09-25 02:33:12', 0, '2019-09-25 02:18:58', 0, '2019-09-25 02:18:58'),
	(62, 'januarthacrowzer@gmail.com', '', '123qweasd', '2tR0SJKaZQCO25f4f1ARpg==', 0, NULL, NULL, 1, '2019-10-10 03:36:58', '2019-10-10 03:36:58', '2019-10-10 03:36:58', '2019-10-10 03:36:58', 0, '2019-10-10 03:36:58', 0, '2019-10-10 03:36:58', 0, '2019-10-10 03:36:58'),
	(63, 'galih.yuani@trilogi.ac.id', '', '123qweasd', 'TnHXnSIN3PvK8FbR0wF3WA==', 0, NULL, NULL, 1, '2019-12-10 11:28:35', '2019-12-10 11:28:35', '2019-11-08 06:26:38', '2019-11-08 06:26:38', 0, '2019-11-08 06:26:38', 0, '2019-11-08 06:26:38', 0, '2019-11-08 06:26:38'),
	(64, 'fitrahrahmawati82@gmail.com', '', 'fitri11', '1k+T53SqyEGqtYJ8IOgacQ==', 0, NULL, NULL, 1, '2019-12-03 13:32:46', '2019-12-03 13:32:46', '2019-12-03 13:32:46', '2019-12-03 13:32:46', 0, '2019-12-03 13:32:46', 0, '2019-12-03 13:32:46', 0, '2019-12-03 13:32:46'),
	(65, 'fitrahrahmawati51@yahoo.com', '', 'fitri11', 'D/mJwl/3PUu7aB5Hq21CLQ==', 0, NULL, NULL, 1, '2019-12-03 13:41:20', '2019-12-03 13:41:20', '2019-12-03 13:41:20', '2019-12-03 13:41:20', 0, '2019-12-03 13:41:20', 0, '2019-12-03 13:41:20', 0, '2019-12-03 13:41:20'),
	(67, 'administrator@pertanian.go.id', '', '123qweasd', 'XEyZvTRS/uEuKwR5Kv5+qg==', 0, NULL, NULL, 1, '2019-12-15 20:30:39', '2019-12-15 20:30:39', '2019-12-10 05:44:55', '2019-12-10 05:44:55', 0, '2019-12-10 05:54:01', 2, '2019-12-14 16:14:42', 0, '2019-12-10 05:44:55'),
	(69, 'erny_yuniarti@yahoo.com', '', '123qweasd', 'SFaTjlNdN4FxocKI7yeDNg==', 0, NULL, NULL, 1, '2019-12-10 04:36:09', '2019-12-10 04:36:09', '2019-12-10 04:36:09', '2019-12-10 04:36:09', 0, '2019-12-10 04:36:09', 0, '2019-12-10 04:36:09', 0, '2019-12-10 04:36:09'),
	(70, 'elsantianti21@gmail.com', '', '123qweasd', 'xNcKdlRBUKkkzcyLzbuFuw==', 0, NULL, NULL, 1, '2019-12-10 04:43:22', '2019-12-10 04:43:22', '2019-12-10 04:43:22', '2019-12-10 04:43:22', 0, '2019-12-10 04:43:22', 0, '2019-12-10 04:43:22', 0, '2019-12-10 04:43:22'),
	(71, 'eepsyaiful64@gmail.com', '', '123qweasd', '3E7uPbrQ00Fpa6hx5gpIHg==', 0, NULL, NULL, 1, '2019-12-10 04:57:59', '2019-12-10 04:57:59', '2019-12-10 04:57:59', '2019-12-10 04:57:59', 0, '2019-12-10 04:57:59', 0, '2019-12-10 04:57:59', 0, '2019-12-10 04:57:59'),
	(72, 'Jjumena17@gmail.com', '', '123qweasd', 'iDAlJr0S7f3+eLgDypS3vw==', 0, NULL, NULL, 1, '2019-12-10 05:00:36', '2019-12-10 05:00:36', '2019-12-10 05:00:36', '2019-12-10 05:00:36', 0, '2019-12-10 05:00:36', 0, '2019-12-10 05:00:36', 0, '2019-12-10 05:00:36'),
	(73, 'aramadh3@gmail.com', '', '123qweasd', '9vUP68TYqqmKMqUCeAzKzg==', 0, NULL, NULL, 1, '2019-12-10 05:01:41', '2019-12-10 05:01:41', '2019-12-10 05:01:41', '2019-12-10 05:01:41', 0, '2019-12-10 05:01:41', 0, '2019-12-10 05:01:41', 0, '2019-12-10 05:01:41'),
	(74, 'ratri.ariani@gmail.com', '', '123qweasd', 'PgFRhxP7irxDpHjV5bbZdQ==', 0, NULL, NULL, 1, '2019-12-10 05:03:51', '2019-12-10 05:03:51', '2019-12-10 05:03:51', '2019-12-10 05:03:51', 0, '2019-12-10 05:03:51', 0, '2019-12-10 05:03:51', 0, '2019-12-10 05:03:51'),
	(75, 'arifbudiyantobudiyanto@yahoo.co.id', '', '123qweasd', 'hTyvU9rKMLuA1oa7QgtsPw==', 0, NULL, NULL, 1, '2019-12-10 05:31:49', '2019-12-10 05:31:49', '2019-12-10 05:31:49', '2019-12-10 05:31:49', 0, '2019-12-10 05:31:49', 0, '2019-12-10 05:31:49', 0, '2019-12-10 05:31:49'),
	(76, 'atinkurdiana@gmail.com', '', '123qweasd', 'wqhVPDND7VM+u5JUH/cD4g==', 0, NULL, NULL, 1, '2019-12-10 05:33:36', '2019-12-10 05:33:36', '2019-12-10 05:33:36', '2019-12-10 05:33:36', 0, '2019-12-10 05:33:36', 0, '2019-12-10 05:33:36', 0, '2019-12-10 05:33:36'),
	(77, 'gatiyogasuripto@gmail.com', '', '123qweasd', 'Ez+iWdKMr2h2pj91SfXQJQ==', 0, NULL, NULL, 1, '2019-12-10 05:34:24', '2019-12-10 05:34:24', '2019-12-10 05:34:24', '2019-12-10 05:34:24', 0, '2019-12-10 05:34:24', 0, '2019-12-10 05:34:24', 0, '2019-12-10 05:34:24'),
	(78, 'musrahman36153@gmail.com', '', '123qweasd', 'pEgR2LaYd6wwYYXLKTcH1Q==', 0, NULL, NULL, 1, '2019-12-10 05:35:40', '2019-12-10 05:35:40', '2019-12-10 05:35:40', '2019-12-10 05:35:40', 0, '2019-12-10 05:35:40', 0, '2019-12-10 05:35:40', 0, '2019-12-10 05:35:40'),
	(79, 'jamaldul4634@gmail.com', '', '123qweasd', '006ZCJWwDqofrKqcdUNbqw==', 0, NULL, NULL, 1, '2019-12-10 05:36:24', '2019-12-10 05:36:24', '2019-12-10 05:36:24', '2019-12-10 05:36:24', 0, '2019-12-10 05:36:24', 0, '2019-12-10 05:36:24', 0, '2019-12-10 05:36:24'),
	(80, 'leanfa.la3ll@gmail.com', '', '123qweasd', 'YDYeyqkGPKhaIEVlBUjEBQ==', 0, NULL, NULL, 1, '2019-12-10 05:37:55', '2019-12-10 05:37:55', '2019-12-10 05:37:55', '2019-12-10 05:37:55', 0, '2019-12-10 05:37:55', 0, '2019-12-10 05:37:55', 0, '2019-12-10 05:37:55'),
	(81, 'firman_geo11@yahoo.co.id', '', '123qweasd', '+n5h7VqV0joIJCgWNAyR+w==', 0, NULL, NULL, 1, '2019-12-10 05:38:42', '2019-12-10 05:38:42', '2019-12-10 05:38:42', '2019-12-10 05:38:42', 0, '2019-12-10 05:38:42', 0, '2019-12-10 05:38:42', 0, '2019-12-10 05:38:42'),
	(84, 'land_nn@yahoo.com', '', '123qweasd', 'xi+3vUEFrsMRnGNvJ0zfxA==', 0, NULL, NULL, 1, '2019-12-12 13:59:09', '2019-12-12 13:59:09', '2019-12-12 13:59:09', '2019-12-12 13:59:09', 0, '2019-12-12 13:59:09', 0, '2019-12-12 13:59:09', 0, '2019-12-12 13:59:09'),
	(86, 'hestiekatantika@gmail.com', '', '123qweasd', 'PeUSokosUTQuGcwptVVdIQ==', 0, NULL, NULL, 1, '2019-12-12 14:02:17', '2019-12-12 14:02:17', '2019-12-12 14:02:17', '2019-12-12 14:02:17', 0, '2019-12-12 14:02:17', 0, '2019-12-12 14:02:17', 0, '2019-12-12 14:02:17'),
	(87, 'pujiningrum@gmail.com', '', '123qweasd', 'kZQgbofPkS96SvllRFdHYQ==', 0, NULL, NULL, 1, '2019-12-12 14:03:42', '2019-12-12 14:03:42', '2019-12-12 14:03:42', '2019-12-12 14:03:42', 0, '2019-12-12 14:03:42', 0, '2019-12-12 14:03:42', 0, '2019-12-12 14:03:42'),
	(88, 'iindwisurhati85@gmail.com', '', '123qweasd', '2Z9es0cSsugGyvQ+cEUMyg==', 0, NULL, NULL, 1, '2019-12-12 14:04:54', '2019-12-12 14:04:54', '2019-12-12 14:04:54', '2019-12-12 14:04:54', 0, '2019-12-12 14:04:54', 0, '2019-12-12 14:04:54', 0, '2019-12-12 14:04:54'),
	(89, 'usman_randika@yahoo.com', '', '123qweasd', 'fs1enjT+cqGRvJ5NWNjhCg==', 0, NULL, NULL, 1, '2019-12-12 14:07:24', '2019-12-12 14:07:24', '2019-12-12 14:07:24', '2019-12-12 14:07:24', 0, '2019-12-12 14:07:24', 0, '2019-12-12 14:07:24', 0, '2019-12-12 14:07:24'),
	(90, 'margi.hastuti@gmail.com', '', '123qweasd', 'Z6i56rjBJ7J7TAelaw8yoA==', 0, NULL, NULL, 1, '2019-12-12 14:10:18', '2019-12-12 14:10:18', '2019-12-12 14:10:18', '2019-12-12 14:10:18', 0, '2019-12-12 14:10:18', 0, '2019-12-12 14:10:18', 0, '2019-12-12 14:10:18'),
	(91, 'ekaindrasetiaman2425@gmail.com', '', '123qweasd', 'D+22wKVXiPVscL7v0cAB0A==', 0, NULL, NULL, 1, '2019-12-12 14:23:45', '2019-12-12 14:23:45', '2019-12-12 14:23:45', '2019-12-12 14:23:45', 0, '2019-12-12 14:23:45', 0, '2019-12-12 14:23:45', 0, '2019-12-12 14:23:45'),
	(92, 'fajarachmad.2009@gmail.com', '', '123qweasd', 'cstMUUn3mddLjbiL1Iv1Aw==', 0, NULL, NULL, 1, '2019-12-12 14:27:19', '2019-12-12 14:27:19', '2019-12-12 14:27:19', '2019-12-12 14:27:19', 0, '2019-12-12 14:27:19', 0, '2019-12-12 14:27:19', 0, '2019-12-12 14:27:19'),
	(93, 'analis_iindwisurhati85@gmail.com', '', '123qweasd', 'VNrcZdxfgnV4JXZZLvqR6A==', 0, NULL, NULL, 1, '2019-12-12 14:32:38', '2019-12-12 14:32:38', '2019-12-12 14:32:38', '2019-12-12 14:32:38', 0, '2019-12-12 14:32:38', 0, '2019-12-12 14:32:38', 0, '2019-12-12 14:32:38'),
	(94, 'awp1146@gmail.com', '', '123qweasd', '/VNwTttrDn2SS4m/GZoABw==', 0, NULL, NULL, 1, '2019-12-12 14:45:45', '2019-12-12 14:45:45', '2019-12-12 14:45:45', '2019-12-12 14:45:45', 0, '2019-12-12 14:45:45', 0, '2019-12-12 14:45:45', 0, '2019-12-12 14:45:45'),
	(95, 'yadialamtirta@gmail.com', '', '123qweasd', 'H7g2XbDOcy5cbx3etH8ZiQ==', 0, NULL, NULL, 1, '2019-12-12 14:52:37', '2019-12-12 14:52:37', '2019-12-12 14:52:37', '2019-12-12 14:52:37', 0, '2019-12-12 14:52:37', 0, '2019-12-12 14:52:37', 0, '2019-12-12 14:52:37'),
	(96, 'audilanandisya@gmail.com', '', '123qweasd', 'sQ7Uoj3NTJyGg595Vac9uQ==', 0, NULL, NULL, 1, '2019-12-12 15:07:23', '2019-12-12 15:07:23', '2019-12-12 15:07:23', '2019-12-12 15:07:23', 0, '2019-12-12 15:07:23', 0, '2019-12-12 15:07:23', 0, '2019-12-12 15:07:23'),
	(97, 'analis_pujiningrum@gmail.com', '', '123qweasd', 'ixxWu4voAMtyOc2U+AOvDg==', 0, NULL, NULL, 1, '2019-12-12 15:34:34', '2019-12-12 15:34:34', '2019-12-12 15:34:34', '2019-12-12 15:34:34', 0, '2019-12-12 15:34:34', 0, '2019-12-12 15:34:34', 0, '2019-12-12 15:34:34'),
	(98, 'zulfikarp24@gmail.com', '', '123qweasd', 's285n7KJDd98OH70DRbxkw==', 0, NULL, NULL, 1, '2019-12-12 15:35:38', '2019-12-12 15:35:38', '2019-12-12 15:35:38', '2019-12-12 15:35:38', 0, '2019-12-12 15:35:38', 0, '2019-12-12 15:35:38', 0, '2019-12-12 15:35:38'),
	(100, 'firnas.muldiansyah@gmail.com', '', '123qweasd', 'JrdK+xcpwyF9KWCleSI0Cg==', 0, NULL, NULL, 1, '2019-12-12 15:36:45', '2019-12-12 15:36:45', '2019-12-12 15:36:45', '2019-12-12 15:36:45', 0, '2019-12-12 15:36:45', 0, '2019-12-12 15:36:45', 0, '2019-12-12 15:36:45'),
	(101, 'marisyakurniasari@gmail.com', '', '123qweasd', 'MvO8BJg0IjFGSwn4wIRZFQ==', 0, NULL, NULL, 1, '2019-12-12 15:37:39', '2019-12-12 15:37:39', '2019-12-12 15:37:39', '2019-12-12 15:37:39', 0, '2019-12-12 15:37:39', 0, '2019-12-12 15:37:39', 0, '2019-12-12 15:37:39'),
	(102, 'debbynuksm@gmail.com', '', '123qweasd', 'k4qLGcl/pV82o47KnULuAg==', 0, NULL, NULL, 1, '2019-12-12 15:38:21', '2019-12-12 15:38:21', '2019-12-12 15:38:21', '2019-12-12 15:38:21', 0, '2019-12-12 15:38:21', 0, '2019-12-12 15:38:21', 0, '2019-12-12 15:38:21'),
	(103, 'sunarya.sr@gmail.com', '', '123qweasd', 'P/D0iGzCAF7ZW88vDXm15Q==', 0, NULL, NULL, 1, '2019-12-12 15:39:23', '2019-12-12 15:39:23', '2019-12-12 15:39:23', '2019-12-12 15:39:23', 0, '2019-12-12 15:39:23', 0, '2019-12-12 15:39:23', 0, '2019-12-12 15:39:23'),
	(104, 'ramafadli20@gmail.com', '', '123qweasd', 'l9Wvs8jbzajmALLDM+6dig==', 0, NULL, NULL, 1, '2019-12-12 15:42:33', '2019-12-12 15:42:33', '2019-12-12 15:42:33', '2019-12-12 15:42:33', 0, '2019-12-12 15:42:33', 0, '2019-12-12 15:42:33', 0, '2019-12-12 15:42:33'),
	(105, 'rini.prihatini.rp@gmail.com', '', '123qweasd', '6xpO57g8CHhc2l2HGFDK6w==', 0, NULL, NULL, 1, '2019-12-12 15:43:52', '2019-12-12 15:43:52', '2019-12-12 15:43:52', '2019-12-12 15:43:52', 0, '2019-12-12 15:43:52', 0, '2019-12-12 15:43:52', 0, '2019-12-12 15:43:52'),
	(106, 'galihyprtm@gmail.com', '', '123qweasd', 'r0MaigivUWhFNytiCzcYYA==', 0, NULL, NULL, 1, '2019-12-12 09:02:18', '2019-12-12 09:02:18', '2019-12-12 08:44:13', '2019-12-12 08:44:13', 0, '2019-12-12 08:44:13', 0, '2019-12-12 08:44:13', 0, '2019-12-12 08:44:13'),
	(107, 'anggrainirenyta@gmail.com', '', '123qweasd', 'eAstkjv8ghxThT9tu1ah3A==', 0, NULL, NULL, 1, '2019-12-12 15:44:35', '2019-12-12 15:44:35', '2019-12-12 15:44:35', '2019-12-12 15:44:35', 0, '2019-12-12 15:44:35', 0, '2019-12-12 15:44:35', 0, '2019-12-12 15:44:35'),
	(108, 'godrealm971@gmail.com', '', '123qweasd', 'Ln6lFpd01D2KowkwvvMIPw==', 0, NULL, NULL, 1, '2019-12-12 17:56:16', '2019-12-12 17:56:16', '2019-12-12 16:04:37', '2019-12-12 16:04:37', 0, '2019-12-12 09:19:08', 0, '2019-12-12 16:04:37', 0, '2019-12-12 16:04:37'),
	(109, 'novie.ekaps@gmail.com', '', '123qweasd', 'v7IIU0HL7u23NdbNZUhnig==', 0, NULL, NULL, 1, '2019-12-12 16:08:26', '2019-12-12 16:08:26', '2019-12-12 16:08:26', '2019-12-12 16:08:26', 0, '2019-12-12 16:08:26', 0, '2019-12-12 16:08:26', 0, '2019-12-12 16:08:26'),
	(110, 'marig.hastuti@gmail.com', '', '123qweasd', 'FhHBrWbJIzT3k85EsLmRuw==', 0, NULL, NULL, 1, '2019-12-12 16:09:29', '2019-12-12 16:09:29', '2019-12-12 16:09:29', '2019-12-12 16:09:29', 0, '2019-12-12 16:09:29', 0, '2019-12-12 16:09:29', 0, '2019-12-12 16:09:29'),
	(111, 'ikhwan.labkim@gmail.com', '', '123qweasd', 'sz0R60hsg1Mrn0+abfCLqw==', 0, NULL, NULL, 1, '2019-12-12 16:12:55', '2019-12-12 16:12:55', '2019-12-12 16:12:55', '2019-12-12 16:12:55', 0, '2019-12-12 16:12:55', 0, '2019-12-12 16:12:55', 0, '2019-12-12 16:12:55'),
	(112, 'roni.labkim@gmail.com', '', '123qweasd', 'cfDMatiN9HLrf+zVc9AbVg==', 0, NULL, NULL, 1, '2019-12-12 16:13:46', '2019-12-12 16:13:46', '2019-12-12 16:13:46', '2019-12-12 16:13:46', 0, '2019-12-12 16:13:46', 0, '2019-12-12 16:13:46', 0, '2019-12-12 16:13:46'),
	(113, 'prayudi.labkim@gmail.com', '', '123qweasd', '8afViTL+XlOvQt3ueVG2Gw==', 0, NULL, NULL, 1, '2019-12-12 16:15:24', '2019-12-12 16:15:24', '2019-12-12 16:15:24', '2019-12-12 16:15:24', 0, '2019-12-12 16:15:24', 0, '2019-12-12 16:15:24', 0, '2019-12-12 16:15:24'),
	(117, 'midahpratama@gmail.com', '', '123qweasd', 'gum96MR9AT9D3lje2ds0dw==', 0, NULL, NULL, 1, '2019-12-12 16:30:35', '2019-12-12 16:30:35', '2019-12-12 16:30:35', '2019-12-12 16:30:35', 0, '2019-12-12 16:30:35', 0, '2019-12-12 16:30:35', 0, '2019-12-12 16:30:35'),
	(118, 'didik.suristyo@gmail.com', '', '123qweasd', 'CJSZYJ2S4BTEV9qHeD5L6A==', 0, NULL, NULL, 1, '2019-12-12 16:36:35', '2019-12-12 16:36:35', '2019-12-12 16:36:35', '2019-12-12 16:36:35', 0, '2019-12-12 16:36:35', 0, '2019-12-12 16:36:35', 0, '2019-12-12 16:36:35'),
	(119, 'ikamardikas@gmail.com', '', '123qweasd', 'HtpafzHD7tsPfyaJxHED4g==', 0, NULL, NULL, 1, '2019-12-12 16:38:27', '2019-12-12 16:38:27', '2019-12-12 16:38:27', '2019-12-12 16:38:27', 0, '2019-12-12 16:38:27', 0, '2019-12-12 16:38:27', 0, '2019-12-12 16:38:27'),
	(121, 'galihyprtm@gmail.com', '', '123qweasd', 'N2XzFqfazBTwBWJqE9q5TQ==', 0, NULL, NULL, 1, '2019-12-12 09:41:48', '2019-12-12 09:41:48', '2019-12-12 09:41:48', '2019-12-12 09:41:48', 0, '2019-12-12 09:41:48', 0, '2019-12-12 09:41:48', 0, '2019-12-12 09:41:48'),
	(122, 'auliarisma102@gmail.com', '', '123qweasd', 'ZDR0JCUcj6VFPXKA0dUe7w==', 0, NULL, NULL, 1, '2019-12-13 02:43:35', '2019-12-13 02:43:35', '2019-12-12 16:42:00', '2019-12-12 16:42:00', 0, '2019-12-12 16:42:00', 0, '2019-12-12 16:42:00', 0, '2019-12-12 16:42:00'),
	(123, 'idede1465@gmail.com', '', '123qweasd', 'fTQahl1iV089rNdR6P+Z5g==', 0, NULL, NULL, 1, '2019-12-12 16:45:55', '2019-12-12 16:45:55', '2019-12-12 16:45:55', '2019-12-12 16:45:55', 0, '2019-12-12 16:45:55', 0, '2019-12-12 16:45:55', 0, '2019-12-12 16:45:55'),
	(124, 'galihyprtm@gmail.com', '', '123qweasd', 'yGCMglk4x1diGzvhtDo40w==', 0, NULL, NULL, 1, '2019-12-12 09:47:00', '2019-12-12 09:47:00', '2019-12-12 09:47:00', '2019-12-12 09:47:00', 0, '2019-12-12 09:47:00', 0, '2019-12-12 09:47:00', 0, '2019-12-12 09:47:00'),
	(125, 'dedisu931@gmail.com', '', '123qweasd', 'OudfgwMzzolcZxnAPWyu8w==', 0, NULL, NULL, 1, '2019-12-12 16:47:38', '2019-12-12 16:47:38', '2019-12-12 16:47:38', '2019-12-12 16:47:38', 0, '2019-12-12 16:47:38', 0, '2019-12-12 16:47:38', 0, '2019-12-12 16:47:38'),
	(126, 'supriadiadi320@gmail.com', '', '123qweasd', 'bpqQDjkaMhATUwMHi0vR+g==', 0, NULL, NULL, 1, '2019-12-12 16:49:31', '2019-12-12 16:49:31', '2019-12-12 16:49:31', '2019-12-12 16:49:31', 0, '2019-12-12 16:49:31', 0, '2019-12-12 16:49:31', 0, '2019-12-12 16:49:31'),
	(127, 'andiandi666666666@gmail.com', '', '123qweasd', 'dO0gAuhh4DvmUXbI25L+Fg==', 0, NULL, NULL, 1, '2019-12-12 16:51:32', '2019-12-12 16:51:32', '2019-12-12 16:51:32', '2019-12-12 16:51:32', 0, '2019-12-12 16:51:32', 0, '2019-12-12 16:51:32', 0, '2019-12-12 16:51:32'),
	(128, 'galihyprtm@gmail.com', '', '123qweasd', 'cwmvl3z015TNsB4AXshK0A==', 0, NULL, NULL, 1, '2019-12-12 09:55:31', '2019-12-12 09:55:31', '2019-12-12 09:55:31', '2019-12-12 09:55:31', 0, '2019-12-12 09:55:31', 0, '2019-12-12 09:55:31', 0, '2019-12-12 09:55:31'),
	(129, 'galihyprtm@gmail.com', '', '123qweasd', 'LGd5b63DNnZd1ZMcLuarUg==', 0, NULL, NULL, 1, '2019-12-12 19:06:51', '2019-12-12 19:06:51', '2019-12-12 10:00:29', '2019-12-12 10:00:29', 0, '2019-12-12 10:00:29', 0, '2019-12-12 10:00:29', 0, '2019-12-12 10:00:29'),
	(130, 'scarletwitchd28@gmail.com', '', 'uhuyahud', 'kPY/WRr/4dTfDK4sNBxQQw==', 0, NULL, NULL, 1, '2019-12-16 09:08:07', '2019-12-16 09:06:49', '2019-12-12 12:54:54', '2019-12-12 12:54:54', 0, '2019-12-12 12:54:54', 2, '2019-12-13 15:48:14', 0, '2019-12-12 12:54:54'),
	(131, 'customer1@gmail.com', '', '123qweasd', 'P6Jv4P76spz4t/BEgMPmqA==', 0, NULL, NULL, 1, '2019-12-16 07:11:21', '2019-12-16 07:11:21', '2019-12-12 20:02:26', '2019-12-12 20:02:26', 0, '2019-12-12 20:02:26', 0, '2019-12-12 20:02:26', 0, '2019-12-12 20:02:26'),
	(132, 'haisany@outlook.com', '', 'uhuyahud', 'ecTCUk/YouWDnwTHwEy/FA==', 0, NULL, NULL, 1, '2019-12-17 03:52:58', '2019-12-17 03:52:45', '2019-12-13 02:34:49', '2019-12-13 02:34:49', 0, '2019-12-13 02:34:49', 0, '2019-12-13 02:34:49', 0, '2019-12-13 02:34:49'),
	(133, 'kustomer1@outlook.co.id', '', '123qweasd', 'SWvtojld4Mdn+gAjAhoGzQ==', 0, NULL, NULL, 1, '2019-12-16 07:43:47', '2019-12-16 07:43:19', '2019-12-13 10:04:13', '2019-12-13 10:04:13', 0, '2019-12-13 10:04:55', 4, '2019-12-16 12:59:45', 0, '2019-12-13 10:04:13'),
	(134, 'markusandas@yahoo.com', '', '123qweasd', 'ZFWVO8CopUqTsqtSra/hQg==', 0, NULL, NULL, 1, '2019-12-13 04:27:31', '2019-12-13 04:27:31', '2019-12-13 04:27:31', '2019-12-13 04:27:31', 0, '2019-12-13 04:27:31', 0, '2019-12-13 04:27:31', 0, '2019-12-13 04:27:31'),
	(135, 'tentremtiti42@gmail.com', '', '123qweasd', '7Ab1reD4EYaR3afqb6HJEg==', 0, NULL, NULL, 1, '2019-12-13 04:32:34', '2019-12-13 04:32:34', '2019-12-13 04:32:34', '2019-12-13 04:32:34', 0, '2019-12-13 04:32:34', 0, '2019-12-13 04:32:34', 0, '2019-12-13 04:32:34'),
	(136, 'yacehidayat@pertanian.go.id', '', '123qweasd', 'Hju2h+URbk5i3Xx1fVdhCg==', 0, NULL, NULL, 1, '2019-12-13 04:34:13', '2019-12-13 04:34:13', '2019-12-13 04:34:13', '2019-12-13 04:34:13', 0, '2019-12-13 04:34:13', 0, '2019-12-13 04:34:13', 0, '2019-12-13 04:34:13'),
	(137, 'antoniusfrasisco@pertanian.go.id', '', '123qweasd', 'xGeCSDu5hkk1ey18Maqqtw==', 0, NULL, NULL, 1, '2019-12-13 04:36:15', '2019-12-13 04:36:15', '2019-12-13 04:36:15', '2019-12-13 04:36:15', 0, '2019-12-13 04:36:15', 0, '2019-12-13 04:36:15', 0, '2019-12-13 04:36:15'),
	(138, 'a.abubakar@pertanian.go.id', '', '123qweasd', 'II6yW6mJM66pA2+w/ZYbvQ==', 0, NULL, NULL, 1, '2019-12-13 04:37:02', '2019-12-13 04:37:02', '2019-12-13 04:37:02', '2019-12-13 04:37:02', 0, '2019-12-13 04:37:02', 0, '2019-12-13 04:37:02', 0, '2019-12-13 04:37:02'),
	(139, 'sukristyohastono@yahoo.co.uk', '', 'dick1965', 'QRr9yhQukE1aBZIAdaOXqA==', 0, NULL, NULL, 1, '2019-12-16 07:00:05', '2019-12-16 07:00:05', '2019-12-16 06:58:41', '2019-12-16 06:58:41', 0, '2019-12-16 06:58:41', 0, '2019-12-16 06:58:41', 0, '2019-12-16 06:58:41'),
	(140, 'umara234@gmail.com', '', '123qweasd', '3Odron/fz7N0j/2P8vw3Xw==', 0, NULL, NULL, 1, '2019-12-16 06:58:53', '2019-12-16 06:58:53', '2019-12-16 06:58:53', '2019-12-16 06:58:53', 0, '2019-12-16 06:58:53', 0, '2019-12-16 06:58:53', 0, '2019-12-16 06:58:53'),
	(141, 'januartharamadhan@yahoo.com', '', '123qweasd', 'Yax4091GSpzz0Gfn3rzL/w==', 0, NULL, NULL, 1, '2019-12-16 07:09:53', '2019-12-16 07:09:53', '2019-12-16 07:09:53', '2019-12-16 07:09:53', 0, '2019-12-16 07:09:53', 0, '2019-12-16 07:09:53', 0, '2019-12-16 07:09:53');
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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_roles: ~8 rows (approximately)
DELETE FROM `my_aspnet_roles`;
/*!40000 ALTER TABLE `my_aspnet_roles` DISABLE KEYS */;
INSERT INTO `my_aspnet_roles` (`id`, `applicationId`, `name`) VALUES
	(1, 1, 'admin'),
	(3, 1, 'pelanggan'),
	(4, 1, 'penyelia'),
	(5, 1, 'manajer teknis'),
	(6, 1, 'evaluator'),
	(7, 1, 'analis'),
	(8, 1, 'cs'),
	(9, 1, 'kasir');
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
) ENGINE=InnoDB AUTO_INCREMENT=142 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_users: ~90 rows (approximately)
DELETE FROM `my_aspnet_users`;
/*!40000 ALTER TABLE `my_aspnet_users` DISABLE KEYS */;
INSERT INTO `my_aspnet_users` (`id`, `applicationId`, `name`, `isAnonymous`, `lastActivityDate`) VALUES
	(2, 1, 'zilong@gmail.com', 0, '2019-12-10 02:54:33'),
	(3, 1, 'asep@gmail.com', 0, '2019-12-10 02:52:17'),
	(4, 1, 'ujang@gmail.com', 0, '2019-08-24 18:08:44'),
	(5, 1, 'jeje@gmail.com', 0, '2019-08-27 15:12:44'),
	(8, 1, 'testpenyelia', 0, '2019-08-26 06:02:46'),
	(31, 1, 'teguh@gmail.com', 0, '2019-09-09 09:08:28'),
	(34, 1, 'mifmasterz@gmail.com', 0, '2019-08-28 10:54:57'),
	(35, 1, 'mifmasterz@yahoo.com', 0, '2019-09-09 11:57:45'),
	(37, 1, 'fariz@gmail.com', 0, '2019-08-29 13:40:37'),
	(38, 1, 'mstokev@gmail.com', 0, '2019-09-11 14:49:48'),
	(39, 1, 'mifmasterz@outlook.com', 0, '2019-09-02 16:32:33'),
	(41, 1, 'manager1@gmail.com', 0, '2019-12-16 10:24:56'),
	(42, 1, 'analis1@gmail.com', 0, '2019-12-15 20:37:59'),
	(43, 1, 'evaluator1@gmail.com', 0, '2019-12-13 11:23:40'),
	(44, 1, 'kasir1@gmail.com', 0, '2019-12-16 18:34:03'),
	(45, 1, 'cs1@gmail.com', 0, '2019-12-16 07:54:07'),
	(46, 1, 'penyelia1@gmail.com', 0, '2019-12-16 11:16:14'),
	(48, 1, 'guntur.fitrano.tik16@mhsw.pnj.ac.id', 0, '2019-09-09 09:10:13'),
	(49, 1, 'umaraaa234@gmail.com', 0, '2019-09-05 09:16:41'),
	(53, 1, 'acuaca00@gmail.com', 0, '2019-09-09 09:07:34'),
	(58, 1, 'agriezmann408@gmail.com', 0, '2019-10-16 09:07:40'),
	(59, 1, 'rizkyansyah031398@gmail.com', 0, '2019-09-16 05:47:42'),
	(60, 1, 'Iwanfals25@gmail.com', 0, '2019-09-25 01:59:26'),
	(61, 1, 'dontworry02051998@gmail.com', 0, '2019-09-26 02:05:01'),
	(62, 1, 'januarthacrowzer@gmail.com', 0, '2019-10-10 03:36:57'),
	(63, 1, 'galih.yuani@trilogi.ac.id', 0, '2019-12-10 11:28:35'),
	(64, 1, 'fitrahrahmawati82@gmail.com', 0, '2019-12-03 13:32:46'),
	(65, 1, 'fitrahrahmawati51@yahoo.com', 0, '2019-12-03 13:41:19'),
	(67, 1, 'administrator@pertanian.go.id', 0, '2019-12-15 20:30:39'),
	(69, 1, 'erny_yuniarti@yahoo.com', 0, '2019-12-10 04:36:08'),
	(70, 1, 'elsantianti21@gmail.com', 0, '2019-12-10 04:43:21'),
	(71, 1, 'eepsyaiful64@gmail.com', 0, '2019-12-10 04:57:59'),
	(72, 1, 'Jjumena17@gmail.com', 0, '2019-12-10 05:00:36'),
	(73, 1, 'aramadh3@gmail.com', 0, '2019-12-10 05:01:41'),
	(74, 1, 'ratri.ariani@gmail.com', 0, '2019-12-10 05:03:50'),
	(75, 1, 'arifbudiyantobudiyanto@yahoo.co.id', 0, '2019-12-10 05:31:48'),
	(76, 1, 'atinkurdiana@gmail.com', 0, '2019-12-10 05:33:35'),
	(77, 1, 'gatiyogasuripto@gmail.com', 0, '2019-12-10 05:34:24'),
	(78, 1, 'musrahman36153@gmail.com', 0, '2019-12-10 05:35:40'),
	(79, 1, 'jamaldul4634@gmail.com', 0, '2019-12-10 05:36:24'),
	(80, 1, 'leanfa.la3ll@gmail.com', 0, '2019-12-10 05:37:55'),
	(81, 1, 'firman_geo11@yahoo.co.id', 0, '2019-12-10 05:38:42'),
	(84, 1, 'land_nn@yahoo.com', 0, '2019-12-12 06:59:11'),
	(86, 1, 'hestiekatantika@gmail.com', 0, '2019-12-12 07:02:16'),
	(87, 1, 'pujiningrum@gmail.com', 0, '2019-12-12 07:03:41'),
	(88, 1, 'iindwisurhati85@gmail.com', 0, '2019-12-12 07:04:53'),
	(89, 1, 'usman_randika@yahoo.com', 0, '2019-12-12 07:07:24'),
	(90, 1, 'margi.hastuti@gmail.com', 0, '2019-12-12 07:10:17'),
	(91, 1, 'ekaindrasetiaman2425@gmail.com', 0, '2019-12-12 07:23:44'),
	(92, 1, 'fajarachmad.2009@gmail.com', 0, '2019-12-12 07:27:18'),
	(93, 1, 'analis_iindwisurhati85@gmail.com', 0, '2019-12-12 07:32:37'),
	(94, 1, 'awp1146@gmail.com', 0, '2019-12-12 07:45:45'),
	(95, 1, 'yadialamtirta@gmail.com', 0, '2019-12-12 07:52:37'),
	(96, 1, 'audilanandisya@gmail.com', 0, '2019-12-12 08:07:23'),
	(97, 1, 'analis_pujiningrum@gmail.com', 0, '2019-12-12 08:34:34'),
	(98, 1, 'zulfikarp24@gmail.com', 0, '2019-12-12 08:35:38'),
	(100, 1, 'firnas.muldiansyah@gmail.com', 0, '2019-12-12 08:36:45'),
	(101, 1, 'marisyakurniasari@gmail.com', 0, '2019-12-12 08:37:39'),
	(102, 1, 'debbynuksm@gmail.com', 0, '2019-12-12 08:38:20'),
	(103, 1, 'sunarya.sr@gmail.com', 0, '2019-12-12 08:39:23'),
	(104, 1, 'ramafadli20@gmail.com', 0, '2019-12-12 08:42:32'),
	(105, 1, 'rini.prihatini.rp@gmail.com', 0, '2019-12-12 08:43:52'),
	(107, 1, 'anggrainirenyta@gmail.com', 0, '2019-12-12 08:44:35'),
	(108, 1, 'godrealm971@gmail.com', 0, '2019-12-12 17:56:16'),
	(109, 1, 'novie.ekaps@gmail.com', 0, '2019-12-12 09:08:25'),
	(110, 1, 'marig.hastuti@gmail.com', 0, '2019-12-12 09:09:28'),
	(111, 1, 'ikhwan.labkim@gmail.com', 0, '2019-12-12 09:12:55'),
	(112, 1, 'roni.labkim@gmail.com', 0, '2019-12-12 09:13:45'),
	(113, 1, 'prayudi.labkim@gmail.com', 0, '2019-12-12 09:15:23'),
	(117, 1, 'midahpratama@gmail.com', 0, '2019-12-12 09:30:35'),
	(118, 1, 'didik.suristyo@gmail.com', 0, '2019-12-12 09:36:35'),
	(119, 1, 'ikamardikas@gmail.com', 0, '2019-12-12 09:38:27'),
	(122, 1, 'auliarisma102@gmail.com', 0, '2019-12-13 02:43:35'),
	(123, 1, 'idede1465@gmail.com', 0, '2019-12-12 09:45:55'),
	(125, 1, 'dedisu931@gmail.com', 0, '2019-12-12 09:47:37'),
	(126, 1, 'supriadiadi320@gmail.com', 0, '2019-12-12 09:49:30'),
	(127, 1, 'andiandi666666666@gmail.com', 0, '2019-12-12 09:51:32'),
	(129, 1, 'galihyprtm@gmail.com', 0, '2019-12-12 19:06:51'),
	(130, 1, 'scarletwitchd28@gmail.com', 0, '2019-12-16 09:08:07'),
	(131, 1, 'customer1@gmail.com', 0, '2019-12-16 07:11:21'),
	(132, 1, 'haisany@outlook.com', 0, '2019-12-17 03:52:58'),
	(133, 1, 'kustomer1@outlook.co.id', 0, '2019-12-16 07:43:47'),
	(134, 1, 'markusandas@yahoo.com', 0, '2019-12-13 04:27:31'),
	(135, 1, 'tentremtiti42@gmail.com', 0, '2019-12-13 04:32:34'),
	(136, 1, 'yacehidayat@pertanian.go.id', 0, '2019-12-13 04:34:13'),
	(137, 1, 'antoniusfrasisco@pertanian.go.id', 0, '2019-12-13 04:36:15'),
	(138, 1, 'a.abubakar@pertanian.go.id', 0, '2019-12-13 04:37:02'),
	(139, 1, 'sukristyohastono@yahoo.co.uk', 0, '2019-12-16 07:00:05'),
	(140, 1, 'umara234@gmail.com', 0, '2019-12-16 06:58:52'),
	(141, 1, 'januartharamadhan@yahoo.com', 0, '2019-12-16 07:09:53');
/*!40000 ALTER TABLE `my_aspnet_users` ENABLE KEYS */;

-- Dumping structure for table smlpob.my_aspnet_usersinroles
DROP TABLE IF EXISTS `my_aspnet_usersinroles`;
CREATE TABLE IF NOT EXISTS `my_aspnet_usersinroles` (
  `userId` int(11) NOT NULL,
  `roleId` int(11) NOT NULL,
  PRIMARY KEY (`userId`,`roleId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.my_aspnet_usersinroles: ~111 rows (approximately)
DELETE FROM `my_aspnet_usersinroles`;
/*!40000 ALTER TABLE `my_aspnet_usersinroles` DISABLE KEYS */;
INSERT INTO `my_aspnet_usersinroles` (`userId`, `roleId`) VALUES
	(3, 3),
	(4, 3),
	(5, 3),
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
	(41, 5),
	(42, 7),
	(43, 6),
	(44, 3),
	(45, 3),
	(46, 4),
	(48, 3),
	(49, 3),
	(50, 3),
	(51, 3),
	(52, 3),
	(54, 3),
	(55, 3),
	(57, 3),
	(58, 3),
	(59, 3),
	(60, 3),
	(61, 3),
	(62, 3),
	(63, 3),
	(64, 3),
	(65, 3),
	(67, 1),
	(69, 5),
	(70, 4),
	(71, 7),
	(72, 7),
	(73, 7),
	(74, 5),
	(75, 4),
	(76, 7),
	(77, 7),
	(78, 7),
	(79, 7),
	(80, 1),
	(81, 7),
	(84, 5),
	(86, 4),
	(87, 4),
	(88, 4),
	(89, 4),
	(90, 7),
	(91, 7),
	(92, 7),
	(93, 7),
	(94, 7),
	(95, 7),
	(96, 7),
	(97, 7),
	(98, 7),
	(100, 7),
	(101, 7),
	(102, 7),
	(103, 7),
	(104, 7),
	(105, 7),
	(106, 3),
	(107, 7),
	(108, 3),
	(109, 7),
	(110, 7),
	(111, 7),
	(112, 7),
	(113, 7),
	(117, 8),
	(118, 8),
	(119, 8),
	(121, 3),
	(122, 9),
	(123, 7),
	(124, 3),
	(125, 7),
	(126, 7),
	(127, 7),
	(128, 3),
	(129, 3),
	(130, 3),
	(131, 3),
	(132, 3),
	(133, 3),
	(134, 5),
	(135, 4),
	(136, 7),
	(137, 7),
	(138, 7),
	(139, 3),
	(140, 3),
	(141, 3);
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
) ENGINE=InnoDB AUTO_INCREMENT=855 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.orderanalysisdetailtbl: ~49 rows (approximately)
DELETE FROM `orderanalysisdetailtbl`;
/*!40000 ALTER TABLE `orderanalysisdetailtbl` DISABLE KEYS */;
INSERT INTO `orderanalysisdetailtbl` (`orderDetailNo`, `orderNo`, `sampleNo`, `elementId`, `parametersNo`, `elementValue`, `status`, `recalculate`, `pic`, `fileAttachmentUrl`, `fileName`, `LabToolAttachmentUrl`, `LabToolFileName`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	(806, '0086/LP Balittanah/12/2019', '19.12.86 K.P. 92', 268, NULL, NULL, 'Diproses', '0', 14, NULL, NULL, NULL, NULL, 'customer1@gmail.com', '2019-12-12 20:20:24', NULL, NULL),
	(807, '0087/LP Balittanah/12/2019', '19.12.87 K.P. 93', 278, NULL, NULL, 'Diproses', '0', 14, NULL, NULL, NULL, NULL, 'customer1@gmail.com', '2019-12-12 20:27:23', NULL, NULL),
	(808, '0087/LP Balittanah/12/2019', '19.12.87 K.P. 93', 281, NULL, NULL, 'Diproses', '0', NULL, NULL, NULL, NULL, NULL, 'customer1@gmail.com', '2019-12-12 20:27:23', NULL, NULL),
	(809, '0088/LP Balittanah/12/2019', '19.12.88 K.P. 94', 268, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'customer1@gmail.com', '2019-12-12 20:34:51', NULL, NULL),
	(810, '0088/LP Balittanah/12/2019', '19.12.88 K.P. 94', 269, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'customer1@gmail.com', '2019-12-12 20:34:51', NULL, NULL),
	(811, '0089/LP Balittanah/12/2019', '19.12.89 K.P. 95', 365, NULL, NULL, 'Menunggu', '0', 14, NULL, NULL, NULL, NULL, 'scarletwitchd28@gmail.com', '2019-12-12 22:44:38', NULL, NULL),
	(812, '0090/LP Balittanah/12/2019', '19.12.90 K.P. 96', 365, NULL, NULL, 'Diproses', '0', 14, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_13Des2019_4pfLW3D9fxHYK.csv', 'manual_analis1@gmail.com_13Des2019_4pfLW3D9fxHYK.csv', 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/alat_analis1@gmail.com_13Des2019_sfp9cOQRV.csv', 'alat_analis1@gmail.com_13Des2019_sfp9cOQRV.csv', 'kustomer1@outlook.co.id', '2019-12-13 10:07:23', 'analis1@gmail.com', '2019-12-13 10:32:44'),
	(813, '0090/LP Balittanah/12/2019', '19.12.90 K.P. 96', 366, NULL, NULL, 'Diproses', '0', NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_13Des2019_m41KK8gGLbM.csv', 'manual_analis1@gmail.com_13Des2019_m41KK8gGLbM.csv', 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/alat_analis1@gmail.com_13Des2019_nyt5IOv.csv', 'alat_analis1@gmail.com_13Des2019_nyt5IOv.csv', 'kustomer1@outlook.co.id', '2019-12-13 10:07:23', 'analis1@gmail.com', '2019-12-13 10:34:22'),
	(814, '0091/LP Balittanah/12/2019', '19.12.91, B.Th.97', 286, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'scarletwitchd28@gmail.com', '2019-12-15 15:35:56', NULL, NULL),
	(815, '0091/LP Balittanah/12/2019', '19.12.91, B.Th.97', 287, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'scarletwitchd28@gmail.com', '2019-12-15 15:35:56', NULL, NULL),
	(816, '0092/LP Balittanah/12/2019', '19.12.92, F.Th.98', 366, NULL, NULL, 'Diproses', '0', 14, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/manual_analis1@gmail.com_15Des2019_cVcDdP5X55w.csv', 'manual_analis1@gmail.com_15Des2019_cVcDdP5X55w.csv', 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/alat_analis1@gmail.com_15Des2019_SjQkIVfVgpb0.csv', 'alat_analis1@gmail.com_15Des2019_SjQkIVfVgpb0.csv', 'kustomer1@outlook.co.id', '2019-12-15 20:25:41', 'analis1@gmail.com', '2019-12-15 20:38:50'),
	(817, '0093/LP Balittanah/12/2019', '19.12.93, K.Th.100', 268, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'customer1@gmail.com', '2019-12-16 08:33:46', NULL, NULL),
	(818, '0093/LP Balittanah/12/2019', '19.12.93, K.Th.99', 268, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'customer1@gmail.com', '2019-12-16 08:33:46', NULL, NULL),
	(819, '0094/LP Balittanah/12/2019', '19.12.94, B.Th.101', 359, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'scarletwitchd28@gmail.com', '2019-12-16 09:08:08', NULL, NULL),
	(820, '0094/LP Balittanah/12/2019', '19.12.94, B.Th.101', 360, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'scarletwitchd28@gmail.com', '2019-12-16 09:08:08', NULL, NULL),
	(821, '0095/LP Balittanah/12/2019', '19.12.95, F.Th.102', 365, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 11:43:23', NULL, NULL),
	(822, '0095/LP Balittanah/12/2019', '19.12.95, F.Th.102', 366, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 11:43:23', NULL, NULL),
	(823, '0095/LP Balittanah/12/2019', '19.12.95, F.Th.103', 365, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 11:43:23', NULL, NULL),
	(824, '0095/LP Balittanah/12/2019', '19.12.95, F.Th.103', 366, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 11:43:23', NULL, NULL),
	(825, '0096/LP Balittanah/12/2019', '19.12.96, K.Th.104', 265, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'customer1@gmail.com', '2019-12-16 13:36:40', NULL, NULL),
	(826, '0096/LP Balittanah/12/2019', '19.12.96, K.Th.104', 268, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'customer1@gmail.com', '2019-12-16 13:36:40', NULL, NULL),
	(827, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.105', 265, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(828, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.105', 266, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(829, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.105', 267, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(830, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.105', 268, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(831, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.105', 269, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(832, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.105', 270, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(833, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.105', 273, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(834, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.106', 265, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(835, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.106', 266, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(836, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.106', 267, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(837, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.106', 268, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(838, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.106', 269, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(839, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.106', 270, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(840, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.106', 273, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(841, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.107', 265, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(842, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.107', 266, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(843, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.107', 267, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(844, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.107', 268, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(845, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.107', 269, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(846, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.107', 270, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(847, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.107', 273, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(848, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.108', 265, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(849, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.108', 266, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(850, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.108', 267, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(851, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.108', 268, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(852, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.108', 269, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(853, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.108', 270, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL),
	(854, '0097/LP Balittanah/12/2019', '19.12.97, K.Th.108', 273, NULL, NULL, 'Menunggu', '0', NULL, NULL, NULL, NULL, NULL, 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', NULL, NULL);
/*!40000 ALTER TABLE `orderanalysisdetailtbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.ordermastertbl
DROP TABLE IF EXISTS `ordermastertbl`;
CREATE TABLE IF NOT EXISTS `ordermastertbl` (
  `orderNo` varchar(30) NOT NULL,
  `batchId` varchar(15) DEFAULT NULL,
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
  `CalculationFileUrl` text,
  `CalculationFilename` varchar(255) DEFAULT NULL,
  `isReviewing` char(1) DEFAULT NULL,
  `packageName` varchar(255) DEFAULT NULL,
  `additionalPrice1` decimal(12,2) DEFAULT NULL,
  `additionalPrice2` decimal(12,2) DEFAULT NULL,
  `totalGenus` int(11) DEFAULT NULL,
  `dosePerHectare` decimal(5,0) DEFAULT NULL,
  `additionalPriceRemark` varchar(256) DEFAULT NULL,
  `creaBy` varchar(255) DEFAULT NULL,
  `creaDate` datetime DEFAULT NULL,
  `modBy` varchar(255) DEFAULT NULL,
  `modDate` datetime DEFAULT NULL,
  PRIMARY KEY (`orderNo`),
  KEY `OrderMasterTbltoCustomerTbl` (`customerNo`),
  KEY `OrderMasterTbltoComodityTbl` (`comodityNo`),
  KEY `OrderMasterTbltoEmployeeTbl` (`pic`),
  KEY `OrderMasterTbltoAnalysisTypeTbl` (`analysisType`),
  KEY `FK_ordermastertbl_batchtbl` (`batchId`),
  CONSTRAINT `FK_ordermastertbl_batchtbl` FOREIGN KEY (`batchId`) REFERENCES `batchtbl` (`batchId`),
  CONSTRAINT `OrderMasterTbltoAnalysisTypeTbl` FOREIGN KEY (`analysisType`) REFERENCES `analysistypetbl` (`analysisTypeName`),
  CONSTRAINT `OrderMasterTbltoComodityTbl` FOREIGN KEY (`comodityNo`) REFERENCES `comoditytbl` (`comodityNo`),
  CONSTRAINT `OrderMasterTbltoCustomerTbl` FOREIGN KEY (`customerNo`) REFERENCES `customertbl` (`customerNo`),
  CONSTRAINT `OrderMasterTbltoEmployeeTbl` FOREIGN KEY (`pic`) REFERENCES `employeetbl` (`employeeNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.ordermastertbl: ~11 rows (approximately)
DELETE FROM `ordermastertbl`;
/*!40000 ALTER TABLE `ordermastertbl` DISABLE KEYS */;
INSERT INTO `ordermastertbl` (`orderNo`, `batchId`, `customerNo`, `comodityNo`, `analysisType`, `sampleTotal`, `priceTotal`, `statusType`, `status`, `paymentStatus`, `ppn`, `receiptDate`, `isPaid`, `paymentDate`, `pic`, `isOnLab`, `ApprPenyelia`, `ApprEvaluator`, `ApprManagerTeknis`, `LHPAttachmentUrl`, `LHPFileName`, `EvaluationFileUrl`, `EvaluationFileName`, `isRecalculate`, `CalculationFileUrl`, `CalculationFilename`, `isReviewing`, `packageName`, `additionalPrice1`, `additionalPrice2`, `totalGenus`, `dosePerHectare`, `additionalPriceRemark`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	('0086/LP Balittanah/12/2019', 'B-00013/12/2019', 1181, 21, 'Kimia', 1, 24000.00, 'Khusus', 'LHP Sudah Diambil', 'Sudah dibayar', 2400.00, '2019-12-12 00:00:00', '1', NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', 'customer1@gmail.com', '2019-12-12 20:20:24', 'customer1@gmail.com', '2019-12-12 20:20:24'),
	('0087/LP Balittanah/12/2019', 'B-00013/12/2019', 1181, 22, 'Kimia', 1, 36000.00, 'Penelitian', 'Menunggu Approval', 'Sudah dibayar', 3600.00, '2019-12-12 00:00:00', '1', NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', 'customer1@gmail.com', '2019-12-12 20:27:23', 'customer1@gmail.com', '2019-12-12 20:27:23'),
	('0088/LP Balittanah/12/2019', NULL, 1181, 21, 'Kimia', 1, 54000.00, 'Khusus', 'Pilih Penyelia', 'Sudah dibayar', 5400.00, '2019-12-12 00:00:00', '1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', 'customer1@gmail.com', '2019-12-12 20:34:51', 'customer1@gmail.com', '2019-12-12 20:34:51'),
	('0089/LP Balittanah/12/2019', NULL, 1180, 27, 'Fisika', 1, 18000.00, 'Penelitian', 'Proses Lab', 'DP', 1800.00, '2019-12-12 00:00:00', '1', NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', 'scarletwitchd28@gmail.com', '2019-12-12 22:44:38', 'scarletwitchd28@gmail.com', '2019-12-12 22:44:38'),
	('0090/LP Balittanah/12/2019', NULL, 1183, 27, 'Fisika', 1, 70500.00, 'Penelitian', 'LHP Sudah Diambil', 'Sudah dibayar', 7050.00, '2019-12-13 00:00:00', '1', NULL, 14, NULL, NULL, NULL, NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/LHP_penyelia1@gmail.com_13Des2019_MdpMBgqdQ.xls', 'LHP_penyelia1@gmail.com_13Des2019_MdpMBgqdQ.xls', NULL, NULL, NULL, 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/LampiranLHP_penyelia1@gmail.com_13Des2019_fYQqVO4e1g.jpeg', 'LampiranLHP_penyelia1@gmail.com_13Des2019_fYQqVO4e1g.jpeg', NULL, NULL, NULL, NULL, NULL, NULL, '', 'kustomer1@outlook.co.id', '2019-12-13 10:07:23', 'kustomer1@outlook.co.id', '2019-12-13 10:07:23'),
	('0091/LP Balittanah/12/2019', NULL, 1180, 23, 'Biologi', 1, 275000.00, 'Komersial', 'Pesanan Baru', 'Verifikasi', 27500.00, '2019-12-15 00:00:00', '0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', 'scarletwitchd28@gmail.com', '2019-12-15 15:35:56', 'scarletwitchd28@gmail.com', '2019-12-15 15:35:56'),
	('0092/LP Balittanah/12/2019', NULL, 1183, 27, 'Fisika', 1, 52500.00, 'Penelitian', 'Verifikasi Penyelia', 'Sudah dibayar', 5250.00, '2019-12-15 00:00:00', '1', NULL, 14, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', 'kustomer1@outlook.co.id', '2019-12-15 20:25:41', 'kustomer1@outlook.co.id', '2019-12-15 20:25:41'),
	('0093/LP Balittanah/12/2019', NULL, 1181, 21, 'Kimia', 2, 48000.00, 'Khusus', 'Pilih Penyelia', 'Sudah dibayar', 4800.00, '2019-12-16 00:00:00', '1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', 'customer1@gmail.com', '2019-12-16 08:33:46', 'customer1@gmail.com', '2019-12-16 08:33:46'),
	('0094/LP Balittanah/12/2019', NULL, 1180, 25, 'Biologi', 1, 175000.00, 'Komersial', 'Pesanan Baru', 'Belum dibayar', 17500.00, '2019-12-16 00:00:00', '0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', 'scarletwitchd28@gmail.com', '2019-12-16 09:08:08', 'scarletwitchd28@gmail.com', '2019-12-16 09:08:08'),
	('0095/LP Balittanah/12/2019', NULL, 1183, 27, 'Fisika', 2, 141000.00, 'Penelitian', 'Barcode Sampel', 'Sudah dibayar', 14100.00, '2019-12-16 00:00:00', '1', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', 'kustomer1@outlook.co.id', '2019-12-16 11:43:23', 'kustomer1@outlook.co.id', '2019-12-16 11:43:23'),
	('0096/LP Balittanah/12/2019', NULL, 1181, 21, 'Kimia', 1, 42000.00, 'Komersial', 'Pesanan Baru', 'Belum dibayar', 4200.00, '2019-12-16 00:00:00', '0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', 'customer1@gmail.com', '2019-12-16 13:36:40', 'customer1@gmail.com', '2019-12-16 13:36:40'),
	('0097/LP Balittanah/12/2019', NULL, 1183, 21, 'Kimia', 4, 792000.00, 'Komersial', 'Pesanan Baru', 'Verifikasi', 79200.00, '2019-12-16 00:00:00', '0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '', 'kustomer1@outlook.co.id', '2019-12-16 14:23:02', 'kustomer1@outlook.co.id', '2019-12-16 14:23:02');
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
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.ordernavigationtbl: ~63 rows (approximately)
DELETE FROM `ordernavigationtbl`;
/*!40000 ALTER TABLE `ordernavigationtbl` DISABLE KEYS */;
INSERT INTO `ordernavigationtbl` (`id`, `name`, `parentId`, `isLeaf`, `commodityNo`, `orderNo`, `isVisible`) VALUES
	(1, 'Lab Kimia', -1, '0', 0, 0, '1'),
	(2, 'Lab Fisika', -1, '0', 0, 1, '1'),
	(3, 'Lab Biologi', -1, '0', 0, 2, '1'),
	(4, 'tanah', 1, '0', 0, 0, '1'),
	(5, 'air', 1, '0', 29, 1, '1'),
	(6, 'tanaman', 1, '0', 28, 2, '1'),
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
	(63, 'Fungi', 55, '1', 0, 0, '1'),
	(64, 'Lab Mineral', -1, '0', 0, 3, '1'),
	(65, 'Contoh Tanah', 3, '1', 23, 0, '1'),
	(66, 'Contoh Pupuk Hayati', 3, '1', 24, 1, '1'),
	(67, 'Pembenah Tanah', 3, '1', 25, 2, '1'),
	(68, 'Mineral Tanah', 64, '1', 26, 0, '1'),
	(69, 'Fisika Tanah', 2, '1', 27, 0, '1');
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
) ENGINE=InnoDB AUTO_INCREMENT=949 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.orderpricedetailtbl: ~25 rows (approximately)
DELETE FROM `orderpricedetailtbl`;
/*!40000 ALTER TABLE `orderpricedetailtbl` DISABLE KEYS */;
INSERT INTO `orderpricedetailtbl` (`orderPriceDetailNo`, `orderNo`, `elementId`, `price`, `quantity`, `TotalPrice`) VALUES
	(924, '0086/LP Balittanah/12/2019', 268, 24000.00, 1, 24000.00),
	(925, '0087/LP Balittanah/12/2019', 278, 18000.00, 1, 18000.00),
	(926, '0087/LP Balittanah/12/2019', 281, 18000.00, 1, 18000.00),
	(927, '0088/LP Balittanah/12/2019', 268, 24000.00, 1, 24000.00),
	(928, '0088/LP Balittanah/12/2019', 269, 30000.00, 1, 30000.00),
	(929, '0089/LP Balittanah/12/2019', 365, 18000.00, 1, 18000.00),
	(930, '0090/LP Balittanah/12/2019', 365, 18000.00, 1, 18000.00),
	(931, '0090/LP Balittanah/12/2019', 366, 52500.00, 1, 52500.00),
	(932, '0091/LP Balittanah/12/2019', 286, 125000.00, 1, 125000.00),
	(933, '0091/LP Balittanah/12/2019', 287, 150000.00, 1, 150000.00),
	(934, '0092/LP Balittanah/12/2019', 366, 52500.00, 1, 52500.00),
	(935, '0093/LP Balittanah/12/2019', 268, 24000.00, 2, 48000.00),
	(936, '0094/LP Balittanah/12/2019', 359, 125000.00, 1, 125000.00),
	(937, '0094/LP Balittanah/12/2019', 360, 50000.00, 1, 50000.00),
	(938, '0095/LP Balittanah/12/2019', 365, 18000.00, 2, 36000.00),
	(939, '0095/LP Balittanah/12/2019', 366, 52500.00, 2, 105000.00),
	(940, '0096/LP Balittanah/12/2019', 265, 18000.00, 1, 18000.00),
	(941, '0096/LP Balittanah/12/2019', 268, 24000.00, 1, 24000.00),
	(942, '0097/LP Balittanah/12/2019', 265, 18000.00, 4, 72000.00),
	(943, '0097/LP Balittanah/12/2019', 266, 30000.00, 4, 120000.00),
	(944, '0097/LP Balittanah/12/2019', 267, 24000.00, 4, 96000.00),
	(945, '0097/LP Balittanah/12/2019', 268, 24000.00, 4, 96000.00),
	(946, '0097/LP Balittanah/12/2019', 269, 30000.00, 4, 120000.00),
	(947, '0097/LP Balittanah/12/2019', 270, 30000.00, 4, 120000.00),
	(948, '0097/LP Balittanah/12/2019', 273, 42000.00, 4, 168000.00);
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

-- Dumping data for table smlpob.ordersampletbl: ~17 rows (approximately)
DELETE FROM `ordersampletbl`;
/*!40000 ALTER TABLE `ordersampletbl` DISABLE KEYS */;
INSERT INTO `ordersampletbl` (`noBalittanah`, `orderNo`, `countNumber`, `sampleCode`, `sampleDescription`, `samplingDate`, `village`, `subDistrict`, `district`, `province`, `longitude`, `latitude`, `landUse`, `isReceived`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	('19.12.86 K.P. 92', '0086/LP Balittanah/12/2019', 1, 's1x', 'tanah sawah', '2019-12-03 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'customer1@gmail.com', '2019-12-12 20:19:25', 'customer1@gmail.com', '2019-12-12 20:19:25'),
	('19.12.87 K.P. 93', '0087/LP Balittanah/12/2019', 1, 'sample2', 'test sample', '2019-12-09 00:00:00', 'PULAU PARI', 'KEC. KEPULAUAN SERIBU SELATAN', 'KAB. KEPULAUAN SERIBU', 'PROV. D.K.I. JAKARTA', '0', '0', 'Lahan Sawah', '0', 'customer1@gmail.com', '2019-12-12 20:26:45', 'customer1@gmail.com', '2019-12-12 20:26:45'),
	('19.12.88 K.P. 94', '0088/LP Balittanah/12/2019', 1, 'sampleX', 'dari hutan', '2019-12-04 00:00:00', 'AMBAKIYANG', 'KEC. AWAYAN', 'KAB. BALANGAN', 'PROV. KALIMANTAN SELATAN', '0', '0', 'Lahan Hutan', '1', 'customer1@gmail.com', '2019-12-12 20:33:39', 'customer1@gmail.com', '2019-12-12 20:33:39'),
	('19.12.89 K.P. 95', '0089/LP Balittanah/12/2019', 1, 'coba', 's', '2019-12-13 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'scarletwitchd28@gmail.com', '2019-12-12 22:43:55', 'scarletwitchd28@gmail.com', '2019-12-12 22:43:55'),
	('19.12.90 K.P. 96', '0090/LP Balittanah/12/2019', 1, 'SAMPLE-001-CUSTOMER', 'ok banget', '2019-12-13 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'kustomer1@outlook.co.id', '2019-12-13 10:06:59', 'kustomer1@outlook.co.id', '2019-12-13 10:06:59'),
	('19.12.91, B.Th.97', '0091/LP Balittanah/12/2019', 1, 'sampel1', 'contoh tanah 1', '2019-12-15 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '456', '123', 'Lahan Sawah', '0', 'scarletwitchd28@gmail.com', '2019-12-15 15:35:23', 'scarletwitchd28@gmail.com', '2019-12-15 15:35:23'),
	('19.12.92, F.Th.98', '0092/LP Balittanah/12/2019', 1, 'SAMPLE-001-CUSTOMER', 'ok', '2019-12-15 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'kustomer1@outlook.co.id', '2019-12-15 20:25:12', 'kustomer1@outlook.co.id', '2019-12-15 20:25:12'),
	('19.12.93, K.Th.100', '0093/LP Balittanah/12/2019', 2, 'smpl002', '2', '2019-12-02 00:00:00', 'BISKANG', 'KEC. DANAU PARIS', 'KAB. ACEH SINGKIL', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'customer1@gmail.com', '2019-12-16 08:32:23', 'customer1@gmail.com', '2019-12-16 08:32:23'),
	('19.12.93, K.Th.99', '0093/LP Balittanah/12/2019', 1, 'smpl001', '1', '2019-12-02 00:00:00', 'BISKANG', 'KEC. DANAU PARIS', 'KAB. ACEH SINGKIL', 'PROV. ACEH', '0', '0', 'Lahan Sawah', '1', 'customer1@gmail.com', '2019-12-16 08:32:16', 'customer1@gmail.com', '2019-12-16 08:32:16'),
	('19.12.94, B.Th.101', '0094/LP Balittanah/12/2019', 1, 'sample 1', 'bala1', '2019-12-16 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '4321', '1234', 'Lahan Sawah', '0', 'scarletwitchd28@gmail.com', '2019-12-16 09:07:55', 'scarletwitchd28@gmail.com', '2019-12-16 09:07:55'),
	('19.12.95, F.Th.102', '0095/LP Balittanah/12/2019', 1, 'sample 1 customer', 'sampel yang diambil diaceh', '2019-12-02 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '123', '123', 'Lahan Lebag', '1', 'kustomer1@outlook.co.id', '2019-12-16 11:39:42', 'kustomer1@outlook.co.id', '2019-12-16 11:39:42'),
	('19.12.95, F.Th.103', '0095/LP Balittanah/12/2019', 2, 'sampel 2 customer', 'sampel yang diambil diaceh', '2019-12-02 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '123', '123', 'Lahan Lebag', '1', 'kustomer1@outlook.co.id', '2019-12-16 11:40:18', 'kustomer1@outlook.co.id', '2019-12-16 11:40:18'),
	('19.12.96, K.Th.104', '0096/LP Balittanah/12/2019', 1, 's1', 'sample1', '2019-12-03 00:00:00', 'ALUE BAGOK', 'KEC. ARONGAN LAMBALEK', 'KAB. ACEH BARAT', 'PROV. ACEH', '0', '0', 'Lahan Hutan', '0', 'customer1@gmail.com', '2019-12-16 13:36:22', 'customer1@gmail.com', '2019-12-16 13:36:22'),
	('19.12.97, K.Th.105', '0097/LP Balittanah/12/2019', 1, 'sample 1', '', '2019-12-03 00:00:00', 'MEKARSARI', 'KEC. CIANJUR', 'KAB. CIANJUR', 'PROV. JAWA BARAT', '0', '0', 'Lahan Sawah', '0', 'kustomer1@outlook.co.id', '2019-12-16 14:17:10', 'kustomer1@outlook.co.id', '2019-12-16 14:17:10'),
	('19.12.97, K.Th.106', '0097/LP Balittanah/12/2019', 2, 'sample 2', '', '2019-12-03 00:00:00', 'MEKARSARI', 'KEC. CIANJUR', 'KAB. CIANJUR', 'PROV. JAWA BARAT', '0', '0', 'Lahan Sawah', '0', 'kustomer1@outlook.co.id', '2019-12-16 14:18:09', 'kustomer1@outlook.co.id', '2019-12-16 14:18:09'),
	('19.12.97, K.Th.107', '0097/LP Balittanah/12/2019', 3, 'SAMPLE/XtxQlLcab2', '', '2019-12-03 00:00:00', 'MEKARSARI', 'KEC. CIANJUR', 'KAB. CIANJUR', 'PROV. JAWA BARAT', '0', '0', 'Lahan Sawah', '0', 'kustomer1@outlook.co.id', '2019-12-16 14:18:20', 'kustomer1@outlook.co.id', '2019-12-16 14:18:20'),
	('19.12.97, K.Th.108', '0097/LP Balittanah/12/2019', 4, 'SAMPLE/5NcBxhzy8X', '', '2019-12-03 00:00:00', 'MEKARSARI', 'KEC. CIANJUR', 'KAB. CIANJUR', 'PROV. JAWA BARAT', '0', '0', 'Lahan Sawah', '0', 'kustomer1@outlook.co.id', '2019-12-16 14:18:23', 'kustomer1@outlook.co.id', '2019-12-16 14:18:23');
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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

-- Dumping data for table smlpob.packagetbl: ~0 rows (approximately)
DELETE FROM `packagetbl`;
/*!40000 ALTER TABLE `packagetbl` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.parameterstbl: ~2 rows (approximately)
DELETE FROM `parameterstbl`;
/*!40000 ALTER TABLE `parameterstbl` DISABLE KEYS */;
INSERT INTO `parameterstbl` (`parametersNo`, `string0`, `string1`, `string2`, `string3`, `string4`, `string5`, `string6`, `string7`, `string8`, `string9`, `creaBy`, `creaDate`, `modBy`, `modDate`) VALUES
	(2, 'a', '', 'b', '1', '2', '', '', '', '', '', '', '2019-12-12 13:18:09', NULL, NULL),
	(3, 'a', '', 'b', '1', '2', '', '', '', '', '', '', '2019-12-12 13:19:49', NULL, NULL);
/*!40000 ALTER TABLE `parameterstbl` ENABLE KEYS */;

-- Dumping structure for table smlpob.paymenttbl
DROP TABLE IF EXISTS `paymenttbl`;
CREATE TABLE IF NOT EXISTS `paymenttbl` (
  `paymentId` bigint(20) NOT NULL AUTO_INCREMENT,
  `status` varchar(50) NOT NULL DEFAULT '0',
  `accountName` varchar(50) DEFAULT NULL,
  `accountNo` varchar(250) DEFAULT NULL,
  `bankName` varchar(50) DEFAULT NULL,
  `paymentReceiptUrl` varchar(250) DEFAULT NULL,
  `amount` decimal(12,2) DEFAULT NULL,
  `orderNo` varchar(50) DEFAULT NULL,
  `name` varchar(250) DEFAULT NULL,
  `attachmentUrl` varchar(350) DEFAULT NULL,
  PRIMARY KEY (`paymentId`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

-- Dumping data for table smlpob.paymenttbl: ~4 rows (approximately)
DELETE FROM `paymenttbl`;
/*!40000 ALTER TABLE `paymenttbl` DISABLE KEYS */;
INSERT INTO `paymenttbl` (`paymentId`, `status`, `accountName`, `accountNo`, `bankName`, `paymentReceiptUrl`, `amount`, `orderNo`, `name`, `attachmentUrl`) VALUES
	(10, 'Diterima', 'Asma', '547867856355345', 'Bank Rakyat Indonesia (BRI)', 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/payment_kustomer1@outlook.co.id_13Des2019_E1HrsafXcNA.jpg', 71000.00, '0090/LP Balittanah/12/2019', 'Asep Surmadi', 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/lampiran_bayar_kustomer1@outlook.co.id_13Des2019_wSxrkN1dc3.jpg'),
	(11, 'Verifikasi', 'sany', '123123123', 'Bank Central Asia (BCA)', 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/payment_scarletwitchd28@gmail.com_15Des2019_Ycs3Tbc.jpg', 275000.00, '0091/LP Balittanah/12/2019', 'sany', 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/lampiran_bayar_scarletwitchd28@gmail.com_15Des2019_oo0P2S24MxI.jpg'),
	(12, 'Diterima', 'asep', '3425768634', 'Bank Mandiri', 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/payment_kustomer1@outlook.co.id_15Des2019_D2nJxSqPbQ13lg.jpg', 53000.00, '0092/LP Balittanah/12/2019', 'Asep Surmadi', 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/lampiran_bayar_kustomer1@outlook.co.id_15Des2019_j9sU64Krn1P.jpg'),
	(13, 'Verifikasi', 'kustomer1', '13300011', 'Bank Mandiri', 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/payment_kustomer1@outlook.co.id_16Des2019_D0Ert1Ow9.jpg', 792000.00, '0097/LP Balittanah/12/2019', 'Asep Surmadi', 'https://balittanahstorage.blob.core.windows.net/balittanahpelayanan/lampiran_bayar_kustomer1@outlook.co.id_16Des2019_5uANHM1RDUp34.jpg');
/*!40000 ALTER TABLE `paymenttbl` ENABLE KEYS */;

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
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

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

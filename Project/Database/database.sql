CREATE DATABASE  IF NOT EXISTS `patienthistorydb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `patienthistorydb`;
-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: localhost    Database: patienthistorydb
-- ------------------------------------------------------
-- Server version	8.0.20

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `doctor`
--

DROP TABLE IF EXISTS `doctor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doctor` (
  `AMKA` varchar(11) NOT NULL,
  `password` varchar(255) NOT NULL,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `specialty` varchar(255) NOT NULL,
  `phone_number` varchar(10) NOT NULL,
  PRIMARY KEY (`AMKA`),
  UNIQUE KEY `email` (`email`),
  UNIQUE KEY `phone_number` (`phone_number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doctor`
--

LOCK TABLES `doctor` WRITE;
/*!40000 ALTER TABLE `doctor` DISABLE KEYS */;
INSERT INTO `doctor` VALUES ('11111111111','D693E213D78BC7A498240B42B207252633298D34','Θωμάς','Πέτρου','th@mail.com','Παθολόγος','1478523694'),('44444444444','7110EDA4D09E062AA5E4A390B0A572AC0D2C0220','Γεώργιος ','Παπαδόπουλος','g@mail.com','Παιδίατρος','1565615616');
/*!40000 ALTER TABLE `doctor` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;



DROP TABLE IF EXISTS `patient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patient` (
  `AMKA` varchar(11) NOT NULL,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `birthdate` date NOT NULL,
  `phone_number` varchar(10) DEFAULT NULL,
  `address` varchar(255) NOT NULL,
  `email` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`AMKA`),
  UNIQUE KEY `phone_number` (`phone_number`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patient`
--

LOCK TABLES `patient` WRITE;
/*!40000 ALTER TABLE `patient` DISABLE KEYS */;
INSERT INTO `patient` VALUES ('03059900154','George','Zaf','1999-05-03',NULL,'Ζάχου 96','zaftn@mail.com'),('03059914351','Peter','Don','1999-02-03','6945968304','Elis 43',NULL),('22222222222','Παύλος','Πλαστήρας','1999-05-03',NULL,'Αιγός Ποταμοί 2',NULL),('33333333333','Κωνσταντίνος','Δαμασκηνός','1999-05-03','6949968303','Appl 3','zaf@mail.com');
/*!40000 ALTER TABLE `patient` ENABLE KEYS */;
UNLOCK TABLES;

DROP TABLE IF EXISTS `visit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `visit` (
  `patient_AMKA` varchar(11) NOT NULL,
  `visit_date` datetime NOT NULL,
  `doctor_amka` varchar(11) NOT NULL,
  `disease` varchar(255) DEFAULT NULL,
  `symptom` varchar(255) DEFAULT NULL,
  `vaccine` varchar(255) DEFAULT NULL,
  `report` varchar(255) DEFAULT NULL,
  `treatment` varchar(255) DEFAULT NULL,
  `status` varchar(7) DEFAULT NULL,
  PRIMARY KEY (`patient_AMKA`,`visit_date`),
  KEY `fk_visit_doctor_idx` (`doctor_amka`),
  CONSTRAINT `fk_visit_doctor` FOREIGN KEY (`doctor_amka`) REFERENCES `doctor` (`AMKA`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_visit_patient` FOREIGN KEY (`patient_AMKA`) REFERENCES `patient` (`AMKA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `visit`
--

LOCK TABLES `visit` WRITE;
/*!40000 ALTER TABLE `visit` DISABLE KEYS */;
INSERT INTO `visit` VALUES ('22222222222','2015-02-21 12:25:12','11111111111','Γρίπη','Πυρετός, Συνάχι, Βήχας',NULL,'Ξεκούραση λίγων ημερών','Depon','settled'),('22222222222','2018-02-21 12:25:12','11111111111','Πνευμονία','Βήχας, Πυρετός',NULL,'Χορήγηση αντιβίοσης','Αugmentin','settled'),('22222222222','2021-07-17 12:15:12','11111111111',NULL,NULL,'johnson',NULL,NULL,NULL),('22222222222','2021-07-21 13:06:46','11111111111',NULL,NULL,'moderna',NULL,NULL,NULL),('33333333333','2005-02-21 12:15:12','44444444444',NULL,NULL,'Εμβόλιο ανεμοβλογιάς',NULL,NULL,NULL),('33333333333','2015-02-21 12:25:12','11111111111','Ευλογιά','φουσκάλες στο δέρμα',NULL,'Το έπερνε κάθε μέρα. Πέρασε ένας μήνας. Θεραπεύτηκε.','Tecovirimat','settled'),('33333333333','2021-07-18 13:55:24','11111111111',NULL,NULL,'pfizer',NULL,NULL,NULL);
/*!40000 ALTER TABLE `visit` ENABLE KEYS */;
UNLOCK TABLES;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-07-21 13:48:19
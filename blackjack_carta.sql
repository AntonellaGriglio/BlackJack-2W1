-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: blackjack
-- ------------------------------------------------------
-- Server version	8.0.30

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
-- Table structure for table `carta`
--

DROP TABLE IF EXISTS `carta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `carta` (
  `idCarta` int NOT NULL AUTO_INCREMENT,
  `valor` int NOT NULL,
  `carta` varchar(3) NOT NULL,
  `isAs` tinyint(1) NOT NULL,
  PRIMARY KEY (`idCarta`)
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carta`
--

LOCK TABLES `carta` WRITE;
/*!40000 ALTER TABLE `carta` DISABLE KEYS */;
INSERT INTO `carta` VALUES (1,1,'AC',1),(2,1,'AP',1),(3,1,'AD',1),(4,1,'AT',1),(5,2,'2C',0),(6,2,'2P',0),(7,2,'2D',0),(8,2,'2T',0),(9,3,'3C',0),(10,3,'3P',0),(11,3,'3D',0),(12,3,'3T',0),(13,4,'4C',0),(14,4,'4P',0),(15,4,'4D',0),(16,4,'4T',0),(17,5,'5C',0),(18,5,'5P',0),(19,5,'5D',0),(20,5,'5T',0),(21,6,'6C',0),(22,6,'6P',0),(23,6,'6D',0),(24,6,'6T',0),(25,7,'7C',0),(26,7,'7P',0),(27,7,'7D',0),(28,7,'7T',0),(29,8,'8C',0),(30,8,'8P',0),(31,8,'8D',0),(32,8,'8T',0),(33,9,'9C',0),(34,9,'9P',0),(35,9,'9D',0),(36,9,'9T',0),(37,10,'10C',0),(38,10,'10P',0),(39,10,'10D',0),(40,10,'10T',0),(41,10,'JC',0),(42,10,'JP',0),(43,10,'JD',0),(44,10,'JT',0),(45,10,'QC',0),(46,10,'QP',0),(47,10,'QD',0),(48,10,'QT',0),(49,10,'KC',0),(50,10,'KP',0),(51,10,'KD',0),(52,10,'KT',0);
/*!40000 ALTER TABLE `carta` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-10 17:47:43

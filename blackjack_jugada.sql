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
-- Table structure for table `jugada`
--

DROP TABLE IF EXISTS `jugada`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jugada` (
  `idjugada` int NOT NULL AUTO_INCREMENT,
  `idUsuario` int NOT NULL,
  `estado` tinyint(1) NOT NULL,
  PRIMARY KEY (`idjugada`),
  KEY `fk_usuario_idx_idx` (`idUsuario`),
  CONSTRAINT `fk_usuario` FOREIGN KEY (`idUsuario`) REFERENCES `usuario` (`idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=116 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jugada`
--

LOCK TABLES `jugada` WRITE;
/*!40000 ALTER TABLE `jugada` DISABLE KEYS */;
INSERT INTO `jugada` VALUES (1,1,1),(2,1,1),(3,1,0),(4,1,0),(5,1,0),(6,1,0),(7,1,0),(8,1,0),(9,1,0),(10,1,0),(11,1,0),(12,1,0),(13,1,0),(14,1,0),(15,1,0),(16,1,0),(17,1,0),(18,1,0),(19,1,0),(20,1,0),(21,1,0),(22,1,0),(23,1,0),(24,1,0),(25,1,0),(26,1,0),(27,1,0),(28,1,0),(29,1,0),(30,1,0),(31,1,0),(32,1,0),(33,1,0),(34,1,0),(35,1,0),(36,1,0),(37,1,0),(38,1,0),(39,1,0),(40,1,0),(41,1,0),(42,1,0),(43,1,0),(44,1,0),(45,1,0),(46,1,0),(47,1,0),(48,1,0),(49,1,0),(50,1,0),(51,1,0),(52,1,0),(53,1,1),(54,1,0),(55,1,0),(56,1,0),(57,1,1),(58,1,1),(59,1,0),(60,2,1),(61,2,1),(62,2,1),(63,2,1),(64,2,1),(65,2,1),(66,2,1),(67,2,1),(68,2,0),(69,2,0),(70,2,0),(71,2,0),(72,2,0),(73,2,0),(74,2,0),(75,2,1),(76,2,0),(77,2,1),(78,2,0),(79,2,0),(80,2,0),(81,2,0),(82,2,0),(83,2,0),(84,2,0),(85,2,0),(86,2,0),(87,2,0),(88,2,0),(89,2,0),(90,2,1),(91,2,0),(92,2,1),(93,2,0),(94,2,0),(95,4,1),(96,4,1),(97,4,1),(98,4,1),(99,4,1),(100,4,1),(101,4,1),(102,4,1),(103,4,1),(104,4,1),(105,4,1),(106,4,1),(107,4,1),(108,4,1),(109,4,1),(110,4,1),(111,2,0),(112,2,0),(113,2,1),(114,2,0),(115,2,0);
/*!40000 ALTER TABLE `jugada` ENABLE KEYS */;
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

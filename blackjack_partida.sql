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
-- Table structure for table `partida`
--

DROP TABLE IF EXISTS `partida`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `partida` (
  `idPartida` int NOT NULL AUTO_INCREMENT,
  `idJugada` int NOT NULL,
  `puntosJugador` int NOT NULL,
  `puntosCrupier` int NOT NULL,
  `estado` tinyint(1) NOT NULL,
  `resultado` varchar(45) NOT NULL,
  PRIMARY KEY (`idPartida`),
  KEY `fk_jugada_idx` (`idJugada`),
  CONSTRAINT `fk_jugada` FOREIGN KEY (`idJugada`) REFERENCES `jugada` (`idjugada`)
) ENGINE=InnoDB AUTO_INCREMENT=112 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `partida`
--

LOCK TABLES `partida` WRITE;
/*!40000 ALTER TABLE `partida` DISABLE KEYS */;
INSERT INTO `partida` VALUES (1,1,20,22,1,'Perdiste'),(2,1,14,10,0,''),(3,4,20,10,1,'Ganaste'),(4,4,20,10,1,'Ganaste'),(5,8,18,25,0,'Ganaste!'),(6,8,15,26,0,'Ganaste!'),(7,10,21,22,1,'Ganaste!'),(8,8,20,22,1,'Ganaste!'),(9,10,0,0,0,''),(10,42,0,0,0,''),(11,49,13,0,1,''),(12,50,0,0,1,''),(13,51,14,0,1,''),(14,52,0,0,1,''),(15,53,24,18,1,'Ganaste!'),(16,50,0,0,1,''),(17,57,0,0,0,''),(18,58,0,0,0,''),(19,59,9,0,1,''),(20,60,20,18,1,'Ganaste!'),(21,60,16,0,1,''),(22,60,0,0,1,''),(23,61,7,0,1,''),(24,62,18,0,1,''),(25,61,12,0,1,''),(26,63,15,0,1,''),(27,64,8,0,1,''),(28,65,11,0,1,''),(29,66,12,24,1,'Ganaste!'),(30,65,8,0,1,''),(31,65,0,0,1,''),(32,67,5,0,1,''),(33,68,21,23,1,'Ganaste!'),(34,69,0,27,1,'Ganaste!'),(35,70,6,0,1,''),(36,71,16,0,1,''),(37,72,2,0,1,''),(38,73,12,0,1,''),(39,74,4,0,1,''),(40,75,25,0,0,''),(41,76,13,19,1,'Perdiste'),(42,77,20,0,0,''),(43,78,16,19,1,'Perdiste'),(44,79,30,0,0,'Perdiste'),(45,80,12,22,1,'Ganaste!'),(46,81,18,25,1,'Ganaste!'),(47,82,20,18,1,'Ganaste!'),(48,83,21,26,1,'Ganaste!'),(49,84,0,0,0,''),(50,84,0,0,0,''),(51,84,0,0,0,''),(52,84,0,0,0,''),(53,84,0,0,0,''),(54,84,0,21,0,'Perdiste'),(55,85,18,0,0,''),(56,86,16,18,1,'Perdiste'),(57,87,16,0,0,''),(58,88,21,21,1,'Empate'),(59,89,19,25,1,'Ganaste!'),(60,90,14,0,0,''),(61,92,14,0,0,''),(62,93,17,18,1,'Perdiste'),(63,94,23,20,1,'Ganaste!'),(64,92,0,0,0,''),(65,95,15,0,0,''),(66,95,0,0,0,''),(67,96,30,19,0,'Ganaste!'),(68,97,0,0,0,''),(69,98,21,18,0,'Ganaste!'),(70,98,0,0,0,''),(71,98,24,20,0,'Ganaste!'),(72,98,24,18,0,'Ganaste!'),(73,98,0,0,0,''),(74,98,24,22,0,'Perdiste'),(75,98,23,20,0,''),(76,99,0,0,0,''),(77,99,0,0,0,''),(78,99,27,21,0,'Perdiste'),(79,99,0,0,0,''),(80,99,11,23,0,'Ganaste!'),(81,100,21,19,0,''),(82,101,2,24,0,'Ganaste!'),(83,102,24,22,0,'Perdiste'),(84,102,21,25,0,'Ganaste!'),(85,103,21,18,0,'Ganaste!'),(86,104,20,21,0,'Perdiste'),(87,105,21,25,0,'Ganaste!'),(88,106,0,0,0,''),(89,107,20,27,0,'Ganaste!'),(90,108,21,22,0,'Ganaste!'),(91,108,0,0,0,''),(92,108,27,20,0,'Ganaste!'),(93,109,0,0,0,''),(94,109,19,23,0,'Ganaste!'),(95,110,0,0,0,''),(96,110,0,0,0,''),(97,110,20,22,0,'Ganaste!'),(98,110,0,0,0,''),(99,110,0,0,0,''),(100,110,18,19,0,'Perdiste'),(101,111,16,22,0,'Ganaste!'),(102,112,20,25,0,'Ganaste!'),(103,112,0,0,0,''),(104,112,21,22,0,'Ganaste!'),(105,112,17,19,0,'Perdiste'),(106,113,0,0,0,''),(107,113,30,23,0,'Perdiste'),(108,114,0,0,0,''),(109,114,22,10,0,'Perdiste'),(110,115,0,0,0,''),(111,115,15,20,0,'Perdiste');
/*!40000 ALTER TABLE `partida` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-11-10 17:47:45

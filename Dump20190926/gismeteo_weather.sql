-- MySQL dump 10.13  Distrib 8.0.17, for Win64 (x86_64)
--
-- Host: localhost    Database: gismeteo
-- ------------------------------------------------------
-- Server version	8.0.17

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
-- Table structure for table `weather`
--

DROP TABLE IF EXISTS `weather`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `weather` (
  `idweather` int(11) NOT NULL AUTO_INCREMENT,
  `day` datetime NOT NULL,
  `cityid` int(11) NOT NULL,
  `nightTemp` varchar(45) NOT NULL,
  `dayTemp` varchar(45) NOT NULL,
  `description` varchar(45) NOT NULL,
  PRIMARY KEY (`idweather`),
  KEY `cityid` (`cityid`),
  CONSTRAINT `weather_ibfk_1` FOREIGN KEY (`cityid`) REFERENCES `city` (`idCity`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `weather`
--

LOCK TABLES `weather` WRITE;
/*!40000 ALTER TABLE `weather` DISABLE KEYS */;
INSERT INTO `weather` VALUES (1,'2019-09-27 00:00:00',1,'3','15','Переменная облачность, небольшой дождь'),(2,'2019-09-27 00:00:00',2,'8','13','Пасмурно, небольшой дождь'),(3,'2019-09-27 00:00:00',3,'5','15','Переменная облачность'),(4,'2019-09-27 00:00:00',4,'7','12','Пасмурно, небольшой дождь'),(5,'2019-09-27 00:00:00',5,'0','5','Облачно, замерзающий дождь'),(6,'2019-09-27 00:00:00',6,'4','8','Пасмурно, небольшой дождь'),(7,'2019-09-27 00:00:00',7,'8','19','Переменная облачность, дождь'),(8,'2019-09-27 00:00:00',8,'12','22','Переменная облачность, небольшой дождь'),(9,'2019-09-27 00:00:00',9,'1','11','Переменная облачность'),(10,'2019-09-27 00:00:00',10,'2','9','Пасмурно, небольшой дождь'),(11,'2019-09-27 00:00:00',11,'5','7','Пасмурно, небольшой дождь'),(12,'2019-09-27 00:00:00',12,'1','11','Переменная облачность, небольшой дождь'),(13,'2019-09-27 00:00:00',13,'3','12','Облачно'),(14,'2019-09-27 00:00:00',14,'-1','11','Переменная облачность, небольшой дождь'),(15,'2019-09-27 00:00:00',15,'4','9','Пасмурно, небольшой дождь'),(16,'2019-09-27 00:00:00',16,'2','5','Пасмурно, небольшой дождь'),(17,'2019-09-27 00:00:00',17,'9','16','Пасмурно, небольшой дождь'),(18,'2019-09-27 00:00:00',18,'3','11','Облачно, небольшой дождь'),(19,'2019-09-27 00:00:00',19,'6','9','Пасмурно, небольшой дождь'),(20,'2019-09-27 00:00:00',20,'5','13','Пасмурно, небольшой дождь'),(21,'2019-09-27 00:00:00',21,'5','12','Переменная облачность, небольшой дождь'),(22,'2019-09-27 00:00:00',22,'0','7','Малооблачно, небольшой дождь'),(23,'2019-09-27 00:00:00',23,'1','7','Пасмурно, замерзающий дождь'),(24,'2019-09-27 00:00:00',24,'0','6','Переменная облачность, небольшой дождь');
/*!40000 ALTER TABLE `weather` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-09-26 12:58:58

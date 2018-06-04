-- Скрипт сгенерирован Devart dbForge Studio for MySQL, Версия 6.0.441.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/mysql/studio
-- Дата скрипта: 31.05.2018 14:32:43
-- Версия сервера: 5.5.25
-- Версия клиента: 4.1

-- 
-- Отключение внешних ключей
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Установка кодировки, с использованием которой клиент будет посылать запросы на сервер
--
SET NAMES 'utf8';

-- 
-- Установка базы данных по умолчанию
--
USE test21;

--
-- Описание для таблицы city
--
DROP TABLE IF EXISTS city;
CREATE TABLE city (
  IDc INT(11) NOT NULL AUTO_INCREMENT,
  cName VARCHAR(30) NOT NULL,
  cindex INT(6) NOT NULL,
  caddress VARCHAR(30) NOT NULL,
  PRIMARY KEY (IDc)
)
ENGINE = INNODB
AUTO_INCREMENT = 2
AVG_ROW_LENGTH = 16384
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Описание для таблицы type
--
DROP TABLE IF EXISTS type;
CREATE TABLE type (
  IDt INT(11) NOT NULL AUTO_INCREMENT,
  tname VARCHAR(30) NOT NULL,
  PRIMARY KEY (IDt)
)
ENGINE = INNODB
AUTO_INCREMENT = 4
AVG_ROW_LENGTH = 5461
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Описание для таблицы typeoplata
--
DROP TABLE IF EXISTS typeoplata;
CREATE TABLE typeoplata (
  IDto INT(11) NOT NULL AUTO_INCREMENT,
  toplata VARCHAR(30) NOT NULL,
  PRIMARY KEY (IDto)
)
ENGINE = INNODB
AUTO_INCREMENT = 3
AVG_ROW_LENGTH = 8192
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Описание для таблицы user
--
DROP TABLE IF EXISTS user;
CREATE TABLE user (
  IDu INT(11) NOT NULL AUTO_INCREMENT,
  upass VARCHAR(10) NOT NULL,
  ulogin VARCHAR(15) NOT NULL,
  PRIMARY KEY (IDu)
)
ENGINE = INNODB
AUTO_INCREMENT = 2
AVG_ROW_LENGTH = 16384
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Описание для таблицы klient
--
DROP TABLE IF EXISTS klient;
CREATE TABLE klient (
  IDk INT(11) NOT NULL AUTO_INCREMENT,
  kfio VARCHAR(40) NOT NULL,
  kserialnumber VARCHAR(40) NOT NULL,
  IDc INT(11) NOT NULL,
  PRIMARY KEY (IDk),
  INDEX IDc (IDc),
  CONSTRAINT klient_ibfk_1 FOREIGN KEY (IDc)
    REFERENCES city(IDc) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
AUTO_INCREMENT = 3
AVG_ROW_LENGTH = 8192
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Описание для таблицы oplata
--
DROP TABLE IF EXISTS oplata;
CREATE TABLE oplata (
  IDo INT(11) NOT NULL AUTO_INCREMENT,
  IDto INT(11) NOT NULL,
  Sdepat CHAR(40) NOT NULL,
  IDt INT(11) NOT NULL,
  PRIMARY KEY (IDo),
  INDEX IDt (IDt),
  INDEX IDto (IDto),
  CONSTRAINT oplata_ibfk_1 FOREIGN KEY (IDt)
    REFERENCES type(IDt) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT oplata_ibfk_2 FOREIGN KEY (IDto)
    REFERENCES typeoplata(IDto) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
AUTO_INCREMENT = 4
AVG_ROW_LENGTH = 5461
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Описание для таблицы poluchatel
--
DROP TABLE IF EXISTS poluchatel;
CREATE TABLE poluchatel (
  IDp INT(11) NOT NULL AUTO_INCREMENT,
  pFIO CHAR(40) NOT NULL,
  IDc INT(11) NOT NULL,
  PRIMARY KEY (IDp),
  UNIQUE INDEX UK_poluchatel_IDc (IDc),
  CONSTRAINT FK_poluchatel_city_IDc FOREIGN KEY (IDc)
    REFERENCES city(IDc) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
AUTO_INCREMENT = 2
AVG_ROW_LENGTH = 16384
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Описание для таблицы dostavka
--
DROP TABLE IF EXISTS dostavka;
CREATE TABLE dostavka (
  IDd INT(11) NOT NULL AUTO_INCREMENT,
  tdost CHAR(20) NOT NULL,
  IDo INT(11) NOT NULL,
  PRIMARY KEY (IDd),
  INDEX IDo (IDo),
  CONSTRAINT dostavka_ibfk_1 FOREIGN KEY (IDo)
    REFERENCES oplata(IDo) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
AUTO_INCREMENT = 5
AVG_ROW_LENGTH = 4096
CHARACTER SET utf8
COLLATE utf8_general_ci;

--
-- Описание для таблицы zayavka
--
DROP TABLE IF EXISTS zayavka;
CREATE TABLE zayavka (
  IDz INT(11) NOT NULL AUTO_INCREMENT,
  IDd INT(11) NOT NULL,
  IDk INT(11) NOT NULL,
  IDu INT(11) NOT NULL,
  IDp INT(11) NOT NULL,
  PRIMARY KEY (IDz),
  INDEX IDd (IDd),
  INDEX IDk (IDk),
  INDEX IDu (IDu),
  CONSTRAINT FK_zayavka_poluchatel_IDp FOREIGN KEY (IDp)
    REFERENCES poluchatel(IDp) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT zayavka_ibfk_1 FOREIGN KEY (IDd)
    REFERENCES dostavka(IDd) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT zayavka_ibfk_2 FOREIGN KEY (IDk)
    REFERENCES klient(IDk) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT zayavka_ibfk_3 FOREIGN KEY (IDu)
    REFERENCES user(IDu) ON DELETE RESTRICT ON UPDATE RESTRICT
)
ENGINE = INNODB
AUTO_INCREMENT = 3
AVG_ROW_LENGTH = 16384
CHARACTER SET utf8
COLLATE utf8_general_ci;

DELIMITER $$

--
-- Описание для процедуры procedure1
--
DROP PROCEDURE IF EXISTS procedure1$$
CREATE DEFINER = 'root'@'localhost'
PROCEDURE procedure1(IN Param1 INT)
BEGIN
UPDATE oplata o
  SET
  o.Sdepat= o.Sdepat+o.Sdepat*Paramal/100;
END
$$

--
-- Описание для функции function1
--
DROP FUNCTION IF EXISTS function1$$
CREATE DEFINER = 'root'@'localhost'
FUNCTION function1(s CHAR(20))
  RETURNS char(50) CHARSET utf8
BEGIN
SELECT o.Sdepat INTO s FROM oplata o where d.IDd=2;
  
RETURN CONCAT("Категория для VIP клиентов- ",s,"!"); 

END
$$

DELIMITER ;

-- 
-- Вывод данных для таблицы city
--
INSERT INTO city VALUES
(1, 'Калинодинозаврск', 667000, 'Сурикова 6б');

-- 
-- Вывод данных для таблицы type
--
INSERT INTO type VALUES
(1, 'Стандартная'),
(2, 'Срочная'),
(3, 'Заказная');

-- 
-- Вывод данных для таблицы typeoplata
--
INSERT INTO typeoplata VALUES
(1, 'Наличными'),
(2, 'Безнал\r\n\r\n');

-- 
-- Вывод данных для таблицы user
--
INSERT INTO user VALUES
(1, 'VitktoriaA', '23er45ty');

-- 
-- Вывод данных для таблицы klient
--
INSERT INTO klient VALUES
(1, 'Ноголомов Никита Ефпатьевич', '0416 199780', 1),
(2, 'Ноголомава Нина Анатольевна', '0415 199700', 1);

-- 
-- Вывод данных для таблицы oplata
--
INSERT INTO oplata VALUES
(1, 1, '500', 1),
(2, 2, '800', 2),
(3, 1, '1000', 3);

-- 
-- Вывод данных для таблицы poluchatel
--
INSERT INTO poluchatel VALUES
(1, 'Антонов Акакий Аристархович', 1);

-- 
-- Вывод данных для таблицы dostavka
--
INSERT INTO dostavka VALUES
(1, 'Письмо', 1),
(2, 'Бандероль', 2),
(3, 'Посылочка', 3),
(4, 'Заказное письмо', 1);

-- 
-- Вывод данных для таблицы zayavka
--
INSERT INTO zayavka VALUES
(2, 1, 1, 1, 1);

-- 
-- Включение внешних ключей
-- 
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
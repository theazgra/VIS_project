-- Generated by Oracle SQL Developer Data Modeler 4.1.5.907
--   at:        2017-04-12 11:45:16 CEST
--   site:      SQL Server 2012
--   type:      SQL Server 2012




CREATE
  TABLE City
  (
    Id INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    name NVARCHAR (30) NOT NULL ,
    zipCode NVARCHAR (10) NOT NULL ,
    District_Id INTEGER NOT NULL ,
    Region_Id   INTEGER NOT NULL
  )
  ON "default"
GO
ALTER TABLE City ADD CONSTRAINT City_PK PRIMARY KEY CLUSTERED (Id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE Customer
  (
    Id INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    name NVARCHAR (20) NOT NULL ,
	login NVARCHAR (20) NOT NULL ,
	password NVARCHAR (150) NOT NULL,
	userLevel INTEGER NOT NULL DEFAULT 3,
    surename NVARCHAR (30) NOT NULL ,
    personalNumber NVARCHAR (12) NOT NULL ,
    phone NVARCHAR (15) ,
    email NVARCHAR (50) ,
    distilledVolume FLOAT NOT NULL DEFAULT 0 ,
    registrationDate DATETIME NOT NULL,
    note NVARCHAR (200) ,
    street NVARCHAR (30) ,
    houseNumber NVARCHAR (10) NOT NULL ,
    City_Id INTEGER NOT NULL
  )
  ON "default"
GO
ALTER TABLE Customer ADD CONSTRAINT Customer_PK PRIMARY KEY CLUSTERED (Id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE Distillation
  (
    Id        INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
	date DATETIME NOT NULL ,
    startTime DATETIME NOT NULL ,
    endTime   DATETIME NOT NULL ,
    amount FLOAT NOT NULL ,
    ethanolPercentage FLOAT NOT NULL ,
    distilledVolume FLOAT NOT NULL ,
    absoluteAlcoholVolume FLOAT NOT NULL ,
    price FLOAT NOT NULL ,
    payed BIT NOT NULL DEFAULT 0 ,
    Customer_Id INTEGER NOT NULL ,
    Season_Id   INTEGER NOT NULL ,
    Period_Id   INTEGER NOT NULL ,
    Material_Id INTEGER NOT NULL
  )
  ON "default"
GO
ALTER TABLE Distillation ADD CONSTRAINT Distillation_PK PRIMARY KEY CLUSTERED (
Id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE District
  (
    Id INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    name NVARCHAR (50) NOT NULL
  )
  ON "default"
GO
ALTER TABLE District ADD CONSTRAINT District_PK PRIMARY KEY CLUSTERED (Id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE Material
  (
    Id INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    name NVARCHAR (15) NOT NULL
  )
  ON "default"
GO
ALTER TABLE Material ADD CONSTRAINT Material_PK PRIMARY KEY CLUSTERED (Id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE Period
  (
    Id INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    name NVARCHAR (20) NOT NULL ,
    startDate DATETIME NOT NULL ,
    endDate   DATETIME ,
    finished BIT NOT NULL DEFAULT 0 ,
    Season_Id INTEGER NOT NULL
  )
  ON "default"
GO
ALTER TABLE Period ADD CONSTRAINT Period_PK PRIMARY KEY CLUSTERED (Id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE Region
  (
    Id INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    name NVARCHAR (50) NOT NULL
  )
  ON "default"
GO
ALTER TABLE Region ADD CONSTRAINT Region_PK PRIMARY KEY CLUSTERED (Id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE
  TABLE Season
  (
    Id        INTEGER NOT NULL IDENTITY NOT FOR REPLICATION ,
    name      VARCHAR (20) NOT NULL ,
    startDate DATETIME NOT NULL ,
    endDate   DATETIME ,
    finished BIT NOT NULL DEFAULT 0 ,
    distillationCount INTEGER NOT NULL DEFAULT 0
  )
  ON "default"
GO
ALTER TABLE Season ADD CONSTRAINT Season_PK PRIMARY KEY CLUSTERED (Id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE TABLE Reservation
	(
		Id INTEGER NOT NULL IDENTITY NOT FOR REPLICATION,
		ReservationDate DATETIME NOT NULL,
		RequestedDate DATETIME NOT NULL,
		Customer_id INTEGER NOT NULL,
		Material_id INTEGER NOT NULL,
		MaterialAmount FLOAT NOT NULL
	)
  ON "default"
GO
ALTER TABLE Reservation ADD CONSTRAINT Reservation_PK PRIMARY KEY CLUSTERED (Id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

CREATE TABLE UserInfo
	(
		Id INTEGER NOT NULL IDENTITY NOT FOR REPLICATION,
		Login NVARCHAR(20) NOT NULL,
		Password NVARCHAR(150) NOT NULL,
		UserLevel INTEGER NOT NULL DEFAULT 2
	)
  ON "default"
 GO
ALTER TABLE UserInfo ADD CONSTRAINT UserInfo_PK PRIMARY KEY CLUSTERED (Id)
WITH
  (
    ALLOW_PAGE_LOCKS = ON ,
    ALLOW_ROW_LOCKS  = ON
  )
  ON "default"
GO

ALTER TABLE City
ADD CONSTRAINT City_District_FK FOREIGN KEY
(
District_Id
)
REFERENCES District
(
Id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE City
ADD CONSTRAINT City_Region_FK FOREIGN KEY
(
Region_Id
)
REFERENCES Region
(
Id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE Customer
ADD CONSTRAINT Customer_City_FK FOREIGN KEY
(
City_Id
)
REFERENCES City
(
Id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE Distillation
ADD CONSTRAINT Distillation_Customer_FK FOREIGN KEY
(
Customer_Id
)
REFERENCES Customer
(
Id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE Distillation
ADD CONSTRAINT Distillation_Material_FK FOREIGN KEY
(
Material_Id
)
REFERENCES Material
(
Id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE Distillation
ADD CONSTRAINT Distillation_Period_FK FOREIGN KEY
(
Period_Id
)
REFERENCES Period
(
Id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE Distillation
ADD CONSTRAINT Distillation_Season_FK FOREIGN KEY
(
Season_Id
)
REFERENCES Season
(
Id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE Period
ADD CONSTRAINT Period_Season_FK FOREIGN KEY
(
Season_Id
)
REFERENCES Season
(
Id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE Reservation
ADD CONSTRAINT Reservation_Customer_FK FOREIGN KEY
(
Customer_Id
)
REFERENCES Customer
(
Id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO

ALTER TABLE Reservation
ADD CONSTRAINT Reservation_Material_FK FOREIGN KEY
(
Material_Id
)
REFERENCES Material
(
Id
)
ON
DELETE
  NO ACTION ON
UPDATE NO ACTION
GO


ALTER TABLE Customer
ADD CONSTRAINT IO_1_DistilledVolumeCustomer
CHECK (distilledVolume >= 0);

ALTER TABLE Distillation
ADD CONSTRAINT IO_2_DistilledVolumeDistillaion
CHECK (distilledVolume >= 0);

ALTER TABLE Distillation
ADD CONSTRAINT IO_3_StartEndTime
CHECK (startTime < endTime);

ALTER TABLE Distillation
ADD CONSTRAINT IO_4_DistillationAmount
CHECK (amount > 0);

ALTER TABLE Distillation
ADD CONSTRAINT IO_5_EthanolPercentage
CHECK (ethanolPercentage  BETWEEN 0 AND 100);

ALTER TABLE Distillation
ADD CONSTRAINT IO_6_AbsoluteAlcoholVolume
CHECK (absoluteAlcoholVolume > 0);

ALTER TABLE Season
ADD CONSTRAINT IO_7_SeasonStartEndDate
CHECK (startDate < endDate);

ALTER TABLE Period
ADD CONSTRAINT IO_7_PeriodStartEndDate
CHECK (startDate < endDate);

ALTER TABLE Season
ADD CONSTRAINT IO_8_SeasonDistillationCount
CHECK (distillationCount >= 0);

ALTER TABLE UserInfo	
ADD CONSTRAINT IO_UserLevel
CHECK (UserLevel  BETWEEN 1 AND 3);



-- Oracle SQL Developer Data Modeler Summary Report: 
-- 
-- CREATE TABLE                             8
-- CREATE INDEX                             0
-- ALTER TABLE                             16
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE DATABASE                          0
-- CREATE DEFAULT                           0
-- CREATE INDEX ON VIEW                     0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE ROLE                              0
-- CREATE RULE                              0
-- CREATE SCHEMA                            0
-- CREATE SEQUENCE                          0
-- CREATE PARTITION FUNCTION                0
-- CREATE PARTITION SCHEME                  0
-- 
-- DROP DATABASE                            0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0

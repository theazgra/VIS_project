INSERT INTO Material (name) VALUES ('Hruöka'), ('ävestka'), ('Jablko'), ('MeruÚka'), ('T¯eöeÚ');
INSERT INTO Region (name) VALUES ('Moravskoslezsk˝ kraj'), ('Olomouck˝ kraj'), ('St¯edoËesk˝ kraj'), ('JihoËesk˝ kraj');
INSERT INTO District (name) VALUES ('Opava'), ('Ostrava'), ('Praha'), ('»esk˝ Krumlov'), ('P¯Ìbram'), ('Olomouc');

INSERT INTO City (name, zipCode, District_Id, Region_Id) 
	VALUES
	('Strahovice', '74724', 1, 1),
	('Haù', '74712', 1, 1),
	('Opava', '74733', 1, 1),
	('Radkov', '74788', 1, 1),--
	('Ostrava', '74750', 2, 1),
	('Klimkovice', '74713', 2, 1),
	('V·clavocice', '75586', 2, 1),
	('V¯esina', '75750', 2, 1),
	('Olomouc', '78754', 6, 2),
	('Babice', '78752', 6, 2),
	('Bouzov', '78753', 6, 2),
	('Lipina', '78655', 6, 2),
	('B¯eznice', '79655', 5, 3),
	('CetynÏ', '75655', 5, 3),
	('Mileöovice', '74655', 5, 3),
	('»esk˝ Krumlov', '11455', 4, 4),
	('P¯ÌdolÌ', '74658', 4, 4),
	('SobÏnov', '74650', 4, 4);


INSERT INTO Customer (name, surename, personalNumber, street, houseNumber,  City_Id, phone, email, registrationDate)
	VALUES
	('Vojta', 'Moravec', '774288/4654', 'Kolonie', '25/5', 1, '555223985', NULL, '2010-04-10 19:30:31.483'),
	('Luk·ö', 'SkoËdopole', '774118/1233', 'Nov·', '5', 2, NULL, 'luk.skoc@vsb.cz', '2010-02-13 19:30:31.483'),
	('Jan', 'Luk·ö', '774258/5225', 'äikm·', '233', 3, '123455612', NULL, '2010-08-25 19:30:31.483'),
	('Petr', 'Jones', '745658/1165', '1. M·je', '21/5', 4, NULL, NULL, '2013-01-20 19:30:31.483'),
	('Pavel', 'SkleniËka', '724258/5665', 'AlejnÌ', '255', 5, '555223985', 'skelPal@seznam.cz', '2013-05-20 19:30:31.483'),
	('Marek', 'St˘l', '774299/5665', 'Trubkov·', '155', 6, '112553996', NULL, '2013-07-20 19:30:31.483'),
	('Eliöka', 'Jorin', '111225/5665', 'KLDR', '236/8', 7, NULL, NULL, '2016-04-20 19:30:31.483'),
	('Tom·ö', 'Nov·k', '7125258/5665', 'Beze jmen·', '210', 8, '553665285', 'novytom@centrum.cz', '2016-04-20 19:30:31.483');

INSERT INTO Season (name, startDate, endDate, finished) VALUES ('2015/2016', '2015-08-20 15:44:35.110', '2016-04-20 15:44:35.110', 1);
INSERT INTO Season (name, startDate, endDate, finished) VALUES ('2016/2017', '2016-07-15 10:44:35.110', NULL, 0);

INSERT INTO Period (name, startDate, endDate, finished, Season_Id) VALUES ('Srpen 2015', '2015-08-01 15:50:35.110', '2015-09-01 15:50:35.110', 1, 1);
INSERT INTO Period (name, startDate, endDate, finished, Season_Id) VALUES ('Z·¯Ì 2015', '2015-09-01 15:50:35.110', '2015-10-01 15:50:35.110', 1, 1);
INSERT INTO Period (name, startDate, endDate, finished, Season_Id) VALUES ('Srpen 2016', '2016-08-01 15:50:35.110', '2016-09-01 15:50:35.110', 1, 2);
INSERT INTO Period (name, startDate, endDate, finished, Season_Id) VALUES ('Duben 2017', '2017-04-01 15:50:35.110', NULL, 0, 2);


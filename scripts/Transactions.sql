INSERT INTO Transactions (PostId, Price, DateFrom, DateTo, PayerId, Status)
VALUES 
(
	(SELECT id FROM Posts WHERE Title = 'Shadowrun Trilogy PS4 '),
	70,
	'2022-04-01', '2022-04-23', 
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	1),
(
	(SELECT id FROM Posts WHERE Title = 'Gotham Knights'),
	100,
	'2022-04-03', '2022-04-05', 
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	2),
(
	(SELECT id FROM Posts WHERE Title = 'Sonic Origins PS4'),
	10,
	'2022-05-01', '2022-05-02', 
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	2),
(
	(SELECT id FROM Posts WHERE Title = 'DEATHLOOP PS4'),
	200,
	'2022-06-02', '2022-06-12', 
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	0)
;

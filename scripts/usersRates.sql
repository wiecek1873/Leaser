INSERT INTO UserRates (RaterUserId, RatedUserId, Rate, Comment)
VALUES 
(
	(SELECT id FROM AspNetUsers WHERE NickName = 'MsMittens'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	5, 'Very nice person'),
(
	(SELECT id FROM AspNetUsers WHERE NickName = 'PandoraBox'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	5, 'WillHunting is very professional, everything went well'),
(
	(SELECT id FROM AspNetUsers WHERE NickName = 'Reformer'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	5, 'Cute, talkative girl'),
(
	(SELECT id FROM AspNetUsers WHERE NickName = 'Bulletheart'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	5, 'I recommend this person'),
(
	(SELECT id FROM AspNetUsers WHERE NickName = 'Crazywar'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	4, 'Small misunderstanding about meeting, but generally was okay'),
(
	(SELECT id FROM AspNetUsers WHERE NickName = 'Commandame'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	5, 'It is worth to rent something from WillHunting just to meet her :)'),
(
	(SELECT id FROM AspNetUsers WHERE NickName = 'Succotash'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	5, 'It was OK'),
(
	(SELECT id FROM AspNetUsers WHERE NickName = 'SmokePlumes'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	5, 'No complains'),
(
	(SELECT id FROM AspNetUsers WHERE NickName = 'Megalith'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	5, ''),
(
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'MsMittens'),
	5, 'It was good transaction.');
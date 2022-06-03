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

delete from Posts;

INSERT INTO Posts (CategoryId, UserId, Title, Description, Price, PricePerWeek, PricePerMonth, AvailableFrom, AvailableTo, DepositValue, Image)
VALUES
(	
	(SELECT id FROM Categories WHERE CategoryName = 'Games'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'MsMittens'),
	'Horizon Forbidden West',
	'Edition includes:
		- Full game (PS5 and PS4).
		Join Aloy as she braves the Forbidden West, a deadly frontier that conceals mysterious new threats.',
	10, 8, 6, 
	'2022-01-01', '2022-03-10', 
	120,
	(SELECT * FROM OPENROWSET(BULK 'C:\images\HorizonForbiddenWest.jpg', SINGLE_BLOB) AS IMG)),
(	
	(SELECT id FROM Categories WHERE CategoryName = 'Games'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'Commandame'),
	'Sniper Elite 5 PS4',
	'The latest instalment in the award-winning series, Sniper Elite 5 offers unparalleled sniping, tactical third-person combat and an enhanced kill cam. Fight your way across the most immersive maps yet, with many real-world locations captured in stunning detail, and an improved traversal system that lets you explore more of them than ever before.
	France, 1944 – As part of a covert US Rangers operation to weaken the Atlantikwall fortifications along the coast of Brittany, elite marksman Karl Fairburne makes contact with the French Resistance. Soon they uncover a secret Nazi project that threatens to end the war before the Allies can even invade Europe: Operation Kraken.

	EXPANSIVE CAMPAIGN
	Many real-world locations have been captured using photogrammetry to recreate a living, immersive environment, and multiple infiltration and extraction points and kill list targets provide a whole new perspective on each mission. Take on the Nazi plot solo or work with a partner, with improved co-op mechanics allowing you to share ammo and items, give orders and heal each other.',
	3, 3, 2, 
	'2022-01-01', '2022-03-10', 
	20,
	(SELECT * FROM OPENROWSET(BULK 'C:\images\SniperElite5.jpg', SINGLE_BLOB) AS IMG)),
(	
	(SELECT id FROM Categories WHERE CategoryName = 'Games'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'MsMittens'),
	'DEATHLOOP PS4',
	'DEATHLOOP is a next-gen first person shooter from Arkane Lyon, the award-winning studio behind Dishonored. In DEATHLOOP, two rival assassins are trapped in a mysterious timeloop on the island of Blackreef, doomed to repeat the same day for eternity. As Colt, the only chance for escape is to end the cycle by assassinating eight key targets before the day resets. Learn from each cycle - try new paths, gather intel, and find new weapons and abilities. Do whatever it takes to break the loop.',
	5, 4, 4, 
	'2022-01-01', '2022-03-10', 
	100,
	(SELECT * FROM OPENROWSET(BULK 'C:\images\DEATHLOOP.jpg', SINGLE_BLOB) AS IMG)),
(	
	(SELECT id FROM Categories WHERE CategoryName = 'Games'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	'ELDEN RING PS4',
	'THE NEW FANTASY ACTION RPG.
	Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between.

	- A Vast World Full of Excitement
	A vast world where open fields with a variety of situations and huge dungeons with complex and three-dimensional designs are seamlessly connected. As you explore, the joy of discovering unknown and overwhelming threats await you, leading to a high sense of accomplishment.

	- Create your Own Character
	In addition to customizing the appearance of your character, you can freely combine the weapons, armor, and magic that you equip. You can develop your character according to your play style, such as increasing your muscle strength to become a strong warrior, or mastering magic.',
	10, 8, 6, 
	'2022-01-01', '2022-03-10', 
	70,
	(SELECT * FROM OPENROWSET(BULK 'C:\images\ELDENRING.jpg', SINGLE_BLOB) AS IMG)),
(	
	(SELECT id FROM Categories WHERE CategoryName = 'Games'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'Crazywar'),
	'Silt',
	'Silt is a surreal underwater puzzle-adventure game. Alone in an underwater abyss, you are a diver searching the deep to uncover long-forgotten mysteries. Possess the creatures around you to solve puzzles and travel further into the darkness…

	Nature has evolved into bizarre forms. Discover strange organisms, unexplored ruins and ancient machinery hidden beneath the water’s surface.

	Survive encounters with giant deep-sea goliaths. Harness their power to awaken a long-dormant force at the centre of the abyss.

	Experience art brought to life. Silt’s unsettling, monochrome world is constructed from the sketches and dark imagination of artist Mr Mead. A harrowing journey awaits you…',
	10, 8, 6, 
	'2022-01-01', '2022-08-10', 
	50,
	(SELECT * FROM OPENROWSET(BULK 'C:\images\Silt.jpeg', SINGLE_BLOB) AS IMG)),
(	
	(SELECT id FROM Categories WHERE CategoryName = 'Games'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	'The Quarry for PS5',
	'YOUR STORY, THEIR FATE
	Will you save your friends or run for your life? Every choice, big or small, shapes your story and determines who lives to tell the tale.

	A STUNNING CINEMATIC EXPERIENCE
	Cutting edge facial capture and filmic lighting techniques, combined with incredible performances from an iconic cast of Hollywood talent, bring the horrors of Hackett’s Quarry to life.

	ENJOY THE FRIGHT WITH FRIENDS
	Play with up to 7 friends online*, where invited players watch along and vote on key decisions, creating a story shaped by the whole group! Or, play together in a party horror couch co-op experience where each player controls a counselor.

	CUSTOMIZE YOUR EXPERIENCE
	Adjustable difficulty lets players of any skill level enjoy the horror, while Movie Mode lets you enjoy The Quarry as a binge-worthy cinematic thriller.',
	10, 8, 6, 
	'2022-01-01', '2022-08-10', 
	50,
	(SELECT * FROM OPENROWSET(BULK 'C:\images\TheQuarry.jpg', SINGLE_BLOB) AS IMG)),
(	
	(SELECT id FROM Categories WHERE CategoryName = 'Games'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'WillHunting'),
	'F1 22 Champions Edition  PS4',
	'Enter the new era of Formula 1® in EA SPORTS™ F1® 22, the official videogame of the 2022 FIA Formula One World Championship™. Take your seat for a new season as redesigned cars and overhauled rules redefine race day, test your skills around the new Miami International Autodrome, and get a taste of the glitz and glamour in F1® Life.

	Race the stunning new cars of the Formula 1® 2022 season with the authentic lineup of all 20 drivers and 10 teams and take control of your race experience with new immersive or broadcast race sequences. Create a team and take them to the front of the grid with new depth in the acclaimed My Team career mode, race head-to-head in split-screen, Two-Player Career or in multiplayer, or change the pace by taking supercars from some of the sport’s biggest names to the track in our all-new Pirelli Hot Laps feature.',
	10, 8, 6, 
	'2022-01-01', '2022-08-10', 
	50,
	(SELECT * FROM OPENROWSET(BULK 'C:\images\F122ChampionsEdition.jpg', SINGLE_BLOB) AS IMG)),
(	
	(SELECT id FROM Categories WHERE CategoryName = 'Games'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'PandoraBox'),
	'Sonic Origins PS4',
	'Relive the classic collected adventures of Sonic The Hedgehog, Sonic The Hedgehog 2, Sonic 3 & Knuckles, and Sonic CD in the newly remastered Sonic Origins! From the iconic Green Hill Zone to the treacherous Death Egg Robot, youll speed down memory lane to thwart the sinister plans of Doctor Robotnik in polished high definition! This latest version includes new areas to explore, additional animations, and a brand new Anniversary mode!

	Classic Re-defined
	Explore the classic Sonic titles in high-resolution, with all-new opening and ending animations for each title!

	New Unlockables
	Complete various missions to collect coins to unlock new content, challenges, and Special Stages through the Museum.

	Classic and Anniversary Mode
	Choose to Spin Dash your way through the numerous zones in Classic mode with the games original resolution and limited lives, or the new Anniversary mode with unlimited lives and revamped fullscreen resolution.',
	10, 8, 6, 
	'2022-01-01', '2022-08-10', 
	50,
	(SELECT * FROM OPENROWSET(BULK 'C:\images\SonicOrigins.jpg', SINGLE_BLOB) AS IMG)),
(	
	(SELECT id FROM Categories WHERE CategoryName = 'Games'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'Reformer'),
	'Gotham Knights',
	'Batman is dead. A new expansive, criminal underworld has swept the streets of Gotham City. It is now up to the Batman Family - Batgirl, Nightwing, Red Hood, and Robin - to protect Gotham, bring hope to its citizens, discipline to its cops, and fear to its criminals.
	From solving mysteries that connect the darkest chapters in the city’s history to defeating notorious villains in epic confrontations.

	Gotham Knights is an open-world, action RPG set in the most dynamic and interactive Gotham City yet. Patrol Gotham’s five distinct boroughs in solo or in co-op and drop in on criminal activity wherever you find it.',
	10, 8, 6, 
	'2022-01-01', '2022-08-10', 
	50,
	(SELECT * FROM OPENROWSET(BULK 'C:\images\GothamKnights.jpg', SINGLE_BLOB) AS IMG)),
(	
	(SELECT id FROM Categories WHERE CategoryName = 'Games'),
	(SELECT id FROM AspNetUsers WHERE NickName = 'Bulletheart'),
	'Shadowrun Trilogy PS4 ',
	'The Shadowrun Trilogy comprises 3 cult tactical RPG games taking place in a dystopian cyberpunk future in which magic has re-awakened, bringing back to life creatures of high fantasy. Initially created as a tabletop RPG over 30 years ago, this one-of-a-kind setting that has gained a huge cult following during the past three decades.

	Shadowrun Returns
	The unique cyberpunk-meets-fantasy world of Shadowrun has gained a huge cult following since its creation over 30 years ago. Nearly 10 years ago, creator Jordan Weisman returned to the world of Shadowrun, modernizing this classic game setting as a single player, turn-based tactical RPG. In the urban sprawl of the Seattle metroplex, the search for a mysterious killer sets you on a trail that leads from the darkest slums to the city’s most powerful megacorps.

	You will need to tread carefully, enlist the aid of other runners, and master powerful forces of technology and magic in order to emerge from the shadows of Seattle unscathed.

	Shadowrun Dragonfall - Directors Cut
	In 2012, magic returned to our world, awakening powerful creatures of myth and legend. Among them was the Great Dragon Feuerschwinge, who emerged without warning from the mountains of Germany, unleashing fire, death, and untold destruction across the countryside. It took German forces nearly four months to finally shoot her down - and when they did, their victory became known as The Dragonfall.',
	10, 8, 6, 
	'2022-01-01', '2022-08-10', 
	50,
	(SELECT * FROM OPENROWSET(BULK 'C:\images\ShadowrunTrilogy.jpg', SINGLE_BLOB) AS IMG));
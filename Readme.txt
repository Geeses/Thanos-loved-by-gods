Haleluja!



--------------------------------------------

Um eine neue Scene zu erstellen:

1. File->New Scene

2. Im Inspector "Main Camera" l�schen

3. Im Ordner Essentials "DemoTile" ausw�hlen // oder alternativ eigene TileMap erstellen.
	4. Per Drag&Drop in die Scene einf�gen

5. Im Ordner Essentials "Base Structure" ausw�hlen
	6. Per Drag&Drop in die Scene einf�gen

7. Im Ordner Prefabs Input -> "Input Manager 1" ausw�hlen
	8. Per Drag&Drop in die Scene einf�gen

9. Im Ordner Essentials -> Enemy k�nnen verschiedene Gegner ausgew�hlt werden
	10. Per Drag&Drop in die Scene einf�gen

11. Im Ordner Prefabs -> Interactables "Door" ausw�hlen
	12. Per Drag&Drop in die Scene einf�gen

13. Im Ordner Prefabs -> Activator "Button" ausw�hlen
	14. Per Drag&Drop in die Scene einf�gen
		15. Im Inspector unter "Button.cs" -> das Gameobject "Door" (Schritt 11) aus der Hierarchy in die Liste ziehen

16. Im Ordner Prefabs -> Collectables "Collectable" ausw�hlen
	17. Per Drag&Drop in die Scene einf�gen
		18. In der Hierarchy -> Scene -> Base Structure -> Thanos -> "Collect.cs" den Wert je Coin einstellen

19. Alle anderen notwendigen Variablen k�nnen mit:
	20. [ESC] oder Start -> Pausemen� -> Options (vor�bergehend als Platzhalter f�r DebugOptions) 
		21. [ESc] oder Start = zur�ck zum Spiel
			22. In der angezeigten Debug-Leiste
    ge�ndert und unter "Save"-Button gespeichert werden. Der ResetButton �ndert zur�ck auf die gespeicherten Werte.


!!!!!!!!!!!!!!!BITTE BEACHTEN:  
				1.) Die Debug-Werte sind noch nicht eingestellt -> bitte nach Launch anpassen, speichern.
				2.) Dieses Debug Men� speichert nur innerhalb einer Editor-Anwendung, Im Build m�ssen die Werte bereits festgelegt worden sein.








Steuerung:

Thanos: 
Angriff		--	[R2]
Block		--	[L2]
Jump		--	[X]
Move		--	( L ) - Joystick

Zeus:

SpawnStone    	-- 	[L1]
SpawnThunder  	-- 	[R2]
SpawnTornado  	-- 	[L2]
Grab          	-- 	[R1]
Move          	-- 	( L )  Joystick
Cursor        	-- 	( R ) Joystick

Sonstige:

Pause         	-- 	[ESC] / Start

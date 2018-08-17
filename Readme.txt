Haleluja!



--------------------------------------------

Um eine neue Scene zu erstellen:

1. File->New Scene

2. Im Inspector "Main Camera" löschen

3. Im Ordner Essentials "DemoTile" auswählen // oder alternativ eigene TileMap erstellen.
	4. Per Drag&Drop in die Scene einfügen

5. Im Ordner Essentials "Base Structure" auswählen
	6. Per Drag&Drop in die Scene einfügen

7. Im Ordner Prefabs Input -> "Input Manager 1" auswählen
	8. Per Drag&Drop in die Scene einfügen

9. Im Ordner Essentials -> Enemy können verschiedene Gegner ausgewählt werden
	10. Per Drag&Drop in die Scene einfügen

11. Im Ordner Prefabs -> Interactables "Door" auswählen
	12. Per Drag&Drop in die Scene einfügen

13. Im Ordner Prefabs -> Activator "Button" auswählen
	14. Per Drag&Drop in die Scene einfügen
		15. Im Inspector unter "Button.cs" -> das Gameobject "Door" (Schritt 11) aus der Hierarchy in die Liste ziehen

16. Im Ordner Prefabs -> Collectables "Collectable" auswählen
	17. Per Drag&Drop in die Scene einfügen
		18. In der Hierarchy -> Scene -> Base Structure -> Thanos -> "Collect.cs" den Wert je Coin einstellen

19. Alle anderen notwendigen Variablen können mit:
	20. [ESC] oder Start -> Pausemenü -> Options (vorübergehend als Platzhalter für DebugOptions) 
		21. [ESc] oder Start = zurück zum Spiel
			22. In der angezeigten Debug-Leiste
    geändert und unter "Save"-Button gespeichert werden. Der ResetButton ändert zurück auf die gespeicherten Werte.


!!!!!!!!!!!!!!!BITTE BEACHTEN:  
				1.) Die Debug-Werte sind noch nicht eingestellt -> bitte nach Launch anpassen, speichern.
				2.) Dieses Debug Menü speichert nur innerhalb einer Editor-Anwendung, Im Build müssen die Werte bereits festgelegt worden sein.








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

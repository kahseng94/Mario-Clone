Team 5 Sprint 5 README
Game controls:
-P for Pause
-Q for Quit
-R for Reset
-End for Castle shortcut
Player Keyboard Controls:
-WASD or Arrow keys for moving 
-Z for Jumping
-X for Running or Shooting fireball

Gamepad controls:
- Up, Down, Left and Right button for Player movement
- A for Jumping
- B for Running or Shooting fireball

Additional Features:
-Jayson implemented a self modified level 1-4.
Level 1-4 included:
-Bowser which can shoot fire,
-Princess Peach at the end of the level 
-Fire wheel
-Different tiles and blocks  

-Jack implemented the new enemy Lakitu
Lakitu Features:
-moving left to right in the sky
-can shoot balls which can damage player

-Zijian implemented the Player controlled enemies
Enemy Key Control:
-B for increase the speed of enemy
-N for change enemy direction
-M for decrease the speed of enemy
-Space for Enemy Jumping Control
 
-Hecheng implemented cheat code for input processing funtionality
-Press A + X + W at the same time to get a extra live
-Press A + X + Up at the same time to turn mario into star mode
-Press A + X + Down at the same time to turn mario into Fire mode

-Mo implemented Achievement screen after the game is over or when the player is dead.
Achievement screen included:
-Collect all coins in the level
-Completed the level in 60 seconds
-Kill all the enemies in the level

Code Analysis Results:
1. There are 77 warnings in the code analysis result. These warning are not important and might cause more errors by changing them. Other than that, they are all resolved.
2. There are 7 warnings shows "Change the collection to be read only by removing the property setter" in WorldLoader.cs file.
-We choose to ignore them because changing them to be read only will cause unnecessary error  
3. There are 37 warning about SoundEffect and SoundObjectFactory All the fields and methods that prompted visible outside of its declared type cannot be changed to private because it will be inaccessible due to its protection level and the program won't run.
4. There are 11 warnings in the SaveState classes. Most of the warning has the same problem as the second bullet point above. Therefore, we choose to ignore them because changing them to be read only will cause unnecessary error.
5. In the LevelLoader.cs, all the initialization of new background element show a warning of "Object initialization can be simplified".
-Changing the original way of initialization will only make the code less readable.

6. Many warnings show that fields or methods are unused. In this case, fixing these warnings would make the code less readable.

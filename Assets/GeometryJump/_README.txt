
/////////////////////////// FIRST OF ALL ///////////////////////////
/////////////////////////// FIRST OF ALL ///////////////////////////
/////////////////////////// FIRST OF ALL ///////////////////////////
/////////////////////////// FIRST OF ALL ///////////////////////////
/////////////////////////// FIRST OF ALL ///////////////////////////

You need to import Dotween.


HOW TO IMPORT DOTWEEN? Have a look here: https://appadvisory.zendesk.com/hc/en-us/article_attachments/204212345/__HOW_TO_IMPORT_DOTWEEN.pdf


/////////////////////////// FIRST OF ALL ///////////////////////////
/////////////////////////// FIRST OF ALL ///////////////////////////
/////////////////////////// FIRST OF ALL ///////////////////////////
/////////////////////////// FIRST OF ALL ///////////////////////////
/////////////////////////// FIRST OF ALL ///////////////////////////





Thanks for your purchase.






To begin, open the scene "GeometryJump".


1 - Musics and FXs:

To Change a background music: Find the GameObject "Main Camera", and find the GameObject "SoundManager" and add your Audioclip music in the "Music Game" field.
Same thing for the Music Menu; and for the FX sounds.

2 - Scripts:

CameraShake.cs:
A simple script to shake the camera when the player hit an obstacle.

ColorManager.cs:
Script in charge to change the color of the background. You have 8 colors set by default. You can add more or change the colors already definied in the GameObject "ColorManager".

GameManager.cs:
This script is attached to the GameObject "GameManager".
This script in in charge of the game logic. And to spawn the obstacles.

MainCameraManager.cs:
This script is attached to the Main Camera. This script is in charge to follow the Player vertically.

MonoBehaviorHelper.cs:
An heper class to avoid some duplicate codes.

PlayerManager.cs:
This script is attached go the GameObject "Player".
In charge to detect the input, and to jump the player from one side to the other side, and detect collisions. 

ScoreManager.cs:
A script to handle the score and save the best score.

SoundManager.cs:
Script attached to the "SoundManager" GameObject (child of the MainCamara). In charge to play musics and sound effects.

CanvasManager.cs:
Script attached to the "CanvasManager" GameObject. In charge to display and change UI elements.

PopupContinue.cs:
Script attached to the "PopUpContinue" GameObject (child of CanvasManager). In charge to display the popup to continue when the player lose, and show a rewarded video if the player click or touch the popup. 

If you have any question, fell free to contact me : contact@app-advisory.com Thanks.
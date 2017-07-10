using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IFattenUpDefines : MonoBehaviour {

	//List Foods
	public const int BANANA 	= 0;
	public const int BONE		= 1;
	public const int SALLAD 	= 2;
	/*
	//List col animals
	public const int ANIMALS_COL[] = {GUI_LAYERS_GAME_PLAY.BUTTON_ANIMAL_1, 
		GUI_LAYERS_GAME_PLAY.BUTTON_ANIMAL_2, 
		GUI_LAYERS_GAME_PLAY.BUTTON_ANIMAL_3};

	//List Animals
	public const int ANIMALS_F[] = {ANIMALS.F_MONKEY,
		ANIMALS.F_DOG,
		ANIMALS.F_PIG};
	*/
	//Number max cols
	public const int MAX_COLS = 3;
	//public const int COL_WIDTH = IDefines.SCREEN_WIDTH/MAX_COLS;
	//Init value
	public const int COL_RESET = 0;
	public const int COL_START = 1;
	public const int SCORE_START = 0;
	public const int SPEED_START = 3;
	public const int LEVEL_START = 1;

	//Number max Foods
	public const int MAX_FOODS = 3;

	//Position Food of Cols
	//public const int WIDTH_HAFT_COL = 80;

	//Position End of Food
	//public const int FEEDED = 710;	

	// level info
	public const int LEVEL_COUNT = 4;

	public const int LEVEL_MAX_SCORE = 0;
	public const int LEVEL_SPEED = 1;
	public const int LEVEL_COLUMN = 2;
	public const int SCORE_TO_BG2COL = 5;
	public const int SCORE_TO_BG3COL = 15;
	public const float POS_X_COL2 = 1.3f;
	public const float POS_X_COL3 = 2f;

	/*Level			Score		Colunm		Speed
		1				0			1			
		2				4	
		3				8			2
		4				16			
		5				32			

	*/
	//{max score, speed, number of column}
	public static int [,] LEVEL_INFO = { {3, 12, 1}, {6, 15, 1}, {11, 12, 2}, {16, 15, 2}, {25, 12, 3} };
	//public const String NAME_DEFAULT = "Fatten Up";
}


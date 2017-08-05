using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDefine : MonoBehaviour {

	// List Foods
	public const int BANANA 	= 0;
	public const int BONE		= 1;
	public const int SALLAD 	= 2;

	// Name default
	public const string NAME_DEFAULT = "Player";

	// Init value
	public const int COL_START = 1;
	public const int SCORE_START = 0;
	public const int SPEED_START = 15;

	// Score to change BG
	public const int SCORE_TO_BG2COL = 12;
	public const int SCORE_TO_BG3COL = 16;

	// Position column
	public const float POS_X_COL2 = 1.3f;
	public const float POS_X_COL3 = 2f;

	// SPEED = [15, 35] => [15 * 0.02 * 10 = 3, 35 * 0.02 * 10 = 7]
	/*Level			Score		Colunm		Speed
		1			0				1		15		3		%2
		2			2						18		3.6
		3			4						21		4.2
		4			6						24		4.8
		5			8						27		5.4		
		6			10						30		6.0		
		7			12				2		25		5.0		%4
		8			16						27		5.4
		9			20						29		5.8
		10			22						31		6.2
		11			24						33		6.6

	*/
}
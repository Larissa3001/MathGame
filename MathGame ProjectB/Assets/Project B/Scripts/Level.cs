using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Level : MonoBehaviour {

	public const string Level1 = "Level1";
	public const string Level2 = "Level2";
	public const string Level3 = "Level3";
	public const string Level4 = "Level4";
	public const string Level5 = "Level5";
	public const string Level6 = "Level6";

	public static int number;
	public static string NextLevel,CurrentLevel,CurrentNumber;

	public Dictionary <string,string> lvlDict = new Dictionary<string, string>();

	bool onlyOnce1;
	bool onlyOnce2;
	bool onlyOnce3;
	bool onlyOnce4;
	bool onlyOnce5;


	void Start(){

		onlyOnce1 = true;
		onlyOnce2 = true;
		onlyOnce3 = true;
		onlyOnce4 = true;
		onlyOnce5 = true;


		lvlDict.Add (Level1, Level2);
		lvlDict.Add (Level2, Level3);
		lvlDict.Add (Level3, Level4);
		lvlDict.Add (Level4, Level5);
		lvlDict.Add (Level5, Level6);

		CurrentLevel = LevelMenu.CLvl;
		GetNextLevel();

	}

	void Update(){

		print (CurrentLevel);
		print (NextLevel);

		if(CurrentLevel != "Level6"){

		if(MathTaskLevel1.changeCurrentToNext && onlyOnce1){
			onlyOnce1 = false;
			CurrentLevel = NextLevel;
			GetNextLevel ();
		}
		if(MathTaskLevel2.changeCurrentToNext2 && onlyOnce2){
			onlyOnce2 = false;
			CurrentLevel = NextLevel;
			GetNextLevel ();
		}
		if(MathTaskLevel3.changeCurrentToNext3 && onlyOnce3){
			onlyOnce3 = false;
			CurrentLevel = NextLevel;
			GetNextLevel ();
		}
		if(MathTaskLevel4.changeCurrentToNext4 && onlyOnce4){
			onlyOnce4 = false;
			CurrentLevel = NextLevel;
			GetNextLevel ();
		}
		if(MathTaskLevel5.changeCurrentToNext5 && onlyOnce5){
			onlyOnce5 = false;
			CurrentLevel = NextLevel;
			GetNextLevel ();
		}
		
		}
		//print (CurrentLevel);
		//print ("Next Level:");
		//print (NextLevel);
	}

/*	void GetNextLevel(){

		
		if(lvlDict.TryGetValue(CurrentLevel, out NextLevel)){
			print ("Next Level:");
			print (NextLevel);
		}

	}*/

	void GetNextLevel(){

		if(CurrentLevel != "Level6"){

		CurrentNumber = CurrentLevel.Substring(CurrentLevel.Length - 1); 

		number = int.Parse (CurrentNumber);
		number += 1;
		CurrentNumber = number.ToString ();
		NextLevel = "Level" + CurrentNumber;
		}
	}
}

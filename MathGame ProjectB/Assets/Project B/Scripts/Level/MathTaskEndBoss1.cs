using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MathTaskEndBoss1 : MonoBehaviour {

	string MathTask1Str;
	string MathTask2Str;
	string MathTask3Str;

	bool bEL1TF;
	bool bEL2TF;
	bool bEL3TF;

	bool bEL4TF;
	bool bEL5TF;
	bool bEL6TF;

	bool bEL7TF;
	bool bEL8TF;
	bool bEL9TF;
	
	bool b1MathTask;
	bool b1Complete;
	bool b1Fail;
	bool b1Show;

	bool b2MathTask;
	bool b2Complete;
	bool b2Fail;
	bool b2Show;

	bool b3MathTask;
	bool b3Complete;
	bool b3Fail;
	bool b3Show;

	bool b1,b2,b3;
	
	public Dictionary <Texture2D,bool> MTaskEndBoss = new Dictionary <Texture2D,bool>();
	
	private bool toggle11button = false;
	private bool toggle12button = false;
	private bool toggle13button = false;

	private bool toggle21button = false;
	private bool toggle22button = false;
	private bool toggle23button = false;

	private bool toggle31button = false;
	private bool toggle32button = false;
	private bool toggle33button = false;
	
	Texture2D icon1el1;
	Texture2D icon1el2;
	Texture2D icon1el3;

	Texture2D icon2el1;
	Texture2D icon2el2;
	Texture2D icon2el3;

	Texture2D icon3el1;
	Texture2D icon3el2;
	Texture2D icon3el3;

	bool bool1Element1;
	bool bool1Element2;
	bool bool1Element3;

	bool bool2Element1;
	bool bool2Element2;
	bool bool2Element3;

	bool bool3Element1;
	bool bool3Element2;
	bool bool3Element3;

	public int Health;

	Time Time;

	bool bstart;

	bool onlyOnce1;
	bool onlyOnce2;
	bool onlyOnce3;

	// Use this for initialization
	void Start () {

		b1 = true;
		b2 = false;
		b3 = false;

		onlyOnce1 = true;
		onlyOnce2 = true;
		onlyOnce3 = true;

		bstart = true;

		Time.timeScale = 1;

		Health = PlayerPrefs.GetInt ("BossDamage");

		b1Show = true;
		b2Show = true;
		b3Show = true;


		b1MathTask = false;
		b2MathTask = false;
		b3MathTask = false;

		b1Complete = false;
		b2Complete = false;
		b3Complete = false;

		b1Fail = false;
		b2Fail = false;
		b3Fail = false;

		SetMathTasks ();
		


	}

	
	// Update is called once per frame
	void Update () {

		print (b1Fail);
		print (b1Complete);

		if(bstart){
			icon1el1 = Element1.Element1Icon;
			icon1el2 = Element2.Element2Icon;
			icon1el3 = Element3.Element3Icon;
			
			icon2el1 = Element4.Element4Icon;
			icon2el2 = Element5.Element5Icon;
			icon2el3 = Element6.Element6Icon;
			
			icon3el1 = Element7.Element7Icon;
			icon3el2 = Element8.Element8Icon;
			icon3el3 = Element9.Element9Icon;
			
			MTaskEndBoss.Add(icon1el1,bEL1TF);
			MTaskEndBoss.Add(icon1el2,bEL2TF);
			MTaskEndBoss.Add(icon1el3,bEL3TF);
			
			MTaskEndBoss.Add(icon2el1,bEL4TF);
			MTaskEndBoss.Add(icon2el2,bEL5TF);
			MTaskEndBoss.Add(icon2el3,bEL6TF);
			
			MTaskEndBoss.Add(icon3el1,bEL7TF);
			MTaskEndBoss.Add(icon3el2,bEL8TF);
			MTaskEndBoss.Add(icon3el3,bEL9TF);
			
			bstart = false;
		}

		Health = PlayerPrefs.GetInt ("BossDamage");


		print (Health);

		if(Health >= 6 && onlyOnce1){
			b1MathTask = true;
			onlyOnce1 = false;
		}
		if(Health >= 12 && onlyOnce2){
			b2MathTask = true;
			onlyOnce2 = false;
		}
		if(Health >= 18 && onlyOnce3){
			b3MathTask = true;
			onlyOnce3 = false;
		}
	}


	void SetMathTasks (){

		MathTask1Str = "Welche Elemente gehören zur Menge: A = {Farben heller als Blau} ?";

		bEL1TF = false;
		bEL2TF = true;
		bEL3TF = true;

		MathTask2Str = "Welche Elemente gehören zur Menge: A = {Farbe Orange} ?";

		bEL4TF = false;
		bEL5TF = true;
		bEL6TF = false;

		MathTask3Str = "Welche Elemente gehören zur Menge: A = {Alle außer Schwarz} ?";

		bEL7TF = true;
		bEL8TF = false;
		bEL9TF = true;

	}

	
	void OnGUI(){
		
		if (b1MathTask && b1Show) {
			Time.timeScale = 0; 
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "");
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "MathTask");
			
			GUI.Label (new Rect (100,100, 400, 400), MathTask1Str);
			
			
			toggle11button = GUI.Toggle (new Rect (50, 175, 100, 50), toggle11button, icon1el1, "button");
			toggle12button = GUI.Toggle (new Rect (250, 175, 100, 50), toggle12button, icon1el2, "button");
			toggle13button = GUI.Toggle (new Rect (450, 175, 100, 50), toggle13button, icon1el3, "button");
			

			if (GUI.Button (new Rect (225, Screen.height / 2 + 100, 150, 25), "Accept")) {
				GetBossBooleans();
				TestIfMathTask1 ();
				b1Show = false;
			}
		}
		
		
		
		if (b1Complete) {
			GUI.Box (new Rect (100, 125, 400, 200), "");
			GUI.Box (new Rect (100, 125, 400, 200), "");
			
			GUI.Label (new Rect (175, 150, 400, 400), "1. Aufgabe geschafft!" );
			
			if (GUI.Button (new Rect (175, 200, 100, 50), "Weiter!")) {
				b1Complete = false;
				Time.timeScale = 1;
				
				
			}
			if (GUI.Button (new Rect (325, 200, 100, 50), "MainMenu")) {
				Application.LoadLevel ("Menu");
			}
		}
		
		if (b1Fail) {
			GUI.Box (new Rect (100, 125, 400, 200), "");
			GUI.Box (new Rect (100, 125, 400, 200), "");
			
			GUI.Label (new Rect (175, 150, 400, 400), "Leider nicht die richtige Lösung!");
			
			if (GUI.Button (new Rect (175, 200, 100, 50), "Neustarten")) {
				Application.LoadLevel (Level.CurrentLevel);
			}
			if (GUI.Button (new Rect (325, 200, 100, 50), "MainMenu")) {
				Application.LoadLevel ("Menu");
			}
		}

		if (b2MathTask && b2Show) {
			Time.timeScale = 0; 
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "");
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "MathTask");
			
			GUI.Label (new Rect (100,100, 400, 400), MathTask2Str);
			
			
			toggle21button = GUI.Toggle (new Rect (50, 175, 100, 50), toggle21button, icon2el1, "button");
			toggle22button = GUI.Toggle (new Rect (250, 175, 100, 50), toggle22button, icon2el2, "button");
			toggle23button = GUI.Toggle (new Rect (450, 175, 100, 50), toggle23button, icon2el3, "button");
			
			
			if (GUI.Button (new Rect (225, Screen.height / 2 + 100, 150, 25), "Accept")) {
				GetBossBooleans();
				TestIfMathTask2 ();
				b2Show = false;
			}
		}
		
		
		
		if (b2Complete) {
			GUI.Box (new Rect (100, 125, 400, 200), "");
			GUI.Box (new Rect (100, 125, 400, 200), "");
			
			GUI.Label (new Rect (175, 150, 400, 400), "2. Aufgabe geschafft!" );
			
			if (GUI.Button (new Rect (175, 200, 100, 50), "Weiter!")) {
				b2Complete = false;
				Time.timeScale = 1;
				
				
			}
			if (GUI.Button (new Rect (325, 200, 100, 50), "MainMenu")) {
				Application.LoadLevel ("Menu");
			}
		}
		if (b2Fail) {
			GUI.Box (new Rect (100, 125, 400, 200), "");
			GUI.Box (new Rect (100, 125, 400, 200), "");
			
			GUI.Label (new Rect (175, 150, 400, 400), "Leider nicht die richtige Lösung!");
			
			if (GUI.Button (new Rect (175, 200, 100, 50), "Neustarten")) {
				Application.LoadLevel (Level.CurrentLevel);
			}
			if (GUI.Button (new Rect (325, 200, 100, 50), "MainMenu")) {
				Application.LoadLevel ("Menu");
			}
		}
		


		if (b3MathTask && b3Show) {
			Time.timeScale = 0; 
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "");
			GUI.Box (new Rect (5, Screen.height / 2 - 200, 593, 400), "MathTask");
			
			GUI.Label (new Rect (100,100, 400, 400), MathTask3Str);
			
			
			toggle31button = GUI.Toggle (new Rect (50, 175, 100, 50), toggle31button, icon3el1, "button");
			toggle32button = GUI.Toggle (new Rect (250, 175, 100, 50), toggle32button, icon3el2, "button");
			toggle33button = GUI.Toggle (new Rect (450, 175, 100, 50), toggle33button, icon3el3, "button");
			
			
			if (GUI.Button (new Rect (225, Screen.height / 2 + 100, 150, 25), "Accept")) {
				GetBossBooleans();
				TestIfMathTask3 ();
				b3Show = false;
			}
		}
		
		
		
		if (b3Complete) {
			GUI.Box (new Rect (100, 125, 400, 200), "");
			GUI.Box (new Rect (100, 125, 400, 200), "");
			
			GUI.Label (new Rect (175, 130, 400, 400), "3. Aufgabe geschafft!" );
			GUI.Label (new Rect (175, 150, 400, 400), "Endboss besiegt! Welt abgeschlossen!" );

			if (GUI.Button (new Rect (250, 200, 100, 50), "MainMenu")) {
				Application.LoadLevel ("Menu");
			}

		}
		if (b3Fail) {
			GUI.Box (new Rect (100, 125, 400, 200), "");
			GUI.Box (new Rect (100, 125, 400, 200), "");
			
			GUI.Label (new Rect (175, 150, 400, 400), "Leider nicht die richtige Lösung!");
			
			if (GUI.Button (new Rect (175, 200, 100, 50), "Neustarten")) {
				Application.LoadLevel (Level.CurrentLevel);
			}
			if (GUI.Button (new Rect (325, 200, 100, 50), "MainMenu")) {
				Application.LoadLevel ("Menu");
			}
		}
		

	}

	void GetBossBooleans(){


		if(MTaskEndBoss.TryGetValue(icon1el1, out bool1Element1)){
			//print ("B");
			//print (boolElement1);
		}
		
		else{
			print ("Key is not found.");
		}

		if(MTaskEndBoss.TryGetValue(icon1el2, out bool1Element2)){
			//print ("P");
			//print (boolElement2);
		}
		
		else{
			print ("Key is not found.");
		}


		if(MTaskEndBoss.TryGetValue(icon1el3, out bool1Element3)){
			//print ("Element3");
			//print(boolElement3);
		}
		
		else{
			print ("Key is not found.");
		}

		if(MTaskEndBoss.TryGetValue(icon2el1, out bool2Element1)){
			//print ("B");
			//print (boolElement1);
		}
		
		else{
			print ("Key is not found.");
		}

		if(MTaskEndBoss.TryGetValue(icon2el2, out bool2Element2)){
			//print ("P");
			//print (boolElement2);
		}
		
		else{
			print ("Key is not found.");
		}

		
		if(MTaskEndBoss.TryGetValue(icon2el3, out bool2Element3)){
			//print ("Element3");
			//print(boolElement3);
		}
		
		else{
			print ("Key is not found.");
		}

		if(MTaskEndBoss.TryGetValue(icon3el1, out bool3Element1)){
			//print ("B");
			//print (boolElement1);
		}
		
		else{
			print ("Key is not found.");
		}

		if(MTaskEndBoss.TryGetValue(icon3el2, out bool3Element2)){
			//print ("P");
			//print (boolElement2);
		}
		
		else{
			print ("Key is not found.");
		}

		
		if(MTaskEndBoss.TryGetValue(icon3el3 , out bool3Element3)){
			//print ("Element3");
			//print(boolElement3);
		}
		
		else{
			print ("Key is not found.");
		}
	}

	void TestIfMathTask1(){
			if(bool1Element2 == toggle12button && bool1Element1 == toggle11button && bool1Element3 == toggle13button){
				b1Complete = true;
				b1MathTask = false;
				b1Fail = false;
			}
			else if(bool1Element2 != toggle12button || bool1Element1 != toggle11button || bool1Element3 != toggle13button){
				b1Fail = true;
				b1MathTask = false;
				b1Complete = false;
			}


		}

	void TestIfMathTask2(){
			if(bool2Element2 == toggle22button && bool2Element1 == toggle21button && bool2Element3 == toggle23button){
				b2Complete = true;
				b2MathTask = false;
				b2Fail = false;
			}
			else if(bool2Element2 != toggle22button || bool2Element1 != toggle21button || bool2Element3 != toggle23button){
				b2Fail = true;
				b2MathTask = false;
				b2Complete = false;
			}

		}

	void TestIfMathTask3(){
			if (bool3Element2 == toggle32button && bool3Element1 == toggle31button && bool3Element3 == toggle33button) {
				b3Complete = true;
				b3MathTask = false;
				b3Fail = false;
			} else if (bool3Element2 != toggle32button || bool3Element1 != toggle31button || bool3Element3 != toggle33button) {
				b3Fail = true;
				b3MathTask = false;
				b3Complete = false;
			}

		}
}


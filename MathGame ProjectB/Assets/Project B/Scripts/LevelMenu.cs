using UnityEngine;
using System.Collections;

public class LevelMenu : MonoBehaviour 
{
	bool bL1 = true;
	bool bL2 = false;
	bool bL3 = false;
	bool bL4 = false;
	bool bL5 = false;
	bool bL6 = false;

	int BL2, BL3, BL4, BL5, BL6;

	public static string CLvl;

	

	// Use this for initialization
	void Start () 
	{


		BL2 = PlayerPrefs.GetInt ("Level2");
		
		if(BL2 == 1){
			bL2 = true;
		}
		BL3 = PlayerPrefs.GetInt ("Level3");
		
		if(BL3 == 1){
			bL3 = true;
		}
		BL4 = PlayerPrefs.GetInt ("Level4");
		
		if(BL4 == 1){
			bL4 = true;
		}
		BL5 = PlayerPrefs.GetInt ("Level5");
		
		if(BL5 == 1){
			bL5 = true;
		}
		BL6 = PlayerPrefs.GetInt ("Level6");
		
		if(BL6 == 1){
			bL6 = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	void OnGUI(){
		
		
		GUI.Box (new Rect (10, Screen.height / 2 - 200, 593, 400), "Choose your Level:");

		if(bL1 == true){
			if (GUI.Button (new Rect (35, Screen.height / 2 - 150, 150, 25), "Level1")) {
				CLvl = "Level1";

				Application.LoadLevel (Level.Level1);
			}
		}

		if(bL2 == true){
			if (GUI.Button (new Rect (230, Screen.height / 2 - 150, 150, 25), "Level2")) {
				CLvl = "Level2";

				Application.LoadLevel (Level.Level2);
			}
		}

		if(bL3 == true){
			if (GUI.Button (new Rect (425, Screen.height / 2 - 150, 150, 25), "Level3")) {
				CLvl = "Level3";

				Application.LoadLevel (Level.Level3);
			}
		}

		if(bL4 == true){
			if (GUI.Button (new Rect (35, Screen.height / 2 - 100, 150, 25), "Level4")) {
				CLvl = "Level4";

				Application.LoadLevel (Level.Level4);
			}
		}

		if(bL5 == true){
			if (GUI.Button (new Rect (230, Screen.height / 2 - 100, 150, 25), "Level5")) {
				CLvl = "Level5";

				Application.LoadLevel (Level.Level5);
			}
		}
		if(bL6 == true){
			if (GUI.Button (new Rect (425, Screen.height / 2 - 100, 150, 25), "Level6")) {
				CLvl = "Level6";
				
				Application.LoadLevel (Level.Level6);
			}
		}
		
		if (GUI.Button (new Rect (425, Screen.height / 2 + 150, 150, 25), "Back")) {
			Application.LoadLevel ("Menu");
		}
		
	}
}

using UnityEngine;
using System.Collections;

public class Element9 : MonoBehaviour {
	
	public static Texture2D Element9Icon;
	
	// Use this for initialization
	void Start () {
		
		SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
		
		Element9Icon = sr.sprite.texture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
}


using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	static int scene = 0;

	public const int SCENE_NORMAL 		= 0;
	public const int SCENE_GAMEOVER 	= 1;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static int getScene()
	{
		return scene;
	}

	public static void SetGameOver()
	{
		scene = SCENE_GAMEOVER;
	}


}

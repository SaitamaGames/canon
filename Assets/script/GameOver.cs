using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	[SerializeField] GameObject obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if( GameManager.getScene() == GameManager.SCENE_GAMEOVER )
		{
			if( obj.gameObject.activeSelf == false  )
			{
				obj.SetActive( true );
				Time.timeScale = 1.0f;
			}
		}else
		{
			obj.SetActive( false);
		}

	}
}

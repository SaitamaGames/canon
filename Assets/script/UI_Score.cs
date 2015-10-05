using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour {

	[SerializeField] Text ScoreText;
	[SerializeField] Text ChainText;

	public static UI_Score main;

	int Score = 0;
	int Chain = 0;

	float ChainTimer = 0;

	// Use this for initialization
	void Start () {
	
		main = this;

		ChainText.gameObject.SetActive( false );

	}
	
	// Update is called once per frame
	void Update () {
	
		if( ChainTimer > 0 )
		{
			ChainTimer-= Time.deltaTime;
			if( ChainTimer <= 0 )
			{
				Chain = 0;
				ChainTimer = 0;
				ChainText.gameObject.SetActive( false );

			}
		}
	}

	public void scoreAdd()
	{
		Chain++;
		Score += Chain;
		ChainTimer = 1.0f;

		ScoreText.text = "Score:"+Score.ToString() ;
		ChainText.text = "ChainVal:"+Chain.ToString() ;
		ChainText.gameObject.SetActive( true );

		Time.timeScale = 1.0f + Score *0.001f;

	}


}








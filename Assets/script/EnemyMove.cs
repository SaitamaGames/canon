using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	Rigidbody2D rigid;

	int mode = 0;
	const int NORMAL = 0;
	const int FALL = 1;
	[SerializeField] GameObject BomObj;

	float fallLifeTime = 0;

	public float speed = 0;
	[SerializeField] int life = 1;

	SpriteRenderer sprite;

	float redTimer = 0;

	// Use this for initialization
	void Start () {
	
		rigid = GetComponent<Rigidbody2D>();

		sprite = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
	

		if( GameManager.getScene () == GameManager.SCENE_GAMEOVER )
		{
			return;
		}

		switch( mode )
		{	
			case NORMAL:
			{
				Vector3 point = transform.localPosition;
				point.x -= Time.deltaTime * speed;
				transform.localPosition = point ;

				//ゲームオーバー
				if( point.x <= -7 )
				{
					GameManager.SetGameOver();
				}

				break;
			}
			case FALL:
			{
				fallLifeTime -= Time.deltaTime;
				if(fallLifeTime <= 0  )
				{
				GameObject obj = Instantiate( BomObj );
					obj.transform.position = transform.position;				
					Destroy( gameObject );
					
				}
				break;
			}
		}
		if( redTimer > 0 )
		{
			colorMove();
		}
	}

	void colorMove()
	{
		redTimer-= Time.deltaTime;

		sprite.color = new Color(1,1-redTimer , 1-redTimer );

		if( redTimer <= 0 )
		{
			redTimer = 0;
		}
	}

	public void HitEnemy()
	{
		if( mode == NORMAL )
		{
			life--;

			sprite.color = new Color(1,0,0);
			redTimer = 1;

			if( life <= 0 )
			{
			UI_Score.main.scoreAdd();

				rigid.isKinematic = false;
				mode = FALL ;
				fallLifeTime = 4;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if( collision.gameObject.tag == "enemy" )
		{
			EnemyMove Enemy = collision.gameObject.GetComponent<EnemyMove>();

			Enemy.HitEnemy();

		}
		if( collision.gameObject.tag == "ground" )
		{
			if( mode == FALL )
			{
				fallLifeTime -= 3;
			}
		}
	}

}











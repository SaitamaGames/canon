using UnityEngine;
using System.Collections;

public class EnemyCreater : MonoBehaviour {

	[SerializeField] EnemyMove originalEnemy;
	//[SerializeField] EnemyMove originalEnemyGround;
	//[SerializeField] EnemyMove originalEnemyBig;

	
	float timer = 0;
	int EnemyNum = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if( GameManager.getScene () == GameManager.SCENE_GAMEOVER )
		{
			return;
		}
		timer += Time.deltaTime;
		if( timer >= 1 )
		{
			timer = 0;

			for( int i = 0 ; i < 3 ; i++)
			{
				EnemyMove enemy = null;

				float Ypoint = 0;

				//int random = Random.Range(0,100 );

				enemy = (EnemyMove)Instantiate( originalEnemy );
				enemy.speed = Random.Range(0.3f,0.4f);
				Ypoint = Random.Range(-2.0f,5.0f);

				//50に一回 ボス
//				if( EnemyNum >= 1 && EnemyNum % 50 == 0 )
//				{
//					enemy = (EnemyMove)Instantiate( originalEnemyBig );
//					enemy.speed = Random.Range(0.3f,0.4f);
//					Ypoint = Random.Range(-2.0f,5.0f);
//
//				}else
//				//80%の確立
//				if(random <= 80 )
//				{
//					//普通の敵
//					enemy = (EnemyMove)Instantiate( originalEnemy );
//					enemy.speed = Random.Range(0.5f,1.5f);
//					Ypoint = Random.Range(-2.0f,5.0f);
//				}
//				else
//				{
//					//地面形を出す
//					enemy = (EnemyMove)Instantiate( originalEnemyGround );
//					enemy.speed = Random.Range(0.3f,0.7f);
//					Ypoint = -2.5f;
//
//				}

				EnemyNum++;
				enemy.transform.localPosition = new Vector3(10, Ypoint ,0);
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class ShotMove : MonoBehaviour {

	float lifeTimer = 0;

	[SerializeField] GameObject BomObj;

	// Use this for initialization
	void Start () {
		lifeTimer = 3;
	
	}
	
	// Update is called once per frame
	void Update () {

		lifeTimer -= Time.deltaTime;
		if( lifeTimer <= 0 )
		{
			if( BomObj != null )
			{
				GameObject obj = Instantiate( BomObj );
				obj.transform.position = transform.position;
			}

			Destroy( gameObject );
		}
	
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if( collision.gameObject.tag == "enemy" )
		{
			EnemyMove Enemy = collision.gameObject.GetComponent<EnemyMove>();
			Enemy.HitEnemy();
		}
		lifeTimer -= 2;

	}
}












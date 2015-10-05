using UnityEngine;
using System.Collections;

public class BomMove : MonoBehaviour {

	float timer = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		timer -= Time.deltaTime;
		if( timer <= 0 )
		{
			Destroy( gameObject );
		}
	}
}

using UnityEngine;
using System.Collections;

public class CanonBase : MonoBehaviour {

	[SerializeField] GameObject CanonCylinder;
	[SerializeField] Camera cam;

	[SerializeField] GameObject TamaOriginal;

	bool firstTouch = false;
	float nowAngle = 0;
	Vector3 target = new Vector3(0,0,0);

	// Use this for initialization
	void Start () {
	
	}
	float timer = 0;

	// Update is called once per frame
	void Update () {
	
		if( GameManager.getScene () == GameManager.SCENE_GAMEOVER )
		{
			return;
		}


		if( Input.GetMouseButton( 0 ))
		{
			firstTouch = true;

			target = cam.ScreenToWorldPoint(Input.mousePosition);

			Vector2 Cylinder = CanonCylinder.transform.position;



				float rad = Mathf.Atan2( target.y - Cylinder.y ,  target.x - Cylinder.x);
			nowAngle = rad * 180 / Mathf.PI-90;

			CanonCylinder.transform.eulerAngles = new Vector3(0,0,nowAngle);


		}

		if( firstTouch )
		{
			timer += Time.deltaTime;
			if( timer >= 1 )
			{
				timer = 0;
				CrateTama();
			}
		}

	}

	void CrateTama()
	{
		GameObject tama = (GameObject)Instantiate( TamaOriginal );

		Vector3 point = CanonCylinder.transform.position;
		float angle = nowAngle +90;
		float rotatedX = Mathf.Cos(angle*Mathf.PI/180) * 2;
		
		float rotatedZ = Mathf.Sin(angle*Mathf.PI/180) * 2 ;
		
//Vector3 result = new Vector3( my.x + rotatedX  , my.y + rotatedZ  , my.z ) ;
		point.x += rotatedX;
		point.y += rotatedZ;

		tama.transform.position = point ;

	
		Vector3 point2 = tama.transform.position ;

		Vector3 pointTarget = new Vector3(rotatedX*20,rotatedZ*20,0);



		//		//指定位置とターゲットの位置を設定（ターゲット座標ーコントロール座標）
		Vector3 anglePoint = Vector3.Normalize( pointTarget - point2 );
		
		
		//		//ターゲットを指定位置に飛ばす
		tama.transform.GetComponent<Rigidbody2D>().AddForce (anglePoint * ( 1000 ) );










	}







}













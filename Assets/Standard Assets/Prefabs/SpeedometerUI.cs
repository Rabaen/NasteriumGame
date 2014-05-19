using UnityEngine;

using System.Collections;



public class SpeedometerUI : MonoBehaviour {
	
	public Texture2D dialTex;
	
	public Texture2D needleTex;
	
	public Vector2 dialPos;
	
	public float topSpeed=0;
	
	public float stopAngle=0;
	
	public float topSpeedAngle=0;
	
	public float speed=0;

	public GameObject GUISpeedoSpeed;

	public float timer = 1;

	void Start()
	{
		dialPos.x = Screen.width  - (dialTex.width + 25);
		//dialPos.x = (Screen.width / 2)  - (dialTex.width * 3);
		dialPos.y = Screen.height - (dialTex.height + 10);
		//GUISpeedoSpeed.transform.position = new Vector3 (dialPos.x / 1000, dialPos.y / 1000, 1);

	}

	void Update()
	{
		timer -= Time.deltaTime; // I need timer which from a particular time goes to zero
		
		if (timer < 0.8)
		{
			GUISpeedoSpeed.guiText.text = speed.ToString("f0");
			timer = 1;
		}

	}

	
	void  OnGUI (){

		speed = Fzero.current_speed;

		//GameObject.Find ("GUISpeedoSpeed").guiText.text = speed.ToString("f0");

		GUI.DrawTexture( new Rect(dialPos.x, dialPos.y, dialTex.width, dialTex.height), dialTex);
		
		Vector2 centre= new Vector2(dialPos.x + (dialTex.width / 2), dialPos.y + (dialTex.height / 2));
		
		Matrix4x4 savedMatrix= GUI.matrix;
		
		float speedFraction= speed / topSpeed;
		
		float needleAngle= Mathf.Lerp(stopAngle, topSpeedAngle, speedFraction);
		
		GUIUtility.RotateAroundPivot(needleAngle, centre);
		
		GUI.DrawTexture( new Rect(centre.x, centre.y - needleTex.height / 2, needleTex.width, needleTex.height), needleTex);
		
		GUI.matrix = savedMatrix;
		
	}
	
}
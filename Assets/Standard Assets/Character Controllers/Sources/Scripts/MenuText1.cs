using UnityEngine;
using System.Collections;

public class MenuText1 : MonoBehaviour
{
	public bool isLevel = false;
	
	//public float HighScore = TextMesh;
	
	//void start()
	//{
	//	HighScore.text = "Score: " + PlayerPrefs.GetInt ("HighScore");
	//}
			
	void OnMouseEnter()
	{
		renderer.material.color = Color.white;
	}
	void OnMouseExit()
	{
		renderer.material.color = Color.black;
	}
	void OnMouseDown()
	{
		if (isLevel)
		{
			Application.LoadLevel("level2");
		}
		else
		{
			Application.LoadLevel("StartMenu");
		}
	}
//	void update()
//	{
//		if( Input.GetKey(KeyCode.Escape))
	//	{
	//		Application.LoadLevel("Instr");
	//	}
	//}
}

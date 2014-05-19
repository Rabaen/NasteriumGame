using UnityEngine;
using System.Collections;

public class MenuText : MonoBehaviour
{
	public bool isInstr = false;
	
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
		if (isInstr)
		{
			Application.LoadLevel("level1");
		}
		else
		{
			Application.LoadLevel("Instr");
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

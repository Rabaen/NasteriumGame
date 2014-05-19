using UnityEngine;
using System.Collections;

public class PlayAgain : MonoBehaviour
{
	public bool isInstr = false;
			
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
			Application.LoadLevel("StartMenu");
		}
	}
}

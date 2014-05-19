using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LoadLevel2 : MonoBehaviour 
{
	//public static List<string> GearCount = new List<string>();
	//public List<string> StartingItems = new List<string>();
	

	
	void Start()
	{
	
	}
	
	void Update()
	{
		if(CountdownTime.GearCogCount == 3)
		{
			Application.LoadLevel ("level2");
		}		
	}
}

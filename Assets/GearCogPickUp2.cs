using UnityEngine;
using System.Collections;

public class GearCogPickUp2 : MonoBehaviour 
{
	
	public AudioClip PickUpSound;
	//public float CurrentTime = 0.0f;
	//public float AddTime = 10.0f;
	//int GearCogCount = 0;
	public float Gtimer = 10;
	public bool GtimerOn = false;
	public GameObject GearCogText;
	
	void Start()
	{
		//collider.isTrigger = true;
	}
	
	void Update()
	{
		if (GtimerOn)  //tracks time to reactivate pickup
		{
			Gtimer -= Time.deltaTime;  //counts down time once pickup is first pickedup			
			Renderer[] rs = GetComponentsInChildren<Renderer> ();  //list of all renderers in pickup
			
			foreach(Renderer r in rs)
			{	
				r.enabled = false;  //turns off all renderers in pickup
			}
			collider.enabled = false;  //turns off collider in pickup
			
			if (Gtimer < 0.8)   //reactivates pickup when timer runs out
			{
				Gtimer = 10;
				GtimerOn = false;
				
				foreach(Renderer r in rs)
				{	
					r.enabled = true;  //reactivates renderers
				}
				collider.enabled = true;  //turns collider back on
			}
		}
	}
	
	void OnTriggerEnter( Collider WhatEnteredTheTrigger )
	{
		if (GtimerOn == false) 
		{
			if (WhatEnteredTheTrigger.tag == "Player") 
			{									
				PickedUp (WhatEnteredTheTrigger.gameObject);	
				GtimerOn = true;  //when player picks up pickup, start timer to deactivate it for 10 seconds.
			}
		}
	}
	
	void PickedUp(GameObject Player)
	{		
		audio.PlayOneShot(PickUpSound);
		//Score.score += 100;
		//renderer.enabled = false;
		//collider.enabled = false;
		//CurrentTime = CurrentTime + AddTime;
		//Fzero.fwd_max_speed += powerBoost;
		//Fzero.timerOn = true;
		//Destroy(gameObject);
		CountdownTime.GearCogCount += 1;
		GearCogText.guiText.text =  "Gears: "+(CountdownTime.GearCogCount);
		
		if(CountdownTime.GearCogCount == 20)
		{
			Application.LoadLevel ("level3");
			
		}
	}
}


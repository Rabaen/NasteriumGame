using UnityEngine;
using System.Collections;

public class SpeedBoostPickUp : MonoBehaviour 
{

	//public string WhatToAddToInventory = "PickUp Name";
	public AudioClip PickUpSound;
	//public float CurrentTime = 0.0f;
	//public float AddTime = 10.0f;
	float powerBoost = 200.0f;
	public float Stimer = 10;
	public bool StimerOn = false;

	public GameObject SpeedBoostOnText;
	public GameObject SpeedBoostTexture;

	void Start()
	{
		//collider.isTrigger = true;
	}

	void Update()
	{
		if (StimerOn)  //tracks time to reactivate pickup
			{
				Stimer -= Time.deltaTime;  //counts down time once pickup is first pickedup

				Renderer[] rs = GetComponentsInChildren<Renderer> ();  //list of all renderers in pickup
				
				foreach(Renderer r in rs)
					{	
						r.enabled = false;  //turns off all renderers in pickup
					}

			//activate GUI speedboost notifier
			SpeedBoostOnText.guiText.text =  "SpeedBoost \n    Active";
			SpeedBoostTexture.guiTexture.enabled = true;


			collider.enabled = false;  //turns off collider in pickup

				if (Stimer < 0.8)   //reactivates pickup when timer runs out
					{
						Stimer = 10;
						StimerOn = false;

					foreach(Renderer r in rs)
						{	
							r.enabled = true;  //reactivates renderers
						}
					collider.enabled = true;  //turns collider back on
					SpeedBoostOnText.guiText.text =  "";  //deactivate speedboost notifier
					SpeedBoostTexture.guiTexture.enabled = false; //deactivate texture

					}
			}
	}
	
	void OnTriggerEnter( Collider WhatEnteredTheTrigger )
	{
		if (StimerOn == false) 
		{
			if (WhatEnteredTheTrigger.tag == "Player") 
			{
					PickedUp (WhatEnteredTheTrigger.gameObject);	
					StimerOn = true;  //when player picks up pickup, start timer to deactivate it for 10 seconds.
			}
		}
	}
	
	void PickedUp(GameObject Player)
	{

		audio.PlayOneShot(PickUpSound);
		//Inventory.PlayerInventory.Add(WhatToAddToInventory);
		//Score.score += 100;
		//renderer.enabled = false;
		//collider.enabled = false;
		//CurrentTime = CurrentTime + AddTime;
		Fzero.fwd_max_speed += powerBoost;
		Fzero.timerOn = true;
		//Destroy(gameObject);
	}
	
}

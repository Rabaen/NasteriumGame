
static var playerTransform : Transform; //Store the player transform
var VisualCheckpoint: GameObject;
var VisualLap: GameObject;
//var Player: GameObject;

function Start () 
{
	playerTransform = gameObject.Find("Player").transform; //Set the player transform
	//Player = gameObject.Find("Player");
}

function OnTriggerEnter (other : Collider) 
{
	//Is it the Player who enters the collider?
	if (!other.CompareTag("Player")) 
		return; //If it's not the player dont continue
		
	//Is this transform equal to the transform of checkpointArrays[currentCheckpoint]?
	if (transform == playerTransform.GetComponent(CarCheckpoint).checkPointArray[CarCheckpoint.currentCheckpoint].transform) 
	{
		CarCheckpoint.totalCheckpoint++;
		
		Debug.Log(CarCheckpoint.totalCheckpoint);
		//Visual.guiText1.text =  "Total Checkpoint: "+(CarCheckpoint.totalCheckpoint);
		//Check so we dont exceed our checkpoint quantity
		if (CarCheckpoint.currentCheckpoint + 1<playerTransform.GetComponent(CarCheckpoint).checkPointArray.length) 
		{
			//Add to currentLap if currentCheckpoint is 0
			if(CarCheckpoint.currentCheckpoint == 0)
				CarCheckpoint.currentLap++;
			CarCheckpoint.currentCheckpoint++;
			//GameObject.Find ("TimerText").guiText.text = Minutes.ToString ("f0") + ":0" + Seconds.ToString("f0");
			CountdownTime.Seconds = CountdownTime.Seconds +10;
		} 
		else
		{
			//If we dont have any Checkpoints left, go back to 0
			CarCheckpoint.currentCheckpoint = 0;
		}
		visualAid(); //Run a coroutine to update the visual aid of our Checkpoints
		//Update the 3dtext
		//VisualCheckpoint = GameObject.FindWithTag ("CheckPoint");
		VisualCheckpoint.guiText.text =  "Checkpoint: "+(CarCheckpoint.currentCheckpoint);		
		//VisualLap = GameObject.FindWithTag("CheckPoint");
		VisualLap.guiText.text =  "Lap: "+(CarCheckpoint.currentLap);
		//Visual.guiText1.text =  "Total Checkpoint: "+(CarCheckpoint.totalCheckpoint);	
	}
}

function visualAid () 
{
	//Set a simple visual aid for the Checkpoints
	for (objAlpha in playerTransform.GetComponent(CarCheckpoint).checkPointArray) 
	{
		objAlpha.renderer.material.color.a = 0.2;
	}
	playerTransform.GetComponent(CarCheckpoint).checkPointArray[CarCheckpoint.currentCheckpoint].renderer.material.color.a = 0.8;
}
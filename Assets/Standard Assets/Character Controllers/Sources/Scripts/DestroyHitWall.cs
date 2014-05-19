using UnityEngine;
using System.Collections;

public class DestroyHitWall : MonoBehaviour {

	public GameObject explosionPrefab;
	public GameObject cubePos;
	//private Vector3 initialPos = new Vector3(-775, 20,2125);



	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		//initialPos = transform.position;
		//initialRotation = transform.rotation;

	}

	private string hitobject;
	
	void OnCollisionEnter(UnityEngine.Collision hit)
	{
		hitobject = hit.gameObject.tag;
		if(hitobject == "Wall")
		{
			Debug.Log ("hit cube");
			PlayerPrefs.SetInt ("CurrentScore", CountdownTime.GearCogCount);
			if (CountdownTime.GearCogCount > PlayerPrefs.GetInt("HighScore"))
			{
				PlayerPrefs.SetInt ("HighScore", CountdownTime.GearCogCount);
			}
			//Destroy(hit.transform.parent.gameObject);
			Instantiate(explosionPrefab, transform.position, transform.rotation);
			//hit.transform.Translate = new Vector3(-880.03, 37.497, 2175.14);
			//hit.transform.parent.position = new Vector3(-860, 37, 2124);
			//hit.transform.parent.rotation = new Quaternion (0,0,0,0);
			//transform.parent.position = new Vector3(-860, 37, 2124);
			//transform.parent.rotation = new Quaternion (0,0,0,0);

			//hit.transform.parent.rotation = cubePos.transform.rotation;
			//hit.transform.parent.position = cubePos.transform.position;//new Vector3(-3084, -22, -1220);
			//hit.transform.parent.rotation = cubePos.transform.localRotation;

			//hit.transform.localRotation = initialRotation;
			//hit.transform.localPosition = initialPos;
			Fzero.current_speed = 0;
		
			Application.LoadLevel("GameOver");
		}
	}
}

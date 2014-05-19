using UnityEngine;
using System.Collections;

public class CountdownTime : MonoBehaviour 
{
	public static float Seconds = 59;
	public static float Minutes = 1;
	//public float Seconds = 59;
	//public float Minutes = 1;
	public static int GearCogCount = 0;

	public float StartCountdown = 3;
	public bool StartBool = false;

	void start ()
	{
		Seconds = 59;
		Minutes = 1;
	}

	void Update () 
	{	
		if (StartBool == false) 
		{
			GameObject.Find ("GUIStartCountdown321").guiText.text = StartCountdown.ToString("f0");
			StartCountdown -= 1 * Time.deltaTime;
		}

		if (StartCountdown <= 1 && StartBool == false) 
		{
			GameObject.Find ("GUIStartCountdown321").guiText.text = StartCountdown.ToString ("GO");
			StartBool = true;
		}

		if (Seconds <= 57) 
		{
			GameObject.Find ("GUIStartCountdown321").guiText.text =  " ";
		}


		if (StartBool == true) 
		{
			GameObject.Find ("GUITimeText").guiText.text = "Time Remaining";
			if (Seconds <= 0) {
					PlayerPrefs.SetInt ("CurrentScore", CountdownTime.GearCogCount);
					if (CountdownTime.GearCogCount > PlayerPrefs.GetInt ("HighScore")) {
							PlayerPrefs.SetInt ("HighScore", CountdownTime.GearCogCount);
					}
					Seconds = 59;
					if (Minutes >= 1) {
							Minutes --;
					} else {
							Minutes = 0;
							Seconds = 0;
							GameObject.Find ("GUITimerText").guiText.text = Minutes.ToString ("f0") + ":0" + Seconds.ToString ("f0");
							//PlayerPrefs.SetInt("newScore", newScore);
							Application.LoadLevel ("GameOver");				
					}
			} else {
					Seconds -= 1 * Time.deltaTime;
					Application.Quit ();
			}
			if (Mathf.Round (Seconds) <= 9) {
					GameObject.Find ("GUITimerText").guiText.text = Minutes.ToString ("f0") + ":0" + Seconds.ToString ("f0");
			} else {
					GameObject.Find ("GUITimerText").guiText.text = Minutes.ToString ("f0") + ":" + Seconds.ToString ("f0");
			}
		}
	}
}
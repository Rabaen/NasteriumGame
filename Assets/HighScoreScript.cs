using UnityEngine;
using System.Collections;

public class HighScoreScript : MonoBehaviour
{
	public TextMesh HighScore;
	public TextMesh CurrentScore;
		// Use this for initialization
		void Start ()
		{
	
		}
		void Awake()
	{
		HighScore.text = "Total Gears: "+ PlayerPrefs.GetInt("HighScore");
		CurrentScore.text = "Gears collected this time: "+ PlayerPrefs.GetInt("CurrentScore");
	}
		// Update is called once per frame
		void Update ()
		{
	
		}
}


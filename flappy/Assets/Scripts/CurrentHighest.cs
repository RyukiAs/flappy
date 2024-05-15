using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentHighest : MonoBehaviour
{
	private GameController gameController;
	private int highestScore = 0;
	
	// Start is called before the first frame update
	void Start()
	{
		//spawnTimer = 0;
		
		gameController = GameController.Instance;
		if (gameController == null)
		{
			Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
		}
	}

	// Update is called once per frame
	public void UpdateScore() 
	{
		if (highestScore < gameController.timer) 
		{
			highestScore = gameController.timer;
		}
		
		
		GameObject gameObject = transform.Find("CurrentHighest").gameObject;
		Debug.Log("above currentHighest");
		TextMeshProUGUI highScore = gameObject.GetComponent<TextMeshProUGUI>();
		highScore.text = highestScore.ToString();
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentHighest : MonoBehaviour
{
	private GameController gameController;
	
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
        // Check if gameController is null
        if (gameController == null)
        {
            // Attempt to find an existing GameController instance
            gameController = FindObjectOfType<GameController>();

            // If no GameController instance exists in the scene, create a new one
            if (gameController == null)
            {
                Debug.LogError("GameController instance not found. Creating a new instance.");
                gameController = GameController.Instance;
            }
        }

        // Now gameController should not be null
        if (gameController != null)
        {
            // Ensure highestScore is accessible in GameController
            if (gameController.highestScore < gameController.timer)
            {
                gameController.highestScore = gameController.timer;
            }

            // Find the GameObject with the name "CurrentHighest" under the current transform
            GameObject currentHighestObject = transform.Find("CurrentHighest").gameObject;

            // Get the TextMeshProUGUI component from the GameObject
            TextMeshProUGUI highScore = currentHighestObject.GetComponent<TextMeshProUGUI>();

            // Check if the component was found
            if (highScore != null)
            {
                // Update the text with the highest score
                highScore.text = gameController.highestScore.ToString();
            }
        }   
    }
}

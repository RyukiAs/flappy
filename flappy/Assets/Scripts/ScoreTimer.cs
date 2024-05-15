using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTimer : MonoBehaviour
{
    private GameController gameController;
    //private int timer;
	// Start is called before the first frame update
	void Start()
	{
        gameController = GameController.Instance;
        if (gameController == null)
        {
            Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
        }
		
	}

	// Update is called once per frame
	void Update()
	{
		if(gameController.playing)
		{
			gameController.incrementTimer();
        }
		GameObject timerObj = transform.Find("Timer").gameObject;
		TextMeshProUGUI text = timerObj.GetComponent<TextMeshProUGUI>();
		text.text = gameController.timer.ToString();
	}
}

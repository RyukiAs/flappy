using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTimer : MonoBehaviour
{
    private GameController gameController;
    int timer;
	// Start is called before the first frame update
	void Start()
	{
        gameController = GameController.Instance;
        if (gameController == null)
        {
            Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
        }
        timer = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if(gameController.playing)
		{
            timer++;
        }
		GameObject parent = transform.parent.gameObject;
		GameObject childObject = parent.transform.Find("GameObject").gameObject;
		GameObject timerObj = childObject.transform.Find("Timer").gameObject;
		TextMeshProUGUI text = timerObj.GetComponent<TextMeshProUGUI>();
		text.text = timer.ToString();
	}
}

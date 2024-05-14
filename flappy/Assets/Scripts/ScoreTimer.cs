using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTimer : MonoBehaviour
{
	int timer;
	// Start is called before the first frame update
	void Start()
	{
		timer = 0;
	}

	// Update is called once per frame
	void Update()
	{
		timer++;
		GameObject parent = transform.parent.gameObject;
		GameObject childObject = parent.transform.Find("GameObject").gameObject;
		GameObject timerObj = childObject.transform.Find("Timer").gameObject;
		TextMeshProUGUI text = timerObj.GetComponent<TextMeshProUGUI>();
		text.text = timer.ToString();
	}
}

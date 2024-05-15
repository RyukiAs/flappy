using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour
{
	[SerializeField] private GameObject canvas;
	private GameController gameController;
	// Start is called before the first frame update
	void Start()
	{
		gameController = GameController.Instance;
		if (gameController == null)
		{
			Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
		}
	}

	public void ReplayGame()
	{
		gameController.initialPlayButtonEverPressed = true;
		gameController.Replay(canvas);
	}
}

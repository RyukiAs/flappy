using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
	[SerializeField] private float jumpHeight = 100f;
	[SerializeField] private float jumpDuration = 0.3f;

	private RectTransform birdRectTransform;
	private Vector2 currentPosition;
	private Vector2 targetPos;
	private float jumpTimer = 0f;
	private GameController gameController;
	private Replay replay;

	// Start is called before the first frame update
	void Start()
	{
		gameController = GameController.Instance;
		if (gameController == null)
		{
			Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
		}
		// Initial values are needed so that gravity's first instance does not result in an error - idk why?
		// I would like to manipulate this data at class scope to not redundantly re-initialize
		// but idk how in C#, I tried a bunch of things - nothing worked, whatever I did kept resulting in 
		// the bird being relocated or stuck to the initial position, yuki fix this shit or our uni professors will sue us XDD
		// clean code is important :3
		GameObject parent = transform.parent.gameObject;
		GameObject childObject = parent.transform.Find("Bird").gameObject;
		birdRectTransform = childObject.GetComponent<RectTransform>();
		currentPosition = birdRectTransform.anchoredPosition;


	}
	public void tapBird()
	{
		// GameObject parent = transform.parent.gameObject;
		// GameObject childObject = parent.transform.Find("Bird").gameObject;
		// RectTransform movement = childObject.GetComponent<RectTransform>();

		// Vector2 currentPosition = movement.anchoredPosition;

		// // Add the offset to move the image up by 30 pixels
		// currentPosition.y += 50;  // TODO: somehow make this move smoothly?

		// // Update the anchored position
		// movement.anchoredPosition = currentPosition;
		
		// OLD TAP LOGIC ABOVE
		if (gameController.initialPlayButtonEverPressed)
		{
			gameController.playing = true;
		}
		
		// reinitialize to get updated values, because how the fuck else in C# ;D
		if(gameController.playing)
		{
			GameObject parent = transform.parent.gameObject;
			GameObject childObject = parent.transform.Find("Bird").gameObject;
			birdRectTransform = childObject.GetComponent<RectTransform>();
			currentPosition = birdRectTransform.anchoredPosition;

			// Calculate targetPos for the jump
			targetPos = new Vector2(currentPosition.x, currentPosition.y + jumpHeight);

			// Reset jump timer
			jumpTimer = 0f;
		}
	}
	// Update is called once per frame
	void Update()
	{
	
		
		// If the bird is currently jumping
		if (jumpTimer < jumpDuration)
		{
			// Increment jump timer
			jumpTimer += Time.deltaTime;

			// Interpolate the position using an ease-out curve
			float t = Mathf.Clamp(jumpTimer / jumpDuration, 0f, 1f);
			float easeOutT = 1f - Mathf.Pow(1f - t, 3f); // Apply ease-out curve
			birdRectTransform.anchoredPosition = Vector2.Lerp(currentPosition, targetPos, easeOutT);
		}
		else
		{
			// Apply gravity continuously while the bird is in the air
			if(gameController.playing) 
			{
				gravity();
			}
			
		}

	}
	
	public void gravity()
	{
		// for the 3rd time, how the fuck else in c# D;
		GameObject parent = transform.parent.gameObject;
		GameObject childObject = parent.transform.Find("Bird").gameObject;
		birdRectTransform = childObject.GetComponent<RectTransform>();
		currentPosition = birdRectTransform.anchoredPosition;
		

		// Add the offset to move the image up by 30 pixels
		if (gameController.initialPlayButtonEverPressed)
		{
			currentPosition.y -= 1.5f;
		}

		// Update the anchored position
		birdRectTransform.anchoredPosition = currentPosition;
	}
}
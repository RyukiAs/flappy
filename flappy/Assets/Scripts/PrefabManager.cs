using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
	[SerializeField] private GameObject prefab1;
	[SerializeField] private GameObject prefab2;
	[SerializeField] private GameObject prefab3;
	[SerializeField] private Transform parentObj;

	private List<GameObject> prefabs = new List<GameObject>();
	private GameController gameController;
	//int spawnTimer;
	
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
	void Update()
	{

		//spawnTimer++;
		if (gameController.initialPlayButtonEverPressed) {
			if ((gameController.timer % 350) == 0 && gameController.playing)
			{
				int randomInt = Random.Range(1, 4);
				if (randomInt == 1)
				{
					GameObject prefabInstance = Instantiate(prefab1, parentObj);
					prefabs.Add(prefabInstance);
				}
				if (randomInt == 2)
				{
					GameObject prefabInstance = Instantiate(prefab2, parentObj);
					prefabs.Add(prefabInstance);
				}
				if (randomInt == 3)
				{
					GameObject prefabInstance = Instantiate(prefab3, parentObj);
					prefabs.Add(prefabInstance);
				}
			}

			for (int i = prefabs.Count - 1; i >= 0; i--)
			{
				GameObject obj = prefabs[i];
				RectTransform prefabRect = obj.GetComponent<RectTransform>();
				if (gameController.playing)
				{
					if (prefabRect != null) // Make sure the RectTransform component exists
					{
						Vector2 currentPosition = prefabRect.anchoredPosition;

						// Add the offset to move the image up by 1 unit
						currentPosition.x -= 1.5f;

						// Check if the x-coordinate is below the threshold
						if (currentPosition.x < -1150)
						{
							// Remove the prefab from the list
							prefabs.RemoveAt(i);

							// Destroy the prefab after 0.5 seconds
							Destroy(obj, 0.5f);
						}
						else
						{
							// Update the anchored position
							prefabRect.anchoredPosition = currentPosition;
						}
					}
					else
					{
						Debug.LogWarning("Prefab is missing RectTransform component.");
					}

				}
			
			}
		}
		if (!gameController.playing)
		{
			prefabs.Clear();
		}

	}
}

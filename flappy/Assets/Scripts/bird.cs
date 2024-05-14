using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class bird : MonoBehaviour
{
	[SerializeField] private GameObject prefab1;
	[SerializeField] private GameObject prefab2;
	[SerializeField] private GameObject prefab3;
	[SerializeField] private Transform parentObj;

	private List<GameObject> prefabs = new List<GameObject>();
	int timer;

	// Start is called before the first frame update
	void Start()
	{
		timer = 0;
	}

	// Update is called once per frame
	void Update()
	{
		gravity();
		timer++;

		if((timer % 750) == 0)
		{
			int randomInt = Random.Range(1, 4);
			if(randomInt == 1)
			{
				GameObject prefabInstance = Instantiate(prefab1, parentObj);
				prefabs.Add(prefabInstance);
				//Debug.Log("prefab1: " + timer.ToString());
			}
			if(randomInt == 2)
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
		GameObject parent = transform.parent.gameObject;
		GameObject childObject = parent.transform.Find("GameObject").gameObject;
		GameObject timerObj = childObject.transform.Find("Timer").gameObject;
		TextMeshProUGUI text = timerObj.GetComponent<TextMeshProUGUI>();
		text.text = timer.ToString();

        for (int i = prefabs.Count - 1; i >= 0; i--)
        {
            GameObject obj = prefabs[i];
            RectTransform prefabRect = obj.GetComponent<RectTransform>();

            if (prefabRect != null) // Make sure the RectTransform component exists
            {
                Vector2 currentPosition = prefabRect.anchoredPosition;

                // Add the offset to move the image up by 1 unit
                currentPosition.x -= 1;

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

	public void tapBird()
	{
		GameObject parent = transform.parent.gameObject;
		GameObject childObject = parent.transform.Find("Bird").gameObject;
		RectTransform movement = childObject.GetComponent<RectTransform>();

		Vector2 currentPosition = movement.anchoredPosition;

		// Add the offset to move the image up by 30 pixels
		currentPosition.y += 50;

		// Update the anchored position
		movement.anchoredPosition = currentPosition;
	}

	public void gravity()
	{
		GameObject parent = transform.parent.gameObject;
		GameObject childObject = parent.transform.Find("Bird").gameObject;
		RectTransform movement = childObject.GetComponent<RectTransform>();

		Vector2 currentPosition = movement.anchoredPosition;

		// Add the offset to move the image up by 30 pixels
		currentPosition.y -= 0.2f;

		// Update the anchored position
		movement.anchoredPosition = currentPosition;
	}
}

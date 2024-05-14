using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void tapBird()
	{
		GameObject parent = transform.parent.gameObject;
		GameObject childObject = parent.transform.Find("Bird").gameObject;
		RectTransform movement = childObject.GetComponent<RectTransform>();

		Vector2 currentPosition = movement.anchoredPosition;

		// Add the offset to move the image up by 30 pixels
		currentPosition.y += 50;  // TODO: somehow make this move smoothly?

		// Update the anchored position
		movement.anchoredPosition = currentPosition;
	}
    // Update is called once per frame
    void Update()
    {
    }
}

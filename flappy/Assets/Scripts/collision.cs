using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        //Debug.Log("Player script Start method called."); // Add this line

        // Your existing code
        gameController = GameController.Instance;
        if (gameController == null)
        {
            Debug.Log("GameController instance not found. Make sure GameControllerInitializer script is in the scene.");
        }
        //Debug.Log("Player script initialization complete."); // Add this line
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        gameController.playing= false;

        GameObject parent = transform.parent.gameObject;
        GameObject childObject = parent.transform.Find("LostMenu").gameObject;
        childObject.SetActive(true);
    }
}

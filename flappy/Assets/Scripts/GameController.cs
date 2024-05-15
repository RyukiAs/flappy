using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool playing = false;
    public int timer = 0;

    // Singleton pattern to ensure only one instance of GameController exists
    private static GameController instance;
    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("GameController");
                instance = go.AddComponent<GameController>();
                DontDestroyOnLoad(go);
            }
            return instance;
        }
    }
    public void incrementTimer()
    {
        timer++;
    }

    public void Replay(GameObject canvas)
    {
        //delete prefabs, reposition bird, set playing to true, reset timer

        // Destroy prefabs
        GameObject prefabManager = canvas.transform.Find("PrefabManager").gameObject;
        foreach (Transform child in prefabManager.transform)
        {
            Destroy(child.gameObject);
        }

        // Reposition bird
        GameObject bird = canvas.transform.Find("Bird").gameObject;
        RectTransform birdRect = bird.GetComponent<RectTransform>();
        Vector3 newPos = birdRect.anchoredPosition;
        newPos.y = -2;
        birdRect.anchoredPosition = newPos;

        //turn off lostScreen
        GameObject lostMenu = canvas.transform.Find("LostMenu").gameObject;
        lostMenu.SetActive(false);

        // Reset timer
        timer = 0;

        // Set playing to true
        playing = true;

    }


    private void Awake()
    {
        Debug.Log("Awake called in GameController."); // Add this line

        if (instance != null && instance != this)
        {
            Debug.Log("Another instance already exists. Destroying current instance."); // Add this line
            Destroy(gameObject);
            return;
        }

        Debug.Log("Setting GameController instance."); // Add this line
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

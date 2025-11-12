using UnityEngine;

public class GameRunner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager gameManager = new GameManager();
        gameManager.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

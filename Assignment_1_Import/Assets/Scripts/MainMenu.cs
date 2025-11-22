using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameManager gameManagerPrefab;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Application.Quit();
    }
}

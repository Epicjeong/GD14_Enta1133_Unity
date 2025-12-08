using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGame : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    public void BackToGame()
    {
        SceneManager.LoadScene("MainGame");
        controller.searching = false;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCanvasController : MonoBehaviour
{

    private Camera mainCamera;

    void Start()
    {
        //transform.Translate(0, 0, 100);
        mainCamera = Camera.main;
    }

    public void ClickRestartButton()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene(0);

    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}

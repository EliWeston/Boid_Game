using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

    public static GameUIManager Instance;
    public GameObject GameOverCanvas;
    public GameObject ScoreCanvas;
    public Camera _mainCamera; 

    public Text ScoreText;
    public Text EmberText;
    public Text BoidText;

    void Start()
    {
        {
            if (Instance != null)
            {
                //if instance exists let's not make another :).
                Destroy(gameObject);
                return;
            }

            GameOverCanvas.SetActive(false);
            ScoreCanvas.SetActive(true);

            //If instane doesn't exist, we initialize the Player Manager
            Init();
        }
    }

        private void Init()
        {
        Cursor.lockState = CursorLockMode.Locked;

        Instance = this;

        }

        //sets GameOverUIManager to be in the game over state

        public void GameOver(GameObject _mainCamera)
    {
        Cursor.lockState = CursorLockMode.None;

        //Vector3 canvasPosition = new Vector3(_mainCamera.transform.position.x, _mainCamera.transform.position.y, _mainCamera.transform.position.z + 20);

        //Instantiate(GameOverCanvas, canvasPosition, Quaternion.identity);
        GameOverCanvas.SetActive(true);
        ScoreCanvas.SetActive(false);
    }

        public void SetEmberText(int value)
    {
        EmberText.text = "Ember: " + value;
    }

    public void SetScoreText(int value)
    {
        ScoreText.text = "Score: " + value;
    }

    public void SetBoidText(int value)
    {
        BoidText.text = "Boids: " + value;
    }
}

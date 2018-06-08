using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public Text scoreCountText;
    public static int scoreCount;
    public static int chooseLevel = 0;
    public SaveData saveData;

    void Start () {
        instance = this;
        scoreCount = PlayerPrefs.GetInt("scoreCount");
        scoreCountText.text = scoreCount.ToString();

    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
        {
            if (SceneManager.GetActiveScene().name == "StartMenu")
            {
                Application.Quit();
            }
        }
	}
    public void StartEarthScene()
    {
        chooseLevel = 1;
        SceneManager.LoadScene("PlayScene");
    }
    public void StartMoonScene()
    {
        chooseLevel = 2;
        SceneManager.LoadScene("PlayScene");
    }
    public void StartJupiterScene()
    {
        chooseLevel = 3;
        SceneManager.LoadScene("PlayScene");
    }
}

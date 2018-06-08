using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public List<PlanetData> planetData;
    public Camera gameCamera;
    public Rigidbody2D playerRigidbody2D;
    public RectTransform touchAreaPatel;
    public float force = 5;

    public Vector2 startPosition = new Vector2(-7.3f, 0.6f);

    public GameObject player;
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;

    [HideInInspector]
    public Vector2 mousePosition;
    [HideInInspector]
    public bool tuchIsTrue = false;

    private void Start()
    {
        switch (GameManager.chooseLevel) // set planet params
        {
            case 1:
                Physics2D.gravity = new Vector2(0f, -planetData[GameManager.chooseLevel - 1].gravity); // set gravity value
                gameCamera.backgroundColor = planetData[GameManager.chooseLevel - 1].backgroundColor; // set background collor
                break;
            case 2:
                Physics2D.gravity = new Vector2(0f, -planetData[GameManager.chooseLevel - 1].gravity);
                gameCamera.backgroundColor = planetData[GameManager.chooseLevel - 1].backgroundColor;
                break;
            case 3:
                Physics2D.gravity = new Vector2(0f, -planetData[GameManager.chooseLevel - 1].gravity);
                gameCamera.backgroundColor = planetData[GameManager.chooseLevel - 1].backgroundColor;
                break;
            default:
                Physics2D.gravity = new Vector2(0f, -planetData[0].gravity);
                gameCamera.backgroundColor = planetData[0].backgroundColor;
                break;
        }

        #region Elements Settings

        if (GameManager.Instance.saveData.ballPosition.x == 0f && GameManager.Instance.saveData.ballPosition.y == 0f) // set ball position
        {
            player.transform.position = startPosition; // set start ball position, if it's first play scene start
        }
        else player.transform.position = GameManager.Instance.saveData.ballPosition; // set start ball position from saving file

        platform1.GetComponent<SpriteRenderer>().color = GameManager.Instance.saveData.colorPlatform1;
        platform2.GetComponent<SpriteRenderer>().color = GameManager.Instance.saveData.colorPlatform2;
        platform3.GetComponent<SpriteRenderer>().color = GameManager.Instance.saveData.colorPlatform3;

        #endregion
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "PlayScene")
            {
                PlayerPrefs.SetInt("scoreCount", GameManager.scoreCount); // save score count to local memory

                GameManager.Instance.saveData.ballPosition = player.transform.position; // save the ball position
                GameManager.Instance.saveData.colorPlatform1 = platform1.GetComponent<SpriteRenderer>().color; // save the first platform color
                GameManager.Instance.saveData.colorPlatform2 = platform2.GetComponent<SpriteRenderer>().color; // save the second platform color
                GameManager.Instance.saveData.colorPlatform3 = platform3.GetComponent<SpriteRenderer>().color; // save the third platform color
                SceneManager.LoadScene("StartMenu");
            }
        }
    }

    

}

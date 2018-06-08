using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScrene : MonoBehaviour {

	void Start () {
        StartCoroutine(StartGame());
	}
	
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("StartMenu");
    }
}

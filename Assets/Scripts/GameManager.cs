using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text scoreText;
    GameObject ui;

    void Start() {
        PlayerPrefs.SetInt("score", 0);
        StartCoroutine("setScore");
    }

    public void restart() {
        SceneManager.LoadScene("Game");
    }

    public void exit() {
        Application.Quit();
    }

    IEnumerator setScore() {
        while (true) {
            scoreText.text = "Score: " + PlayerPrefs.GetInt("score").ToString();
            yield return new WaitForSeconds(0.1f);
        }
    }
}

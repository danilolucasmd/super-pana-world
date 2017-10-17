using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Functions : MonoBehaviour {

    public GameObject ModalScore;
    public GameObject score;
    public GameObject nick;
    public GameObject InputField;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame() {
        SceneManager.LoadScene("level");
    }

    public void Restart() {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void OpenRank() {
        ModalScore.SetActive(true);
    }

    public void CloseRank() {
        ModalScore.SetActive(false);
        InputField.SetActive(false);
    }

    public void Exit() {
        SceneManager.LoadScene("menu");
    }

    public void SendScore() {
        StartCoroutine(Send());
    }

    IEnumerator Send() {
        WWW www = new WWW("http://poke.thabis.com/panaapi/index.php?cmd=score&seri[nick]=" + nick.GetComponent<Text>().text + "&seri[score]=" + score.GetComponent<Text>().text);
        yield return www;
        ModalScore.SetActive(true);
    }
}

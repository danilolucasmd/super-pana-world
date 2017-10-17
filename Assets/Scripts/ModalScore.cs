using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalScore : MonoBehaviour {

    public GameObject InputField;
    private string url = "http://poke.thabis.com/panaapi/index.php?cmd=score";
    public GameObject score;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable() {
        StartCoroutine(GetScore());
    }

    private void OnDisable() {
        InputField.SetActive(false);
    }

    IEnumerator GetScore() {
        WWW www = new WWW(url);
        yield return www;
        ScoreData data = JsonUtility.FromJson<ScoreData>(www.text);

        if (data.listScores.Length < 10 || (int.Parse(score.GetComponent<Text>().text) > data.listScores[data.listScores.Length - 1])) {
            InputField.SetActive(true);
        }
    }
}

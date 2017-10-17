using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public GameObject[] scoreItems = new GameObject[] { };

    public string url = "http://poke.thabis.com/panaapi/index.php?cmd=score";

    private void OnEnable() {
        StartCoroutine(GetScore());
    }

    IEnumerator GetScore() {
        WWW www = new WWW(url);
        yield return www;
        ScoreData data = JsonUtility.FromJson<ScoreData>(www.text);

        for (int i = 0; i < data.listNames.Length; i++) {
            scoreItems[i].SetActive(true);
            scoreItems[i].transform.GetChild(1).GetComponent<Text>().text = data.listScores[i].ToString();
            scoreItems[i].transform.GetChild(2).GetComponent<Text>().text = data.listNames[i].Substring(0, 3).ToUpper();
        }
    }
}

public class ScoreData {
    public string[] listNames;
    public int[] listScores;
}

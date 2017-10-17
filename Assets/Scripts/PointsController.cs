using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour {

    public int score = 0;
    private int increaseScore = 0;
    public GameObject scoreLabel;

    private void Awake() {
        score = 0;
    }

    void Start () {
		
	}

    void Update() {
        scoreLabel.GetComponent<Text>().text = getScore().ToString();
    }

    public void IncreaseScore(int value) {
        increaseScore += value;
    }

    public void DecreaseScore(int value) {
        increaseScore -= value;
    }

    public void setScore(int value) {
        score = value + increaseScore;
    }

    public int getScore() {
        return score;
    }
}

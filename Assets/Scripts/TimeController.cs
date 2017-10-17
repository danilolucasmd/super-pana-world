using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

    public float gameSpeedIncrease = 1e-05f;
    private float startTime;

    private void Awake() {
        Time.timeScale = 1;
    }

    // Use this for initialization
    void Start () {
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        Time.timeScale += (Time.time - startTime) * gameSpeedIncrease;
	}
}

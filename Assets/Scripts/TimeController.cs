using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

    public float gameSpeedIncrease = 0.2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale += Time.time * gameSpeedIncrease;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

    public float amplitude;
    public float speed;
    private float tempVal;
    private Vector3 tempPos;

    void Start() {
        tempVal = transform.position.y;
    }

    void Update() {
        tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
        tempPos.x = transform.position.x;
        transform.position = tempPos;
    }
}

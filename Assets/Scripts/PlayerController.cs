using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D rb2d;
    public float jumpHeight = 5f;

    private string[] jumpAnims = new string[]{"Mortal", "Jump"};
    private string[] dashAnims = new string[] {"Lay", "Dash" };
    private string curDashAnim;

    private bool isGrounded = true;
    private bool isDashing = false;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("up") && isGrounded) {
            animator.SetTrigger(jumpAnims[Random.Range(0, jumpAnims.Length)]);
            rb2d.AddForce(new Vector2(0, jumpHeight));
            isGrounded = false;
        }

        if (Input.GetKeyDown("down")) {
            curDashAnim = dashAnims[Random.Range(0, jumpAnims.Length)];
            animator.SetBool(curDashAnim, true);
        }

        if (Input.GetKeyUp("down")) {
            animator.SetBool(curDashAnim, false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "ground") {
            isGrounded = true;
            animator.SetTrigger("Run");
        }
        if (collision.gameObject.tag == "enemy") {
            animator.SetTrigger("Mortal");
        }

        Debug.Log(collision);
    }
}

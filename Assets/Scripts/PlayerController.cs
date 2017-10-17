using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D rb2d;
    public float jumpHeight = 5f;
    public GameObject world;
    public GameObject ModalScore;
    public Animator animations;

    private string[] jumpAnims = new string[] {"Mortal", "Jump"};
    private string[] dashAnims = new string[] {"Lay", "Dash" };
    private string curDashAnim;

    private bool isGrounded = true;
    private bool isDashing = false;

    private float startFixedTime;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Awake() {
        startFixedTime = Time.fixedTime;
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetKeyDown("up")) {
            JumpDown();
        }

        if (Input.GetKeyDown("down")) {
            DashDown();
        }
    
        if (Input.GetKeyUp("down")) {
            DashUp();
        }

        world.GetComponent<PointsController>().setScore((int)((Time.fixedTime - startFixedTime) * 10));
    }

    public void JumpDown() {
        if (isGrounded) {
            animator.SetTrigger(jumpAnims[Random.Range(0, jumpAnims.Length)]);
            rb2d.AddForce(new Vector2(0, jumpHeight));
            isGrounded = false;
        }
    }

    public void DashDown() {
        curDashAnim = dashAnims[Random.Range(0, jumpAnims.Length)];
        animator.SetBool(curDashAnim, true);
    }

    public void DashUp() {
        animator.SetBool(curDashAnim, false);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "ground") {
            isGrounded = true;
            animator.SetTrigger("Run");
        }

        if (collision.gameObject.tag == "enemy") {
            float y = transform.position.y;
            Destroy(this.gameObject);
            animations.SetTrigger("Die");
            ModalScore.SetActive(true);
        }

        if (collision.gameObject.tag == "buff") {
            Destroy(collision.gameObject);
            world.GetComponent<PointsController>().IncreaseScore(10);
            animations.SetTrigger("Plus");
        }

        if (collision.gameObject.tag == "debuff") {

            if (world.GetComponent<PointsController>().getScore() - 100 <= 0) {
                Destroy(this.gameObject);
                ModalScore.SetActive(true);
                animations.SetTrigger("Die");
            } else {
                world.GetComponent<PointsController>().DecreaseScore(100);
                animations.SetTrigger("Less");
            }

            Destroy(collision.gameObject);
        }
    }
}

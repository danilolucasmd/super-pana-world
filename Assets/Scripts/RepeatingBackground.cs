using UnityEngine;
using System.Collections;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;
    public GameObject buff = new GameObject();
    public GameObject debuff = new GameObject();
    public GameObject airEnemy = new GameObject();
    public GameObject groundEnemy = new GameObject();
    private GameObject instantiatedObject = new GameObject();

    private void Awake() {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }

    private void Update() {
        if (transform.position.x < -groundHorizontalLength) {
            RepositionBackground();
        }
    }

    private void RepositionBackground() {
        Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

        transform.position = (Vector2)transform.position + groundOffSet;

        InstantiateObject();
    }

    private void InstantiateObject() {
        Destroy(instantiatedObject);

        switch (Random.Range(0, 4)) {
            case 0:
                instantiatedObject = Instantiate(buff, new Vector3(transform.position.x - 15, transform.position.y - 2, 0), transform.rotation);
                break;
            case 1:
                instantiatedObject = Instantiate(debuff, new Vector3(transform.position.x - 15, transform.position.y - 2, 0), transform.rotation);
                break;
            case 2:
                instantiatedObject = Instantiate(airEnemy, new Vector3(transform.position.x - 10, transform.position.y + 2, 0), transform.rotation);
                break;
            case 3:
                instantiatedObject = Instantiate(groundEnemy, new Vector3(transform.position.x - 15, transform.position.y - 3, 0), transform.rotation);
                break;
            default:
                break;
        }

        instantiatedObject.transform.SetParent(transform);
    }
}
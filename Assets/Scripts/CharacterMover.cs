using UnityEngine;

public class CharacterMover : MonoBehaviour {
    Rigidbody rb;
    Vector3 direction;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        direction = new Vector3();
    }

    // Update is called once per frame
    void Update() {
        processInput();
        move();
    }

    void move() {
        rb.velocity = direction * speed;// * Time.deltaTime;
    }

    void processInput() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertival = Input.GetAxis("Vertical");
        direction.x = horizontal;
        direction.z = vertival;
    }
}

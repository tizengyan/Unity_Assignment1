using UnityEngine;

public class BulletMover : MonoBehaviour {
    Rigidbody rb;
    public float speed = 40f;
    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag != "Player")
            Destroy(gameObject);
    }
}

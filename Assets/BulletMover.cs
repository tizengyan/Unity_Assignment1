using UnityEngine;

public class BulletMover : MonoBehaviour {
    Rigidbody rb;
    float speed = 30f;
    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * speed;
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag != "Player")
            Destroy(gameObject);
    }
}

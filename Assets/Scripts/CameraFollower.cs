using UnityEngine;

public class CameraFollower : MonoBehaviour {
    GameObject player;
    Vector3 offset;
    void Start() {
        player = GameObject.FindWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    void Update() {
        transform.position = player.transform.position + offset;
    }
}

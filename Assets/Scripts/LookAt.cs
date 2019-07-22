using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {
    public Transform target;

    void FixedUpdate() {
        transform.LookAt(new Vector3(target.position.x, 210f, target.position.z));
    }
}

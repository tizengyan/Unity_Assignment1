using UnityEngine;

public class Aimer : MonoBehaviour {
    Ray ray;
    Plane plane;
    float dis;

    void Update() {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        plane = new Plane(Vector3.up, Vector3.zero);
        if(plane.Raycast(ray, out dis)) {
            Vector3 target = ray.GetPoint(dis);
            Vector3 direction = target - transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; // z
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
    }
}

using UnityEngine;

public class BulletSpawner : MonoBehaviour {
    public GameObject bulletPrefab;

    void Update() {
        if (Input.GetButtonDown("Fire1"))
            spawnBullet();
    }

    void spawnBullet() {
        GameObject clone = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(clone, 5);
    }
}

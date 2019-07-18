using UnityEngine;

public class BulletSpawner : MonoBehaviour {
    public GameObject bulletPrefab;
    public GameObject firePoint;

    void Update() {
        if (Input.GetButtonDown("Fire1"))
            spawnBullet();
    }

    void spawnBullet() {
        GameObject clone = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation * Quaternion.Euler(90, 0, 0));
        Destroy(clone, 5);
    }
}

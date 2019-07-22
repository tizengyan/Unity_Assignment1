using UnityEngine;

public class Enemy : MonoBehaviour {
    public float health = 3f;
    public GameObject deathEffect;

    void Start() {

    }

    void Update() {

    }

    public void takeDamage() {
        health--;
        if (health <= 0) {
            die();
        }
    }

    void die() {
        GameObject clone = Instantiate(deathEffect, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(clone, 3);
        Destroy(gameObject);
        int score = PlayerPrefs.GetInt("score", -1) + 1;
        PlayerPrefs.SetInt("score", score);
    }
}

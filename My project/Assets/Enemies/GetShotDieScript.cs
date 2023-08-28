using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShotDieScript : MonoBehaviour
{
    [SerializeField] int maxHealth = 1;
    [SerializeField] GameObject deathEffect;
    int currentHealth;

    void Awake() {
        currentHealth = maxHealth;
    }

    public void Damage() {
        currentHealth--;

        if (currentHealth <= 0) {
            Die();
        } 
    }

    public void Die() {
        Instantiate(deathEffect, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DamageEvent(int health);

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] GameObject damageEffect;
    [SerializeField] float timeInvulnerable = 1.5f;
    [SerializeField] int maxHealth = 5;
    int currentHealth;

    bool canBeDamaged = true;

    public event DamageEvent OnDamage;
    public event DamageEvent OnDeath;

    void Start() {
        currentHealth = maxHealth;
        Debug.Log(currentHealth);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Enemy")) {
            Damage();
        }
    }

    void Damage() {
        if (!canBeDamaged) return;
        currentHealth--;
        OnDamage?.Invoke(currentHealth);
        Instantiate(damageEffect, this.transform.position + new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f)), this.transform.rotation);
        StartCoroutine(InvulnerablityTime());
        

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        OnDeath?.Invoke(currentHealth);
        Destroy(this.gameObject);
    }

    IEnumerator InvulnerablityTime() {
        canBeDamaged = false;
        yield return new WaitForSeconds(timeInvulnerable);
        canBeDamaged = true;
    }
}

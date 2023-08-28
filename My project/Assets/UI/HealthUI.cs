using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] int healthRepresenting;

    void Start() {
        GameObject.Find("Player").GetComponent<PlayerDamage>().OnDamage += Damage;
    }

    void Damage(int health) {
        if (health == healthRepresenting) {
            Destroy(this.gameObject);
        }
    }
}

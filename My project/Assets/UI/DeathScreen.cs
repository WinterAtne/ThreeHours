using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] GameObject normalUI;
    [SerializeField] GameObject deathUI;

    void Start() {
        GameObject.Find("Player").GetComponent<PlayerDamage>().OnDeath += EnableDeathUI;
    }

    void EnableDeathUI(int e) {
        normalUI.SetActive(false);
        deathUI.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject ray;
    [SerializeField] GameObject shotgunShell;
    [SerializeField] float rifleTime;
    [SerializeField] float shotgunTime;

    private bool canShoot = true;

    void Update() {
        if (canShoot && Input.GetButton("Fire1")) {
            StartCoroutine(Shoot(rifleTime));
            Instantiate(ray, this.transform.position, this.transform.rotation);
        }
        else if (canShoot && Input.GetButtonDown("Fire2")) {
            StartCoroutine(Shoot(shotgunTime));
            Instantiate(shotgunShell, this.transform.position, this.transform.rotation);
        }
    }

    IEnumerator Shoot(float time) {
        canShoot = false;

        yield return new WaitForSeconds(time);
        canShoot = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    [SerializeField] GameObject ray;

    void Start() {
        for (int i = 0; i < 10; i++) {
            Instantiate(ray, this.transform.position + new Vector3(Random.Range(-0.25f, 0.25f), Random.Range(-0.25f, 0.25f)), this.transform.rotation);
        }
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunRay : MonoBehaviour
{
    [SerializeField] float speed;

    void Start() {
        this.GetComponent<Rigidbody2D>().velocity = transform.up * speed + new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(-2.5f, 2.5f));
        Destroy(this.gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D col) {
        GetShotDieScript gsds = col.gameObject.GetComponent<GetShotDieScript>();
        if (gsds == null) return;

        gsds.Damage();  
        Destroy(this.gameObject);
    }
}

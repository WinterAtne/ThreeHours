using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;


    Rigidbody2D rb;
    Vector2 direction;


    void Awake() {
        rb = this.GetComponent<Rigidbody2D>();
    }


    //We grab our input every frame in order to make movements feel snappy and procise;
    void Update() {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        rb.velocity = direction;
        float currentMaxSpeedRatio = speed / (rb.velocity.magnitude + 0.00001f);
        rb.velocity *= currentMaxSpeedRatio;
    }
}

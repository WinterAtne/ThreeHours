using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayer : MonoBehaviour
{
    [SerializeField] float speed;

    Transform playerTransform;
    Transform thisTransform;

    void Start() {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        thisTransform = this.transform;
    }

    void Update() {
        thisTransform.position = Vector3.MoveTowards(thisTransform.position, playerTransform.position, speed * Time.deltaTime);
        if (thisTransform.position == playerTransform.position) this.gameObject.GetComponent<GetShotDieScript>().Die();
    }
}

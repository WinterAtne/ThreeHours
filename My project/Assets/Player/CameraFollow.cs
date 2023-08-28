using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] float speed = 0.125f;
    [SerializeField] Vector3 offset;

    void Awake() {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    void LateUpdate() {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, speed);

        transform.position = smoothedPosition;
    }
}

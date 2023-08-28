using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    float rotation = 0f;

    void LateUpdate() {
        this.transform.Rotate(0f, 0f, -rotation);
        

        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        rotation = Mathf.Atan((mousePosition.y) / (mousePosition.x)) * (180 / 3.1415f);

        //I don't know why the Atan function doesn't return values greater than 90 or less than -90, and I don't care to ask at this point
        if (mousePosition.x < 0 ) {
            rotation += 180f;
        }

        rotation -= 90f;

        this.transform.Rotate(0f, 0f, rotation);
    }
}

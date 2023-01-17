using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xrotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public void ProcessLook(Vector2 Input)
    {
        float mouseX = Input.x;
        float mouseY = Input.y;
        //calculate camera rotation for looking up and down.
        xrotation -= (mouseY * Time.deltaTime * ySensitivity);
        xrotation = Mathf.Clamp(xrotation, -80f, 80f);
        cam.transform.localRotation = Quaternion.Euler(xrotation, 0, 0);
        //rotate to look left and right.
        transform.Rotate(Vector3.up * mouseX * Time.deltaTime * xSensitivity);
    }
}

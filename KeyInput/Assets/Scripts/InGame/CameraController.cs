using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    public float rotX = 0.0f;
    public float rotY = 0.0f;

    public Transform targetCharacter;

    public void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    public void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //string msg = string.Format("X : {0}, Y : {1}", x, y);
        //Debug.Log(msg);
        //Debug.LogFormat("X : {0}, Y : {1}", x, y);

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        //rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;

        targetCharacter.rotation = localRotation;
    }
}

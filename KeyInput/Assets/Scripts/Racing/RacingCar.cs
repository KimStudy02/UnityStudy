using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingCar : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4];
    public Transform[] tires = new Transform[4];
    public float maxForce = 50.0f;
    public float power = 2000.0f;
    public Rigidbody rigidbody;
    public float targetRot = 45.0f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        for(int i = 0; i < 4; i++)
        {
            wheels[i].steerAngle = 0;
        }
        rigidbody.centerOfMass = Vector3.zero;
    }

    private void Update()
    {
        for(int i = 0; i < 4; i++)
        {
            Quaternion rot;
            Vector3 pos;
            wheels[i].GetWorldPose(out pos, out rot);
            tires[i].position = pos;
            tires[i].rotation = rot;
        }
    }

    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        rigidbody.AddForce(transform.rotation * new Vector3(vertical * power, 0, 0));
        for(int i = 0; i < wheels.Length; i++)
        {
            wheels[i].motorTorque = maxForce * vertical;
        }
        float horizontal = targetRot * Input.GetAxis("Horizontal");
        for(int i = 0; i < 2; i++)
        {
            wheels[i].steerAngle = horizontal;
        }
    }

}

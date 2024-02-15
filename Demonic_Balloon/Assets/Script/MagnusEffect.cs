using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusEffect : MonoBehaviour
{
    public float spin = 1000f;
    public float magnusCoefficient = 0.1f;
    
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
        {
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            Vector3 angularVelocity = GetComponent<Rigidbody>().angularVelocity;
            Vector3 magnusForce = magnusCoefficient * Vector3.Cross(angularVelocity, velocity);
            GetComponent<Rigidbody>().AddForce(magnusForce);
            GetComponent<Rigidbody>().AddTorque(transform.up * spin);
        }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Obstacle") || collision.gameObject.CompareTag("Balloon") || collision.gameObject.CompareTag("Floor"))
        {
            rb.angularVelocity = Vector3.zero;
            spin = 0f;
        }
    }
}

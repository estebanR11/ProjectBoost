 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int mainThrust;
    public int rotation;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProccessInput();
        ProcessThrust();
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }


    }

    void ProccessInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Rotation(rotation);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            Rotation(-rotation);
        }
      

    }

    private void Rotation(float rotationthis)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationthis * Time.deltaTime); 
        rb.freezeRotation = false;
    }
}

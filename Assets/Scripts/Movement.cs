 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int mainThrust;
    public int rotation;

    AudioSource asource;
    Rigidbody rb;

    [SerializeField] AudioClip engine;

    [SerializeField] ParticleSystem mainEngine;
    [SerializeField] ParticleSystem right;
    [SerializeField] ParticleSystem left;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        asource = GetComponent<AudioSource>();
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

        
            ThrustEffects();
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
        else
        {
            mainEngine.Stop();
            asource.Stop();
        }


    }

    private void ThrustEffects()
    {
        if (!asource.isPlaying)
        {
            asource.PlayOneShot(engine);
        }
        if (!mainEngine.isPlaying)
        {
            mainEngine.Play();
        }
    }

    void ProccessInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            LeftEffects();
            Rotation(rotation);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            RightEffects();
            Rotation(-rotation);
        }
        else
        {
            StopEffects();
        }


    }

    private void StopEffects()
    {
        left.Stop();
        right.Stop();
    }

    private void RightEffects()
    {
        right.Stop();
        if (!left.isPlaying)
        {
            left.Play();
        }
    }

    private void LeftEffects()
    {
        left.Stop();
        if (!right.isPlaying)
        {
            right.Play();
        }
        
    }

    private void Rotation(float rotationthis)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationthis * Time.deltaTime); 
        rb.freezeRotation = false;
    }

   
}

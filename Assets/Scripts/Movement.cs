using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] float jumpSpeed = 300f;
    [SerializeField] float rotSpeed = 100f;
    Rigidbody rb;

    AudioSource myAudio;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myAudio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        ProcessInput();
        ProcessRotation();

        
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * jumpSpeed * Time.deltaTime);
            if (!myAudio.isPlaying)
            {
                myAudio.Play();
            }
            
        }
        else
        {

            myAudio.Stop();

        }
    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotSpeed);
        }
    }

    void ApplyRotation(float rotThisFrame)
    {
        rb.freezeRotation = true; // freeze the rotation, so we can rotate it manually.
        transform.Rotate(Vector3.forward * rotThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //physics system can take over.  
    }

}

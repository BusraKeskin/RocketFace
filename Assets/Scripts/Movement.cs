using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    
    [SerializeField] float jumpSpeed = 300f;
    [SerializeField] float rotSpeed = 100f;
   
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainPrtclEngine;
    [SerializeField] ParticleSystem rightPrtcl;
    [SerializeField] ParticleSystem leftPrtcl;

    Rigidbody rb;

    AudioSource myAudio;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();    
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Oscillator>().enabled = false;
            StartThrust();
        }
        else
        {
            StopThrust();

        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Oscillator>().enabled = false;
            RotateLeft();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Oscillator>().enabled = false;
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }


    private void StopThrust()
    {
        mainPrtclEngine.Stop();
        myAudio.Stop();
    }

    private void StartThrust()
    {
        rb.AddRelativeForce(Vector3.up * jumpSpeed * Time.deltaTime);
        if (!myAudio.isPlaying)
        {
            mainPrtclEngine.Play();
            myAudio.PlayOneShot(mainEngine);
        }
    }

    private void RotateLeft()
    {
        ApplyRotation(rotSpeed);
        if (!rightPrtcl.isPlaying)
        {
            rightPrtcl.Play();
        }
    }
    private void RotateRight()
    {
        ApplyRotation(-rotSpeed);
        if (!leftPrtcl.isPlaying)
        {
            leftPrtcl.Play();
        }
    }
    private void StopRotating()
    {
        rightPrtcl.Stop();

        leftPrtcl.Stop();
    }

    void ApplyRotation(float rotThisFrame)
    {
        rb.freezeRotation = true; // freeze the rotation, so we can rotate it manually.
        transform.Rotate(Vector3.forward * rotThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //physics system can take over.  
    }

}

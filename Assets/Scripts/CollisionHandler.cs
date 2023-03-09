using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crash;
    [SerializeField] ParticleSystem successPrtcl;
    [SerializeField] ParticleSystem crashPrtcl;

    
    AudioSource audioSource;

    bool isTransitioning = false;
    bool isCollisionDisabled = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        forcedLoading();
        disableCollision();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning || isCollisionDisabled) { return; }

        switch (collision.gameObject.tag)
        {
            case "Start":
                Debug.Log("You've started");
                break;
            case "Finish":
                StartSuccesSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }
    void StartSuccesSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        successPrtcl.Play();
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", delayTime);
    }
    void StartCrashSequence()
    {

        //TODO: Add SFX upon crash
        //TODO: Add particle effects
        isTransitioning = true;
        audioSource.Stop();
        crashPrtcl.Play();
        audioSource.PlayOneShot(crash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delayTime);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void forcedLoading()
    {
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextLevel();
        }
    }
    
    void disableCollision()
    {
        if (Input.GetKey(KeyCode.C))
        {
            isCollisionDisabled = !isCollisionDisabled;
        }
    }
}
    
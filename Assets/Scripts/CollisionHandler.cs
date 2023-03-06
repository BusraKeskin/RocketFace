using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Finish":
                Debug.Log("You've done!");
                break;
            case "Start":
                Debug.Log("You've started");
                break;
            case "Fuel":
                Debug.Log("You've bumped with fuel!");
                break;
            default:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
        }
            

    }
}
    
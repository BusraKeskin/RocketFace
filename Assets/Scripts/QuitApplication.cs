using UnityEngine;

public class QuitApplication : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("you hit the ESC!");
            Application.Quit();
        }
    }
}

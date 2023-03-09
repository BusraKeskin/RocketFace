using UnityEngine;

public class Spinner : MonoBehaviour
{

    [SerializeField] float xRot = 0f;
    [SerializeField] float yRot = 0f;
    [SerializeField] float zRot = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRot, yRot, zRot + 1);
    }
}

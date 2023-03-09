using UnityEngine;

public class Oscillator : MonoBehaviour
{

    Vector3 startingPos;
    [SerializeField] Vector3 moveVector;
    float moveFactor;

    [SerializeField] float period = 2f;

    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon)
        {
            Debug.Log("The value of period cannot be Zero or any number less than 0! How can you divide it!?");
            return;
        }
        {
            float cycles = Time.time / period;  // continually growing over time

            const float tau = Mathf.PI * 2;  // constant value of 6.283
            float rawSinWave = Mathf.Sin(cycles * tau);  // going from -1 to 1

            moveFactor = (rawSinWave + 1f) / 2f;   // recalculated to go from 0 to 1 so its cleaner


            Vector3 offset = moveVector * moveFactor;
            transform.position = startingPos + offset;
        }
        
        
        
    }
}

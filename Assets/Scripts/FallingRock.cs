using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    public AudioSource audioSource;
    
    private Rigidbody rockRigidbody;

    // This method is called when the button is pressed
    public void StartRockFall()
    {
        // Get the Rigidbody component if not already set
        if (rockRigidbody == null)
        {
            rockRigidbody = GetComponent<Rigidbody>();
        }

        // Enable gravity (if it was disabled previously) to make the rock fall
        rockRigidbody.useGravity = true;
        audioSource.Play();

        // Optional: You can apply an initial force to make it fall with more speed
        // rockRigidbody.AddForce(Vector3.down * 10f, ForceMode.Impulse);
    }
}

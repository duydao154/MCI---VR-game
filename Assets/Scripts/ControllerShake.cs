using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerShake : MonoBehaviour {

	public GameObject leftHandAnchor; // Assign from OVRPlayerController hierarchy
    public GameObject rightHandAnchor;
	public GameObject player;
    public float shakeThreshold = 1.5f; // Adjust based on desired sensitivity
    public float moveSpeed = 10f; // Movement speed
    public float cooldownTime = 0.2f; // Cooldown to prevent rapid movements
    private bool enable = false;
    
    private float lastShakeTime = 0f;
    
    public void EnableControllerShake(){
        enable = true;
    }
    void MovePlayer()
    {
        // Move the player forward in the direction they're facing
        // Get the forward direction
    Vector3 forward = player.transform.forward;
    forward.y = 0; // Prevent upward movement by zeroing out the y-component

    // Normalize forward vector to prevent scaling issues
    forward.Normalize();

    // Move the player along the adjusted forward vector
    Vector3 newPosition = player.transform.position - forward * moveSpeed * Time.deltaTime;

    // Lock the y-position to prevent vertical movement
    newPosition.y = player.transform.position.y;

    // Update the player's position
    player.transform.position = newPosition;
    }
    

    void Update()
    {
        if(enable){
        // Get the velocities of both hands
        getPlayerHandShakeMovement();
       
    }

     void getPlayerHandShakeMovement(){
        
        Vector3 leftVelocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
        
        // Calculate the magnitude of the velocity
        float leftMagnitude = leftVelocity.magnitude;

        // Check if either hand exceeds the shake threshold
        if (Time.time > lastShakeTime + cooldownTime)
        {
            if (leftMagnitude > shakeThreshold)
            {
                MovePlayer();
                lastShakeTime = Time.time;
            }
        } 
        }
    }

   
}

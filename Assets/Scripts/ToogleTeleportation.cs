using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToogleTeleportation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject locomotionController; // Reference to the LocomotionController GameObject.

    private TeleportInputHandlerTouch inputHandler;   // Reference to the input handler.
    private TeleportAimHandlerParabolic aimHandler;   // Reference to the aim handler.
    private LocomotionTeleport locomotionTeleport;    // Reference to the LocomotionTeleport script.

    void Start()
    {
        // Get the necessary components from the LocomotionController.
        inputHandler = locomotionController.GetComponentInChildren<TeleportInputHandlerTouch>();
        aimHandler = locomotionController.GetComponentInChildren<TeleportAimHandlerParabolic>();
        locomotionTeleport = locomotionController.GetComponentInChildren<LocomotionTeleport>();
    }

    public void EnableTeleportation()
    {
        if (inputHandler != null)
            inputHandler.enabled = true;

        if (aimHandler != null)
            aimHandler.enabled = true;

        if (locomotionTeleport != null)
            locomotionTeleport.enabled = true;
    }
}

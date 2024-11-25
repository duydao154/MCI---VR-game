using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    
 public string grabButton = "Oculus_CrossPlatform_PrimaryHandTrigger"; // Change this based on the desired button
    private GameObject grabbedObject = null;
    private Rigidbody grabbedRigidbody = null;

    void Update()
    {
        // Check for grabbing input
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            TryGrabObject();
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            ReleaseObject();
        }
    }

    private void TryGrabObject()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.1f);
        foreach (Collider collider in colliders)
        {
            if (collider.attachedRigidbody)
            {
                grabbedObject = collider.gameObject;
                grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();
                grabbedRigidbody.isKinematic = true; // Disable physics while grabbing
                grabbedObject.transform.SetParent(transform);
                break;
            }
        }
    }

    private void ReleaseObject()
    {
        if (grabbedObject)
        {
            grabbedObject.transform.SetParent(null);
            grabbedRigidbody.isKinematic = false; // Re-enable physics
            grabbedObject = null;
            grabbedRigidbody = null;
        }
    }
}

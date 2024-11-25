using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUpObject : MonoBehaviour
{
    private Transform controller; // Controller/hand reference
    private Rigidbody objectRigidbody;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Coroutine moveToControllerCoroutine;
    private bool isMovingToController = false;

    static public bool pickedUp = false;

    void Start()
    {
        // Save the original position and rotation
        startPosition = transform.position;
        startRotation = transform.rotation;

        // Get the Rigidbody component if it exists
        objectRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (pickedUp && controller != null && !isMovingToController)
        {
            // Follow the controller
            transform.position = controller.position;
            transform.rotation = controller.rotation;
        }
    }

    public void Grab(Transform controllerTransform)
    {
        pickedUp = true;
        controller = controllerTransform;

        if (objectRigidbody != null)
        {
            objectRigidbody.isKinematic = true;
        }

        // Start moving the object to the controller
        if (moveToControllerCoroutine != null)
        {
            StopCoroutine(moveToControllerCoroutine);
        }
        moveToControllerCoroutine = StartCoroutine(MoveToController());
    }

    public void Drop()
    {
        pickedUp = false;
        controller = null;

        if (objectRigidbody != null)
        {
            objectRigidbody.isKinematic = false;
        }

        // Stop any active movement coroutine
        if (moveToControllerCoroutine != null)
        {
            StopCoroutine(moveToControllerCoroutine);
        }

        // Reset position if needed
        transform.position = startPosition;
        transform.rotation = startRotation;
    }

    private IEnumerator MoveToController()
    {
        isMovingToController = true;
        float speed = 5f;
        while (Vector3.Distance(transform.position, controller.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, controller.position, Time.deltaTime * speed);
            yield return null;
        }
        isMovingToController = false;
    }
}

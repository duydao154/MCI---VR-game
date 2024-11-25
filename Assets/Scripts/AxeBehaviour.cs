using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AxeBehaviour : MonoBehaviour
{
    public AudioSource audiosource;
    public TextMeshProUGUI debugtext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int damage = 10; // Amount of damage the axe deals per hit

    private void OnTriggerEnter(Collider other)
    {
        debugtext.text = "Colliding";
        // Check if the object hit is the rock
        if (other.CompareTag("Rock"))
        {
            debugtext.text = "Damaging";
            // Get the Rock script component from the collided object
            MinedRockBehaviour rock = other.GetComponent<MinedRockBehaviour>();
            if (rock != null)
            {   
                rock.TakeDamage(damage); // Inflict damage on the rock
                audiosource.Play();
            }
        }
    }
}

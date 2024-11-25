using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinedRockBehaviour : MonoBehaviour
{    
    public int health = 10; // Rock's starting health
    public Color hitColor = Color.red; // Color to show when hit
    public float colorChangeDuration = 0.2f; // Duration to keep the rock red

    private Color originalColor; // Original color of the rock
    private Renderer rockRenderer; // Renderer of the rock
    private bool isHit = false; // Whether the rock is being hit

    public TextMeshProUGUI debugtext;  

    private void Start()
    {
        // Cache the renderer and original color
        rockRenderer = GetComponent<Renderer>();
        if (rockRenderer != null)
        {
            originalColor = rockRenderer.material.color;
        }
    }

    public void TakeDamage(int damage)
    {
        // Reduce health
        health -= damage;
        

        // Check if health is zero or below
        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the rock
        }
        else
        {
            // Change the rock's color temporarily
            if (!isHit)
            {
                StartCoroutine(ChangeColorTemporarily());
            }
        }
    }

    private System.Collections.IEnumerator ChangeColorTemporarily()
    {
        isHit = true;

        // Change the color to indicate a hit
        if (rockRenderer != null)
        {
            rockRenderer.material.color = hitColor;
        }

        // Wait for the duration
        yield return new WaitForSeconds(colorChangeDuration);

        // Revert to the original color
        if (rockRenderer != null)
        {
            rockRenderer.material.color = originalColor;
        }

        isHit = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{ 
    // Reference to UI Text element to display the timer (optional)
    public TextMeshProUGUI timerText;  // Make sure you assign this in the Inspector if you're using it.
    private float timer = 0f;
    private bool isCounting = false;


    // Method to start the timer, called on button click
    public void StartTimer()
    {
        isCounting = true;
    }
    public string getTime(){
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer % 60F);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Method to stop the timer (optional)
    public void StopTimer()
    {
        isCounting = false;
    }

    // Reset the timer (optional)
    public void ResetTimer()
    {
        isCounting = false;
        timer = 0f;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (isCounting)
        {
            timer += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    // Update the timer display text
    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer % 60F);
        int milliseconds = Mathf.FloorToInt((timer * 100F) % 100F);
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}

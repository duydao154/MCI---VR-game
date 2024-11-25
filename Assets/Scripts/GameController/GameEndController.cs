using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.SceneManagement;

public class GameEndController : MonoBehaviour
{
    public GameObject OVRPlayerController;
    public Timer timer;
    public TextMeshProUGUI playerTimeText;

    public void displayPlayerTime(){
        playerTimeText.text = "Your time is: " + timer.getTime();
    }
    // Start is called before the first frame update
    public void resetGame (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

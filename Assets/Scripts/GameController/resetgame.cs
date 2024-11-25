using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class resetgame : MonoBehaviour
{

    void Update ()
    {
        if(OVRInput.Get(OVRInput.Button.Two))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}

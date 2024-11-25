using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStartMenuController : MonoBehaviour
{

    public TextMeshProUGUI debugtext;

    public void StartGame(){
        debugtext.text = "Button WORK";
    }

    public void StartGameWithTeleportation(){

    }
}

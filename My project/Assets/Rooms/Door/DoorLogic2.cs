using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic2 : MonoBehaviour
{
    public Transform theDoor;
    bool drawGUI = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            drawGUI = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            drawGUI = false;
        }
    }

    private void OnGUI()
    {
        if (drawGUI == true)
        {
            Rect doorGUI = new Rect(Screen.width / 2 - 75, Screen.height / 3, 150, 30);
            GUI.Box(doorGUI, "Closed");
        }
    }

}
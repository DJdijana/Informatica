using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic3 : MonoBehaviour
{
    public Transform theDoor;
    bool drawGUI = false;
    bool doorIsClose = true;

    void Update()
    {
        if (drawGUI == true && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine("ChangeDoorState"); // ChangeDoorState is a coroutine IEnumerator
            drawGUI = false;
        }
    }

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
            GUI.Box(doorGUI, "Press E to open");
        }
    }

    IEnumerator ChangeDoorState() // In order to WaitForSeconds to work, you need to create a IEnumerator coroutine
    {
        if (doorIsClose == true)
        {
            GameObject.Find("PivotDoor 3").GetComponent<Animation>().Play("Open");
            // audio for door opening
            doorIsClose = false;
            yield return new WaitForSeconds(3);
            GameObject.Find("PivotDoor 3").GetComponent<Animation>().Play("Close");
            //audio for door closing
            doorIsClose = true;
        }
    }
}
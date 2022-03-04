using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaptopTransition : MonoBehaviour
{
    public Transform theLaptop;
    bool drawGUI = false;

    public Animator animator;
    private int levelToLoad;

    void Update()
    {
        if (drawGUI == true && Input.GetKeyDown(KeyCode.E))
        {
            FadeToNextLevel();
            //StartCoroutine("ChangeLaptopState"); // ChangeDoorState is a coroutine IEnumerator
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
            GUI.Box(doorGUI, "Press E to use");
        }
    }

  

    public void FadeToNextLevel()
    {  
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
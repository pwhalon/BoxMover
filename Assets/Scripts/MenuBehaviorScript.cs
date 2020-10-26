using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviorScript : MonoBehaviour
{
    public bool isStart;
    public bool isQuit;

    // Start is called before the first frame update
    void Start()
    {
      GetComponent<Renderer>().material.color = Color.black;
    }

    // When hovering over the text option change the color to green
    void OnMouseEnter()
    {
      GetComponent<Renderer>().material.color = Color.green;
    }

    // When not hovering over the text option change the color to black
    void OnMouseExit()
    {
      GetComponent<Renderer>().material.color = Color.black;
    }

    // Linking the menu to the game and quitting.
    void OnMouseUp()
    {
      if(isStart)
      {
        Debug.Log("Load Scene");
        SceneManager.LoadScene("GameScene");
      }
      else if (isQuit)
      {
        Debug.Log("Quit");
        Application.Quit();
      }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAreaScript : MonoBehaviour
{
    public bool BoxHasEntered;
    public AudioSource YouWinAudio;

    public int xPos;
    public int yPos;
    public int zPos;

    // Start is called before the first frame update
    void Start()
    {
        BoxHasEntered = false;
        YouWinAudio = GetComponent<AudioSource>();
        xPos = Random.Range(-50, 50);
        yPos = 5;
        zPos = Random.Range(-50, 50);

        transform.position = new Vector3(xPos, yPos, zPos);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MovableBox" && BoxHasEntered == false)
        {
            BoxHasEntered = true;
            YouWinAudio.Play(0);
        }
    }
}

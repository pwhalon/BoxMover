using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBox : MonoBehaviour
{

    public bool BeingHeld { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.blue;
        BeingHeld = false;

        int xPos = Random.Range(-20, 20);
        int yPos = 3;
        int zPos = Random.Range(-20, 20);

        transform.position = new Vector3(xPos, yPos, zPos);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

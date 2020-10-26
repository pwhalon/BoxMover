using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapsuleController : MonoBehaviour
{
    private float movementSpeed = 5f;
    private float jumpSpeed = 5f;
    public Text objectiveText;
    public Objective currentObjective;

    // Start is called before the first frame update
    void Start()
    {
        currentObjective = null;
        objectiveText.text = "Current Objective: None";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") > 0)
        {
            MoveDirection(transform.GetComponentInChildren<Camera>().transform.forward);
        }
        if(Input.GetAxis("Vertical") < 0)
        {
            MoveDirection(-1 * transform.GetComponentInChildren<Camera>().transform.forward);
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            MoveDirection(transform.GetComponentInChildren<Camera>().transform.right);
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            MoveDirection(-1 * transform.GetComponentInChildren<Camera>().transform.right);
        }

        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }
    }



    void MoveDirection(Vector3 movement)
    {
        //update the position
        transform.position = transform.position + movement * movementSpeed * Time.deltaTime;
    }

    void Jump()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = (Vector3.up * jumpSpeed);
    }

    bool isGrounded()
    {
        RaycastHit hit;
        CapsuleCollider collider = GetComponent<CapsuleCollider>();

        float distanceToPoints = collider.height * 0.5F - collider.radius;

        Vector3 lowerPoint = collider.bounds.center - Vector3.up * distanceToPoints;
        Vector3 upperPoint = collider.bounds.center + Vector3.up * distanceToPoints;

        // Cast character controller shape .1 meters down to see if it is grounded.
        // Note: If there is overlap between the collider and the ground collider (or other collider) then the cast will return false.
        // So this is the reason for the -.1 to the radius and the +.2 to the sweep.
        // Note: There is an issue with moving in the lower left I believe it has to do with rounding so I will give an extra .01 to the sweep.
        if (Physics.CapsuleCast(lowerPoint, upperPoint, collider.radius - 0.01F, -Vector3.up, out hit, 0.02F))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

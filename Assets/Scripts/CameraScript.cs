using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float sensitivity = 0.05f;
    private Camera fpCamera;
    private float holdRange = 2.0F;
    private MovableBox HeldBox;

    // Start is called before the first frame update
    void Start()
    {
        fpCamera = GetComponent<Camera>();
        HeldBox = null;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lineOrigin = fpCamera.ViewportToWorldPoint(new Vector3(0.5F, 0.5F, 0));

        updateCameraDirection();

        Debug.DrawRay(lineOrigin, fpCamera.transform.forward * 50F, Color.green);

        if (HeldBox != null)
        {
            HeldBox.transform.position = transform.position + transform.TransformDirection(Vector3.forward);
        }

        if(Input.GetButtonDown("Fire"))
        {
            HoldRelease();
        }
    }

    void updateCameraDirection()
    {
        Vector3 vp = fpCamera.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, fpCamera.nearClipPlane));
        vp.x -= 0.5f;
        vp.y -= 0.5f;
        vp.x *= sensitivity;
        vp.y *= sensitivity;
        vp.x += 0.5f;
        vp.y += 0.5f;
        Vector3 sp = fpCamera.ViewportToScreenPoint(vp);

        Vector3 v = fpCamera.ScreenToWorldPoint(sp);
        transform.LookAt(v, Vector3.up);
    }

    void HoldRelease()
    {
        RaycastHit hit;
        if (HeldBox != null)
        {
          HeldBox = null;
        }
        else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, holdRange))
        {
              MovableBox box = hit.collider.GetComponent<MovableBox>();

              if (box != null)
              {
                  box.BeingHeld = true;
                  HeldBox = box;
              }
        }
    }

}

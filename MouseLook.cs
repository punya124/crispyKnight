using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 60f;
    public GameObject target;
    float xRotation, yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -10f, 45f);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -20f, 20f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        Debug.DrawRay(this.transform.position, this.transform.forward, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 1000f))
        {
            target.transform.position = hit.point;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; //adjustable value like in most fps games to control sensitivity
    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //assigning to variable the input of mouse on the X-axis (can be found in edit/project settings/input)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //likewise to input of mouse in the Y-axis

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0); //The only reason why we do this for the Y as compared to the X method beneath, is so we can clamp.
        playerBody.Rotate(Vector3.up * mouseX);


    }
}

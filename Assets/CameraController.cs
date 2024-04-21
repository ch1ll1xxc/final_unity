using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float sensitivity = 2.0f;
    public float smoothness = 5f;
    public float maxYAngle = 80.0f;

    private float rotationX = 0.0f;
    private float normalFieldOfView = 70f;
    private float sprintFieldOfView = 90f;
    private float targetFieldOfView;
    public Camera calledCamera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(0,mouseX*sensitivity, 0);
        calledCamera.transform.Rotate(-mouseY*sensitivity,0,0);

    }
}

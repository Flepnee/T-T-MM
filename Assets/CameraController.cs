using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float maxDistance = 20f;
    public float minSize = 1f;
    public float maxSize = 10f;
    public float scrollSensitivity = 1f;

    void Update()
    {
        MoveCamera();
        ZoomCamera();
    }

    void MoveCamera()
    {
        if (Input.GetMouseButton(2))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 moveDirection = new Vector3(-mouseX, -mouseY, 0f) * moveSpeed * Time.deltaTime;

            if (Mathf.Abs(transform.position.x + moveDirection.x) <= maxDistance && Mathf.Abs(transform.position.y + moveDirection.y) <= maxDistance)
            {
                transform.Translate(moveDirection);
            }
        }
    }

    void ZoomCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            Camera camera = Camera.main;
            float newSize = camera.orthographicSize - scroll * scrollSensitivity;
            newSize = Mathf.Clamp(newSize, minSize, maxSize);
            camera.orthographicSize = newSize;
        }
    }
}

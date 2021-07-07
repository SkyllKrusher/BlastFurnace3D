using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private Camera cam;
    private static readonly float panSpeed = 10f;
    private static readonly float zoomSpeed = 0.5f;
    private Vector3 lastPanPos;
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        HandleMouseControls();
    }

    private void HandleMouseControls()
    {
        if(Input.GetMouseButtonDown(2))
        {
            lastPanPos = Input.mousePosition;
        }
        else if(Input.GetMouseButton(2))
        {
            PanCamera(Input.mousePosition);
        }
        ZoomCamera();
    }

    private void PanCamera(Vector3 newPanPos)
    {
        Vector3 drag = cam.ScreenToViewportPoint(lastPanPos - newPanPos);
        Vector3 move = new Vector3 (drag.x * panSpeed, drag.y * panSpeed, 0);

        transform.Translate(move, Space.World);

        lastPanPos = newPanPos;
    }

    private void ZoomCamera()
    {
        Vector3 move = new Vector3 (0, 0, Input.mouseScrollDelta.y * zoomSpeed);

        transform.Translate(move, Space.World);
    }
}
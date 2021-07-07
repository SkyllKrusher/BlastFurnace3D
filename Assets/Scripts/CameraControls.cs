using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private Camera cam;
    private static readonly float panSpeed = 100f;
    private static readonly float zoomSpeed = 50f;
    private static readonly float rotSpeed = 100f;
    // private static readonly float[] BoundsX = new float[]{-10f, 10f};
    // private static readonly float[] BoundsY = new float[]{-10f, 10f};
    // private static readonly float[] BoundsZ = new float[]{-10f, 10f};
    private Vector3 lastPanPos;
    private Vector3 lastRotPos;
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

        if(Input.GetMouseButtonDown(0))
        {
            lastRotPos = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0))
        {
            RotateCamera(Input.mousePosition);
        }

        ZoomCamera();
    }

    private void PanCamera(Vector3 newPanPos)
    {
        Vector3 drag = cam.ScreenToViewportPoint(lastPanPos - newPanPos);
        Vector3 move = new Vector3 (drag.x, drag.y, 0) * panSpeed * Time.deltaTime;
        transform.Translate(move, Space.Self);

        Vector3 pos = transform.position;
        // pos.x = Mathf.Clamp(pos.x, BoundsX[0], BoundsX[1]);
        // pos.y = Mathf.Clamp(pos.y, BoundsY[0], BoundsY[1]);
        // pos.z = Mathf.Clamp(pos.z, BoundsZ[0], BoundsZ[1]);
        transform.position = pos;

        lastPanPos = newPanPos;
    }

    private void ZoomCamera()
    {
        Vector3 move = new Vector3 (0, 0, Input.mouseScrollDelta.y * zoomSpeed * Time.deltaTime);

        transform.Translate(move, Space.World);
    }

    private void RotateCamera(Vector3 newRotPos)
    {
        Vector3 drag = cam.ScreenToViewportPoint(lastRotPos - newRotPos);
        Vector3 rot = new Vector3 (drag.y, -drag.x, 0);
        
        transform.RotateAround(Vector3.zero, rot, rotSpeed *Time.deltaTime);

        lastRotPos = newRotPos;
    }
}
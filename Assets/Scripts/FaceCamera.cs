using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Camera cam;

    private void Awake()
    {
        cam = FindObjectOfType<Camera>();
    }
    void Update()
    {
        Vector3 lookDir = cam.transform.rotation.eulerAngles;
        Quaternion newRot = transform.rotation;
        newRot.eulerAngles = lookDir;
        transform.rotation = newRot;
    }
}

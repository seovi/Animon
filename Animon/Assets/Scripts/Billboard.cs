using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Billboard : MonoBehaviour
{
    GameObject cam;

    void Update()
    {
        if (cam == null)
            cam = GameObject.FindGameObjectWithTag("MainCamera");

        if (cam == null)
        {
            Debug.Log("Cam is null");
            return;
        }

        Debug.Log("Text look at cam");
        transform.LookAt(cam.transform);
        transform.Rotate(Vector3.up * 180);
    }
}

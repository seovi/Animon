using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offsetX;
    public float offsetY;
    public float offsetZ;

    void LateUpdate()
    {
        transform.position = new Vector3(
            player.transform.position.x + offsetX,
            player.transform.position.y + offsetY,
            player.transform.position.z + offsetZ
            );
    }
}

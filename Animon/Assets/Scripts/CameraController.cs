using Photon.Pun;
using Cinemachine;
using UnityEngine;


public class CameraController : MonoBehaviourPun
{
    private void Start()
    {
        if(photonView.IsMine) {
            CinemachineVirtualCamera followCam = FindObjectOfType<CinemachineVirtualCamera>();
            followCam.Follow = transform;
            followCam.LookAt = transform;
        }
    }

    
}

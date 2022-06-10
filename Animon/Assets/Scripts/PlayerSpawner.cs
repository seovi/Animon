using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    void Start()
    {
        Vector3 pos = new Vector3(0, 1, 0);
        PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);
    }
}

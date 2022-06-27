using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Animon.Const;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefab;
    void Start()
    {
        Vector3 pos = new Vector3(0, 1, 0);

        int charcterNum = 0;
        object character;
        if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue(AnimonConst.PLAYER_CHARACTER, out character))
        {
            charcterNum = (int)character;
        }

        Debug.Log("Player Name : "+playerPrefab[charcterNum].name);
        GameObject player = PhotonNetwork.Instantiate(playerPrefab[charcterNum].name, pos, Quaternion.identity);

        if (player)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.SetFollowCam(player.GetComponent<Transform>());
        }
    }
}

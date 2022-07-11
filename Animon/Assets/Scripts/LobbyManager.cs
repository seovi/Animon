using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1";
    public Button joinButton;
    public TextMeshProUGUI connectionInfoText;
    void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        joinButton.interactable = false;
    }

    public void Connect()
    {
        Debug.Log("Button On Click - Connect");
        SceneManager.LoadScene("CharacterSelection");        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        joinButton.interactable = true;
        connectionInfoText.text = "Connection Completed";
        
        // Player �ߺ� ó���� �����ϸ鼭 NickName�� �ӽ÷� �߰� 
        // ���� �α��� ������ ���޵Ǹ� ���� 
        System.Random rnd = new System.Random();
        int plaerNum = rnd.Next(1000, 9999);

        PhotonNetwork.LocalPlayer.NickName = "player" + plaerNum;
    }
        
}

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
        
        // Player 중복 처리를 구현하면서 NickName을 임시로 추가 
        // 추후 로그인 정보가 전달되면 수정 
        System.Random rnd = new System.Random();
        int plaerNum = rnd.Next(1000, 9999);

        PhotonNetwork.LocalPlayer.NickName = "player" + plaerNum;
    }
        
}

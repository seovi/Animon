using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
    }
        
}

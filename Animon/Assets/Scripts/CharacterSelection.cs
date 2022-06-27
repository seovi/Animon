using UnityEngine;
using Photon.Pun;
using Animon.Const;
using ExitGames.Client.Photon;
using Photon.Realtime;

public class CharacterSelection : MonoBehaviourPunCallbacks
{
	public GameObject[] characters;
	public int selectedCharacter = 0;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        
    }

    public void NextCharacter()
	{
		characters[selectedCharacter].SetActive(false);
		selectedCharacter = (selectedCharacter + 1) % characters.Length;
		characters[selectedCharacter].SetActive(true);

        PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { AnimonConst.PLAYER_CHARACTER, selectedCharacter } });
    }

	public void PreviousCharacter()
	{
		characters[selectedCharacter].SetActive(false);
		selectedCharacter--;
		if (selectedCharacter < 0)
		{
			selectedCharacter += characters.Length;
		}
		characters[selectedCharacter].SetActive(true);

        PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable() { { AnimonConst.PLAYER_CHARACTER, selectedCharacter } });
    }

	public void StartGame()
	{
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            PreviousCharacter();

        if (Input.GetKeyDown(KeyCode.RightArrow))
            NextCharacter();

        if (Input.GetKeyDown(KeyCode.Return))
            StartGame();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4 });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");

        PhotonNetwork.LoadLevel("SampleScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class UserNameDisplay : MonoBehaviour
{
    [SerializeField] PhotonView photonView;
    [SerializeField] TMP_Text text;

    private void Start()
    {
        text.text = photonView.Owner.NickName;
    }
}

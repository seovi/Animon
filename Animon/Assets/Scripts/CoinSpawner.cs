using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class CoinSpawner : MonoBehaviourPunCallbacks
{
    public GameObject coinPrefab;
    public const float COIN_MIN_SPAWN_TIME = 5f; // 최소 생성 주기
    public const float COIN_MAX_SPAWN_TIME = 5f; // 최대 생성 주기
    public const float COIN_MIN_SPAWN_POS = -50;
    public const float COIN_MAX_SPAWN_POS = 50;

    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간

    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(SpawnCoin());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator SpawnCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(COIN_MIN_SPAWN_TIME, COIN_MAX_SPAWN_TIME));

            float xPos = Random.Range(COIN_MIN_SPAWN_POS, COIN_MAX_SPAWN_POS);
            float zPos = Random.Range(COIN_MIN_SPAWN_POS, COIN_MAX_SPAWN_POS);

            Vector3 rndPos = new Vector3(xPos, 1, zPos);

            PhotonNetwork.InstantiateRoomObject(coinPrefab.name, rndPos, transform.rotation);
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == newMasterClient.ActorNumber)
        {
            StartCoroutine(SpawnCoin());
        }
    }
}

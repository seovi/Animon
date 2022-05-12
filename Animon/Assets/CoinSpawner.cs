using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinfPrefab;
    public float spawnRateMin = 10f; // �ּ� ���� �ֱ�
    public float spawnRateMax = 30f; // �ִ� ���� �ֱ�
    public float spawnMinPos = -9;
    public float spawnMaxPos = 9;

    private float spawnRate; // ���� �ֱ�
    private float timeAfterSpawn; // �ֱ� ���� �������� ���� �ð�
    // Start is called before the first frame update
    void Start()
    {
        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        // �Ѿ� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ���� 
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
    }

    // Update is called once per frame
    void Update()
    {
        // timeAfterSpawn�� ����
        timeAfterSpawn += Time.deltaTime;

        // �ֱ� ���� ������������ ������ �ð���, ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if (timeAfterSpawn >= spawnRate)
        {
            // ������ �ð��� ����
            timeAfterSpawn = 0f;
                        
            GameObject bullet = Instantiate(coinfPrefab,
                randPosition(), transform.rotation);            
            

            // ������ ���� ������ spawnRateMin, spawnRateMax ���̿��� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

    Vector3 randPosition()
    {
        float xPos = Random.Range(spawnMinPos, spawnMaxPos);
        float zPos = Random.Range(spawnMinPos, spawnMaxPos);

        Vector3 rndPos = new Vector3(xPos, 1, zPos);
        return rndPos;
    }
}

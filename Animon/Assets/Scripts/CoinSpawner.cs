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

    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        // �Ѿ� ���� ������ spawnRateMin�� spawnRateMax ���̿��� ���� ���� 
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����

        time = 0;
        transform.localScale = Vector3.one;
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

            transform.localScale = Vector3.one * (1 - time);
            if (time > 1f)
            {
                time = 0;
                gameObject.SetActive(false);
            }
            time += Time.deltaTime;
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

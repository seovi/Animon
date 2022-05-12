using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject boxPrefab;
    public int spawnCount = 100;
    public int spawnMinPos = -90;
    public int spawnMaxPos = 90;

    void Start()
    {
        Vector3 spawnPos;
        GameObject instance;
        for (int i = 0; i < spawnCount; ++i)
        {
            spawnPos = randPosition();
            instance = Instantiate(boxPrefab, spawnPos, Quaternion.identity);
        }
    }

    private Vector3 randPosition()
    {
        // TOOD: ���� ��ġ�� ���� ���� �ʵ��� ���� (�ؽ�ó�� �������鼭 �����Ÿ� �߻�, Z-fighting)

        float xPos = Random.Range(spawnMinPos, spawnMaxPos);
        float zPos = Random.Range(spawnMinPos, spawnMaxPos);

        Vector3 rndPos = new Vector3(xPos, 2.5f, zPos);
        return rndPos;
    }
}

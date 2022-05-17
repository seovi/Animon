using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject boxPrefab;
    public int spawnCount = 150;

    private int mapSizeX;
    private int mapSizeY;

    private static T[] ShuffleArray<T>(T[] array, int seed)
    {
        System.Random prng = new System.Random(seed);

        for (int i = 0; i < array.Length - 1; i++)
        {
            int randomIndex = prng.Next(i, array.Length);
            T tempItem = array[randomIndex];
            array[randomIndex] = array[i];
            array[i] = tempItem;
        }

        return array;
    }
    private struct Coord
    {
        public int x;
        public int y;

        public Coord(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }

    private Vector3 CoordToPosition(int x, int y)
    {
        return new Vector3(-mapSizeX / 2 + x, 2.5f, -mapSizeX / 2 + y);
    }

    void Start()
    {
        GameObject mapObj = GameObject.FindWithTag("Map");
        if (mapObj == null)
            return;

        mapSizeX = (int)mapObj.transform.localScale.x * 10 - 10;
        mapSizeY = (int)mapObj.transform.localScale.z * 10 - 10;

        int sacaleX = (int)boxPrefab.transform.localScale.x;
        int sacaleY = (int)boxPrefab.transform.localScale.z;

        List<Coord> tileMapCoords = new List<Coord>();
        for (int x = 0; x < mapSizeX; x += sacaleX)
        {
            for (int y = 0; y < mapSizeX; y += sacaleY)
            {
                tileMapCoords.Add(new Coord(x, y));
            }
        }

        Queue<Coord> shuffledTileCoords = new Queue<Coord>(ShuffleArray(tileMapCoords.ToArray(), 0));
        for (int i = 0; i < spawnCount; ++i)
        {
            Coord randomCoord = shuffledTileCoords.Dequeue();
            Vector3 spawnPos = CoordToPosition(randomCoord.x, randomCoord.y);
            GameObject instance = Instantiate(boxPrefab, spawnPos, Quaternion.identity);
        }
    }
}

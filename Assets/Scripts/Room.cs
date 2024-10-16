using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    protected System.Random rand;
    public Dictionary<(int, int), GameObject> obstacles;
    public Dictionary<(int, int), GameObject> enemies;
    public int[,] tiles;
    public GameObject wall;
    public GameObject floor;
    public GameObject enemy;
    public int roomSize;
    public int roomX;
    public int roomY;
    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        tiles = new int[roomSize + 1, roomSize + 1];
        floor = Resources.Load<GameObject>("Prefabs/floor");
        wall = Resources.Load<GameObject>("Prefabs/wall");
        enemy = Resources.Load<GameObject>("Prefabs/BasicEnemy");

        for (int i = 0; i < roomSize + 1; i++)
        {
            for (int j = 0; j < roomSize + 1; j++)
            {
                if (isOnPerimeter(i, j, roomSize + 1))
                {
                    wall = Instantiate(wall, new Vector2(i, j), Quaternion.identity);
                    tiles[i, j] = 1;
                } else
                {
                    floor = Instantiate(floor, new Vector2(i, j), Quaternion.identity);
                }
            }
        }

        enemy = Instantiate(enemy, new Vector2(1, 11), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool isOnPerimeter(int x, int y, int size)
    {
        return (x == 0 || x == size - 1 || y == 0 || y == size - 1);
    }
}

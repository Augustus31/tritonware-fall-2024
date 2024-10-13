using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    protected System.Random rand;
    public Dictionary<(int, int), GameObject> obstacles;
    public Dictionary<(int, int), GameObject> enemies;
    public List<GameObject> tiles;
    public GameObject wall;
    public GameObject floor;
    public GameObject enemy;
    public roomSize;
    public roomX;
    public roomY;
    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
        floor = Resources.Load<GameObject>("./Prefabs/floor");
        wall = Resources.Load<GameObject>("./Prefabs/wall");



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool IsOnPerimeter(int x, int y, int size)
    {
        return (x == 0 || x == size - 1 || y == 0 || y == size - 1);
    }
}

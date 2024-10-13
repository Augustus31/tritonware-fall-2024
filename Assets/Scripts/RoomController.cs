using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Root class representing the entire structure
[System.Serializable]
public class GameData
{
    public List<Level> levels;
}

// Class representing a level
[System.Serializable]
public class Level
{
    public int levelId;                     // ID of the level
    public List<RoomInfo> rooms;  // List of rooms
}

// Class representing a room
[System.Serializable]
public class RoomInfo
{
    public int roomId;                      // ID of the room
    public int roomX;                       // x coordinate
    public int roomY;                       // y coordinate
    public int roomSize;                     // Size of the room
}

public class RoomController : MonoBehaviour
{
    public List<Level> levels;
    public GameObject room;
    public GameObject currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        room = Resources.Load<GameObject>("Prefabs/Room");
        if (room == null)
        {
            Debug.Log("room null");
        }
        loadJSON();
        loadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadJSON()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("levelData/levelData");
        if (jsonFile == null)
        {
            Debug.Log("jsonFile null");
        }
        GameData gameData = JsonUtility.FromJson<GameData>(jsonFile.text);
        levels = gameData.levels;
        if (levels == null)
        {
            Debug.Log("levels null");
        }
    }

    void loadLevel()
    {
        currentLevel = Instantiate(room, new Vector2(0, 0), Quaternion.identity);
        if (currentLevel == null)
        {
            Debug.Log("currentLevel null");
        }
        if (currentLevel.GetComponent<Room>() == null)
        {
            Debug.Log("currentLevel component null");
        }
        if (levels[0]== null)
        {
            Debug.Log("levels[0] null");
        }
        if (levels[0].rooms == null)
        {
            Debug.Log("levels[0].rooms null");
        }
        if (levels[0].rooms[0] == null)
        {
            Debug.Log("levels[0].rooms[0] null");
        }
        if (levels[0].rooms[0].roomSize == null)
        {
            Debug.Log("levels[0].rooms[0].roomSize null");
        }
        currentLevel.GetComponent<Room>().roomSize = levels[0].rooms[0].roomSize;
        currentLevel.GetComponent<Room>().roomX = 0;
        currentLevel.GetComponent<Room>().roomY = 0;
    }
}

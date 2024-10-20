using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public int level;
    public static GameControllerScript GC;

    private void Awake()
    {
        if(GC != null && GC != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GC = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        level = 1;

        GameObject collectible = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/CollectibleWeapon"), transform.position - new Vector3(3,-3,0), Quaternion.identity);
        collectible.GetComponent<CollectibleWeaponScript>().weapon = new Shotgun();

        GameObject rangedEnemy = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/RangedEnemy"), transform.position - new Vector3(-3, -3, 1), Quaternion.identity);
        rangedEnemy.GetComponent<RangedEnemyScript>().weapon = new StormPistol();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

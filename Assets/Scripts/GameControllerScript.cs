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

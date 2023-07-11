using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControll : MonoBehaviour
{
    bool restart;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        restart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !restart)
        {
            restart = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if(Input.GetKeyUp(KeyCode.Escape))
            Application.Quit();
                
    }

}

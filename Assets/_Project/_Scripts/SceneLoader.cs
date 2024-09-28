using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{


    int currentSceneIndex;
    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void SceneLoad()
    {
        SceneManager.LoadScene(currentSceneIndex+1);
    }

    public void Reload()
    {
        SceneManager.LoadScene(currentSceneIndex);

    }
}

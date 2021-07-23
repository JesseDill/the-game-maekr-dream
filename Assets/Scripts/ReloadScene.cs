using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    // Restart
    string scene_name;
    int index;

    public void DelayedRestart(float time)
    {

        Invoke("RestartGame", time);

    }

    public void DelayedNext(float time)
    {

        Invoke("NextScene", time);

    }

    public void DelayedPrev(float time)
    {

        Invoke("PrevScene", time);

    }

    public void RestartGame()
    {
        scene_name = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(scene_name);

    }

    public void NextScene()
    {
        index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(index);
    }

    public void PrevScene()
    {
        index = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(index);
    }
}

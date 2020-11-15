using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
  public void loadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void loadLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void loadLevel3()
    {
        SceneManager.LoadScene(3);
    }

}

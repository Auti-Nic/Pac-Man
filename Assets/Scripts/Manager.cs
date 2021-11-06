using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public void Loadlevel()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
}

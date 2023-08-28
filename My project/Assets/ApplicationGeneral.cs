using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationGeneral : MonoBehaviour
{
    void Awake() {
        Application.targetFrameRate = 60;
    }

    public void Close() {
        Application.Quit();
    }

    public void Restart() {
        SceneManager.LoadSceneAsync("MainScene");
    }
}

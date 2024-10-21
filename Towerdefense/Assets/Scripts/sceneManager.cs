using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToGameScene()
    {
        SceneManager.LoadScene(1);
    }
}

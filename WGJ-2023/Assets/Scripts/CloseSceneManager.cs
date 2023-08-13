using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseSceneManager : MonoBehaviour
{
    public string sceneToReturn;

    public void ReturnToScene ()
    {
        SceneManager.LoadScene(sceneToReturn);
    }
}

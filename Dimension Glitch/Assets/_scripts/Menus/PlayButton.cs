using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public string sceneToLoad = "Mapa1Sol"; // escribe aquí el nombre del nivel

    public void OnPlay()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

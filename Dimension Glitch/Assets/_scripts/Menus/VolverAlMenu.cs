using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAlMenu : MonoBehaviour
{
    public string sceneToLoad;
    public void VolverMenu()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}

using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bottones : MonoBehaviour
{
    public VideoPlayer videoPlayer;   // Tu VideoPlayer
    public Button myButton;           // El botón a mostrar
    public string nextSceneName;      // Nombre de la escena a cargar

    private bool buttonShown = false;

    void Start()
    {
        myButton.gameObject.SetActive(false);  // Ocultar botón al inicio

        // Cuando el video termine una reproducción
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void Update()
    {
        // Si el jugador presiona cualquier tecla o clic → mostrar botón
        if (!buttonShown && (Input.anyKeyDown || Input.GetMouseButtonDown(0)))
        {
            ShowButton();
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        if (!buttonShown)
        {
            ShowButton();
        }
    }

    private void ShowButton()
    {
        buttonShown = true;
        myButton.gameObject.SetActive(true);
        myButton.onClick.AddListener(ChangeScene);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}

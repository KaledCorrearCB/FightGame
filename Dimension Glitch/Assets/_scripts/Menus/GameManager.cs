using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayerDied(int playerID)
    {
        if (playerID == 1)
        {
            // Murió Player1 → gana Player2
            SceneManager.LoadScene("GanarLobo");
        }
        else if (playerID == 2)
        {
            // Murió Player2 → gana Player1
            SceneManager.LoadScene("GanarZorra");
        }
    }
}

using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public CharacterDatabase database;
    public Transform player1Spawn;
    public Transform player2Spawn;
    public CameraController cameraController;

    [Header("HUDs")]
    public PlayerHUD HUD_Player1; // referencia al HUD del Canvas
    public PlayerHUD HUD_Player2;

    void Start()
    {
        SpawnPlayers();
    }

    void SpawnPlayers()
    {
        string p1Name = PlayerPrefs.GetString("P1Character", "");
        string p2Name = PlayerPrefs.GetString("P2Character", "");

        CharacterData p1Data = GetCharacterByName(p1Name);
        CharacterData p2Data = GetCharacterByName(p2Name);

        // Spawn Player 1
        if (p1Data != null)
        {
            GameObject p1 = Instantiate(p1Data.prefab, player1Spawn.position, player1Spawn.rotation);
            cameraController.AddTarget(p1.transform);

            CharacterStats stats1 = p1.GetComponent<CharacterStats>();
            HUD_Player1.Setup(stats1, p1Data); // Conecta directamente el HUD
        }

        // Spawn Player 2
        if (p2Data != null)
        {
            GameObject p2 = Instantiate(p2Data.prefab, player2Spawn.position, player2Spawn.rotation);
            cameraController.AddTarget(p2.transform);

            CharacterStats stats2 = p2.GetComponent<CharacterStats>();
            HUD_Player2.Setup(stats2, p2Data); // Conecta directamente el HUD
        }
    }

    CharacterData GetCharacterByName(string name)
    {
        foreach (var c in database.characters)
        {
            if (c.characterName == name)
                return c;
        }
        return null;
    }
}

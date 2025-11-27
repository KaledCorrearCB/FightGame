using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public CharacterDatabase database;
    public Transform player1Spawn;
    public Transform player2Spawn;
    public CameraController cameraController;

    [Header("HUDs")]
    public PlayerHUD HUD_Player1;
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

        // -------------------------
        //     PLAYER 1 SPAWN
        // -------------------------
        if (p1Data != null)
        {
            GameObject p1 = Instantiate(
                p1Data.prefab,
                player1Spawn.position,
                player1Spawn.rotation
            );

            cameraController.AddTarget(p1.transform);

            CharacterStats stats1 = p1.GetComponent<CharacterStats>();

            // ⭐ AQUÍ ASIGNAS EL ID DEL JUGADOR
            stats1.playerID = 1;

            // Conectar HUD
            HUD_Player1.Setup(stats1, p1Data);
        }

        // -------------------------
        //     PLAYER 2 SPAWN
        // -------------------------
        if (p2Data != null)
        {
            GameObject p2 = Instantiate(
                p2Data.prefab,
                player2Spawn.position,
                player2Spawn.rotation
            );

            cameraController.AddTarget(p2.transform);

            CharacterStats stats2 = p2.GetComponent<CharacterStats>();

            // ⭐ AQUÍ ASIGNAS EL ID DEL JUGADOR
            stats2.playerID = 2;

            // Conectar HUD
            HUD_Player2.Setup(stats2, p2Data);
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

using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Game/Character")]
public class CharacterData : ScriptableObject
{
    public string characterName;
    public Sprite portrait;         // Imagen para el selector
    public GameObject prefab;       // Prefab del personaje
    public RuntimeAnimatorController animator; // Opcional
}

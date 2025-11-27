using System;
using UnityEngine;

public static class GameEventManager
{
    public static Action<int, CharacterStats, CharacterData> OnPlayerSpawned;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUIController : MonoBehaviour
{
    public CharacterDatabase database; // lista de personajes SO
    public Transform container;        // donde se instancian los botones
    public CharacterButton buttonPrefab;

    [Header("Big Display Images")]
    public Image leftDisplay;
    public Image rightDisplay;

    bool isPlayer1Selecting = true;

    void Start()
    {
        GenerateButtons();
    }

    void GenerateButtons()
    {
        foreach (var character in database.characters)
        {
            var button = Instantiate(buttonPrefab, container);
            button.Setup(character, this);
        }
    }

    public void SelectCharacter(CharacterData data)
    {
        if (isPlayer1Selecting)
        {
            leftDisplay.sprite = data.bigSprite;
            PlayerPrefs.SetString("P1Character", data.name);
            isPlayer1Selecting = false;
        }
        else
        {
            rightDisplay.sprite = data.bigSprite;
            PlayerPrefs.SetString("P2Character", data.name);
        }
    }
}

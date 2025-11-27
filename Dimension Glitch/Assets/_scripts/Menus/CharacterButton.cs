using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterButton : MonoBehaviour
{
    public Image portraitImage;

    CharacterData data;
    CharacterSelectUIController controller;

    public void Setup(CharacterData data, CharacterSelectUIController controller)
    {
        this.data = data;
        this.controller = controller;

        portraitImage.sprite = data.portrait;
    }

    public void OnClick()
    {
        controller.SelectCharacter(data);
    }
}

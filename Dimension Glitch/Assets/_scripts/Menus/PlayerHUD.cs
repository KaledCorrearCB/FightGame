using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public Slider healthSlider;
    public Image portraitImage;
    public TMP_Text nameText;

    private CharacterStats target;

    // Este método lo llamamos desde CharacterSpawner
    public void Setup(CharacterStats stats, CharacterData data)
    {
        target = stats;

        healthSlider.maxValue = stats.maxHP;
        healthSlider.value = stats.HP;

        portraitImage.sprite = data.portrait;
        nameText.text = data.characterName;
    }

    void Update()
    {
        if (target != null)
            healthSlider.value = target.HP;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : UIBase
{
    public string playerName;

    public Text PlayerNameText;
    public Slider HpSlider;
    public Slider StaminaSlider;

    private void Awake()
    {
        PlayerNameText.text = playerName;
    }

    public void SetHp(float hp)
    {
        HpSlider.value = hp / 100;
    }

    public void SetStamina(float stamina)
    {
        StaminaSlider.value = stamina / 100;
    }
}

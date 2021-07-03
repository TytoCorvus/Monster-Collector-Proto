using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCreatureHUD : MonoBehaviour
{
    public Slider healthSlider;
    public Slider focusSlider;
    public Text healthText;
    public Text focusText;

    public int maxHP;
    public int maxFocus;

    public void setup(int maxHP, int currentHP, int maxFocus, int currentFocus)
    {
        this.maxHP = maxHP;
        this.maxFocus = maxFocus;

        updateHP(currentHP);
        updateFocus(currentFocus);
    }

    private void updateHP(int currentHP)
    {
        healthSlider.value = (float)currentHP / (float)maxHP;
        healthText.text = currentHP + " / " + maxHP;
    }

    private void updateFocus(int currentFocus)
    {
        focusSlider.value = (float)currentFocus / (float)maxFocus;
        focusText.text = currentFocus + " / " + maxFocus;
    }

    public void updateTo(BattleCreature battleCreature)
    {
        updateHP(battleCreature.currentHP);
        updateFocus(battleCreature.focus.getCurrentFocus());
    }
}

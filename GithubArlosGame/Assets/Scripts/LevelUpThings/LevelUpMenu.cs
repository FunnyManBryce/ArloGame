using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class LevelUpMenu : RestartScene
{
    public List<LevelUpEffect> levelUpEffects;

    public List<Button> buttons;

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void Start()
    {
        InitializeMenu();
    }

    public void InitializeMenu()
    {

        if (buttons.Count == 0 || levelUpEffects.Count == 0)
        {
            Debug.LogWarning("Buttons or level up effects are not assigned.");
            return;
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            LevelUpEffect randomEffect = levelUpEffects[Random.Range(0, levelUpEffects.Count)];

            TMPro.TMP_Text buttonText = buttons[i].GetComponentInChildren<TMPro.TMP_Text>();

            if (buttonText != null)
            {
                buttonText.text = randomEffect.buttonText;  
            }   
            else
            {
                Debug.LogWarning("Text component not found on the button.");
            }

            buttons[i].onClick.AddListener(() => randomEffect.ApplyEffect());
        }
    }
}

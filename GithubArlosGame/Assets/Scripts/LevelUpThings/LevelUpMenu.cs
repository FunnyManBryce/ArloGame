using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelUpMenu : RestartScene
{
    public List<LevelUpEffect> levelUpEffects;
    public Button[] setButtons;

    public void Resume()
    {
        Time.timeScale = 1;
    }

 public void ApplyRandomEffects()
{
    if (levelUpEffects.Count == 0)
    {
        Debug.LogWarning("No level up effects assigned.");
        return;
    }

    Button[] buttons = GetComponentsInChildren<Button>();

        foreach (Button button in setButtons)
        {
            if (button == null)
            {
                Debug.LogWarning("Button reference not assigned.");
                continue;
            }

            LevelUpEffect randomEffect = levelUpEffects[Random.Range(0, levelUpEffects.Count)]; // Create local variable here

            button.onClick.AddListener(() =>
            {
                randomEffect.ApplyEffect(); // Use the local variable here
            });
        }
    }
}
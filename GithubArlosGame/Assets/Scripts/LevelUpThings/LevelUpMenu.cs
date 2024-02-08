using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelUpMenu : RestartScene
{
    public List<LevelUpEffect> levelUpEffects;

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

        foreach (Button button in buttons)
        {
            Debug.Log(button.name);

            LevelUpEffect randomEffect = levelUpEffects[Random.Range(0, levelUpEffects.Count)];

            button.onClick.AddListener(() => randomEffect.ApplyEffect());
        }
    }
}

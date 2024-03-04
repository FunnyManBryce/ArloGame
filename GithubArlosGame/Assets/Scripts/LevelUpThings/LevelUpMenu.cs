using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class LevelUpMenu : RestartScene
{
    public List<LevelUpEffect> levelUpEffects;
    public List<Button> buttons;

    public bool wait = false;
    public float time = 3;
    public void Resume()
    {
            Time.timeScale = 1;
    }

    public void Start()
    {
        InitializeMenu();
    }

    public void ResetAndApplyEffects(Button clickedButton)
    {
        foreach (Button button in buttons)
        {
            button.onClick.RemoveAllListeners();

            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            Image buttonImage = button.GetComponentInChildren<Image>(); // Change here

            LevelUpEffect defaultEffect = button.GetComponent<LevelUpEffect>();
            if (defaultEffect != null)
            {
                if (buttonText != null)
                {
                    buttonText.text = defaultEffect.buttonText;
                }
                if (buttonImage != null)
                {
                    buttonImage.sprite = defaultEffect.buttonIcon;
                }
            }

            LevelUpEffect randomEffect = levelUpEffects[Random.Range(0, levelUpEffects.Count)];
            if (buttonText != null)
            {
                buttonText.text = randomEffect.buttonText;
            }
            if (buttonImage != null)
            {
                buttonImage.sprite = randomEffect.buttonIcon;
            }
            button.onClick.AddListener(() => randomEffect.ApplyEffect());
        }
    }

    public void InitializeMenu()
    {
        if (buttons.Count == 0 || levelUpEffects.Count == 0)
        {
            Debug.LogWarning("Buttons or level up effects are not assigned.");
            return;
        }

        foreach (Button button in buttons)
        {
            LevelUpEffect defaultEffect = button.GetComponent<LevelUpEffect>();
            if (defaultEffect != null)
            {
                TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    buttonText.text = defaultEffect.buttonText;
                }
                Image buttonImage = button.GetComponentInChildren<Image>(); // Change here
                if (buttonImage != null)
                {
                    buttonImage.sprite = defaultEffect.buttonIcon;
                }
            }
                ResetAndApplyEffects(button);
        }
    }

    public void LevelUp()
    {
        StartCoroutine(UpgradeDelay());
    }

    public IEnumerator UpgradeDelay()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }    
        Debug.Log("gritty?");
        //wait = true;
        yield return new WaitForSeconds(time);
        //wait = false;
        Debug.Log("GRITTY!");
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpMenu : RestartScene
{
    public ScriptableObject[] levelUpOptions;
    public void Resume()
    {
        Time.timeScale = 1;
    }
    
}

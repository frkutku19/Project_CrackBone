using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "ButtonManager",menuName ="Manager/ButtonManager")]
public class ScriptablesForButtons : ScriptableObject
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Resume()
    {
        UIManager.instance.ButtonPauseMenuClose();
    }
}

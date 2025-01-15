using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text enemyRemaining;
    public Text ammoText;
    public GameObject pauseMenu;
    public GameObject winMenu;
    private bool menuIsOpen = false;
    public static UIManager instance;

    void Start()
    {
        PublicMethods.MakeGameObjectList("Enemy");
        menuIsOpen = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        instance = this;
        FirstPersonController.cameraCanMove = true;

    }

    void Update()
    {
        enemyRemaining.text = "Enemy Left: " + PublicMethods.MakeGameObjectList("Enemy").Length.ToString();
        ammoText.text = RevolverBasics.RevolverStats["Ammo"].ToString() + "/" + RevolverBasics.RevolverStats["MagazineSize"].ToString();
        PauseMenuControl();
        WinCondition();
    }
    public void ButtonPauseMenuClose()
    {
        if (menuIsOpen)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            menuIsOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
            FirstPersonController.cameraCanMove = true;
        }
    }

    void PauseMenuControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !menuIsOpen)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            menuIsOpen = true;
            Cursor.lockState = CursorLockMode.None;
            FirstPersonController.cameraCanMove = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuIsOpen)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            menuIsOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
            FirstPersonController.cameraCanMove = true;
        }
    }

    public void WinCondition()
    {
        if (PublicMethods.MakeGameObjectList("Enemy").Length <= 0)
        {
            winMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            FirstPersonController.cameraCanMove = false;
        }
    }
}

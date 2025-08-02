using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
  [SerializeField] private GameObject PauseMenu;
  [SerializeField] private GameObject startPanel;
  [SerializeField] private GameObject settingsPanel;
  public static event Action SettingsRequested;
  public void SetScene(int sceneIndex)
  {
    SceneManager.LoadScene(sceneIndex);
  }

  public void Exit()
  {
    Application.Quit();
  }

  public void PauseGame(bool pause)
  {
    Time.timeScale = pause ? 0 : 1;
  }

  public void ShowPauseMenu(bool show)
  {
    if (PauseMenu != null)
    {
      PauseMenu.SetActive(show);
    }
  }

  public void GoToSettings()
  {
    startPanel.SetActive(false);
    settingsPanel.SetActive(true);
  }

  public void GoToMainMenu()
  {
    startPanel.SetActive(true);
    settingsPanel.SetActive(false);
    SettingsRequested?.Invoke();
  }
  private void Update()
  {
    if (PauseMenu != null && Input.GetKeyDown(KeyCode.Escape))
    {
      PauseMenu.SetActive(!PauseMenu.activeInHierarchy);
      PauseGame(PauseMenu.activeInHierarchy);
    }
  }
}

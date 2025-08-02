using TMPro;
using UnityEngine;
using Animations;
using UnityEngine.UI;

namespace Settings
{
  public class SettingsManager : MonoBehaviour
  {
    PlayerSettings userSettings;

    private void Awake()
    {
      DontDestroyOnLoad(gameObject);
      userSettings = new PlayerSettings();
      MenuController.SettingsRequested += DisplaySettings;
      foreach (Button item in GameObject.Find("SettingsPanel").GetComponentsInChildren<Button>(true))
      {
        TextMeshProUGUI buttonText = item.GetComponentInChildren<TextMeshProUGUI>();
        if (buttonText != null)
        {
          buttonText.text = item.name switch
          {
            "WalkRight" => userSettings.settingsFile.RightKey,
            "WalkLeft" => userSettings.settingsFile.LeftKey,
            "Sprint" => userSettings.settingsFile.SprintingKey,
            "Jump" => userSettings.settingsFile.JumpingKey,
            "Interact" => userSettings.settingsFile.InteractKey,
            _ => buttonText.text
          };
        }
        item.onClick.AddListener(() => GameObject.Find("SettingsPanel").GetComponentInChildren<A_SelectKeybindController>().PlayPopupAnim());
      }
    }

    private void DisplaySettings()
    {
      Button WalkRight = GameObject.Find("WalkRight").GetComponent<Button>();
      Button WalkLeft = GameObject.Find("WalkLeft").GetComponent<Button>();
      Button Sprint = GameObject.Find("Sprint").GetComponent<Button>();
      Button Jump = GameObject.Find("Jump").GetComponent<Button>();
    }
  }
}
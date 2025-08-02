using UnityEngine;

namespace Settings
{
  public class PlayerSettings
  {
   public PlayerSettingsJsonObject settingsFile;
    public PlayerSettings()
    {
      TextAsset settingsFileTmp = Resources.Load<TextAsset>("Json/Settings");
      if (settingsFileTmp != null)
      {
        settingsFile = JsonUtility.FromJson<PlayerSettingsJsonObject>(settingsFileTmp.text);
        
        
        Debug.Log("PlayerSettings Loaded");
      }
      else
      {
        Debug.LogError("PlayerSettings failed you fucked up");
      }
    }

    public class PlayerSettingsJsonObject
    {
        public string JumpingKey;
        public string LeftKey;
        public string RightKey;
        public string SprintingKey;
        public string InteractKey;
    }
  }
}
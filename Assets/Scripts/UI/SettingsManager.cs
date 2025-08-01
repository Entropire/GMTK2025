using UnityEngine;

public class SettingsManager : MonoBehaviour
{
  private Settings settings;
  void Start()
  {
    settings = Resources.Load<Settings>("Settings");
  }

  public KeyCode GetKeyBind(string name)
  {
    return settings.KeyBinds[name];
  }

  public void SetKeyBind(string name, KeyCode key)
  {
    settings.KeyBinds[name] = key;
  }
}

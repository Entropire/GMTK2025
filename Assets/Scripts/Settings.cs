using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "ScriptableObjects/Settings", order = 1)]
public class Settings : ScriptableObject
{
  [Range(0, 100)]
  public int Volume = 10;
  public Dictionary<string, KeyCode> KeyBinds = new Dictionary<string, KeyCode>();
}
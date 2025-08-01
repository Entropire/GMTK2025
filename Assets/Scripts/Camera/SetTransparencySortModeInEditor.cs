using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class SetTransparencySortModeInEditor : MonoBehaviour
{
  public TransparencySortMode sortMode = TransparencySortMode.Orthographic;

  void OnEnable()
  {
    GetComponent<Camera>().transparencySortMode = sortMode;
  }
}
using UnityEngine;

namespace Animations
{
  public class A_SelectKeybindController : MonoBehaviour
  {
    Animation animKeybind;
    Animation animBackground;
    void Start()
    {
      animKeybind = GetComponent<Animation>();
      animBackground = GameObject.Find("BackgroundBlur").GetComponent<Animation>();
      if (animKeybind == null || animBackground == null)
      {
        Debug.LogError("Animation component not found on " + gameObject.name);
        return;
      }
    }

    public void PlayPopupAnim()
    {
      animBackground.Play("BackgroundBlur");
      animKeybind.Play("SelectKeybind");
    }
  }
}
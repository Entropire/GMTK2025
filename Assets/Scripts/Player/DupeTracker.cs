using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

namespace Player.Dupes
{
  public class DupeTracker : MonoBehaviour
  {
    [SerializeField] public string KeyBind = "W";
    [Range(0, 6)] public short MaxDupes;
    public static List<PlayerDupes> Instances = new List<PlayerDupes>();
    public PlayerDupes CurrentInstance = new();
    StatesEnum currentlyKnownState = StatesEnum.Idle;

    void Start()
    {
      CurrentInstance = new PlayerDupes();
      Instances.Add(CurrentInstance);
      PlayerState.Instance.OnStateChanged += UpdateStateLogging;
    }
    void FixedUpdate()
    {
      try
      {
        if (transform == CurrentInstance.CoordsAnimSet.Last().Transform)
        {
          CurrentInstance.CoordsAnimSet.Last().TimePassed += Time.deltaTime;  //if the transform is the same as the last one, just update the time passed
        }
        else
        {
          CurrentInstance.CoordsAnimSet.Add(new(transform, currentlyKnownState, Time.deltaTime)); //otherwise, add a new dupe data with the current transform and state
        }
      }
      catch
      {
        CurrentInstance.CoordsAnimSet.Add(new(transform, currentlyKnownState, Time.deltaTime));
      }
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyBind) && MaxDupes >= Instances.Count)
      {
        IfReset();
      }
    }

    public void IfReset()
    {
      print("Resetting dupe tracker");
      CurrentInstance = new PlayerDupes();
      Instances.Add(CurrentInstance);
    }

    void UpdateStateLogging(StatesEnum @enum)
    {
      currentlyKnownState = @enum;
    }
  }
}

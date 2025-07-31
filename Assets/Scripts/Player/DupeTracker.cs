using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Player.Dupes
{
  public class DupeTracker : MonoBehaviour
  {
    [SerializeField] public KeyCode KeyBind = KeyCode.W;
    [Range(0, 6)] public short MaxDupes;
    public static List<PlayerDupes> Instances = new List<PlayerDupes>();
    public PlayerDupes CurrentInstance = new();
    StatesEnum currentlyKnownState = StatesEnum.Idle;

    void Start()
    {
      NewCloneTrack();
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
      if (Input.GetKeyDown(KeyBind) && Instances.Count < MaxDupes)
      {
        NewCloneTrack();
      }
    }

    public void NewCloneTrack()
    {
      print("Resetting dupe tracker");
      CurrentInstance = new PlayerDupes();
      Instances.Add(CurrentInstance);
    }

    void UpdateStateLogging(StatesEnum @StatesEnum)
    {
      currentlyKnownState = @StatesEnum;
    }
  }   
}

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
    public PlayerDupes CurrentInstance;
    StatesEnum currentlyKnownState = StatesEnum.Idle;

    void Start()
    {
      NewCloneTrack();
      PlayerState.Instance.OnStateChanged += UpdateStateLogging;
    }
    void FixedUpdate()
    {
      if (Instances.Count != 0 && Instances.Last().CoordsAnimSet.Count != 0)
      {
        Vector2 lastPosition = new(transform.position.x, transform.position.y);
        //Debug.Log($"{transform.position} == {CurrentInstance.CoordsAnimSet.Last().Location}");
        if (Vector2.Distance((Vector2)transform.position, CurrentInstance.CoordsAnimSet.Last().Location) == 0)
        {
          print("Adding time cuz standing still");
          CurrentInstance.CoordsAnimSet.Last().TimePassed += Time.deltaTime;  //if the transform is the same as the last one, just update the time passed
        }
        else
        {
          print("Adding new position");
          CurrentInstance.CoordsAnimSet.Add(new(lastPosition, currentlyKnownState, Time.deltaTime)); //otherwise, add a new dupe data with the current transform and state
        }
      }
      else
      {
        print("Adding first position/fallback");
        Vector2 lastPosition = new(transform.position.x, transform.position.y);
        CurrentInstance.CoordsAnimSet.Add(new(lastPosition, currentlyKnownState, Time.deltaTime));
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

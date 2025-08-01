using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

namespace Player.Dupes
{
  public class DupeTracker : MonoBehaviour
  {
    [Header("This script is added to the player itself")]
    [SerializeField] public Vector3 StartPosition;
    [SerializeField] public KeyCode KeyBind = KeyCode.W;
    [Range(0, 6)] public short MaxDupes;
    public static List<PlayerDupes> Instances = new List<PlayerDupes>();
    public PlayerDupes CurrentInstance;
    StatesEnum currentlyKnownState = StatesEnum.Idle;
    bool isTracking = false;

    void Start()
    {
      NewCloneTrack();
      transform.position = StartPosition;
      PlayerState.Instance.OnStateChanged += UpdateStateLogging;
    }
    void FixedUpdate()
    {
      if (!isTracking) return;
      if (Instances.Count != 0 && Instances.Last().CoordsAnimSet.Count != 0)
      {
        Vector2 lastPosition = new(transform.position.x, transform.position.y);
        if (Vector2.Distance((Vector2)transform.position, CurrentInstance.CoordsAnimSet.Last().Location) == 0)
        {
          CurrentInstance.CoordsAnimSet.Last().TimePassed += Time.deltaTime;  //if the transform is the same as the last one, just update the time passed
        }
        else
        {
          CurrentInstance.CoordsAnimSet.Add(new(lastPosition, currentlyKnownState, Time.deltaTime)); //otherwise, add a new dupe data with the current transform and state
        }
      }
      else
      {
        Vector2 lastPosition = new(transform.position.x, transform.position.y);
        CurrentInstance.CoordsAnimSet.Add(new(lastPosition, currentlyKnownState, Time.deltaTime));
      }
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyBind) && Instances.Count < MaxDupes && isTracking)
      {
        isTracking = false;
        NewCloneTrack();
      }
    }

    public void NewCloneTrack()
    {
      print("Resetting dupe tracker");
      CurrentInstance = new PlayerDupes();
      Instances.Add(CurrentInstance);
      transform.position = StartPosition;
      isTracking = true;
    }

    void UpdateStateLogging(StatesEnum @StatesEnum)
    {
      currentlyKnownState = @StatesEnum;
    }
  }
}

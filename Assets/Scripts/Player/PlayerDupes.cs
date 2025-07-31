using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player.Dupes
{
  public class PlayerDupes 
  {
    public List<DupeData> CoordsAnimSet = new();
  }


  public class DupeData
  {
    public Transform Transform { get; set; }
    public StatesEnum AnimationState { get; set; }

    public float TimePassed { get; set; }
    public DupeData(Transform transform, StatesEnum animationState, float timePassed)
    {
      Transform = transform;
      AnimationState = animationState;
      TimePassed = timePassed;
    }
  }
}
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
    public Vector2 Location { get; set; }
    public StatesEnum AnimationState { get; set; }

    public float TimePassed { get; set; }
    public DupeData(Vector2 location, StatesEnum animationState, float timePassed)
    {
      Location = location;
      AnimationState = animationState;
      TimePassed = timePassed;
    }
  }
}
using System;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
  StatesEnum currentState = StatesEnum.Idle;
  public event Action<StatesEnum> OnStateChanged;

  public static PlayerState Instance { get; private set; }

  private void Start()
  {
    Instance = this;
  }
  public void SetState(StatesEnum newState)
  {
    if (currentState != newState)
    {
      currentState = newState;
      OnStateChanged?.Invoke(currentState);
    }
  }

}

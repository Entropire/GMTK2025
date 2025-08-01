using System;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class PlayerState : MonoBehaviour
{
  StatesEnum currentState = StatesEnum.Idle;
  public event Action<StatesEnum> OnStateChanged;

  public static PlayerState Instance { get; private set; }

  private void Awake()
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

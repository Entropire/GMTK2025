using UnityEngine;

namespace Assets.Scripts.Player
{
  public abstract class StateFetcher : MonoBehaviour
  {
    protected IState[] states;

    public abstract IState[] GetStates();
  }
}
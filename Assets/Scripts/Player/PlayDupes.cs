using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Dupes
{
  public class PlayDupes : MonoBehaviour
  {
    [SerializeField] public KeyCode KeyBind = KeyCode.E;
    [SerializeField] private GameObject playerPrefab;
    List<GameObject> playerDupes = new();
    DupeTracker dupeTracker;

    void Start()
    {
      dupeTracker = FindObjectOfType<DupeTracker>();
    }

    void Update()
    {
      if (Input.GetKeyDown(KeyBind) && dupeTracker != null && dupeTracker.CurrentInstance != null && dupeTracker.CurrentInstance.CoordsAnimSet.Count > 0)
      {
        foreach (var instance in DupeTracker.Instances)
        {
          GameObject newDupe = Instantiate(playerPrefab);
          
          playerDupes.Add(newDupe);

          StartCoroutine(PlaySequence(newDupe.transform, instance.CoordsAnimSet));
        }
      }
    }
    public IEnumerator PlaySequence(Transform target, List<DupeData> sequence)
    {
      print("Playing sequence for dupe");
      Animator animator = target.GetComponent<Animator>();
      Vector2 LastPos = target.transform.position;
      for (int i = 0; i < sequence.Count; i++)
      { 
        Vector3 startPos = target.position;
        Vector3 endPos = new Vector3(sequence[i].Location.x, sequence[i].Location.y, startPos.z);
        float duration = sequence[i].TimePassed;
        float elapsed = 0f;
        HandleStateChanged(sequence[i].AnimationState, animator);

        while (elapsed < duration)
        {
          target.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
          target.transform.rotation = Quaternion.Euler(0f, (LastPos.x > target.transform.position.x ? 180f : 0f), 0f);
          LastPos = target.transform.position;
          elapsed += Time.deltaTime;
          yield return null;
        }
        target.position = endPos; 
      }
      sequence.Add(new DupeData(target.position, StatesEnum.Idle, 0f));
      HandleStateChanged(StatesEnum.Idle, animator);
     }

    private void HandleStateChanged(StatesEnum newState, Animator animator)
        {
            Debug.Log($"State changed to: {newState}");

            ResetTriggers(animator);

            switch (newState)
            {
                case StatesEnum.Idle:
                    animator.SetTrigger("Idle");
                    break;
                case StatesEnum.WalkingLeft:
                case StatesEnum.WalkingRight:
                    animator.SetTrigger("Walk");
                    break;
                case StatesEnum.RunningLeft:
                case StatesEnum.RunningRight:
                    animator.SetTrigger("Run");
                    break;
                case StatesEnum.JumpingLeft:
                case StatesEnum.JumpingRight:
                case StatesEnum.JumpingRunnuingLeft:
                case StatesEnum.JumpingRunnuingRight:
                case StatesEnum.FallingRight:
                case StatesEnum.FallingLeft:
                case StatesEnum.FallingRunningLeft:
                case StatesEnum.FallingRunnuingRight:
                    animator.SetTrigger("Jump");
                    break;
                default:
                    animator.SetTrigger("Idle");
                    break;
            }
        }

        private void ResetTriggers(Animator animator)
        {
            animator.ResetTrigger("Idle");
            animator.ResetTrigger("Walk");
            animator.ResetTrigger("Run");
            animator.ResetTrigger("Jump");
        }
    }
}
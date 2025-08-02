using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        PlayerState.Instance.OnStateChanged += HandleStateChanged;
    }

    private void HandleStateChanged(StatesEnum newState)
    { 
        Debug.Log($"State changed to: {newState}");

        ResetTriggers();

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
                animator.SetTrigger("Jump");
                break;
            default:
                animator.SetTrigger("Idle");
                break;
        }
    }

    private void ResetTriggers()
    {
        animator.ResetTrigger("Idle");
        animator.ResetTrigger("Walk");
        animator.ResetTrigger("Run");
        animator.ResetTrigger("Jump");
    }
}
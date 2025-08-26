using UnityEngine;

namespace Assets.Scripts.Player
{
    public class StateContext
    {
        public Rigidbody2D rigidbody { get; private set; }
        public Animator animator { get; private set; }
        public PlayerInputActions inputActions { get; private set; }

        public StateContext(Rigidbody2D rigidbody, Animator animator, PlayerInputActions inputActions)
        {
            this.rigidbody = rigidbody;
            this.animator = animator;
            this.inputActions = inputActions;
        }
    }
}
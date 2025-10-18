using UnityEngine;

namespace Assets.Scripts.Player
{
    [CreateAssetMenu(fileName = "StateData", menuName = "ScriptableObjects/StateData")]
    public class StateData : ScriptableObject
    {
        public float movementSpeed = 10f;
        public float jumpForce = 15f;
        public float groundCheckRadius = 0.2f;
        public LayerMask whatIsGround;
        public Transform groundCheck;
        public float coyoteTime = 0.2f; 
    }
}

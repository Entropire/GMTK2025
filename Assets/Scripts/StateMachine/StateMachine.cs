using System.Linq;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    internal abstract class StateMachine : MonoBehaviour
    {
        [SerializeField] private AState currentState;
        private StateContext stateContext;
#if UNITY_EDITOR
        private GameObject text;
        private TMP_Text textComponent;
#endif

        public abstract void InitStates();

        public void ChangeState(AState newState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }
            currentState = newState;
            if (currentState != null)
            {
                currentState.Enter();
            }
        }

        private void Awake()
        {
            InitStates();

            stateContext = new StateContext(
                GetComponent<Rigidbody2D>(),
                GetComponent<Animator>(),
                new PlayerInputActions()
                );

#if UNITY_EDITOR
            text = Instantiate(new GameObject("State Text"), transform);
        text.AddComponent<TextMeshPro>();
        textComponent = text.GetComponent<TMP_Text>();
        textComponent.fontSize = 3;
        textComponent.alignment = TextAlignmentOptions.Midline;
#endif
        }

        private void Update() => currentState?.Update();

        private void FixedUpdate()
        {
            currentState?.FixedUpdate();
#if UNITY_EDITOR
            text.transform.position = transform.position + new Vector3(0, transform.localScale.y * 0.75f, 0);
            textComponent.text = currentState?.GetType().Name.Replace("State", "") ?? "No State";
            text.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
#endif
        }
    }
}

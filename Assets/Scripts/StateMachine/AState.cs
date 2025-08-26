namespace Assets.Scripts.Player
{
    internal abstract class AState
    {
        private StateData stateData;

        public AState(StateData stateData)
        {
            this.stateData = stateData;
        }

        public virtual void Enter(StateContext stateContext) { }
        public virtual void Exit(StateContext stateContext) { }
        public virtual void Update(StateContext stateContext) { }
        public virtual void FixedUpdate(StateContext stateContext) { }
    }
}

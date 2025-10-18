namespace Assets.Scripts.Player
{
    internal abstract class AState
    {
        private StateData stateData;

        public AState(StateData stateData)
        {
            this.stateData = stateData;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
        public virtual void FixedUpdate() { }
    }
}

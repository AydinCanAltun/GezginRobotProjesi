using prolab21.Entity.Enums;

namespace prolab21.Abstractions
{
    public abstract class PlayerActionHandler {
        private PlayerAction takenAction { get; set; }
        public PlayerActionHandler() {
            this.takenAction = PlayerAction.Nothing;
        }

        public abstract void AskForAction();
        public abstract void SetTakenAction(int action);
        protected virtual void SetTakenAction(PlayerAction action)
        {
            takenAction = action;
        }
        public PlayerAction GetPlayerAction()
        {
            return takenAction;
        }

        public void ResetAction()
        {
            takenAction = PlayerAction.Nothing;
        }

        public abstract void WaitForInput();

    }
}

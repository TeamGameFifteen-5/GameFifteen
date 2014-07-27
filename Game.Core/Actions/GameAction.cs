namespace Game.Core.Actions
{
    using Game.Common;
	using Game.Core.Actions.ActionReceiver;

	public abstract class GameAction : IGameAction
	{
		public GameAction(ActionType actionType, IActionReceiver actionReceiver)
		{
			this.ActionReceiver = actionReceiver;
			this.ActionType = actionType;
		}

		protected IActionReceiver ActionReceiver { get; private set; }
		protected ActionType ActionType { get; private set; }

		public virtual void Execute()
		{
			this.ActionReceiver.Execute(this.ActionType);
		}

		public virtual void UnExecute()
		{
			var undoActionType = this.GetUndoActionType(this.ActionType);
			this.ActionReceiver.Execute(undoActionType);
		}

		protected virtual ActionType GetUndoActionType(ActionType actionType)
		{
			return ActionType.Get("Unmapped");
		}
	}
}
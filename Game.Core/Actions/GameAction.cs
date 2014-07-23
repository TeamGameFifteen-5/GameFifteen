using Game.Common;
using Game.Core.Actions.ActionInvokers;

namespace Game.Core.Actions
{
	public abstract class GameAction : IGameAction
	{
		public GameAction(ActionType actionType, IActionInvoker actionInvoker)
		{
			this.ActionInvoker = actionInvoker;
			this.ActionType = actionType;
		}

		protected IActionInvoker ActionInvoker { get; private set; }
		protected ActionType ActionType { get; private set; }

		public virtual void Execute()
		{
			this.ActionInvoker.Invoke(this.ActionType);
		}

		public virtual void UnExecute()
		{
			var undoActionType = this.GetUndoActionType(this.ActionType);
			this.ActionInvoker.Invoke(undoActionType);
		}

		protected virtual ActionType GetUndoActionType(ActionType actionType)
		{
			return new ActionType("Unmapped");
		}
	}
}
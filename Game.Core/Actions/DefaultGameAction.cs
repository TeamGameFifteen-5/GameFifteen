using Game.Core.Actions.ActionInvokers;

namespace Game.Core.Actions
{
	public class DefaultGameAction : GameAction
	{
		public DefaultGameAction(ICoreEngine coreEngine, ActionType actionType, IActionInvoker actionInvoker = null)
			: base(actionType, actionInvoker ?? new DefaultActionInvoker(coreEngine))
		{
		}

		protected override ActionType GetUndoActionType(ActionType actionType)
		{
			ActionType undoActionType;

			switch (actionType)
			{
				case ActionType.Up:
					undoActionType = ActionType.Down;
					break;

				case ActionType.Down:
					undoActionType = ActionType.Up;
					break;

				case ActionType.Left:
					undoActionType = ActionType.Right;
					break;

				case ActionType.Right:
					undoActionType = ActionType.Left;
					break;

				default:
					undoActionType = ActionType.Unmapped;
					break;
			}

			return undoActionType;
		}
	}
}
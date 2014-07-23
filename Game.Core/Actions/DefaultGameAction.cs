using Game.Common;
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

			switch (actionType.Name)
			{
				case "Up":
					undoActionType = ActionType.Get("Down");
					break;

				case "Down":
					undoActionType = ActionType.Get("Up");
					break;

				case "Left":
					undoActionType = ActionType.Get("Right");
					break;

				case "Right":
					undoActionType = ActionType.Get("Left");
					break;

				default:
					undoActionType = ActionType.Get("Unmapped");
					break;
			}

			return undoActionType;
		}
	}
}
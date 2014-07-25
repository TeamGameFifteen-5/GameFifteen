﻿namespace Game.Core.Actions
{
    using Game.Common;
    using Game.Core.Actions.ActionInvokers;

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
				case DefaultActionTypes.Up:
					undoActionType = ActionType.Get(DefaultActionTypes.Down);
					break;

				case DefaultActionTypes.Down:
					undoActionType = ActionType.Get(DefaultActionTypes.Up);
					break;

				case DefaultActionTypes.Left:
					undoActionType = ActionType.Get(DefaultActionTypes.Right);
					break;

				case DefaultActionTypes.Right:
					undoActionType = ActionType.Get(DefaultActionTypes.Left);
					break;

				default:
					undoActionType = ActionType.Get(DefaultActionTypes.Unmapped);
					break;
			}

			return undoActionType;
		}
	}
}
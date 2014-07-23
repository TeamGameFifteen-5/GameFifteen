using Game.Core.Actions.ActionInvokers;

namespace Game.Core.Actions.ActionProviders
{
	public abstract class ActionProvider : IActionProvider
	{
		public ActionProvider(IActionInvoker actionInvoker)
		{
			this.ActionInvoker = actionInvoker;
		}

		protected IActionInvoker ActionInvoker { get; set; }

		public abstract IGameAction CreateAction(ActionType actionType);
	}
}
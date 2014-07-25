namespace Game.Core.Actions.ActionProviders
{
    using Game.Common;
    using Game.Core.Actions.ActionInvokers;

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
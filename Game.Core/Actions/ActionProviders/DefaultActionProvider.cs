namespace Game.Core.Actions.ActionProviders
{
    using Game.Common;
    using Game.Core.Actions.ActionInvokers;

	public class DefaultActionProvider : ActionProvider
	{
		private ICoreEngine _coreEngine;

		public DefaultActionProvider(ICoreEngine coreEngine, IActionInvoker actionInvoker = null)
			: base(actionInvoker ?? new DefaultActionInvoker(coreEngine))
		{
			this._coreEngine = coreEngine;
		}

		public override IGameAction CreateAction(ActionType actionType)
		{
			return new DefaultGameAction(this._coreEngine, actionType, this.ActionInvoker);
		}
	}
}
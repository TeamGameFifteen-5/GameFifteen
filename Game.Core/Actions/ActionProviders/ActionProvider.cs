namespace Game.Core.Actions.ActionProviders
{
	using Game.Common;
	using Game.Core.Actions.ActionReceiver;
	using System.Collections.Concurrent;
	using System.Collections.Generic;

	/// <summary>
	/// Represents Action provider.
	/// Implements FlyWeight and Template Method Design Pattern.
	/// </summary>
	/// <seealso cref="Game.Core.Actions.ActionProviders.IActionProvider"/>
	public abstract class ActionProvider : IActionProvider
	{
		private static readonly ConcurrentDictionary<KeyValuePair<ActionType, IActionReceiver>, IGameAction> _ActionsCache;

		static ActionProvider()
		{
			_ActionsCache = new ConcurrentDictionary<KeyValuePair<ActionType, IActionReceiver>, IGameAction>();
		}

		public virtual IGameAction GetAction(ActionType actionType, IActionReceiver actionReceiver)
		{
			var action = new KeyValuePair<ActionType, IActionReceiver>(actionType, actionReceiver);
			return _ActionsCache.GetOrAdd(action, this.CreateAction);
		}

		protected abstract IGameAction CreateAction(KeyValuePair<ActionType, IActionReceiver> action);
	}
}
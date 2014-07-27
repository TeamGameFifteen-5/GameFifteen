namespace Game.Core.Actions.ActionProviders
{
	using Game.Common;
	using Game.Common.Utils;
	using Game.Core.Actions.ActionReceiver;
	using System.Collections.Generic;

	/// <summary>
	/// Represents default action provider.
	/// </summary>
	/// <seealso cref="Game.Core.Actions.ActionProviders.ActionProvider"/>
	public class DefaultActionProvider : ActionProvider
	{
		protected override IGameAction CreateAction(KeyValuePair<ActionType, IActionReceiver> action)
		{
			Validation.ThrowIfNull(action.Value);
			return new DefaultGameAction(action.Key, action.Value);
		}
	}
}
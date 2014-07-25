namespace Game.Core.Actions.ActionProviders
{
    using Game.Common;
	using Game.Core.Actions.ActionReceiver;

	/// <summary>
	/// Interface for action provider.
	/// </summary>
	public interface IActionProvider
	{
		/// <summary>
		/// Gets an action.
		/// </summary>
		/// <param name="actionType">	 Type of the action.</param>
		/// <param name="actionReceiver">The action receiver.</param>
		/// <returns>
		/// The action.
		/// </returns>
		IGameAction GetAction(ActionType actionType, IActionReceiver actionReceiver);
	}
}
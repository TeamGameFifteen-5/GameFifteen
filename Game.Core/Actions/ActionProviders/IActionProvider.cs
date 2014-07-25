namespace Game.Core.Actions.ActionProviders
{
    using Game.Common;

	/// <summary>
	/// Interface for action provider.
	/// </summary>
	public interface IActionProvider
	{
		/// <summary>
		/// Creates an action.
		/// </summary>
		/// <param name="actionType">Type of the action.</param>
		/// <returns>
		/// The new action.
		/// </returns>
		IGameAction CreateAction(ActionType actionType);
	}
}
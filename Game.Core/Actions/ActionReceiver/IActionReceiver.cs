namespace Game.Core.Actions.ActionReceiver
{
    using Game.Common;

	/// <summary>
	/// Interface for action reciever.
	/// </summary>
	public interface IActionReceiver
	{
		/// <summary>
		/// Executes the given operation.
		/// </summary>
		/// <param name="actionType">Type of the action.</param>
		void Execute(ActionType actionType);
	}
}
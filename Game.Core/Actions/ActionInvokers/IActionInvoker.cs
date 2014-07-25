namespace Game.Core.Actions.ActionInvokers
{
    using Game.Common;

	/// <summary>
	/// Interface for action invoker.
	/// </summary>
	public interface IActionInvoker
	{
		/// <summary>
		/// Executes the given operation.
		/// </summary>
		/// <param name="actionType">Type of the action.</param>
		void Invoke(ActionType actionType);
	}
}
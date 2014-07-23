namespace Game.Core.Actions.ActionInvokers
{
	public interface IActionInvoker
	{
		void Invoke(ActionType actionType);
	}
}
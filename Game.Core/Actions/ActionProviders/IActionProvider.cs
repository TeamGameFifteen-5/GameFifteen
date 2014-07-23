namespace Game.Core.Actions.ActionProviders
{
	public interface IActionProvider
	{
		IGameAction CreateAction(ActionType actionType);
	}
}
namespace Game.Core.Actions
{
	public interface IGameAction
	{
		void Execute();

		void UnExecute();
	}
}
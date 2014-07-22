namespace Game.UI
{
	public interface IUIEngine
	{
		void Start();

		void OnGameStart();

		void OnGameEnd();

		void OnGameExit();

		void OnGameMovement();

		void OnGameIllegalMove();

		void OnGameIllegalCommand();
	}
}
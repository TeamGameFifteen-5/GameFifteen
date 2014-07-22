namespace Game.Core.Input
{
	public interface IInputProvider
	{
		string GetTextInput();

		KeyType GetKeyInput(bool displayKey = false);
	}
}
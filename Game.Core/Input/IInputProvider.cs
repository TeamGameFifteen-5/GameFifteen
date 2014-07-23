using Game.Common;

namespace Game.Core.Input
{
	public interface IInputProvider
	{
		string GetTextInput();

		ActionType GetKeyInput(bool displayKey = false);
	}
}
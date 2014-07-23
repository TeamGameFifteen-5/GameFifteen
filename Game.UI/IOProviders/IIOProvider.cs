using Game.Core.Input;
using Game.UI.Renderers;
using System.Drawing;

namespace Game.UI.IOProviders
{
	public interface IIOProvider
	{
		string GetTextInput();

		ActionType GetKeyInput(bool displayKey = false);

		void Display(string output = null);

		void Display(string format, params string[] args);

		void DisplayLine(string output = null);

		void DisplayLine(string format, params string[] args);

		void ChangeColor(Color color);

		void ChangeStyle(IOStyleType style);

		void Invalidate();

		void Format(IRenderer renderer = null);
	}
}
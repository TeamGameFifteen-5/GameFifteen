using Game.Common;
using Game.Core.Input;
using Game.UI.KeyMappings;
using Game.UI.Renderers;
using System.Drawing;

namespace Game.UI.IOProviders
{
	public abstract class IOProvider<TKey> : IIOProvider, IInputProvider, IKeyMapping<TKey>
	{
		private IRenderer _renderer;

		protected IOProvider(IRenderer renderer = null)
		{
			this._renderer = renderer ?? new DefaultRenderer();
		}

		protected abstract IKeyMapping<TKey> KeyMapping { get; }

		public abstract string GetTextInput();

		public abstract ActionType GetKeyInput(bool displayKey = false);

		public abstract void Display(string output = null);

		public abstract void Display(string format, params string[] args);

		public abstract void DisplayLine(string output = null);

		public abstract void DisplayLine(string format, params string[] args);

		public abstract void ChangeColor(Color color);

		public abstract void ChangeStyle(IOStyleType style);

		public abstract void Invalidate();

		public virtual void Format(IRenderer renderer = null)
		{
			(renderer ?? this._renderer).Format(this);
		}

		public ActionType Map(TKey key)
		{
			return this.KeyMapping.Map(key);
		}
	}
}
namespace Game.UI.IOProviders
{
    using System.Drawing;
    using Game.Common;
    using Game.UI.IOProviders.Settings;
    using Game.UI.KeyMappings;

	/// <summary>
	/// Represents abstract Input/Output provider.
	/// Implements Bridge, Strategy, Template Method Design Pattern.
	/// </summary>
	/// <typeparam name="TKey">Type of the key.</typeparam>
	/// <seealso cref="Game.UI.IOProviders.IIOProvider"/>
	/// <seealso cref="Game.Core.Input.IInputProvider"/>
	/// <seealso cref="Game.UI.KeyMappings.IKeyMapping{TKey}"/>
	public abstract class IOProvider<TKey> : IIOProvider, IKeyMapping<TKey>
	{
		protected IOProvider(IIOProviderSettings renderer = null)
		{
			this.Settings = renderer ?? new DefaultIOProviderSettings();
		}

		protected IIOProviderSettings Settings { get; set; }

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

		public virtual void ApplySettings(IIOProviderSettings settings = null)
		{
			(settings ?? this.Settings).Apply(this);
		}

		public ActionType Map(TKey key)
		{
			return this.KeyMapping.Map(key);
		}
	}
}
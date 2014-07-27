namespace Game.UI.IOProviders
{
	using Game.Common;
	using Game.Common.Utils;
	using Game.UI.IOProviders.Settings;
	using Game.UI.KeyMappings;
	using System.Drawing;

	/// <summary>
	/// Represents abstract Input/Output provider.
	/// Implements Strategy, Template Method Design Pattern.
	/// </summary>
	/// <typeparam name="TKey">Type of the key.</typeparam>
	/// <seealso cref="Game.UI.IOProviders.IIOProvider"/>
	/// <seealso cref="Game.UI.KeyMappings.IKeyMapping{TKey}"/>
	/// <seealso cref="Game.Core.Input.IInputProvider"/>
	public abstract class IOProvider<TKey> : IIOProvider, IKeyMapping<TKey>
		where TKey : struct
	{
		/// <summary>
		/// Gets the key mapping.
		/// </summary>
		/// <value>
		/// The key mapping.
		/// </value>
		protected abstract IKeyMapping<TKey> KeyMapping { get; }

		/// <summary>
		/// Gets text input.
		/// </summary>
		/// <returns>
		/// The text input.
		/// </returns>
		public abstract string GetTextInput();

		/// <summary>
		/// Gets key input.
		/// </summary>
		/// <param name="displayKey">(optional) the display key.</param>
		/// <returns>
		/// The key input.
		/// </returns>
		public abstract ActionType GetKeyInput(bool displayKey = false);

		/// <summary>
		/// Displays the given output.
		/// </summary>
		/// <param name="output">(optional) the output.</param>
		public abstract void Display(string output = null);

		/// <summary>
		/// Displays the given arguments formated.
		/// </summary>
		/// <param name="format">Describes the format to use.</param>
		/// <param name="args">  A variable-length parameters list containing arguments.</param>
		public abstract void Display(string format, params string[] args);

		/// <summary>
		/// Displays the given output and puts a new line at the end.
		/// </summary>
		/// <param name="output">(optional) the output.</param>
		public abstract void DisplayLine(string output = null);

		/// <summary>
		/// Displays the given arguments formated and puts a new line at the end.
		/// </summary>
		/// <param name="format">Describes the format to use.</param>
		/// <param name="args">  A variable-length parameters list containing arguments.</param>
		public abstract void DisplayLine(string format, params string[] args);

		/// <summary>
		/// Change color.
		/// </summary>
		/// <param name="color">The color.</param>
		public abstract void ChangeColor(Color color);

		/// <summary>
		/// Change style.
		/// </summary>
		/// <param name="style">The style.</param>
		public abstract void ChangeStyle(IOStyleType style);

		/// <summary>
		/// Invalidates the output.
		/// </summary>
		public abstract void Invalidate();

		/// <summary>
		/// Applies the settings described by settings.
		/// </summary>
		/// <param name="settings">Options for controlling the operation.</param>
		public virtual void ApplySettings(IIOProviderSettings settings)
		{
			Validation.ThrowIfNull(settings);

			settings.Apply(this);
		}

		/// <summary>
		/// Maps the given key.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns>
		/// The mapped action type.
		/// </returns>
		public ActionType Map(TKey key)
		{
			return this.KeyMapping.Map(key);
		}

		/// <summary>
		/// Validate format and arguments.
		/// </summary>
		/// <param name="format">Describes the format to use.</param>
		/// <param name="args">  A variable-length parameters list containing arguments.</param>
		protected void ValidateFormatAndArgs(string format, params string[] args)
		{
			Validation.ThrowIfNullOrWhiteSpace(format);
			foreach (var arg in args)
			{
				Validation.ThrowIfNull(arg);
			}
		}
	}
}
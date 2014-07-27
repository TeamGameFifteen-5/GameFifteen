namespace Game.Common
{
	using Game.Common.Utils;
	using System;

	/// <summary>
	/// Represents serializable name-value.
	/// </summary>
	/// <seealso cref="Game.Common.INameValue"/>
	[Serializable]
	public abstract class NameValue : INameValue
	{
		#region Fields

		/// <summary>
		/// The name.
		/// </summary>
		private string _name;

		#endregion Fields

		/// <summary>
		/// Initializes a new instance of the NameValue class.
		/// </summary>
		/// <param name="name">The name.</param>
		public NameValue(string name)
		{
			this.Name = name;
		}

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name
		{
			get
			{
				return this._name;
			}
			private set
			{
				Validation.ThrowIfNullOrWhiteSpace(value);
				this._name = value;
			}
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		public abstract string Value { get; protected set; }
	}
}
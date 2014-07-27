namespace Game.Common
{
	using Game.Common.Utils;
	using System;

	/// <summary>
	/// Represents serializable name-value.
	/// </summary>
	/// <typeparam name="TValue">Type of the value.</typeparam>
	/// <seealso cref="Game.Common.NameValue"/>
	/// <seealso cref="Game.Common.INameValue{TValue}"/>
	[Serializable]
	public class NameValue<TValue> : NameValue, INameValue<TValue>
		where TValue : struct
	{
		#region Fields

		/// <summary>
		/// The value.
		/// </summary>
		private string _value;

		/// <summary>
		/// The value object.
		/// </summary>
		private TValue _valueObject;

		#endregion Fields

		/// <summary>
		/// Initializes a new instance of the NameValue class.
		/// </summary>
		/// <param name="name"> The name.</param>
		/// <param name="value">The value.</param>
		public NameValue(string name, TValue value)
			: base(name)
		{
			this.ValueObject = value;
		}

		/// <summary>
		/// Gets the value object.
		/// </summary>
		/// <value>
		/// The value object.
		/// </value>
		public TValue ValueObject
		{
			get
			{
				return this._valueObject;
			}
			private set
			{
				this._valueObject = value;
				this.Value = value.ToString();
			}
		}

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		public override string Value
		{
			get
			{
				return this._value;
			}
			protected set
			{
				Validation.ThrowIfNullOrWhiteSpace(value);
				this._value = value;
			}
		}
	}
}
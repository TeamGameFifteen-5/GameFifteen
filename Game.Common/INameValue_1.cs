namespace Game.Common
{
	/// <summary>
	/// Interface for name value.
	/// </summary>
	/// <typeparam name="TValue">Type of the value.</typeparam>
	public interface INameValue<TValue> : INameValue
		where TValue : struct
	{
		/// <summary>
		/// Gets the value object.
		/// </summary>
		/// <value>
		/// The value object.
		/// </value>
		TValue ValueObject { get; }
	}
}
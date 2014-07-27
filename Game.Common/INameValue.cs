namespace Game.Common
{
	/// <summary>
	/// Interface for name value.
	/// </summary>
	public interface INameValue
	{
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		string Name { get; }

		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		string Value { get; }
	}
}
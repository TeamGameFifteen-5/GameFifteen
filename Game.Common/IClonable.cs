namespace Game.Common
{
	/// <summary>
	/// Interface for clonable.
	/// </summary>
	/// <typeparam name="T">Generic type parameter.</typeparam>
	public interface IClonable<T>
	{
		/// <summary>
		/// Makes a shallow copy of this object.
		/// </summary>
		/// <returns>
		/// A shallow copy of this object.
		/// </returns>
		T Clone();

		/// <summary>
		/// Gets the deep copy of this object.
		/// </summary>
		/// <returns>
		/// A deep copy of this object.
		/// </returns>
		T DeepCopy();
	}
}
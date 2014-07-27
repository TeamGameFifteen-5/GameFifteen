namespace Game.Common
{
	using System;
	using System.IO;
	using System.Runtime.Serialization.Formatters.Binary;

	/// <summary>
	/// Represents abstract Clonable class.
	/// Implements Prototype Design Pattern.
	/// </summary>
	/// <typeparam name="T">Generic type parameter.</typeparam>
	/// <seealso cref="Game.Common.IClonable{T}"/>
	[Serializable]
	public abstract class Clonable<T> : IClonable<T>
	{
		/// <summary>
		/// Makes a shallow copy of this object.
		/// </summary>
		/// <returns>
		/// A shallow copy of this object.
		/// </returns>
		public T Clone()
		{
			return (T)this.MemberwiseClone();
		}

		/// <summary>
		/// Gets the deep copy of this object.
		/// </summary>
		/// <returns>
		/// A deep copy of this object.
		/// </returns>
		public T DeepCopy()
		{
			using (var ms = new MemoryStream())
			{
				var formatter = new BinaryFormatter();
				formatter.Serialize(ms, this);
				ms.Position = 0;

				return (T)formatter.Deserialize(ms);
			}
		}
	}
}
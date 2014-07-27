namespace Game.Common
{
	using Game.Common.Utils;
	using System.Collections.Concurrent;

	/// <summary>
	/// Represents Action type.
	/// Implements FlyWeight Design Pattern.
	/// </summary>
	public struct ActionType
	{
		/// <summary>
		/// The ActionType cache. Made ThreadSafe because the whole project depends on it and the whole
		/// project is extendable, except for this class.
		/// </summary>
		private static readonly ConcurrentDictionary<string, ActionType> _ActionTypesCache = new ConcurrentDictionary<string, ActionType>();

		/// <summary>
		/// The name.
		/// </summary>
		private string _name;

		/// <summary>
		/// Initializes a new instance of the ActionType class.
		/// </summary>
		/// <param name="name">The name.</param>
		private ActionType(string name)
			: this()
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
		/// Gets.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns>
		/// The action type that corresponds to that name.
		/// </returns>
		public static ActionType Get(string name)
		{
			Validation.ThrowIfNullOrWhiteSpace(name);
			return _ActionTypesCache.GetOrAdd(name, actionTypeName => new ActionType(actionTypeName));
		}

		/// <summary>
		/// == casting operator.
		/// </summary>
		/// <param name="actionType1">The first action type.</param>
		/// <param name="actionType2">The second action type.</param>
		/// <returns>
		/// The result of the operation.
		/// </returns>
		public static bool operator ==(ActionType actionType1, ActionType actionType2)
		{
			return actionType1.Name == actionType2.Name;
		}

		/// <summary>
		/// != casting operator.
		/// </summary>
		/// <param name="actionType1">The first action type.</param>
		/// <param name="actionType2">The second action type.</param>
		/// <returns>
		/// The result of the operation.
		/// </returns>
		public static bool operator !=(ActionType actionType1, ActionType actionType2)
		{
			return actionType1.Name != actionType2.Name;
		}

		/// <summary>
		/// == casting operator.
		/// </summary>
		/// <param name="actionType1">The first action type.</param>
		/// <param name="actionType2">The second action type.</param>
		/// <returns>
		/// The result of the operation.
		/// </returns>
		public static bool operator ==(ActionType actionType1, string actionType2)
		{
			return actionType1.Name == actionType2;
		}

		/// <summary>
		/// != casting operator.
		/// </summary>
		/// <param name="actionType1">The first action type.</param>
		/// <param name="actionType2">The second action type.</param>
		/// <returns>
		/// The result of the operation.
		/// </returns>
		public static bool operator !=(ActionType actionType1, string actionType2)
		{
			return actionType1.Name != actionType2;
		}

		/// <summary>
		/// Indicates whether this instance and a specified object are equal.
		/// </summary>
		/// <param name="obj">The object to compare with the current instance.</param>
		/// <returns>
		/// true if <paramref name="obj" /> and this instance are the same type and represent the same
		/// value; otherwise, false.
		/// </returns>
		public override bool Equals(object obj)
		{
			bool isEqual = false;

			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			if (obj is ActionType)
			{
				isEqual = this.Name.Equals(((ActionType)obj).Name);
			}

			if (obj is string)
			{
				isEqual = this.Name.Equals((string)obj);
			}

			return isEqual;
		}

		/// <summary>
		/// Indicates whether this instance and a specified object are equal.
		/// </summary>
		/// <param name="other">The action type to compare to this object.</param>
		/// <returns>
		/// true if <paramref name="obj" /> and this instance are the same type and represent the same
		/// value; otherwise, false.
		/// </returns>
		public bool Equals(ActionType other)
		{
			return string.Equals(this.Name, other.Name);
		}

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>
		/// A 32-bit signed integer that is the hash code for this instance.
		/// </returns>
		public override int GetHashCode()
		{
			return this.Name.GetHashCode();
		}
	}
}
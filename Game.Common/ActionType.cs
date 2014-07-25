namespace Game.Common
{
    using System.Collections.Concurrent;

	/// <summary>
	/// Represents Action type.
	/// Implements FlyWeight Design Pattern.
	/// </summary>
	public struct ActionType
	{
		/// <summary>
		/// The ActionType cache.
		/// Made ThreadSafe because the whole project depends on it and the whole project is extendable, except for this class
		/// </summary>
		private static readonly ConcurrentDictionary<string, ActionType> _cache = new ConcurrentDictionary<string, ActionType>();

		private string _name;

		public ActionType(string name)
			: this()
		{
			this.Name = name;
		}

		public string Name
		{
			get
			{
				return this._name;
			}
			private set
			{
				this._name = value;
			}
		}

		public static ActionType Get(string name)
		{
			return _cache.GetOrAdd(name, actionTypeName => new ActionType(actionTypeName));
		}

		public static bool operator ==(ActionType actionType1, ActionType actionType2)
		{
			return actionType1.Name == actionType2.Name;
		}

		public static bool operator !=(ActionType actionType1, ActionType actionType2)
		{
			return actionType1.Name != actionType2.Name;
		}

		public static bool operator ==(ActionType actionType1, string actionType2)
		{
			return actionType1.Name == actionType2;
		}

		public static bool operator !=(ActionType actionType1, string actionType2)
		{
			return actionType1.Name != actionType2;
		}

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

		public bool Equals(ActionType other)
		{
			return string.Equals(this.Name, other.Name);
		}

		public override int GetHashCode()
		{
			return this.Name != null ? this.Name.GetHashCode() : 0;
		}
	}
}
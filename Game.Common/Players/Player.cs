namespace Game.Common.Players
{
    using Game.Common.Utils;

	/// <summary>
	/// Player.
	/// </summary>
	/// <seealso cref="Game.Common.Players.IPlayer"/>
	public class Player : IPlayer
	{
		/// <summary>
		/// The name.
		/// </summary>
		private string _name;

		/// <summary>
		/// Initializes a new instance of the Player class.
		/// </summary>
		public Player()
		{
		}

		/// <summary>
		/// Initializes a new instance of the Player class.
		/// </summary>
		/// <param name="name"> The name.</param>
		/// <param name="score">The score.</param>
		public Player(string name, int score)
		{
			this.Name = name;
			this.Score = score;
		}

		/// <summary>
		/// Gets or sets the name.
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
			set
			{
				Validation.ThrowIfNullOrWhiteSpace(value);
				this._name = value;
			}
		}

		/// <summary>
		/// Gets or sets the score.
		/// </summary>
		/// <value>
		/// The score.
		/// </value>
		public int Score { get; set; }
	}
}
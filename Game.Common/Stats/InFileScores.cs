namespace Game.Common.Stats
{
	using Game.Common.Utils;
	using System.Collections.Generic;
	using System.IO;
	using System.Runtime.Serialization.Formatters.Binary;

	/// <summary>
	/// In file scores.
	/// Implements Singleton Design Pattern
	/// </summary>
	/// <seealso cref="Game.Common.Stats.StatsStorage"/>
	/// <seealso cref="Game.Common.Stats.IIntegerStats"/>
	public sealed class InFileScores : StatsStorage<INameValue<int>>, IIntegerStats
	{
		/// <summary>
		/// The maximum top players.
		/// </summary>
		private const int MAX_TOP_PLAYERS = 5;

		/// <summary>
		/// Full pathname of the file.
		/// </summary>
		private const string FILE_PATH = @"../../GameFifteen.game15";

		/// <summary>
		/// The instance.
		/// </summary>
		private static readonly IIntegerStats _Instance = new InFileScores();

		/// <summary>
		/// Prevents a default instance of the InFileScores class from being created.
		/// </summary>
		private InFileScores()
			: base(MAX_TOP_PLAYERS)
		{
			this.Stats = this.LoadFromFile();
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static IIntegerStats Instance
		{
			get
			{
				return _Instance;
			}
		}

		/// <summary>
		/// Loads the collection.
		/// </summary>
		/// <returns>
		/// The loaded from file scores.
		/// </returns>
		public override IEnumerable<INameValue<int>> LoadTyped()
		{
			return this.LoadFromFile();
		}

		/// <summary>
		/// Saves the given score.
		/// </summary>
		/// <param name="score">The score to save.</param>
		public override void Save(INameValue<int> score)
		{
			Validation.ThrowIfNull(score);

			if (this.Stats.Count < MAX_TOP_PLAYERS)
			{
				this.Stats.Add(score);
			}
			else
			{
				foreach (var personScore in this.Stats)
				{
					if (score.ValueObject <= personScore.ValueObject)
					{
						this.Stats.Remove(this.Stats[MAX_TOP_PLAYERS - 1]);
						this.Stats.Add(score);
						break;
					}
				}
			}

			this.Sort<int>(x => x.ValueObject);
			this.SaveInFile();
		}

		/// <summary>
		/// Saves the in file.
		/// </summary>
		private void SaveInFile()
		{
			using (Stream file = File.Open(FILE_PATH, FileMode.OpenOrCreate))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(file, this.Stats);
			}
		}

		/// <summary>
		/// Loads from file.
		/// </summary>
		/// <returns>
		/// from file.
		/// </returns>
		private IList<INameValue<int>> LoadFromFile()
		{
			Stream stream = null;
			IList<INameValue<int>> stats;

			if (File.Exists(FILE_PATH))
			{
				using (stream = File.Open(FILE_PATH, FileMode.Open))
				{
					BinaryFormatter formatter = new BinaryFormatter();
					stats = (IList<INameValue<int>>)formatter.Deserialize(stream);
				}
			}
			else
			{
				stats = new List<INameValue<int>>(MAX_TOP_PLAYERS);
			}

			return stats;
		}
	}
}
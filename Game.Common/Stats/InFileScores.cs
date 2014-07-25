using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Game.Common.Stats
{
	public sealed class InFileScores : StatsStorage<INameValue<int>>, IIntegerStats
	{
		private const int MAX_TOP_PLAYERS = 5;
		private const string FILE_PATH = @"../../GameFifteen.game15";
		private static readonly IIntegerStats _Instance = new InFileScores();

		private InFileScores()
			: base(MAX_TOP_PLAYERS)
		{
		}

		public static IIntegerStats Instance
		{
			get
			{
				return _Instance;
			}
		}

		public override void Save(INameValue<int> score)
		{
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

		private void SaveInFile()
		{
			using (Stream file = File.Open(FILE_PATH, FileMode.OpenOrCreate))
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(file, this.Stats);
			}
		}

		private INameValue<int> LoadFromFile()
		{
			Stream stream = null;
			INameValue<int> stats;
			try
			{
				using (stream = File.Open(FILE_PATH, FileMode.OpenOrCreate))
				{
					BinaryFormatter formatter = new BinaryFormatter();
					stats = (INameValue<int>)formatter.Deserialize(stream);
				}
			}
			catch (Exception)
			{
				if (stream != null)
				{
					stream.Close();
				}

				return null;
			}

			return stats;
		}
	}
}
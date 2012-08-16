using System;

namespace Microsoft.Xna.Framework.GamerServices
{
	public sealed class LeaderboardEntry
	{
		public PropertyDictionary Columns {
			get {
				return new PropertyDictionary ();
			}
		}
		public Gamer Gamer {
			get {
				throw new NotImplementedException();
			}
		}
		public long Rating { get; set; }

		//Part of XNA XDK Extensions
		public int GetRank ()
		{
			return 0;
		}
	}
}


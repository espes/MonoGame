using System;

namespace Microsoft.Xna.Framework.GamerServices
{
	public struct LeaderboardIdentity
	{
		public int GameMode { get; set; }
		public string Key { get; set; }

		public static LeaderboardIdentity Create (LeaderboardKey key)
		{
			return Create (key, 0);
		}

		public static LeaderboardIdentity Create (LeaderboardKey key, int gameMode)
		{
			return new LeaderboardIdentity {
				Key = key.ToString(),
				GameMode = gameMode
			};
		}
	}
}


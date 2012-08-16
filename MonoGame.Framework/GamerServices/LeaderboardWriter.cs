using System;

namespace Microsoft.Xna.Framework.GamerServices
{
	public sealed class LeaderboardWriter
	{
		internal LeaderboardWriter ()
		{
		}

		public LeaderboardEntry GetLeaderboard (LeaderboardIdentity leaderboardId)
		{
			return new LeaderboardEntry();
		}
	}
}


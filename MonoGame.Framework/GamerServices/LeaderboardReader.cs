using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.GamerServices
{
	public sealed class LeaderboardReader : IDisposable
	{
		internal LeaderboardReader ()
		{
		}

		public static LeaderboardReader Read (LeaderboardIdentity id,
		                                     IEnumerable<Gamer> gamers,
		                                     Gamer pivotGamer, int pageSize)
		{
			throw new NotImplementedException ();
		}

		public static LeaderboardReader Read (LeaderboardIdentity id,
		                                     Gamer pivotGamer, int pageSize)
		{
			throw new NotImplementedException ();
		}

		public static LeaderboardReader Read (LeaderboardIdentity id,
		                                      int pageStart, int pageSize)
		{
			throw new NotImplementedException ();
		}

		public void PageUp ()
		{
			throw new NotImplementedException ();
		}

		public void PageDown ()
		{
			throw new NotImplementedException ();
		}

		public ReadOnlyCollection<LeaderboardEntry> Entries {
			get {
				return new ReadOnlyCollection<LeaderboardEntry> (new LeaderboardEntry[0]);
			}
		}

		public int TotalLeaderboardSize {
			get {
				throw new NotImplementedException ();
			}
		}

		public int PageStart {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool CanPageUp {
			get {
				throw new NotImplementedException ();
			}
		}

		public bool CanPageDown {
			get {
				throw new NotImplementedException ();
			}
		}

		public void Dispose ()
		{
		}
	}
}


using System;

namespace Microsoft.Xna.Framework
{
	//Internal, but some apps use reflection to get at it -_-
	internal static class TitleLocation
	{
		public static string Path {
			get {
				return TitleContainer.GetFilename ("");
			}
		}
	}
}


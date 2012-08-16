using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework
{
	public class VisualizationData
	{
		public VisualizationData ()
		{
		}

		public ReadOnlyCollection<float> Frequencies {
			get {
				return new ReadOnlyCollection<float>(new float[0]);
			}
		}

		public ReadOnlyCollection<float> Samples {
			get {
				return new ReadOnlyCollection<float>(new float[0]);
			}
		}
	}
}


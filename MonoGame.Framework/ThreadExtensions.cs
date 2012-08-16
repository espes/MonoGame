namespace System.Threading
{
	public static class ThreadExtensions
	{
		//Method exists only on Xbox 360
		//Stub it for porting convenience
		public static void SetProcessorAffinity(this Thread thread, params int[] cpus)
		{
		}
	}
}


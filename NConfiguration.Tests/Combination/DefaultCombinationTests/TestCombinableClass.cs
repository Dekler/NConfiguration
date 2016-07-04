using NConfiguration.Combination;

namespace NConfiguration.Tests.Combination.DefaultCombinationTests
{
	public class TestCombinableClass : ICombinable
	{
		public string F1;
		public int F2;

		public void Combine(ICombiner combiner, object item)
		{
			var other = item as TestCombinableClass;

			if (other == null)
				return;

			F1 += other.F1;
			F2 += other.F2;
		}
	}
}


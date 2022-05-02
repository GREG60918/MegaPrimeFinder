using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MegaPrimeFinderTests
{
	/// <summary>
	/// Contains test methods for the <see cref="MegaPrimeFinder.MegaPrimeFinder"/> class
	/// </summary>
	[TestClass]
	public class MegaPrimeFinderTests
	{
		#region Tests

		[TestMethod]
		public void Input_Of_10_Should_Return_Correct_Megaprimes()
		{
			int input = 10;

			var megaprimes = MegaPrimeFinder.MegaPrimeFinder.GetMegaPrimes(input).ToArray();

			CollectionAssert.AreEqual(new[] { 2, 3, 5, 7 }, megaprimes);
		}

		[TestMethod]
		public void Input_Of_37_Should_Return_Correct_Megaprimes()
		{
			int input = 37;

			var megaprimes = MegaPrimeFinder.MegaPrimeFinder.GetMegaPrimes(input).ToArray();

			CollectionAssert.AreEqual(new[] { 2, 3, 5, 7, 23, 37 }, megaprimes);
		}

		[TestMethod]
		public void Input_Of_1_Should_Return_Empty_Array()
		{
			int input = 1;

			var megaprimes = MegaPrimeFinder.MegaPrimeFinder.GetMegaPrimes(input).ToArray();

			CollectionAssert.AreEqual(new int[] { }, megaprimes);
		}

		#endregion
	}
}
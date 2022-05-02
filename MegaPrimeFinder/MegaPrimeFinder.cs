namespace MegaPrimeFinder
{
	/// <summary>
	/// Contains methods for finding mega prime numbers
	/// </summary>
	public class MegaPrimeFinder
	{
		#region Methods

		/// <summary>
		/// Returns a sequence of mega prime numbers found between 1 and <paramref name="maximumNumber"/>
		/// </summary>
		/// <param name="maximumNumber">The maximum number</param>
		public static IEnumerable<int> GetMegaPrimes(int maximumNumber)
		{
			for (int i = 1; i <= maximumNumber; i++)
			{
				if (!AreAllDigitsMegaPrimeDigits(i, out int numberToAddToI))
				{
					i += numberToAddToI;

					continue;
				}

				if (IsPrime(i))
					yield return i;
			}
		}

		/// <summary>
		/// Gets a value indicating whether all digits in the given number are prime digits
		/// </summary>
		/// <param name="number">The candidate number</param>
		/// <param name="indexingIncrement">The indexing increment, to increase the indexer by so that the mega prime candiate no longer contains its higest order non megaprime digit</param>
		/// <returns>True if all digits are mega prime digits; false otherwise. The indexing increment to increase the indexer by</returns>
		private static bool AreAllDigitsMegaPrimeDigits(int number, out int indexingIncrement)
		{
			indexingIncrement = 0;

			// Convert the candidate number into an array of its digits
			var digits = number.ToString().Select(t => int.Parse(t.ToString())).ToArray();

			int numberOfDigits = digits.Count();

			for (int j = 0; j < numberOfDigits; j++)
			{
				// If a digit is not a megaprime digit
				if (!IsMegaPrimeDigit(digits[j]))
				{
					// Return a value to add to the indexer based on the magnitude of the non megaprime digit (for example, for the number 40 - we would return 10 to skip checking all other 40 values for megaprimes in the 40-50 range)
					indexingIncrement = (numberOfDigits - 1 - j) * 10;

					return false;
				}
			}

			return true;
		}

		// In practice, depending on the context of the below methods usage, may need to add handling to check for int values passed with multiple digits - I have ommitted this in these example

		/// <summary>
		/// Returns a value indicating whether the given int is a mega prime digit
		/// </summary>
		/// <param name="digit">The candidate digit</param>
		private static bool IsMegaPrimeDigit(int digit) => digit == 2 || digit == 3 || digit == 5 || digit == 7;

		// Used implementation of this method as found https://stackoverflow.com/questions/15743192/check-if-number-is-prime-number
		// From my reading there has been a lot of research into various methods of how to check for prime numbers efficiently.
		// Therefore instead of spending time trying to optimize these methods, I have focussed on the "megaprime" part of the question
		// Specifically, how to reduce the amount of calls made to this method in the first place

		/// <summary>
		/// Returns a value indicating whether <paramref name="number"/> is a prime number, using the trial by division method
		/// </summary>
		/// <param name="number">The number</param>
		/// <returns>True if the number is prime; false otherwise</returns>
		private static bool IsPrime(int number)
		{
			if (number <= 1)
				return false;

			if (number == 2)
				return true;

			// Prime cant be even
			if (number % 2 == 0)
				return false;

			var squareRoot = (int)Math.Floor(Math.Sqrt(number));

			for (int i = 3; i <= squareRoot; i += 2)
			{
				if (number % i == 0)
					return false;
			}

			return true;
		}

		#endregion
	}
}

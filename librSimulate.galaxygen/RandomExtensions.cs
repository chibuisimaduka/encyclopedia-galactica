using System;

namespace librSimulate.galaxygen
{
	/// <summary>
	/// R -andom utility
	/// </summary>
	public class R 
	{
		public Int32 Seed {
			get 
			{
				int n_seed = DateTime.Now.Second + 1;
				Random r = new Random(n_seed);
				return r.Next(1 * n_seed, 10 * n_seed);
			}
		}
	}
	/// <summary>
	/// Extensions for the Random Class 
	/// </summary>
	public static class RandomExtensions
	{
		#region [ Integers ]
		public static Int32 RandomInt(this R r,Int32 seed, Int32 Min, Int32 Max)
		{
			return (new Random(seed).Next(Min,Max));
		}

		public static Boolean Randombinary (this R r)
		{
			bool value = false;

			value = (DateTime.Now.Second <= 30);

			return value;
		}

		public static Int32[] RandomIntegral (this R r, Int32 seed, Int32 starting_amount, Int32 pieces)
		{
			Int32[] items = new Int32[pieces];

			int index = 0;
			int used_amount = 0;

			while (index <= (pieces -1)) 
			{
				items[index] = pieces;
				int n_amount = r.RandomInt(seed,1,(starting_amount - used_amount));
				used_amount = used_amount + n_amount;
				items[index] = items[index] + n_amount;
				index++;
			}

			return items;
		}

		public static bool Between (this R r, Int32 Value, Int32 Min, Int32 Max)
		{
			return Value <= Max && Value >= Min;
		}
		#endregion
	}
}


using System;
using librSimulate.galaxygen;

namespace encgal
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string output_path = @"B:\_sectors"; // change output path to argument
			Console.WriteLine ("If you wish to make an apple pie from scratch, you must first invent the universe.");

			try 
			{
				// Current arrangemnet is a "sector" genreation
				Int32 star_count_min = 100;
				Int32 star_count_max = 256;

				Int32 SectorID = 128; // For now arbitrary, but each sector will need a unique identifer, that is alos its seed

				SectorGenerator.GenerateSector(SectorID,output_path,star_count_min,star_count_max);

			} catch (Exception x) {
				Console.WriteLine("Error:{0}",x.Message);
			}



			Console.WriteLine("Complete.");
		}
	}
}

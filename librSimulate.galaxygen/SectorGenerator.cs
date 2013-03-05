using System;
using System.IO;

namespace librSimulate.galaxygen
{
	public class SectorGenerator
	{
		public static void GenerateSector (Int32 seed, String outputPath, Int32 StarMin, Int32 StarMax)
		{
			R r = new R ();
			var sector = new sectorData("0","0"); // Galaxy ID later
			Console.WriteLine("Creating Sector from seed: {0}",seed);

			Int32 star_sys_index = 0;
			Int32 star_sys_count = r.RandomInt (seed,StarMin, StarMax);

			Console.WriteLine("Star System Count : {0}",star_sys_count);

			#region [ Generation While Tree ]
			while (star_sys_index <= (star_sys_count -1)) 
			{
				var star_system = new starSystemData(star_sys_index.ToString(),"0");
				Int32 star_index = 0;
				Int32 star_count = r.RandomInt((seed + star_sys_index),1,4); // Option, max star grouping function?
				Console.WriteLine("[STEP][{0}][{1}] Star Count:{2}",DateTime.Now,star_sys_index,star_count);
			
				while(star_index <= (star_count -1))
				{
					Int32 planet_index = 0;
					Int32 planet_count = r.RandomInt((seed + star_index),0,64);// Option, max planet function?
					var star = new starData(star_index.ToString(),star_sys_index.ToString());
					Console.WriteLine("[STEP][{0}][{1}][{2}] Planet Count: {3}",DateTime.Now,star_sys_index,star_index,planet_count);

					while(planet_index <= (planet_count -1))
					{
						var planet = new planetData(planet_index.ToString(),star_index.ToString());
						Int32 moon_index = 0;
						Int32 moon_count = r.RandomInt((planet_index + seed),0,128); // Option, max moon  function?
						Console.WriteLine("[STEP][{0}][{1}][{2}][{3}] Moon Count: {4}",DateTime.Now,star_sys_index,star_index,planet_index,moon_count);

						while(moon_index <= (moon_count - 1))
						{
							var moon = new moonData(moon_index.ToString(),planet_index.ToString());
							Console.WriteLine("[STEP][{0}][{1}][{2}][{3}][{4}]",DateTime.Now,star_sys_index,star_index,planet_index,moon_index);

							/// Add moon to Planet
							planet.Moons.Add(moon);
							moon_index = moon_index + 1;
						}

						/// Add Planet to Star
						star.Planets.Add(planet);
						planet_index = planet_index + 1;
					}

					/// Add Star to Star System
					star_system.Stars.Add(star);
					star_index = star_index + 1;
				}

				// Add Star System to Sector
				sector.StarSystems.Add(star_system);
				star_sys_index = star_sys_index + 1;
			}
			#endregion

			sector.WriteData(outputPath);
		}
	}
}


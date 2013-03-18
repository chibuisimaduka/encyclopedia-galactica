using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librSimulate
{
    public class GalaxyGeneratorOptions 
    {
        public Int32 GalaxySeed { get; set; }
        public String OutputPath { get; set; }

        public GalaxyGeneratorOptions()
        {
        }
    }

    public class GalaxyGenerator
    {
        public static void GenerateGalaxy(GalaxyGeneratorOptions options)
        {
            R galaxy_r = new R(options.GalaxySeed);

            Int32 star_sector_index = 0;
            Int32 star_sector_count = galaxy_r.Rand(0, 128,256);

            while (star_sector_index <= (star_sector_count - 1))
            {
                Int32 star_system_index = 0;
                Int32 star_system_count = galaxy_r.Rand(star_sector_index, 12, 128);

                while (star_system_index <= (star_system_count - 1))
                {
                    Int32 star_index = 0;
                    Int32 star_count = galaxy_r.Rand(star_system_index,

                    star_system_index = star_system_index + 1;
                }

                star_sector_index = star_sector_index + 1;
            }


        }
    }
}

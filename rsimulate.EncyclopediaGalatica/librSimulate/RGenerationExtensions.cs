using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librSimulate
{
    /// <summary>
    /// Random GenerationExtensions
    /// </summary>
    public class R
    {
        #region [ Properties ]
        public Int32 InstanceSeed { get; set; }
        #endregion

        #region [ Constructors ]
        public R(Int32 seed)
        {
            this.InstanceSeed = seed;
        }
        #endregion

    } 

    public static class RGenerationExtensions
    {
        public static Int32 Rand(this R r,Int32 context_id, Int32 min, Int32 max)
        {
            Int32 context_seed = Int32.Parse(String.Format("{0}{1}", r.InstanceSeed, context_id + 1));
            Random rand = new Random(context_seed);

            return rand.Next(min, max);
        }
    }
}

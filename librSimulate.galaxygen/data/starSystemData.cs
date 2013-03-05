using System;
using System.Collections.Generic;

namespace librSimulate.galaxygen
{
	public class starSystemData : spaceData
	{
		public List<starData> Stars { get; set; }

		#region [ Constructor ]
		public starSystemData (string ObjectID, string ownerID) : base("starsystem",ObjectID,ownerID)
		{
			this.Stars = new List<starData>();
		}
		#endregion
	}
}


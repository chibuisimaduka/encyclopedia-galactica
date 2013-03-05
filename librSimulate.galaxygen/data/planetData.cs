using System;
using System.Collections.Generic;

namespace librSimulate.galaxygen
{
	public class planetData : spaceData
	{
		public List<moonData> Moons { get; set; }

		public planetData (string ObjectID, string OwnerID) : base("planet",ObjectID,OwnerID)
		{
			this.Moons = new List<moonData>();
		}
	}
}


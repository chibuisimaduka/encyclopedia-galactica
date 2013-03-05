using System;
using System.Collections.Generic;

namespace librSimulate.galaxygen
{
	public class starData : spaceData
	{
		#region [ Properties ] 
		public List<planetData> Planets { get; set; }
		#endregion

		#region [ Constructors ]
		public starData (string objectId, string ownerID) : base("star",objectId,ownerID)
		{
			this.Planets = new List<planetData>();
		}
		#endregion
	
	}
}


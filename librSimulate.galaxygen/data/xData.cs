using System;
using System.Collections.Generic;

namespace librSimulate.galaxygen
{
	public class xData
	{
		public String Domain { get; set; } 
		public String TypeName { get; set; }
		public String ObjectID { get; set; }
		public String OwnerID { get; set; }
		public Dictionary<String,String> Attributes { get; set; }

		#region [ Constructors ]
		public xData (String domain, String typeName, String objectID, String ownerID)
		{
			this.Domain = domain;
			this.TypeName = typeName;
			this.ObjectID = objectID;
			this.OwnerID = ownerID;
			this.Attributes = new Dictionary<string, string>();
		}

		public void Save()
		{

		}
		#endregion
	}
}


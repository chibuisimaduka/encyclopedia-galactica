using System;

namespace librSimulate.galaxygen
{
	/// <summary>
	/// Base object for all Objects in space
	/// </summary>
	public class spaceData : xData
	{
		#region [ Properties ]
		public float SemiMajorAxis  { get; set; }
		public float Eccentricity  { get; set; }
		public float AngularVelocity  { get; set; }
		public float Inclination  { get; set; }
		public float NonLocalPositionX  { get; set; }
		public float NonLocalPositionY  { get; set; }
		public float NonLocalPositionZ  { get; set; }
		public bool IsUpdateble  { get; set; }
		public float HasOrbit  { get; set; }
		#endregion


		public spaceData (string typeName, string objectID, string ownerID) : base("space",typeName,objectID,ownerID)
		{

		}
	}
}


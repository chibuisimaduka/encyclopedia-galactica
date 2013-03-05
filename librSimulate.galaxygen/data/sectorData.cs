using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace librSimulate.galaxygen
{
	public class sectorData : spaceData
	{
		public List<starSystemData> StarSystems { get; set; }

		public sectorData (string objectId, string ownerID) :base("sector",objectId,ownerID)
		{
			this.StarSystems = new List<starSystemData>();
		}

		public void WriteData (string rootPath)
		{
			string file_name = String.Format ("{0}\\sector.{1}.json", rootPath, this.ObjectID);
			string data = "";

			try 
			{
				data = JsonConvert.SerializeObject (this);
				File.WriteAllText(file_name,data);
			} 
			catch (JsonException jError) 
			{
				File.WriteAllText(String.Format ("{0}\\sector.{1}.error", rootPath, this.ObjectID),jError.Message);
			} 
			catch (IOException ioError) 
			{
				throw ioError;
			}
		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace librSimulate.Structures
{
    public class spaceData
    {
        #region [ Attributes ]
        public Int64 ObjectID { get; set; }
        public Int64 ParentID { get; set; }
        public String TypeID { get; set; }
        public String Name { get; set; }
        public float LocalX { get; set; }
        public float LocalY { get; set; }
        public float LocalZ { get; set; }
        public float InfluenceRadius { get; set; }

        public Dictionary<String, String> DataAttributes { get; set; }
        public Dictionary<String,XElement> InfoAttributes { get; set; }
        #endregion

        public spaceData()
        {
            this.DataAttributes = new Dictionary<string,string>();
            this.InfoAttributes = new Dictionary<string,XElement>();
            
        }

           
    }
}t

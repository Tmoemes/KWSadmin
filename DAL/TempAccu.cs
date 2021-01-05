using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace KWSAdmin.Persistence
{
    public class TempAccu
    {

        public int id { get; set; }

        public string name { get; set; }

        public int creatorid { get; set; }


        public string specs { get; set; }


        public TempAccu(int id,string name ,int creatorid,string specs)
        {
            this.id = id;
            this.name = name;
            this.creatorid = creatorid;
            this.specs = specs;
        }

    }
}

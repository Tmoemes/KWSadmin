using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace KWSAdmin.Persistence
{
    public class TempOrder
    {

        public int id { get; set; }

        public int locationid { get; set; }

        public int clientid { get; set; }

        public int creatorid { get; set; }

        public int accuid { get; set; }

        public string info { get; set; }



        public TempOrder(int id,int locationid,int clientid,int creatorid,int accuid,string info)
        {
            this.id = id;
            this.locationid = locationid;
            this.clientid = clientid;
            this.creatorid = creatorid;
            this.accuid = accuid;
            this.info = info;
        }

    }
}

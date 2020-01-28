using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Resources;

namespace WISLEY.BLL.Resources
{
    public class grpResource
    {
        public string fileName { get; set; }
        public string resourceType { get; set; }
        public int grpId { get; set; }
        public int customOrder { get; set; }
        public DateTime dateUploaded { get; set; }
        public int id { get; set; }

    

        public grpResource()
        {

        }

        public grpResource(string fileName, string resourceType, int grpId)
        {
            this.fileName = fileName;
            this.resourceType = resourceType;
            this.grpId = grpId;

            this.customOrder = getLatestOrder(grpId, resourceType) + 1;
            dateUploaded = DateTime.Now;
            id = -1;
        }

        public grpResource(string fileName, string resourceType, int grpId, DateTime dateUploaded, int customOrder, int id)
        {
            this.fileName = fileName;
            this.resourceType = resourceType;
            this.grpId = grpId;

            this.dateUploaded = dateUploaded;
            this.customOrder = customOrder;
            this.id = id;
        }

        public int insertResource()
        {
            grpResourceDAO grpResDAO = new grpResourceDAO();
            return grpResDAO.Insert(this);
        }

        public int getLatestOrder(int grpId, string resourceType)
        {
            grpResourceDAO grpResDAO = new grpResourceDAO();
            return grpResDAO.getLatestOrder(grpId, resourceType);
        }


    }
}
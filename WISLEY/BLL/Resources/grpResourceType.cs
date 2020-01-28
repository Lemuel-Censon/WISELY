using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WISLEY.DAL.Resources;

namespace WISLEY.BLL.Resources
{
    public class grpResourceType
    {
        public string resourceType { get; set; }
        public int grpId { get; set; }
        public int customOrder { get; set; }
        public DateTime dateCreated { get; set; }
        public int visibility { get; set; }
        public int id { get; set; }
        //public List<string> fileNames { get; set; }

        public grpResourceType()
        {

        }

        public grpResourceType(string resourceType, int grpId)
        {
            this.resourceType = resourceType;
            this.grpId = grpId;
            this.dateCreated = DateTime.Now;
            visibility = 1;
        }

        public grpResourceType(string resourceType, int grpId, int customOrder, DateTime dateCreated, int visibility, int id)
        {
            this.resourceType = resourceType;
            this.grpId = grpId;
            this.customOrder = customOrder;
            this.dateCreated = dateCreated;
            this.visibility = visibility;
            this.id = id;
        }

        public int insertResourceType()
        {
            grpResourceTypeDAO grpResDAO = new grpResourceTypeDAO();
            return grpResDAO.Insert(this);
        }

        public int getLatestOrder(int grpId, string resourceType)
        {
            grpResourceTypeDAO grpResDAO = new grpResourceTypeDAO();
            return grpResDAO.getLatestOrder(grpId, resourceType);
        }

    }
}
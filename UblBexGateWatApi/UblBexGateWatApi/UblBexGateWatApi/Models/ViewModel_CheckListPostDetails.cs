﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UblBexGateWatApi.Models
{
    public class ViewModel_CheckListPostDetails
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string BranchId { get; set; }
        public List<PostAllCheckList> PostCheckList { get; set; }

    }
    public class PostAllCheckList
    {
        public string PostId { get; set; }
        public string ExtraRecipent { get; set; }
        public string PostedDate { get; set; }
        public int UserId { get; set; }
        public int CheckListId { get; set; }

        public List<PostAllActiveAttribute> PostAttributes { get; set; }
    }
    public class PostAllActiveAttribute
    {
        public int AttrId { get; set; }

        public List<PostSubAttributes> PostSubAttributes { get; set; }
    }



    public class PostSubAttributes
    {
        public int SubAttrId { get; set; }
        public int MarkingCriteriaId { get; set; }
        public string comments { get; set; }
        public string Rating { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UblBexGateWatApi.Models
{
    public class ViewModel_CheckListPostDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string BranchCode { get; set; }
        public List<PostAllCheckList> PostCheckList { get; set; }

    }
    public class PostAllCheckList
    {
        public string PostId { get; set; }
        public string ExtraRecipent { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime StartedDate { get; set; }
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

    public class ViewModel_PostRatingBOM
    {
        public List<PostRatingBOM> PostRatingBOM { get; set; }
    }

    public class PostRatingBOM
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string brCode { get; set; }

        public string comment { get; set; }
        public string postId { get; set; }
    }
    public class ViewModel_PostRatingSQM
    {
        public List<PostRatingSQM> PostRatingSQM { get; set; }
    }

    public class PostRatingSQM
    {
        public int Id { get; set; }
        public string postId { get; set; }
        public bool isResolved { get; set; }
        public string comment { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UblBexGateWatApi.Models
{
    public class ViewModel_CheckList
    {
        
    }

    public class GetDetalById
    {
        public int UserId { get; set; }
        public string Token { get; set; }
    }
    public class GetUserCheckListDetails
    {
        public int UserId { get; set; }
        public string Token { get; set; }
    }
    public class GetUserCheckProfileDetails
    {
        public int UserId { get; set; }
        public string Token { get; set; }
    }
}
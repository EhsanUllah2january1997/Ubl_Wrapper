using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UblBexGateWatApi.Models
{
    public class ViewModel_CheckList
    {

    }

    public class ViewMmodel_GetLastScore
    {
        public int UserId { get; set; }
        public string BrCode { get; set; }
        public string Token { get; set; }
    }
    public class GetDetalById
    {
        public int UserId { get; set; }
        public string Token { get; set; }
    }

    public class GeToken
    {
        public string Token { get; set; }
    }
    public class GetScheduleBranchListData
    {
        public int UserId { get; set; }
        public bool IsUpcoming { get; set; }
        public string Token { get; set; }
    }

    public class GetDetalByIdDate
    {
        public int? UserId { get; set; }
        public string Token { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
    }
    public class GetUserDetalByEmail
    {
        public string Emails { get; set; }
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
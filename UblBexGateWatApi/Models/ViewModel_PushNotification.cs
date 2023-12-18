using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UblBexGateWatApi.Models
{
    public class ViewModel_PushNotification
    {
        public string Msg { get; set; }
        public List<string> DeviceId { get; set; }
    }
}
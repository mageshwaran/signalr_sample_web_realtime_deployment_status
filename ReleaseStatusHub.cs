using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace ProdRelease
{
    public class ReleaseStatusHub : Hub
    {
        public static Dictionary<string, string> TeamMembers = new Dictionary<string, string>(){
            { "kajal", "" },
            { "kadharbhi", "" },
            { "kadharbhishaik", "" }
        };


        public void Send(string teamMemberName, string deploymentStatus)
        {
            TeamMembers[teamMemberName] = deploymentStatus;
            var data = JsonConvert.SerializeObject(
                TeamMembers.Select(y => new Dictionary<string, string>
                {
                    { $"{y.Key}", y.Value }
                }).ToList());

            Clients.All.showLiveResult(data);
        }
    }
}
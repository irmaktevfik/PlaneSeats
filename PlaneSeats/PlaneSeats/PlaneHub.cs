using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PlaneSeats
{
    public class PlaneHub : Hub
    {
        //just added to create dummy user Id :)
        static int userId;

        private static List<Models.PlaneSeatsArrangement> allSeats = new List<Models.PlaneSeatsArrangement>();

        public void CreateUser()
        {
            userId++;
            Clients.All.createUser(userId);
        }

        public void PopulateSeatData()
        {
            var returnData = Newtonsoft.Json.JsonConvert.SerializeObject(allSeats);
            Clients.All.populateSeatData(returnData);
        }

        public void SelectSeat(int userId, int seatNumber)
        {
            //create document model
            var planeSeatsArrangement = new Models.PlaneSeatsArrangement() { SeatNumber = seatNumber, UserId = userId };
            allSeats.Add(planeSeatsArrangement);
            var returnData = Newtonsoft.Json.JsonConvert.SerializeObject(planeSeatsArrangement);
            Clients.All.selectSeat(returnData);
        }
    }
}
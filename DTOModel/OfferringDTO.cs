using System;
using System.Collections.Generic;
using CarPoolAPI.Enums;
using CarPoolAPI.Models;

namespace CarPoolAPI.PostModel {
    public class OfferringDTO {
        public int Id { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsRideStarted { get; set; }
        public Discount Discount { get; set; }
        public LocationDTO Source { get; set; }
        public LocationDTO Destination { get; set; }
        public float TotalEarning { get; set; }
        public int SeatsAvailable { get; set; }
        public int SeatsOffered { get; set; }

        public LocationDTO CurrentLocation { get; set; }
        public float PricePerKM { get; set; }
        public int VehicleRef { get; set; }
        public int MaxOfferSeats { get; set; }
        public VehicleDTO Vehicle { get; set; }
        public List<LocationDTO> ViaPoints { get; set; }
        public Location Location { get; set; }
    }
}
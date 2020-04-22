using System.Collections.Generic;
using AutoMapper.Mappers;
using CarPoolAPI.Models;
using CarPoolAPI.PostModel;
using System.Linq;

namespace CarPoolAPI.Profiles {
    public class CarPoolProfile : AutoMapper.Profile {
        public CarPoolProfile () {
            CreateMap<User, UserDTO> ().ForMember (desc => desc.Password, opt => opt.Ignore ());
            CreateMap<Booking, BookingDTO> ();
            CreateMap<Location, LocationDTO> ();
            CreateMap<Vechicles, VehicleDTO> ();
            CreateMap<Offerring, OfferringDTO>().ForMember(desc => desc.ViaPoints,opt => opt.MapFrom(src => src.ViaPoints.Select(e=>e.Location)));
        }
    }
}
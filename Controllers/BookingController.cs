using System;
using System.Collections.Generic;
using AutoMapper;
using CarPoolAPI.Enums;
using CarPoolAPI.Models;
using CarPoolAPI.PostModel;
using CarPoolAPI.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarPoolAPI.Controllers {
    public class BookingController : ControllerBase {
        readonly IBookingRepository _repos;
        readonly IMapper _mapper;

        public BookingController (IBookingRepository repos, IMapper mapper) { _repos = repos; _mapper = mapper; }

        [HttpGet]
        public BookingStatus ViewStatus ([FromQuery] int bookingId) {
            return _repos.GetStatusById (bookingId);
        }
        public List<BookingDTO> GetByUserId ([FromQuery] int userId) {
            List<Booking> bookings = _repos.GetByUserId (userId);
            List<BookingDTO> resultBookings = _mapper.Map<List<Booking>, List<BookingDTO>> (bookings);
            return resultBookings;
        }

        [HttpGet]
        public List<BookingDTO> GetAllByOfferId ([FromQuery] int offerId) {
            List<Booking> Bookings = _repos.GetByOfferId (offerId);
            List<BookingDTO> BookingDTOs = _mapper.Map<List<Booking>, List<BookingDTO>> (Bookings);
            return BookingDTOs;
        }
        public List<BookingDTO> GetAllOfferedRides ([FromQuery] int userId) {
            List<Booking> Bookings = _repos.GetAllOfferRideByUserId (userId);
            List<BookingDTO> BookingDTOs = _mapper.Map<List<Booking>, List<BookingDTO>> (Bookings);
            return BookingDTOs;
        }

        [HttpPost]
        public BookingDTO Create ([FromBody] BookingDTO booking) {
            Booking Booking = _repos.Create (booking);
            BookingDTO BookingDTO = _mapper.Map<Booking, BookingDTO> (Booking);
            return BookingDTO;
        }

        [HttpGet]
        public BookingDTO GetById ([FromQuery] int id) {
            Booking Booking = _repos.GetById (id);
            BookingDTO BookingDTO = _mapper.Map<Booking, BookingDTO> (Booking);
            return BookingDTO;
        }

        [HttpPut]
        public BookingDTO AcceptBooking ([FromBody] BookingDTO booking) {
            Booking Booking = _repos.AcceptBooking (booking);
            BookingDTO BookingDTO = _mapper.Map<Booking, BookingDTO> (Booking);
            return BookingDTO;
        }

        [HttpPut]
        public bool UpdateBookingStatus ([FromBody] String data){
            dynamic json = JObject.Parse (data);
            int bookingStatus = json.BookingStatus;
            int bookingId = json.BookingId;
            return _repos.UpdateStatus (bookingId, (BookingStatus) bookingStatus);
        }

        [HttpGet]
        public bool IsUnderBooking (int userId) {
            return _repos.IsUnderBooking (userId);
        }

        [HttpGet]
        public List<BookingDTO> GetAll () {
            List<Booking> Bookings = _repos.GetAll ();
            List<BookingDTO> BookingDTOs = _mapper.Map<List<Booking>, List<BookingDTO>> (Bookings);
            return BookingDTOs;
        }

        [HttpPut]
        public BookingDTO Update (int Id, Location Source, Location Destination, float Distance, int OfferId) {
            Booking Booking =  _repos.Update (Id, Source, Destination, Distance, OfferId);
            BookingDTO BookingDTO = _mapper.Map<Booking, BookingDTO> (Booking);
            return BookingDTO;
        }
    }
}
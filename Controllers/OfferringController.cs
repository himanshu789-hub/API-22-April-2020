using System;
using System.Collections.Generic;
using AutoMapper;
using CarPoolAPI.Models;
using CarPoolAPI.PostModel;
using CarPoolAPI.RepositoryInterfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CarPoolAPI.Controllers {
    [EnableCors ("AllowMyOrigin")]
    public class OfferringController : ControllerBase {
        readonly IOfferringRepository _repos;
        readonly IMapper _mapper;
        public OfferringController (IOfferringRepository repos,IMapper mapper) {
            _repos = repos;
            _mapper = mapper;
        }

        [HttpPost]
        //POST
        public OfferringDTO Create([FromBody] OfferringDTO offerring) {
            Offerring Offer =  _repos.Create (offerring);
            OfferringDTO OfferDTO = _mapper.Map<Offerring,OfferringDTO>(Offer);
            return OfferDTO;
        }
        public bool Update ([FromBody] OfferringDTO offerring) {
            return _repos.Update (offerring);
        }

        [HttpGet]
        public List<OfferringDTO> GetByEndPoints ([FromQuery] string form) {
            dynamic json = JObject.Parse (form);
            JObject SourceJson = json.Source;
            JObject DestinationJson = json.Destination;
            LocationDTO Source = SourceJson.ToObject<LocationDTO> ();
            LocationDTO Destination = DestinationJson.ToObject<LocationDTO> ();
            int SeatsRequired = json.SeatsRequired;
            List<Offerring> Offers =  _repos.GetByEndPoints (Source, Destination, SeatsRequired);
            List<OfferringDTO> OffersDTOs = _mapper.Map<List<Offerring>,List<OfferringDTO>>(Offers);
            return OffersDTOs;
        }
        [HttpGet]
        public bool IsOfferredRide(int userId){
          return  _repos.IsUnderOfferring(userId);
        }
        //DONE
        [HttpGet]
        public OfferringDTO GetById ([FromQuery] int id) {
            Offerring Offer =  _repos.GetById (id);
            OfferringDTO OfferDTO = _mapper.Map<Offerring,OfferringDTO>(Offer);
            return OfferDTO; 
        }

        [HttpGet]
        public List<OfferringDTO> GetByUserId ([FromQuery] int userId) {
            List<Offerring> Offers =  _repos.GetByUserId (userId);
            List<OfferringDTO> OfferDTOs = _mapper.Map<List<Offerring>,List<OfferringDTO>>(Offers);
            return OfferDTOs;
        }

        [HttpDelete]
        public bool Delete ([FromBody] String data) {
            dynamic json = JObject.Parse(data);
            int offerId = json.OfferId;
            return _repos.Delete (offerId);
        }

        [HttpPut]
        public string HandleNextLocation ([FromBody] String data) {
            dynamic json = JObject.Parse (data);
            int OfferId = json.OfferId;
            return _repos.HandleNextLocation (OfferId);
        }
        
        [HttpPut]
        public bool UpdateLocation ([FromBody] String data) {
            dynamic json = JObject.Parse (data);
            int OfferId = json.OfferId;
            string NextLocation = json.ReachedLocation;
            return _repos.UpdateLocation (OfferId, NextLocation);
        }

        [HttpPut]
        public bool StartRide ([FromBody] String data) {
            dynamic json = JObject.Parse (data);
            int offerId = json.OfferId;
            return _repos.StartRide (offerId);
        }
    }
}
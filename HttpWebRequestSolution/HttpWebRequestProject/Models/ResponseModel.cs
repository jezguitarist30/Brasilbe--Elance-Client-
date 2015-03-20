using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace HttpWebRequestProject.Models
{
    public class ResponseModel
    {        
        public int id { get; set; }        
        public string afid { get; set; }        
        public string subafid { get; set; }
        [Display(Name = "first-name")]
        [JsonProperty("first-name")]
        public string FirstName { get; set; }
        [Display(Name = "last-name")]
        [JsonProperty("last-name")]
        public string LastName { get; set; }
        public string country { get; set; }
        [Display(Name = "birth-date")]
        [JsonProperty("birth-date")]
        public DateTime BirthDate { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        [Display(Name = "family-coregistration")]
        [JsonProperty("family-coregistration")]
        public bool FamilyCoregistration { get; set; }
        [Display(Name = "give-registration-bonus")]
        [JsonProperty("give-registration-bonus")]
        public bool GiveRegistrationBonus { get; set; }               
    }
}
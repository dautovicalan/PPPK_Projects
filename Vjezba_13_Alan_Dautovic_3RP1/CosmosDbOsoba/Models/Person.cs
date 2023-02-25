using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CosmosDbOsoba.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [Required]
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }
        [Required]
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }
        [Required]
        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }
        [Required]
        [JsonProperty(PropertyName = "birthday")]
        public DateTime Birthday { get; set; }
    }
}
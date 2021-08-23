
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace rest.Model
{
    public class Tournament
    {
        [BsonId]
        public string Id { get; set; }
       [Required(ErrorMessage = "Tournament name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Place name is required")]
        public string Place { get; set; }
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "No of Rounds is Required is required")]
        public int Rounds { get; set; }
        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }
        [Required(ErrorMessage = "URL is required")]
        public string URL { get; set; }


    }
}
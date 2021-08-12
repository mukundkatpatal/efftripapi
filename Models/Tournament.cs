using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

 

using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models

{

    public class Tournament
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        

        public ObjectId Id { get; set; }


        public int TournamentId { get; set; }

        [Required(ErrorMessage = "Tournament name is required")]
        //[MinLength(3)]
        //[MaxLength(200)]

        public string TournamentName { get; set; }
        [Required(ErrorMessage = "Place is required")]
        //[MinLength(3)]
        //[MaxLength(200)]

        public string Place { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]


        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]


        public DateTime EndDate { get; set; }

        [Required(ErrorMessage ="No Of Rounds Required")]
        //[Range(1, 20)]

        public int Rounds { get; set; }
        [Required(ErrorMessage = "Category is required")]
        //[MinLength(3)]
        //[MaxLength(30)]

        public string Category { get; set; }
        [Required(ErrorMessage ="URL is Required")]
        [Url]

        public string Website { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Flowers.Models
{
    public class FlowersModel
    {
        
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        public String Flowering { get; set; }
        public String Colour { get; set; }
        public int Size { get; set; }

        public FlowersModel()
        {
            Id = 1;
            Name = "Rose";
            Flowering = "June";
            Colour = "Red";
            Size = 30;
        }

        public FlowersModel(int id, string name, string flowering, string colour, int size)
        {
            Id = id;
            Name = name;
            Flowering = flowering;
            Colour = colour;
            Size = size;
        }
    }
}
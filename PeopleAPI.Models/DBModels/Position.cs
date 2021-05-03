using PeopleAPI.Models.Interfaces;
using System;

namespace PeopleAPI.Models.DBModels
{
    public class Position : IEntity<Guid>
    {
        public Guid Id { get ; set ; }
        public bool IsOficer { get; set; }
        public bool IsDeleted { get ; set ; }
        public string name { get; set; }
        public string VYC { get; set; }
        public float koeff { get; set; }
    }
}

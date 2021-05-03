using PeopleAPI.Models.Interfaces;
using System;

namespace PeopleAPI.Models.DBModels
{
    public class Unit : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string name { get; set; }
        public int importance { get; set; }
        public bool IsOficer { get; set; }
    }
}

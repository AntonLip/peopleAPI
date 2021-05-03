using PeopleAPI.Models.Interfaces;
using System;

namespace PeopleAPI.Models.DBModels
{
    public class MilitaryRank :  IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsOficers { get; set; }
        public bool IsDeleted { get ; set ; }
    }
}

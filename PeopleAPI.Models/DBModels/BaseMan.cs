using PeopleAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleAPI.Models.DBModels
{
   public abstract class BaseMan : IEntity<Guid>
    {
        public Guid Id { get ; set ; }
        public bool IsDeleted { get ; set ; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PathPhotoSmall { get; set; }
        public bool IsMarried { get; set; }
        public DateTime DateOfStartService { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email{ get; set; }
        public Guid Unit { get; set; }
        public Guid Position { get; set; }
    }
}

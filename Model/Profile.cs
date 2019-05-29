using System;
using Model.Attributes;

namespace Model
{
    public class Profile
    {
        [PrimaryKey]
        public Guid ProfileId { get; set; }
        public string DisplayName { get; set; }
        public string LoginId { get; set; }
        public string Pwd { get; set; }
        public bool Active { get; set; }
    }
}

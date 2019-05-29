using System;
using Model.Attributes;

namespace Model
{
    public class AppAdministrator
    {
        [PrimaryKey]
        public Guid AdminId { get; set; }
        public string DisplayName { get; set; }
        public string LoginId { get; set; }
        public string Pwd { get; set; }
    }
}
using System;
using Model.Attributes;

namespace Model
{
    public class Category
    {
        [PrimaryKey]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryType { get; set; }
        public decimal Budget { get; set; }
        public Guid ProfileId { get; set; }
    }
}

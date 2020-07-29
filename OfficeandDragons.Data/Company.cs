using System.Collections.Generic;

namespace OfficeandDragons.Data
{
    public class Company
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] Reports { get; set; }
   
    }
}
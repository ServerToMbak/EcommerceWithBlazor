using System.ComponentModel.DataAnnotations;

namespace Server.Dto
{
    public class ProductReadDto
    {

        public string Name { get; set; }

        public int Price { get; set; }
        public string CategoryName { get; set; }
    }
}

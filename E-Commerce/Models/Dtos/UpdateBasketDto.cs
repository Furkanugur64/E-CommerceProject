namespace E_Commerce.Models.Dtos
{
    public class UpdateBasketDto
    {        
            public int basketid { get; set; }
            public int count { get; set; }
            public string Operation { get; set; }
    }
}

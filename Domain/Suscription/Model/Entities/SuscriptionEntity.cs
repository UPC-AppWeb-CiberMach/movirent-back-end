
using Domain.Suscription.Model.Commands;
using Domain.Suscription.Model.Commands;

namespace Domain.Suscription.Model.Entities;
public partial class SuscriptionEntity 
{
    public int Id { get; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Image { get; set; }
    public double PricePerHour { get; set; }
    public string District { get; set; }
    public string Phone { get; set; }
    
}

public partial class SuscriptionEntity
{
    public SuscriptionEntity(CreateSuscriptionCommand command)
    {
        Name = command.Name;
        Brand = command.Brand;
        Model = command.Model;
        Image = command.Image;
        PricePerHour = command.PricePerHour;
        District = command.District;
        Phone = command.Phone;
    }

    public SuscriptionEntity()
    {
        Name = string.Empty;
        Brand = string.Empty;
        Model = string.Empty;
        Image = string.Empty;
        PricePerHour = 0;
        District = string.Empty;
        Phone = string.Empty;
    }
}





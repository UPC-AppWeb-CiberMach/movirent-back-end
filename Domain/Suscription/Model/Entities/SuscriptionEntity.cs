using Domain.Suscription.Model.Commands;

namespace Domain.Suscription.Model.Entities;

public partial class SuscriptionEntity
{
    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stars { get; set; }
    public double Price { get; set; }

}

public partial class SuscriptionEntity
{
    public SuscriptionEntity(CreateSuscriptionCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Stars = command.Stars;
        Price = command.Price;
        
    }

    public SuscriptionEntity()
    {
        Name = string.Empty;
        Description = string.Empty;
        Stars = 0;
        Price = 0;
    }
}





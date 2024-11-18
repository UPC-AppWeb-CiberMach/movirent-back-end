using Domain.ReviewManagement.Model.Commands;

namespace Domain.ReviewManagement.Model.Entities;
public partial class ReviewEntity 
{
    public int Id { get; }

    private string _comment;
    public string Comment
    {
        get => _comment;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 200)
            {
                throw new ArgumentException("El comentario no puede estar vacío y debe tener menos de 200 caracteres.");
            }
            _comment = value;
        }
    }

    private int _starNumb;
    public int StarNumb
    {
        get => _starNumb;
        set
        {
            if (value < 1 || value > 5)
            {
                throw new ArgumentException("La cantidad de estrellas debe estar entre 1 y 5.");
            }
            _starNumb = value;
        }
    }
}

public partial class ReviewEntity
{
    public ReviewEntity(CreateReviewCommand command)
    {
        Comment = command.Comment;
        StarNumb = command.StarNumb;
    }

    public ReviewEntity()
    {
        Comment = string.Empty;
        StarNumb = 1; // Valor mínimo válido por defecto
    }
}

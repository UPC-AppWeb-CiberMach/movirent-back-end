namespace Domain.ReviewManagement.Model.Commands;

public record CreateReviewCommand
{
    public string Comment { get; }
    public int StarNumb { get; }

    public CreateReviewCommand(string comment, int starNumb)
    {
        // Validación para Comment
        if (string.IsNullOrWhiteSpace(comment) || comment.Length > 200)
        {
            throw new ArgumentException("El comentario no puede estar vacío y debe tener menos de 200 caracteres.");
        }
        Comment = comment;

        // Validación para StarNumb
        if (starNumb < 1 || starNumb > 5)
        {
            throw new ArgumentException("La cantidad de estrellas debe estar entre 1 y 5.");
        }
        StarNumb = starNumb;
    }
}
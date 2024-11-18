
using Domain.Review.Model.Commands;

namespace Domain.Review.Model.Entities;
public partial class ReviewEntity 
{
    public int Id { get; }
    public string Comment { get; set; }
    public int StarNumb { get; set; }
    
    
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
        StarNumb = 0;
    }
}




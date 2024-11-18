namespace Presentation.IAM.Resources;

public record UpdateUserResource(string email, string password, string completeName, string phone, string dni, string photo, string address);

/*
 * public partial class UserProfile
    {
    public int id { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string completeName { get; set; }
    public string phone { get; set; }
    public string dni { get; set; }
    public string photo { get; set; }
    public string address { get; set; }
 */
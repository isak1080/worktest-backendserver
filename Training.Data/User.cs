namespace Training.Data;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;
    
    /// <summary>
    /// Users in the "Athlete" role should have a reference to the Athlete. Coaches should not have this.
    /// </summary>
    public int? AthleteId { get; set; }
    public virtual Athlete? Athlete { get; set; }
    
}
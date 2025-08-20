namespace Training.Data;

/// <summary>
/// An athlete who can be assigned planned sessions and log their performance.
/// </summary>
public class Athlete
{
    /// <summary>
    /// Unique identifier of the athlete.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The athlete's full name.
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// The athlete's email address. This value is unique.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The athlete's date of birth.
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Timestamp (UTC) when the athlete record was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Sessions planned for this athlete.
    /// </summary>
    public ICollection<PlannedSession> PlannedSessions { get; set; } = new List<PlannedSession>();
}
namespace Training.Data;

/// <summary>
/// A scheduled training session for an athlete based on a workout template.
/// </summary>
public class PlannedSession
{
    /// <summary>
    /// Unique identifier of the planned session.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Foreign key referencing the athlete for whom the session is planned.
    /// </summary>
    public int AthleteId { get; set; }

    /// <summary>
    /// Navigation to the athlete.
    /// </summary>
    public Athlete? Athlete { get; set; }

    /// <summary>
    /// Foreign key referencing the workout template used in this session.
    /// </summary>
    public int WorkoutTemplateId { get; set; }

    /// <summary>
    /// Navigation to the workout template.
    /// </summary>
    public WorkoutTemplate? WorkoutTemplate { get; set; }

    /// <summary>
    /// The scheduled start time of the session (UTC).
    /// </summary>
    public DateTime ScheduledAt { get; set; }

    /// <summary>
    /// Optional notes for the session (coach or athlete).
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Sets logged for this session.
    /// </summary>
    public ICollection<CompletedSet> CompletedSets { get; set; } = new List<CompletedSet>();
}
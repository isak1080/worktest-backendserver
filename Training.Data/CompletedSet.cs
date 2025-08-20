namespace Training.Data;

/// <summary>
/// Created by athletes after a session has been completed.
/// </summary>
public class CompletedSet
{
    /// <summary>
    /// Unique identifier of the completed set.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The sequential number of this set within the session (starting at 1). Unique per session.
    /// </summary>
    public int SequenceNumber { get; set; }
    /// <summary>
    /// Foreign key referencing the session this set belongs to.
    /// </summary>
    public int PlannedSessionId { get; set; }
    /// <summary>
    /// Navigation to the parent planned session.
    /// </summary>
    public PlannedSession? PlannedSession { get; set; }

    /// <summary>
    /// Total number of reps completed
    /// </summary>
    public int NumberOfReps { get; set; }

    /// <summary>
    /// Total work (kJ) done during the set.
    /// </summary>
    public double TotalWork { get; set; }
    /// <summary>
    /// Max force achieved during the set
    /// </summary>
    public double MaxForce { get; set; }
    /// <summary>
    /// Timestamp (UTC) when this set was recorded.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
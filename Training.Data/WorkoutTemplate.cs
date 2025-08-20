namespace Training.Data;

/// <summary>
/// A reusable workout template that describes the target metric and activity.
/// </summary>
public class WorkoutTemplate
{
    /// <summary>
    /// Unique identifier of the workout template.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Human-readable name of the template (e.g., "Bench press").
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Optional free-form description of the workout.
    /// </summary>
    public string? Description { get; set; }
}
namespace Barber.Domain.DTOs;

public class WorkingHourDto
{
    public Guid Id { get; set; }
    public DayOfWeek Day { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan StartBreakingTime { get; set; }
    public TimeSpan EndBreakingTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}

public class CreateWorkingHourDto
{
    public DayOfWeek Day { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan StartBreakingTime { get; set; }
    public TimeSpan EndBreakingTime { get; set; }
    public TimeSpan EndTime { get; set; }
}

public class UpdateWorkingHourDto
{
    public DayOfWeek Day { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan StartBreakingTime { get; set; }
    public TimeSpan EndBreakingTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
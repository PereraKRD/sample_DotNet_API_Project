namespace FormulaOne.Entities.DTOs.Requests;

public class CreateDriverAchievementRequest
{
    public Guid DriverId { get; set; }
    public int WorldChampionship { get; set; }
    public int PolePosition { get; set; }
    public int FastestLap { get; set; }
    public int RaceWins { get; set; }
}
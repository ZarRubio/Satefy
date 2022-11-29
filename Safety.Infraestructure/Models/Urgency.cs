namespace Safety.Infraestructure.Models;

public class Urgency :BaseModel
{
    public int id { get; set; }
    public string title { get; set; }
    public string summary { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public DateTime reportedAt { get; set; }
    public int GuardianId { get; set; }
    public Guardian Guardian { get; set; }
}
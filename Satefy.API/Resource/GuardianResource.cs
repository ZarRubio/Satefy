using System.ComponentModel.DataAnnotations;

namespace Satefy.API.Resource;

public class GuardianResource
{
    [Required]
    public string username { get; set; }
    public string email { get; set; }
    public string gender { get; set; }
}
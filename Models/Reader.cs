using System.ComponentModel.DataAnnotations.Schema;

namespace maldeaBackend.Models;

[Table("Reader")]
public class Reader : User
{
    // Remove the Default Value
    public string phoneNumber { get; set; } = "0938069240";
    public string firstName { get; set; } = "Eyouale";
    public string lastName { get; set; } = "Tensae";
    public string address { get; set; } ="Tensae";
    public string email { get; set; }="Tensae";

    public List<History> Histories { get; set; }
    public List<Subscription> Subscriptions { get; set; }
}
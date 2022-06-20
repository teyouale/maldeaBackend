using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace maldeaBackend.Models;

[Table("Company")]
public class Company : User
{
    public string email { get; set; }
    public string phoneNumber { get; set; }
    // Todo string  ---> File
    public string licence { get; set; }
    public string companyDecription { get; set; }
    public string bio { get; set; }
    public List<Subscription> Subscriptions { get; set; }

}
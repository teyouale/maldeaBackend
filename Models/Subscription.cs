using System.ComponentModel.DataAnnotations;

namespace maldeaBackend.Models;

public class Subscription
{
    [Key]
       public int subscriptionId { get; set; }
        public Company Company { get; set; }
        public Reader Reader  { get; set; }
}
namespace maldeaBackend.Dtos;

public class ReaderDto:UserDto
{
        public string phoneNumber { get; set; } = "0938069240";
        public string firstName { get; set; } = "Eyouale";
        public string lastName { get; set; } = "Tensae";
        public string address { get; set; } ="Tensae";
        public string email { get; set; }="Tensae";
        public List<GetSubscriptionDto> subscriptions { get; set; } 
}
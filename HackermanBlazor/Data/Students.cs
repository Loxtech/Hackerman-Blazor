namespace HackermanBlazor.Data
{
    public class Students
    {
        public Students()
        {
        }

        public Students(int id, string? firstName, string? lastName, int age, string? city, string? road, string? hobby)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            City = city;
            Road = road;
            Hobby = hobby;
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
        public string? Road { get; set; }
        public string? Hobby { get; set; }
    }
}

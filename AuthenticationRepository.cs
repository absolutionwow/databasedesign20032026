using MongoDB.Driver;

public class AuthenticationRepository
{
    private readonly IMongoCollection<User> _users;

    public AuthenticationRepository()
    {
        var client = new MongoClient("your connection string");
        var database = client.GetDatabase("name for database");
        _users = database.GetCollection<User>("name for collection");
    }

    public void SaveUser(User user)
    {
       // your code
    }
   

    public User FindUser(string username, string password)
    {
       // your code that returns a user
       
       return null;  // remove this line when you finish your implementation
    }
}
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class AuthenticationController
{
    private readonly AuthenticationRepository _repository;

    public AuthenticationController()
    {
        _repository = new AuthenticationRepository();
    }

    public void CreateAccount(string name, string email, string username, string password)
    {
        var newUser = new User
        {
            Name = name,
            Email = email,
            Username = username,
            Password = password
        };

        _repository.CreateUser(newUser);
    }

    public User ValidateCredentials(string username, string password)
    {
        var user = _repository.GetUserByUsername(username);

        if (user == null) return null;

        return user.Password == password ? user : null;
    }
    public class AuthenticationRepository
    {
        private readonly IMongoCollection<User> _users;

        public AuthenticationRepository()
        {
            var client = new MongoClient("mongodb+srv://adpita1sem:ita2sem@cluster0.t0xutha.mongodb.net/");
            var database = client.GetDatabase("adpita1sem");
            _users = database.GetCollection<User>("users");
        }

        public void CreateUser(User user)
        {
            _users.InsertOne(user);
        }

        public User GetUserByUsername(string username)
        {
            return _users.Find(u => u.Username == username).FirstOrDefault();
        }
    }
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

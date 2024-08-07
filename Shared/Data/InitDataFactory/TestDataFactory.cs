namespace QuickChat.Shared.Data.InitDataFactory
{
    using QuickChat.Shared.Entities;

    /// <summary>
    /// Concrete implementation of AbstractDataFactory for providing test data arrays.
    /// </summary>
    public class TestDataFactory : AbstractDataFactory
    {
        /// <summary>
        /// Gets the user data.
        /// </summary>
        public override User[] GetUserData()
        {
            return new User[]
            {
                new User(1, "John", "Doe", "john.doe", "password", 1),
                new User(2, "Jane", "Doe", "jane.doe", "password", 2),
                new User(3, "Alice", "Smith", "alice.smith", "password", 1),
                new User(4, "Bob", "Smith", "bob.smith", "password", 2),
                new User(5, "Charlie", "Brown", "charlie.brown", "password", 1),
                new User(6, "Daisy", "Brown", "daisy.brown", "password", 2),
                new User(7, "Eve", "Black", "eve.black", "password", 1),
                new User(8, "Frank", "Black", "frank.black", "password", 2),
                new User(9, "Grace", "White", "grace.white", "password", 1),
                new User(10, "Henry", "White", "henry.white", "password", 2)
            };
        }

        /// <summary>
        /// Gets the chat data.
        /// </summary>
        public override Chat[] GetChatData()
        {
            return new Chat[]
            {
                new Chat(1, "Chat 1", "First chat", 1, 2),
                new Chat(2, "Chat 2", "Second chat", 3, 4),
                new Chat(3, "Chat 3", "Third chat", 5, 6),
                new Chat(4, "Chat 4", "Fourth chat", 7, 8),
                new Chat(5, "Chat 5", "Fifth chat", 9, 10)
            };
        }

        /// <summary>
        /// Gets the message data.
        /// </summary>
        public override Message[] GetMessageData()
        {
            return new Message[]
            {
                new Message(1, "Hello, Jane!", 1, 3),
                new Message(2, "Hello, John!", 1, 2),
                new Message(3, "Hello, Bob!", 2, 4)
            };
        }
    }
}
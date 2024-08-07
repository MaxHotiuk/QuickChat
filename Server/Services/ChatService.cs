namespace QuickChat.Server.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using QuickChat.Server.Interfaces;
    using QuickChat.Server.Models;
    using QuickChat.Shared.Data;
    using QuickChat.Shared.Entities;
    using QuickChat.Shared.Interfaces;
    using QuickChat.Shared.Repository;

    /// <summary>
    /// Service class for managing chats implementing the <see cref="ICrud"/> interface.
    /// </summary>
    public class ChatService : ICrud
    {
        private readonly IChatRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatService"/> class with a database context.
        /// </summary>
        /// <param name="context">The database context used for repository operations.</param>
        public ChatService(QuickChatDbContext context)
        {
            this.repository = new ChatRepository(context);
        }

        /// <summary>
        /// Adds a new chat to the repository.
        /// </summary>
        /// <param name="model">The chat model to add.</param>
        public void Add(AbstractModel model)
        {
            var x = (ChatModel)model;
            this.repository.Add(new Chat()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            });
        }

        /// <summary>
        /// Deletes a chat by its ID.
        /// </summary>
        /// <param name="modelId">The ID of the chat to delete.</param>
        public void Delete(int modelId)
        {
            this.repository.DeleteById(modelId);
        }

        /// <summary>
        /// Retrieves all chats from the repository.
        /// </summary>
        /// <returns>An enumerable collection of chat models.</returns>
        public IEnumerable<AbstractModel> GetAll()
        {
            return this.repository.GetAll().Select(x => new ChatModel(x.Id, x.Name, x.Description));
        }

        /// <summary>
        /// Retrieves a chat by its ID.
        /// </summary>
        /// <param name="modelId">The ID of the chat to retrieve.</param>
        /// <returns>The chat model with the specified ID.</returns>
        public AbstractModel GetById(int modelId)
        {
            var x = this.repository.GetById(modelId);
            return new ChatModel(x.Id, x.Name, x.Description);
        }

        /// <summary>
        /// Updates a chat in the repository.
        /// </summary>
        /// <param name="model">The chat model to update.</param>
        /// <param name="modelId">The ID of the chat to update.</param>
        /// <returns>The updated chat model.</returns>
        public void Update(AbstractModel model)
        {
            var chat = (ChatModel)model;
            var existingChat = this.repository.GetById(chat.Id);

            if (existingChat != null)
            {
                existingChat.Id = chat.Id;
                existingChat.Name = chat.Name;
                existingChat.Description = chat.Description;
                this.repository.Update(existingChat);
            }
            else
            {
                throw new ArgumentException("Chat not found");
            }
        }
    }
}
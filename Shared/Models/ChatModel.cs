namespace QuickChat.Shared.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a chat model derived from AbstractModel.
    /// </summary>
    public class ChatModel : AbstractModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChatModel"/> class with specified properties.
        /// </summary>
        /// <param name="id">The ID of the chat.</param>
        /// <param name="name">The name of the chat.</param>
        /// <param name="description">The description of the chat.</param>
        public ChatModel(int id, string name, string description)
            : base(id)
        {
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// Gets or sets the name of the chat.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the chat.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets user one participating in the chat.
        /// </summary>
        public UserModel UserOne { get; set; }

        /// <summary>
        /// Gets or sets user two participating in the chat.
        /// </summary>
        public UserModel UserTwo { get; set; }

        public override string ToString()
        {
            return $"Id:{this.Id} {this.Name} {this.Description} {this.UserOne} {this.UserTwo}";
        }
    }
}
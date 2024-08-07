using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuickChat.Shared.Entities
{
    /// <summary>
    /// Represents a message entity.
    /// </summary>
    [Table("messages")]
    public class Message : BaseEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class with default values.
        /// </summary>
        public Message()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class with specified identifier, text, chatId, userId.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="text">The text of the message.</param>
        /// <param name="chatId">The chat identifier of the message.</param>
        /// <param name="userId">The user identifier of the message.</param>
        public Message(int id, string text, int chatId, int userId)
            : base(id)
        {
            this.Text = text;
            this.ChatId = chatId;
            this.UserId = userId;
        }

        /// <summary>
        /// Gets or sets the text of the message.
        /// </summary>
        [Column("text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the chat identifier of the message.
        /// </summary>
        [ForeignKey(nameof(Chat))]
        [Column("chat_id")]
        public int ChatId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier of the message.
        /// </summary>
        [ForeignKey(nameof(User))]
        [Column("user_id")]
        public int UserId { get; set; }
    }
}
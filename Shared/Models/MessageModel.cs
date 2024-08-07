namespace QuickChat.Shared.Models;
using System;
using System.Collections.Generic;

/// <summary>
/// Represents a message model derived from AbstractModel.
/// </summary>
public class MessageModel : AbstractModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageModel"/> class with specified properties.
    /// </summary>
    /// <param name="id">The ID of the message.</param>
    /// <param name="content">The content of the message.</param>
    /// <param name="chatId">The chat ID of the message.</param>
    /// <param name="userId">The user ID of the message.</param>
    public MessageModel(int id, string content, int chatId, int userId)
        : base(id)
    {
        this.Content = content;
        this.ChatId = chatId;
        this.UserId = userId;
    }

    /// <summary>
    /// Gets or sets the content of the message.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Gets or sets the chat ID of the message.
    /// </summary>
    public int ChatId { get; set; }

    /// <summary>
    /// Gets or sets the user ID of the message.
    /// </summary>
    public int UserId { get; set; }

    public override string ToString()
    {
        return $"Id:{this.Id} {this.Content} {this.ChatId} {this.UserId}";
    }
}
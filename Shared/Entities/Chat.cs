using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuickChat.Shared.Entities;

/// <summary>
/// Represents a chat entity.
/// </summary>
[Table("chats")]
public class Chat : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Chat"/> class with default values.
    /// </summary>
    public Chat()
        : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Chat"/> class with specified identifier, name, description, userone, usertwo.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="name">The name of the chat.</param>
    /// <param name="description">The description of the chat.</param>
    /// <param name="userone">The first user of the chat.</param>
    /// <param name="usertwo">The second user of the chat.</param>
    public Chat(int id, string name, string description, int userone, int usertwo)
        : base(id)
    {
        this.Name = name;
        this.Description = description;
        this.UserOne = userone;
        this.UserTwo = usertwo;
    }

    /// <summary>
    /// Gets or sets the name of the chat.
    /// </summary>
    [Column("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the description of the chat.
    /// </summary>
    [Column("description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the first user of the chat.
    /// </summary>
    [ForeignKey(nameof(User))]
    [Column("user_one")]
    public int UserOne { get; set; }

    /// <summary>
    /// Gets or sets the second user of the chat.
    /// </summary>
    [ForeignKey(nameof(User))]
    [Column("user_two")]
    public int UserTwo { get; set; }
}
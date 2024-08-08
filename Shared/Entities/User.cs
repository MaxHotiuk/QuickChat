using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuickChat.Shared.Entities;

/// <summary>
/// Represents a user entity.
/// </summary>
[Table("users")]
public class User : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class with default values.
    /// </summary>
    public User()
        : base()
    {
        this.Name = string.Empty;
        this.LastName = string.Empty;
        this.Login = string.Empty;
        this.Password = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class with specified identifier, name, last name, login, and password.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="name">The first name of the user.</param>
    /// <param name="lastName">The last name of the user.</param>
    /// <param name="login">The login of the user.</param>
    /// <param name="password">The password of the user.</param>
    public User(int id, string? name, string? lastName, string? login, string? password)
        : base(id)
    {
        this.Name = name!;
        this.LastName = lastName!;
        this.Login = login!;
        this.Password = password!;
    }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    [Column("first_name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    [Column("last_name")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the login of the user.
    /// </summary>
    [Column("login")]
    public string Login { get; set; }

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    [Column("Password")]
    public string Password { get; set; }
}
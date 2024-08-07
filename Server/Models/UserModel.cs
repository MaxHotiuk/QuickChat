namespace Server.Models;
using System;
using System.Collections.Generic;

/// <summary>
/// Represents a user model derived from AbstractModel.
/// </summary>
public class UserModel : AbstractModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserModel"/> class with specified properties.
    /// </summary>
    /// <param name="id">The ID of the user.</param>
    /// <param name="name">The first name of the user.</param>
    /// <param name="lastName">The last name of the user.</param>
    /// <param name="login">The login name of the user.</param>
    /// <param name="password">The hashed password of the user.</param>
    public UserModel(int id, string name, string lastName, string login, string password)
        : base(id)
    {
        this.Name = name;
        this.LastName = lastName;
        this.Login = login;
        this.Password = password;
    }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the login name of the user.
    /// </summary>
    public string Login { get; set; }

    /// <summary>
    /// Gets or sets the hashed password of the user.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the ID of the role assigned to the user.
    /// </summary>
    public override string ToString()
    {
        return $"Id:{this.Id} {this.Name} {this.LastName} {this.Login} {this.Password}";
    }
}

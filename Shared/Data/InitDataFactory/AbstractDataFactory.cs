namespace Shared.Data.InitDataFactory;
using Shared.Entities;

/// <summary>
/// Represents an abstract data factory.
/// </summary>
public abstract class AbstractDataFactory
{
    /// <summary>
    /// Gets the user data.
    /// </summary>
    public abstract User[] GetUserData();

    /// <summary>
    /// Gets the chat data.
    /// </summary>
    public abstract Chat[] GetChatData();

    /// <summary>
    /// Gets the message data.
    /// </summary>
    public abstract Message[] GetMessageData();
}
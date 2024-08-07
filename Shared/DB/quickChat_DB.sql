CREATE TABLE users (
    id INT PRIMARY KEY,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    login VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL
);
CREATE TABLE messages (
    id INT PRIMARY KEY,
    text TEXT NOT NULL,
    chat_id INT NOT NULL,
    user_id INT NOT NULL,
    FOREIGN KEY (chat_id) REFERENCES chats(id),
    FOREIGN KEY (user_id) REFERENCES users(id)
);
CREATE TABLE chats (
    id INT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    user_one INT NOT NULL,
    user_two INT NOT NULL,
    FOREIGN KEY (user_one) REFERENCES users(id),
    FOREIGN KEY (user_two) REFERENCES users(id)
);

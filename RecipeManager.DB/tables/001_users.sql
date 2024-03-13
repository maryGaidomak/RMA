CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE IF NOT EXISTS users (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    username VARCHAR(50) UNIQUE NOT NULL,
    email VARCHAR(50) UNIQUE NOT NULL,
    firstname VARCHAR(255) NOT NULL,
    lastname VARCHAR(255),
    dateofbirth DATE,
    createdat TIMESTAMP NOT NULL DEFAULT timezone('utc'::text, now()),
    updatedat TIMESTAMP NOT NULL DEFAULT timezone('utc'::text, now())
);

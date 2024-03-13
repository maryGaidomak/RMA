DO $$
BEGIN
    -- Check if the database does not exist, then create it
    IF NOT EXISTS (
        SELECT FROM pg_database WHERE datname = 'recipebook'
    ) 
    THEN
        CREATE DATABASE recipebook;
    END IF;
END
$$;

GRANT ALL PRIVILEGES ON DATABASE recipebook TO postgres;

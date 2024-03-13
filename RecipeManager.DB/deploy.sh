#!/bin/bash

# Variables
DB_USER="postgres"
DB_NAME="recipebook"
export PGPASSWORD='postgres'

# Check if database exists
database_exists() {
    psql -U "$DB_USER" -lqt | cut -d \| -f 1 | grep -qw "$DB_NAME"
}

# Create database if it doesn't exist
if ! database_exists; then
    echo "Database $DB_NAME does not exist. Creating..."
    psql -h localhost -U "$DB_USER" -d postgres -c "CREATE DATABASE $DB_NAME;"
    psql -h localhost -U "$DB_USER" -d "$DB_NAME" -c "GRANT ALL PRIVILEGES ON DATABASE $DB_NAME TO $DB_USER;"
    echo "Created database $DB_NAME."
else
    echo "Database $DB_NAME already exists."
fi

# Function to run SQL scripts in a directory
run_sql_scripts() {
    directory=$1
    shopt -s nullglob 
    sql_files=($directory/*.sql)
    
    if [ ${#sql_files[@]} -gt 0 ]; then
        for sql_file in "${sql_files[@]}"; do
            echo "Running $sql_file..."
            psql -h localhost -U "$DB_USER" -d "$DB_NAME" -f "$sql_file"
        done
    else
        echo "No SQL scripts found in $directory."
    fi
    shopt -u nullglob 
}

# Run SQL scripts from each directory
run_sql_scripts "tables"
run_sql_scripts "functions"
run_sql_scripts "patches"

echo "Database setup complete."

#!/bin/bash

# Variables
DB_USER="rootuser"
DB_NAME="recipebook"

# Path to the directory containing your SQL scripts
SQL_DIR="./"

# Function to run SQL scripts in a directory
run_sql_scripts() {
    for sql_file in $1/*.sql; do
        echo "Running $sql_file..."
        psql -h localhost -U "$DB_USER" -d "$DB_NAME" -f "$sql_file"
    done
}

# Create database and user
psql -h localhost -U "$DB_USER" -f "$SQL_DIR/create_db.sql"

# Run SQL scripts from each directory
run_sql_scripts "$SQL_DIR/tables"
run_sql_scripts "$SQL_DIR/functions"
run_sql_scripts "$SQL_DIR/patches"

echo "Database setup complete."

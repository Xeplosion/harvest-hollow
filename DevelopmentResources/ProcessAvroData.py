import fastavro
from fastavro.utils import generate_one
import json
import os
import re
import subprocess

# Constants for directories and file types
DIRECTORY = '..\\HarvestHollow\\Entities\\LevelData\\'
EDITOR_DIR = '..\\HarvestHollow.LevelEditor\\Models\\'
EXTENSION = '.avsc'

def main():
    files = find_avro_files(DIRECTORY)  # Find Avro files
    if not files:
        print("No .avsc files found in the specified directory.")
        return

    print("Available Avro schema files:")
    for i, file in enumerate(files):
        print(f"{i + 1}: {file}")

    selected_files = input("Enter the numbers of the files you want to process (comma-separated), or 'all' for all files: ")
    
    # Check for 'all' option
    if selected_files.strip().lower() == 'all':
        selected_indices = list(range(len(files)))  # Select all files
    else:
        selected_indices = [int(num.strip()) - 1 for num in selected_files.split(',')]

    # Validate input
    valid_indices = [i for i in selected_indices if 0 <= i < len(files)]
    if not valid_indices:
        print("No valid file selections made.")
        return

    delete_old()
    for index in valid_indices:
        process_file(files[index])


# Function to find all Avro schema files in the specified directory
def find_avro_files(directory):
    return [file for file in os.listdir(directory) if file.endswith(EXTENSION)]

def delete_old():
    delete = [file for file in os.listdir(DIRECTORY) if file.endswith('Struct.cs')]
    for file in delete:
        os.remove(DIRECTORY + file)


def process_avro_schemas(schema_path, cs_file_path):
    # Function to find all aliases in the Avro schema
    def find_aliases(schema, aliases=None):
        if aliases is None:
            aliases = {}

        # Handle case where 'type' is a list (unions like ['null', {...}])
        if isinstance(schema, list):
            for item in schema:
                find_aliases(item, aliases)

        # Handle case where 'schema' is a dictionary (typical schema object)
        elif isinstance(schema, dict):
            # If 'aliases' and 'name' are present, store them in the aliases dictionary
            if 'aliases' in schema and 'name' in schema:
                aliases[schema['name']] = schema['aliases']
        
            # Recurse into 'fields' if they exist (for records)
            if 'fields' in schema:
                for field in schema['fields']:
                    find_aliases(field, aliases)

            # Recurse into 'items' if present (for arrays)
            if 'items' in schema:
                find_aliases(schema['items'], aliases)
        
            # Recurse into 'type' if it's a dictionary or a list (handles nested records or unions)
            if isinstance(schema.get('type'), (dict, list)):
                find_aliases(schema['type'], aliases)

        return aliases

    # Function to rename properties in a C# file based on the aliases in the Avro schema
    def rename_properties_in_cs_file(cs_file_path, aliases):
        # Read the C# file content
        with open(cs_file_path, 'r', encoding='utf-16') as file:
            content = file.read()

        # Loop over each original name and its list of aliases
        for name, alias_list in aliases.items():
            # Pick the first alias (or apply your own logic to select one)
            alias = alias_list[0]
        
            # Define the regex pattern to match the original name as a word, case-insensitive
            pattern = r"\b{}\b".format(re.escape(name))
        
            # Replace the original name with the chosen alias in the content (case-insensitive replacement)
            content = re.sub(pattern, alias, content, flags=re.IGNORECASE)

        # Write the updated content back to the C# file
        with open(cs_file_path, 'w', encoding='utf-16') as file:
            file.write(content)

    all_aliases = {}

    with open(schema_path, 'r', encoding='utf-8-sig') as schema_file:
        schema = json.load(schema_file)
        aliases = find_aliases(schema)
        all_aliases.update(aliases)
        print(f'All C# aliases: {json.dumps(all_aliases, indent=4)}')

    rename_properties_in_cs_file(cs_file_path, all_aliases)


def generate_csharp_structs(schema_path, out):
    temp_out = schema_path.split('Schema.', 1)[0] + 'TempStruct.cs'
    command = f'Get-Content {schema_path} | dotnet avro generate --nullable-references | Out-File {temp_out}'
    print("\nAttempting to generate C# struct from Avro schema...")
    result = subprocess.run(['powershell', '-Command', command], shell=True)
    if result.returncode != 0:
        print("Error generating C# struct.")
        print("Standard Output:", result.stdout)
        print("Standard Error:", result.stderr)
        print("Return Code:", result.returncode)

    with open(temp_out, 'r', encoding='utf-16') as infile:
        content = infile.readlines()
        with open(out, 'w', encoding='utf-16') as outfile:
            for line in content:
                if 'class' in line:
                    line = line.replace('class', 'struct')
                outfile.write(line)

    subprocess.run(['powershell', '-Command', 'rm ' + temp_out])


def convert_to_file_scoped_namespace(path):
    # Read the content of the C# file with UTF-16 encoding
    with open(path, 'r', encoding='utf-16') as file:
        content = file.readlines()

    # Prepare to store modified content
    modified_content = []
    namespace_declaration = False

    # Iterate through the lines to find and replace namespace declaration
    for index, line in enumerate(content):
        # Skip over the line after namespace declaration
        if namespace_declaration:
            namespace_declaration = False
            continue

        # Remove one level of indentation (assuming 4 spaces)
        stripped_line = line[4:] if line.startswith("    ") else line.lstrip()  # Adjust this for your indentation style

        # Check if the line contains a standard namespace declaration
        if stripped_line.startswith("namespace"):
            modified_content.append(f'{line.strip()};\n\n')
            namespace_declaration = True
            continue

        # Skip the last line of the file and the closing brace
        if index == len(content) - 1:
            continue

        if index == 0:
            modified_content.append(f'{line}\n')
            continue
        
        # Add the rest of the lines without modification (removing indentation)
        modified_content.append(stripped_line)

    # Write the modified content back to the same file or a new file
    with open(path, 'w', encoding='utf-16') as file:
        file.writelines(modified_content)


def level_editor_copy(schema_path, editor_path, out):
    try:
        subprocess.run(['powershell', '-Command', 'rm ' + editor_path])
    except Exception:
        print("No existing schema file found in the HarvestHollow.LevelEditor project.")

    try:
        subprocess.run(['powershell', '-Command', 'rm ' + editor_path.split('Schema.', 1)[0] + 'Struct.cs'])
    except Exception:
        print("No existing Struct file found in the HarvestHollow.LevelEditor project.")

    command = f'Copy-Item {schema_path} {editor_path}'
    result = subprocess.run(['powershell', '-Command', command], shell=True)
    if result.returncode != 0:
        print("Error copying schema file.")
        print("Standard Output:", result.stdout)
        print("Standard Error:", result.stderr)
        print("Return Code:", result.returncode)

    command = f'Copy-Item {out} {editor_path.split("Schema.", 1)[0]}Struct.cs'
    result = subprocess.run(['powershell', '-Command', command], shell=True)
    if result.returncode != 0:
        print("Error copying struct file.")
        print("Standard Output:", result.stdout)
        print("Standard Error:", result.stderr)
        print("Return Code:", result.returncode)

def generate_avro_data(schema_path):
    try:
        with open(schema_path, 'r', encoding='utf-8-sig') as schema_file:
            schema_content = schema_file.read()
            print("Creating test schema data...")
            schema = json.loads(schema_content)
    except FileNotFoundError:
        print(f"File not found: {schema_path}")
        exit(1)
    except json.JSONDecodeError as e:
        print(f"Error decoding JSON from the schema file: {e}")
        exit(1)

    parsed_schema = fastavro.parse_schema(schema)

    avro_file_path = './avrodata.avro'
    try:
        with open(avro_file_path, 'wb') as out:
            fastavro.schemaless_writer(out, parsed_schema, generate_one(parsed_schema))
    except Exception as e:
        print(f"Error writing to Avro file: {e}")
        exit(1)

    try:
        with open(avro_file_path, 'rb') as avro_file:
            record = fastavro.schemaless_reader(avro_file, parsed_schema)
            print("\nReading random test data from Avro file...")
    except Exception as e:
        print(f"Error reading from Avro file: {e}")
        exit(1)

def process_file(file):
    schema_path = DIRECTORY + file
    editor_path = EDITOR_DIR + file
    out = schema_path.split('Schema.', 1)[0] + 'Struct.cs'

    generate_csharp_structs(schema_path, out)
    process_avro_schemas(schema_path, out)
    convert_to_file_scoped_namespace(out)
    level_editor_copy(schema_path, editor_path, out)
    generate_avro_data(schema_path)

if __name__ == "__main__":
    main()

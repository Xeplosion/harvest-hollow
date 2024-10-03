import os
import sys

# Settings for the asset path generation tool
DIRECTORY = '../HarvestHollow/Content/'  # Directory being checked for files
ROOT = '../HarvestHollow/Content'        # New root for the file paths
OUTPUT_FILE = './FilePaths.txt'          # File to output the generated paths to
SECTION_NAMES = ["Font_", "OST_", "SFX_", "SpriteSheet_", "TileSheet_", "Texture_"]

# Generate asset paths for the selected section(s)
def main():
    generate_asset_paths(get_input_options(True))
    print(f"Asset paths have been generated and saved to the {OUTPUT_FILE} file.")
    input("Press any key to exit...")

# Display path generation options:
def display_path_options_text(first=True):
    os.system('cls' if os.name == 'nt' else 'clear')
    print("ASSET PATH CREATION TOOL")  # Cool output text because why not \_(ツ)_/¯
    print("\nAsset sections for generating paths:" if first else "\nInvalid option. Please enter a number:")

    for section in SECTION_NAMES:
        print(f"\t{SECTION_NAMES.index(section) + 1}). {section}")

    print(f"\t{len(SECTION_NAMES) + 1}). All\n")

# Get user input for generating path sections
def get_input_options(first=False):
    display_path_options_text(first)
    try:
        option = input("\nSelect a section to generate paths for (or 'all' for all sections): ")
        os.system('cls' if os.name == 'nt' else 'clear')

        if option.strip().lower() == 'all':
            print("Creating asset paths for all sections...")
            return len(SECTION_NAMES) + 1
        
        option = int(option)
        if 0 < option <= len(SECTION_NAMES) + 1:  # Check if input is a valid number
            print(f"Creating asset paths for {SECTION_NAMES[option - 1].split('_', 1)[0]} assets..." if option < len(SECTION_NAMES) + 1 \
                else "Creating asset paths for all sections...")
            return option
        else:
            display_path_options_text()
            return get_input_options()

    except ValueError:
        display_path_options_text()
        return get_input_options()

# Generate asset paths for given section(s)
def generate_asset_paths(option):
    # Set the output directory for the created asset paths
    with open(OUTPUT_FILE, 'w') as output:
        sys.stdout = output

        # Output file header
        print(f"GENERATED ASSET PATHS :D{"\n" * 3}")
        files = list_files_with_os(DIRECTORY, ROOT)
        sections = separate_file_types(files)

        # Output the asset paths to the selected file
        if option == len(SECTION_NAMES) + 1:
            for index, section in enumerate(sections):
                print(SECTION_NAMES[index] + ":\n")
                print(sections[index])
                if index != len(SECTION_NAMES) - 1:
                    print("\n" * 3)
        else:
            print(SECTION_NAMES[option - 1] + ":\n")
            print(sections[option - 1])

    sys.stdout = sys.__stdout__  # Reset the output stream for console output

# Lists all files in a given directory and its subdirectories
def list_files_with_os(directory, root):
    file_paths = []
    for current_root, dirs, files in os.walk(directory):
        # Remove 'bin' and 'obj' directories from the traversal
        dirs[:] = [d for d in dirs if d not in ['bin', 'obj']]

        for file in files:
            # Calculate the relative path from the directory to the root
            relative_path = os.path.relpath(os.path.join(current_root, file), root)
            # Convert to forward slashes
            relative_path = relative_path.replace('\\', '/')
            file_paths.append(relative_path)

    return file_paths

# Separates files into their respective sections
def separate_file_types(files):
    sections = ["", "", "", "", "", ""]

    # Goes through each file and sorts by section
    for file in files:
        for index, section in enumerate(SECTION_NAMES):
            if section in file:
                file_name = os.path.basename(file)
                clean_file_name = os.path.splitext(file_name)[0]
                clean_file_path = os.path.splitext(file)[0]
                sections[index] += f'{"\t" * 6}("{clean_file_name}", "{clean_file_path}"),\n'

    return sections

if __name__ == "__main__":
    main()

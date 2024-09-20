from operator import indexOf
import os

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

directory = '../HarvestHollow/Content/'  # Directory being checked for files
root = '../HarvestHollow/Content'                # New root for the file paths
files = list_files_with_os(directory, root)

types = ["Font_", "OST_", "SFX_", "SpriteSheet_", "TileSheet_", "Palette_"]
sections = ["", "", "", "", "", ""]

def seperate_file_types():
    for file in files:
        for index, type in enumerate(types):
            if type in file:
                fileName = os.path.basename(file)
                cleanFileName = os.path.splitext(fileName)[0]
                cleanFilePath = os.path.splitext(file)[0]
                sections[index] += '                        ("' + cleanFileName + '", "' + cleanFilePath + '"),\n'

seperate_file_types()

for index, type in enumerate(types):
    print(types[index] + ":\n")
    print(sections[index])
    print("\n\n\n")
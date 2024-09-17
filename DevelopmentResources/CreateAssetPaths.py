import os

def list_files_with_os(directory, root):
    file_paths = []
    for current_root, dirs, files in os.walk(directory):
        for file in files:
            # Calculate the relative path from the directory to the root
            relative_path = os.path.relpath(os.path.join(current_root, file), root)
            # Convert to forward slashes
            relative_path = relative_path.replace('\\', '/')
            file_paths.append(relative_path)
    return file_paths

directory = '../HarvestHollow/Content/Images/SpriteSheets'  # Directory being checked for files
root = '../HarvestHollow/Content'                # New root for the file paths
files = list_files_with_os(directory, root)
for file in files:
    print(file)
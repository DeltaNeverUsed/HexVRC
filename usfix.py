import git, os, re

def main():
    repo = git.Repo('.')  # Assumes the script is run from the root directory of the repository

    # Get a list of unstaged files
    unstaged_files = repo.git.diff(None, name_only=True).split('\n')

    prev_commit = repo.git.rev_parse('HEAD')

    pos_match = re.compile("\\+( +)serialized(Udon)*ProgramAsset: {fileID: (\\d+), guid: ")
    neg_match = re.compile("-( +)serialized(Udon)*ProgramAsset: {fileID: (\\d+), guid: ")


    # Iterate over each unstaged file
    for file_path in unstaged_files:
        replace_changed = []
        replace_original = []

        if not file_path.endswith((".unity", ".prefab", ".asset")):
            print("Skipped: "+file_path)
            continue

        # Check if the file exists and is not a directory
        if file_path:
            # Read the file contents
            try:
                with open(file_path, 'r') as file:
                    file_lines = file.readlines()
            except:
                print("Something wen't wrong with reading file.")
                continue;
            
            thing = os.popen("git --no-pager diff -U0 \"" + file_path + "\"")
            lines = thing.read().split('\n')


            for i in range(len(lines)):
                if i+2 > len(lines):
                    break

                search = pos_match.match(lines[i+1])
                search2 = neg_match.match(lines[i])
                if search and search2:
                    guid_start = len(search.group(0))
                    guid_start2 = len(search2.group(0))
                    replace_changed.append(lines[i+1][guid_start:])
                    replace_original.append(lines[i][guid_start2:])

                    #print("bad: " + lines[i+1][guid_start:])
                    #print("good: "+ lines[i][guid_start2:])

                    i += 1
            
            for i in range(len(file_lines)):
                if not 'guid' in file_lines[i]:
                    continue

                for guid_index in range(len(replace_changed)):
                    file_lines[i] = file_lines[i].replace(replace_changed[guid_index], replace_original[guid_index])
            
            # Write the modified contents back to the file
            with open(file_path, 'w') as file:
                file.writelines(file_lines)
    
    print("finished")

if __name__ == "__main__":
    main()

with open('input_file.txt', 'r') as f:
    lines = f.readlines()

with open('output_file.txt', 'w') as f:
    for line in lines:
        first_char = line[0]
        if line[0] != "":
            modified_line = "<div>" + first_char + "</div>" + line[1:]
            f.write(modified_line)

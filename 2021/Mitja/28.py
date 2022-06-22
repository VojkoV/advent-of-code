string = input()
char = input()

for i in range(len(string)+1):
    print(string[:i] + char + string[i:])
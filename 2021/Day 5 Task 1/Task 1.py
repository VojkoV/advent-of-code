my_file = open("Day 5 Task 1\input.txt", "r")
content_list = my_file.read().split("\n")
my_file.close()

content_list[0] = content_list[0].removeprefix("ď»ż")
grid = [[0]*1000 for _ in range(1000)]

print("Initial grid:")
print(grid)
print("After adding vents:")

overlapCounter = 0
# Add vents to the sea floor
for i in range(0, len(content_list)):
    [dot1, dot2] = content_list[i].split(" -> ")
    dot1 = list(map(int, dot1.split(",")))
    dot2 = list(map(int, dot2.split(",")))
    if dot1[0] != dot2[0] and dot1[1] != dot2[1]:
        continue
    #dot1 has to have smaller or equal coordinates
    if dot1[0] > dot2[0] or dot1[1] > dot2[1]:
        dot1, dot2 = dot2, dot1
    for x in range(dot1[0], dot2[0] + 1):
        for y in range(dot1[1], dot2[1] + 1):
            grid[x][y] = grid[x][y] + 1
            if grid[x][y] == 2:
                overlapCounter += 1

print(grid)
print("Overlaps: ", overlapCounter)


    
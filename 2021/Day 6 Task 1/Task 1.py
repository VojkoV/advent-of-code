my_file = open("Day 6 Task 1\input.txt", "r")
lanternfishList = list(map(int, my_file.read().removeprefix("ď»ż").split(",")))
my_file.close()

# Initialize status
lanternfishStatus = []
for i in range(9):
    lanternfishStatus.append(lanternfishList.count(i))

print("Initial lanternfish number: ", sum(lanternfishStatus))
for day in range(80000):
    tempStatus = [0 for _ in range(len(lanternfishStatus))]
    tempStatus[6] = lanternfishStatus[0]
    tempStatus[8] = lanternfishStatus[0]
    for el in range(len(lanternfishStatus) - 1):
        tempStatus[el] += lanternfishStatus[el + 1]
    lanternfishStatus = tempStatus

print("Final lanternfish number: ", sum(lanternfishStatus))
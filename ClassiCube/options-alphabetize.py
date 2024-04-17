#!/usr/bin/python3

file = "options.txt"
lines = []

with open(file, 'r') as f:
	lines = f.readlines()
	lines.sort()

with open(file, 'w') as f:
	f.writelines(lines)

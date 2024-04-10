#!/usr/bin/python3
import sys, os, platform, requests, getpass

def resCheck(res):
	msg = 'Error: empty response object'
	try:
		json = res.json()
		return json
	except ValueError:
		print(msg)
		sys.exit(1)

def sortServers(s):
	return s['players']
	
def space(l, s):
	a = s - l
	b = ''
	i = 0
	while i < a:
		b += ' '
		i += 1
	return b

apiRoot = 'http://www.classicube.net/api'

print('Please enter your username: ', end='')
username = input()
while username == '':
	username = input()

password = getpass.getpass('Please enter your password: ')	

r = requests.get(apiRoot + '/login/')
json = resCheck(r)

token = json['token']
data = {'username': username, 'password': password, 'token': token}

r2 = requests.post(apiRoot + '/login/', data=data, cookies=r.cookies)
resCheck(r)

r3 = requests.get(apiRoot + '/servers/', cookies=r2.cookies)
json3 = resCheck(r3)

servers = json3['servers']
servers.sort(reverse=True, key=sortServers)

i = 0
while i < len(servers):
	num        = '{:02X}'.format(i)
	players    = servers[i]['players']
	maxplayers = servers[i]['maxplayers']
	country    = servers[i]['country_abbr']
	name       = servers[i]['name']
	
	p = str(players) + '/' + str(maxplayers) + space(len(str(maxplayers)), 10)
	
	d = [ num, country, p, name ]
	print(' | '.join(d))
	i += 1

print('Which server would you like to join? ', end='')
server = input()
servernum = int(server, 16)
if servernum >= len(servers):
	print('Selection must be within 00-' + '{:02X}'.format(len(servers) - 1) + 'inclusive.')
s = servers[servernum]

cc = './ClassiCube'
if platform.system() == 'Windows':
	cc = 'ClassiCube.exe'
prog = [ cc, username, s['mppass'], s['ip'], str(s['port']) ]
progstr = ' '.join(prog)
os.system(progstr)
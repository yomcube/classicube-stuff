#!/usr/bin/python3

from flask import Flask, make_response
from os.path import isfile, isdir
from os import mkdir
import urllib

skinurl = 'http://cdn.classicube.net/skin/'
skindir = 'skins/'

app = Flask(__name__)

if not isdir(skindir):
	mkdir(skindir)

@app.route("/<skin>")
def skin(skin):
	p = skindir + skin
	if not isfile(p):
		data = urllib.request.urlopen(skinurl + skin).read()
		with open(p, 'wb') as f:
			f.write(data)
		resp = make_response(data)
		resp.headers['Content-Type'] = 'image/png'
		return resp
	with open(p, 'rb') as f:
		resp = make_response(f.read())
		resp.headers['Content-Type'] = 'image/png'
		return resp
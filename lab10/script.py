import pymongo
from pymongo import MongoClient
client = MongoClient('localhost', 27017)
db = client.csci2963_mmetro
for defi in db.definitions.find():
	print defi
print db.definitions.find_one()
print db.definitions.find_one({"word":"Capitaland"})
print db.definitions.find_one({'_id': ObjectId('56fe9e22bad6b23cde07b949')})
db.definitions.insert_one({"word": "cat", "definition":"Not a dog"})
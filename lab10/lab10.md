## db.definitions.find()
This command returns all of the documents in a collection

## db.definitions.findOne()
This command finds the first matching document in a collection

## db.definitions.find({word: "Capitaland"})
This command finds all documents where the "word" attribute is equal to "Capitaland"

## db.definitions.find({_id: ObjectId("56fe9e22bad6b23cde07b8ce")})
This command finds all objects where the _id is equal to 56fe9e22bad6b23cde07b8ce.  Since _id is by default a unique index, this will return only one document
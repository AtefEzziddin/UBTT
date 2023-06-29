import PyMongoConnection as pymo
from help_function import save_json

simDB = pymo.PyMongoConnect(f"config_reader.json")

#print(simDB.db.list_collection_names())
print("Writing Data in JSON...")

#limit the number of documents for each part of the avatar
limit = 1000
#choose the range of message ids to be visualized
#messageId = {"$gte": 1, "$lte" : 10}
messageId = {"$gte": 100, "$lte" : 110}
#choosing the player
playerId = "1598f50c-a910c040"

#Body info
botBody = simDB.db.Body.find({"playerId": playerId, "messageId": messageId}, {"_id":0, "position":1, "rotation":1})

#start the json files with these keys, relevant for unity. Done for every part.
outPos = {"botPos": []}
outRot = {"botRot": []}

i = 0
for doc in botBody:
    #print(doc["position"])
    #print(doc["rotation"])
    outPos["botPos"].append(doc["position"])
    outRot["botRot"].append(doc["rotation"])
    i+=1
    if i == limit: break
 
save_json(outPos, ".\\botBodyPosition.json")
save_json(outRot, ".\\botBodyRotation.json")
#Body info=======================================

#Head info
botHead = simDB.db.Head.find({"playerId": playerId, "messageId": messageId}, {"_id":0, "position":1, "rotation":1})

outPos = {"botPos": []}
outRot = {"botRot": []}

i = 0
for doc in botHead:
    #print(doc["position"])
    #print(doc["rotation"])
    outPos["botPos"].append(doc["position"])
    outRot["botRot"].append(doc["rotation"])
    i+=1
    if i == limit: break
 
save_json(outPos, ".\\botHeadPosition.json")
save_json(outRot, ".\\botHeadRotation.json")
#Head info=======================================


#rHand info
botRHand = simDB.db.Hand.find({"playerId": playerId, "messageId": messageId, "identifier": "right"}, {"_id":0, "position":1, "rotation":1})

outPos = {"botPos": []}
outRot = {"botRot": []}

i = 0
for doc in botRHand:
    #print(doc["position"])
    #print(doc["rotation"])
    outPos["botPos"].append(doc["position"])
    outRot["botRot"].append(doc["rotation"])
    i+=1
    if i == limit: break
 
save_json(outPos, ".\\botRHandPosition.json")
save_json(outRot, ".\\botRHandRotation.json")
#rHand info=======================================


#lHand info
botLHand = simDB.db.Hand.find({"playerId": playerId, "messageId": messageId, "identifier": "left"}, {"_id":0, "position":1, "rotation":1})

outPos = {"botPos": []}
outRot = {"botRot": []}

i = 0
for doc in botLHand:
    #print(doc["position"])
    #print(doc["rotation"])
    outPos["botPos"].append(doc["position"])
    outRot["botRot"].append(doc["rotation"])
    i+=1
    if i == limit: break
 
save_json(outPos, ".\\botLHandPosition.json")
save_json(outRot, ".\\botLHandRotation.json")
#lHand info=======================================

print("Complete.")
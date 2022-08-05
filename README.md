# unin-unity

UNIN Client for Unity

## APIs

### UninClient->GetItemsForOwner(ownerAddr)

Example response:

```json
[
    {
        "owner": "0xbeedf3d1645bb6468b660754bf33298c0d88c566",
        "type": 1,
        "attrs": [ 15, 0, 0, 15, 0, 70, 0],
        "name": "RedGreenPurple Item",
        "description": "It's red, green, and purple."
    },
    {
        "owner": "0xbeedf3d1645bb6468b660754bf33298c0d88c566",
        "type": 1,
        "attrs": [ 0, 20, 0, 0, 0, 80, 0],
        "name": "Orange and Purple Item",
        "description": "It's orange and purple."
    }
]
```

### UninClient->GetItem(itemId)

Example response:

```json
{
    "owner": "0xbeedf3d1645bb6468b660754bf33298c0d88c566",
    "type": 1,
    "attrs": [ 15, 0, 0, 15, 0, 70, 0],
    "name": "RedGreenPurple Item",
    "description": "It's red, green, and purple."
}
```

## Credit

This would not be possible without https://github.com/Bunny83/SimpleJSON.
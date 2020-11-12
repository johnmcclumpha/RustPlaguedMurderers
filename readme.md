Spawn murderers with random selections of custom attire and skins.

_Note: v2.0.0 requires a new config and is not compatible with config files from earlier versions_

Configure the attire and skins to choose from (or leave the plugin defaults if you want) and when spawning murderers will be fitted out with a random combination of attire and skins.

A great way to really customise the appearance of your murderers without them all looking identical.

![](https://darkaz.com/wp-content/uploads/2020/11/Rust-Plagued-Murderers-v2-2-560x416.jpg)

## Configuration

**Configure which clothing (attire) murderers should wear:**

The attire to dress murderers in is defined in the following areas within the config:

Headwear
Torso
Legs
Shoes
Gloves

Each area contains a list of items to choose from.

A value of "none" can be added to any of these to make them optional (having only a value of "none" will result in no attire being added to this "slot").

_example: (Headwear)_

```
"Headwear": [
  "bucket.helmet",
  "burlap.headwrap",
  "none"
],
```

This would fitout muderers with a random selection of either a bucket helmet, burlap headwrap, or no headwear.

***Which items are available?***

Realistically any of the items that can be "worn" will work, it is recommended to use those listed below:

*Headwear*
```
"bucket.helmet", "burlap.headwrap", "clatter.helmet", "coffeecan.helmet", "deer.skull.mask", "diving.mask", "hat.beenie", "hat.boonie", "hat.cap", "hat.candle", "hat.dragonmask", "hat.miner", "heavy.plate.helmet", "mask.balaclava", "mask.bandana", "nightvisiongoggles", "riot.helmet", "wood.armor.helmet"
```

*Torso*
```
"attire.hide.poncho", "attire.hide.vest", "bone.armor.suit", "burlap.shirt", "heavy.plate.jacket", "hoodie", "jacket", "jacket.snow", "roadsign.jacket", "shirt.collared", "shirt.tanktop", "tshirt", "tshirt.long", "wood.armor.jacket", "none"
```

*Legs*
```
"attire.hide.skirt", "burlap.trousers", "heavy.plate.pants", "pants", "pants.shorts", "wood.armor.pants", "heavy.plate.pants", "roadsign.kilt"
```

*Feet*
```
"burlap.shoes", "attire.hide.boots", "shoes.boots", "boots.frog", "diving.fins"
```

*Hands*
```
"burlap.gloves", "tactical.gloves", "roadsign.gloves", "burlap.gloves.new"
```

**Configure the skins to use for the clothing**

Skins are configured by using the item names (from attire above) and the id of the skins to be utilised.

If no skins are defined for a piece of attire, it will be added with its default skin.

_example:_

```
"Skins": {
  "bucket.helmet": [
    747281863,
    816503044,
    818863931
  ],
  "burlap.headwrap": [
    84948907,
    1076584212,
    811534810
  ]
},
```

This would then randomly select one of the three skins in the relevant group for use when the attire is added to the murderers.

**Enable Glowing Eyes**

Defines whether murderers should spawn with glowing eyes

Glowing Eyes: true/false

## What's Next?

With the release of v2.0.0 the ability to utilise other clothing items has been added, rather than just thelimited set in earlier versions. Some of the ideas moving forward include:

- support other entities (scarecrows, scientists(?), and more)
- support/integration with kits (possibly)

If you have any suggestions or requests, head on over to the support forms for the plugin on uMod and let me know.
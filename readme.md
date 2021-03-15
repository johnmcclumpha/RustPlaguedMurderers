Fit out murderers (and now scarecrows!) with random selections of custom attire, skins and melee weapons.

Configure the attire, skins and weapons to choose from (or leave the plugin defaults if you want) and when spawning murderers will be fitted out with a random combination of attire, skins and weapons.

You can also configure the health (strength) of the murderers and scarecrows.

A great way to really customise the appearance of your murderers without them all looking identical.

![](https://darkaz.com/wp-content/uploads/2020/11/Rust-Plagued-Murderers-v2-2-560x416.jpg)

## Configuration

Settings for scarecrows are configured in the same way as murderers, but in the sections of the config file suffixed with _"(scarecrows)"_.

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
"attire.reindeer.headband", "bucket.helmet", "burlap.headwrap", "clatter.helmet", "coffeecan.helmet", "deer.skull.mask", "diving.mask", "hat.beenie", "hat.boonie", "hat.cap", "hat.candle", "hat.dragonmask", "hat.miner", "heavy.plate.helmet", "mask.balaclava", "mask.bandana", "nightvisiongoggles", "riot.helmet", "santahat", "santabeard", "wood.armor.helmet"
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

_Note: skins will be randomly chosen from the same sets for both Murderers and Scarecrows:_

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

**Configure which melee weapons murderers should be equipped with:**

The weapons to choose from is defined in the Melee Weapon section of the config. A value of "none" can be added to have some murderers spawned without a weapon (although this seems like a weird thing to do, it will work).

_example:_

```
"Melee Weapon": [
  "hatchet",
  "knife.bone",
  "knife.butcher",
  "knife.combat",
  "machete",
  "paddle",
  "salvaged.cleaver",
  "salvaged.sword"
]
```


**Enable Glowing Eyes**

Defines whether murderers and scarecrows should spawn with glowing eyes

Glowing Eyes: true/false

**Set Health for Murderers and Scarecrows**

Sets the health/strength of the murderers and scarecrows, (higher numbers will make them stronger).

Default plugin value for murderers is 100 and 500 for scarecrows.

## Spawning Murderers and Scarecrows

The plugin itself doesn't cause murderers to spwan, there's a couple of ways to get this happening on your server:

1. Update the server config with (or type these into your console):

halloween.enabled "true"
halloween.murdererpopulation "10"
halloween.scarecrowpopulation "5"
 
2. Utilise another plugin to spawn them such as Murderers ot Night Zombies

## Kits

The plugin now supports kits! From v2.4.0 onwards.

Simply add the names of the kits to the configuration file under the relevant sections, and set "Use Kits" to true.

_Note: if "Use Kits" is set to true, then all other config options will be ignored._

## What's Next?

Possible ideas: (nothing is locked in here yet)
- Support for other entities such as scientists
- Ability to randomly clothe HumanNPCs

If you have any suggestions or requests, head on over to the support forms for the plugin on uMod and let me know.
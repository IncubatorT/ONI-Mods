## Geyser - EthanolGas Vent 乙醇蒸气喷孔

**[[简体中文](../README.md)]/[English]**

Adding a geyser that erupts with 500℃ EthanolGas. *SpacedOut!* and The Frosty Planet Pack required (but The Frosty Planet Pack is no need to be enabled), you have to enable *SpacedOut!* (although the geyser itself does not depend on *SpacedOut!*, it will not spawn naturally without *SpacedOut!*)

### Spawning Rules:

One will be guaranteed to spawn on all MarshyMoonlet (52B), including both Vanilla style and *SpacedOut!* style maps.

In addition, in *SpacedOut!* style, it will try to spawn one on the bottom of the map at the Start or Inner (Including Ceres and ShatteredCeres(*SpacedOut!*)), but will not in Vanilla style.

Note: When enabled simultaneously with any other mod that modifies the map generation .yaml configuration file, it may not be generated naturally. You need to manually modify the .yaml file. For specific methods, see below.

### Geyser original parameter configuration:

Rate per cycle during active period: 180~360kg

Temperature: 500℃

Other parameters use default parameters

### GeoTuner configuration:

Use 400kg refined Phosphorus each time, lasts for 4500 seconds

output +20%, temperature +50℃, 5 times max

### Use with other mods that modify the map generation .yaml configuration files：

Using this geyser with other mods that modify the .yaml configuration files in the worldgen directory may prevent it from spawning naturally (the geyser data will be loaded as usual, but it will not spawn naturally).

You need to merge the world generation rules provided by multiple mods that modify the same .yaml file into a single .yaml file. Since this mod makes minor changes to the generation rules, it is recommended to always append the additional rules added by this mod to the .yaml files provided by other mods.

- First, you should find the .yaml file in other mods that overlaps with this mod's worldgen.yaml file and causes the geyser generation rules to be overwritten.
  
  This is usually located in \<mods>\other mods\worldgen\worlds
  
  or \<mods>\other mods\dlc\expansion1 (or dlc2)\worldgen\worlds. 
  
  There may be multiple files in this directory corresponding to different maps. You need to pick out the .yaml file corresponding to the map you want to play.

- Then append the following content to the end of this file. Note that the indentation needs to be consistent with the original file (under the "worldTemplateRules:" field, this field will be written at the end of the file in the official default file)

- ```
    # Geyser - HotEthanol
    - names:
      - poi/magma/geyser_hot_ethanol_with_iron
      - geysers/hot_ethanol
      listRule: TryOne
      priority: 160
      allowedCellsFilter:
        - command: Replace
          zoneTypes: [ MagmaCore ]
        - command: Replace
          tagcommand: DistanceFromTag
          tag: AtDepths
          minDistance: 0
          maxDistance: 1
  ```
  
  This template provides slightly more lenient spawn conditions, and will attempt to spawn a geyser at the bottom of the map, which should basically ensure that most map seeds can be spawned successfully, but you can also modify the spawn conditions to suit your own ideas.

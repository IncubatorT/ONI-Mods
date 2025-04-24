# ONl-Mods

## Geyser - EthanolGas Vent 乙醇蒸气喷孔

[简体中文]/[[English](HotEthanol\README_en.md)]

添加了能够喷出500度气态乙醇的气体喷孔。需要拥有*眼冒金星*！和寒霜行星包（但不必在地图生成时启用寒霜行星包），需要启用*眼冒金星*！（尽管这个间歇泉本身并不依赖于*眼冒金星*！，但不启用*眼冒金星*！时此间歇泉将无自然生成）。

##### 生成规则：

所有湿地小行星（52B）中都将确保生成一个，包括原版风格和*眼冒金星*！风格的地图。
除此之外，在*眼冒金星*！风格地图的起始或临近小行星的地图底部将尝试生成一个（包括小谷神星和小型星群 - 谷神星地幔）。不会在原版风格地图的起始或临近小行星自然生成。
note：与其他任何修改了地图生成.yaml配置文件的模组同时启用时可能无法自然生成，需要手动修改.yaml文件，具体方法参见下文。

##### 间歇泉原始参数配置：

活跃期每周期产率：180~360kg
温度：500℃
其他参数使用默认参数

##### 地质调谐仪配置：

（按原版游戏机制似乎应当使用深渊晶石，但考虑到深渊晶石无法稳定再生，暂定使用精炼磷）

每次使用400kg精炼磷，持续4500秒间歇泉喷发时间
产量+20％，温度+50℃，最多5次

##### 与其他修改地图生成.yaml配置文件的mods同时使用：

与其他修改了worldgen目录中的.yaml配置文件模组同时使用时可能会让此间歇泉无法自然生成（间歇泉的数据照常被游戏加载，只是无法自然生成）。

需要将多个修改了同一个.yaml文件的mods所提供的世界生成规则合并为一个.yaml文件，由于本mod对生成规则的修改较小，所以推荐总是把本mod附加的额外规则追加至其他mod提供的.yaml文件中。

- 首先应该找到其他mod中，与本mod的worldgen.yaml文件重叠导致间歇泉生成规则被覆盖的.yaml文件。
  
  这一般位于\<mods>\other mods\worldgen\worlds
  
  或 \<mods>\other mods\dlc\expansion1（或者dlc2）\worldgen\worlds
  
  路径中，此目录中可能存在多个文件，分别对应不同的地图，需要挑选出你想要游玩的地图所对应的.yaml文件。

- 然后将以下内容追加至此文件的末尾，注意缩进需要与原文件保持一致（”worldTemplateRules:“ 字段中，官方默认文件中此字段会写在文件最后）
  
  ```
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
  
  此模板提供了略微宽泛的生成条件，会尝试在地图底部生成一个间歇泉，基本上能保证大部分地图种子都能顺利生成，你也可以根据自己的想法修改生成条件。

## Build

* 找到路径\<steam游戏根目录>\OxygenNotIncluded\OxygenNotIncluded_Data\Managed，复制此文件夹至本地保存本存储库的路径中。

* 为本项目重新添加引用。删除原引用，将刚才复制的所有.dll文件添加至项目引用。

Target: .Net Framework4.8 或 .Net Framework4.7.1

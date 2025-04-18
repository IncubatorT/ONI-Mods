using STRINGS;

namespace HotEthanol.STRINGS;

public class CREATURES
{
        // Strings.Add($"STRINGS.CREATURES.SPECIES.GEYSER.{GeyserEthanol.HotEthanol.ToUpper()}.NAME", GeyserEthanol.NAME);
        // Strings.Add($"STRINGS.CREATURES.SPECIES.GEYSER.{GeyserEthanol.HotEthanol.ToUpper()}.DESC", GeyserEthanol.DESC);
        public class HOT_ETHANOL
        {
                public static LocString NAME = (LocString) UI.FormatAsLink("Ethanol Vapor Vent", "GeyserGeneric_HOT_ETHANOL");
                public static LocString DESC = (LocString) ("A highly pressurized vent that periodically erupts with boiling " + UI.FormatAsLink("Ethanol", "ETHANOL") + ".");

        }
}
using System.Runtime.CompilerServices;

namespace SurvivalExpanded.Modulation
{
    public static class SEModuleCodesExtension
    {
        static string[] moduleCodes =
        {
            "se-toolpower",
            "se-betterknapping",
            "se-claybreaking",
            "se-entityeffects",
            "se-hiddennutrition",
            "se-misc",
            "se-playerneeds",
            "se-enhancednutrition",
            "se-survivalprogression"
        };

        public static string Code(this SEModuleCodes code)
        {
            return moduleCodes[(int)code];
        }
    }

    public enum SEModuleCodes
    {
        ToolPower = 0,
        BetterKnapping = 1,
        ClayBreaking = 2,
        EntityEffects = 3,
        HiddenNutrition = 4,
        Misc = 5,
        PlayerNeeds = 6,
        EnhancedNutrition = 7,
        SurvivalProgression = 8
    }
}

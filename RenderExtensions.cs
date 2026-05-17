using Microsoft.AspNetCore.Components;

namespace CharacterSheet
{
    public static class RenderExtensions
    {
        private const string IconHtmlTemplate = @"<i class=""ffi {0}""></i>";

        public static MarkupString RenderWithIcons(this string text)
        {
            var result = text.Replace("(D)", GetIconHtml(ForceIconType.Dark));
            result = text.Replace("(Dark)", GetIconHtml(ForceIconType.Dark));
            result = result.Replace("(L)", GetIconHtml(ForceIconType.Light));
            result = result.Replace("(Light)", GetIconHtml(ForceIconType.Light));
            result = result.Replace("(F)", GetIconHtml(ForceIconType.Split));
            result = result.Replace("(Force)", GetIconHtml(ForceIconType.Split));

            result = result.Replace("[S]", GetIconHtml(DieType.Setback));
            result = result.Replace("[Black]", GetIconHtml(DieType.Setback));
            result = result.Replace("[B]", GetIconHtml(DieType.Boost));
            result = result.Replace("[Blue]", GetIconHtml(DieType.Boost));
            result = result.Replace("[A]", GetIconHtml(DieType.Ability));
            result = result.Replace("[Green]", GetIconHtml(DieType.Ability));
            result = result.Replace("[P]", GetIconHtml(DieType.Proficiency));
            result = result.Replace("[Yellow]", GetIconHtml(DieType.Proficiency));
            result = result.Replace("[D]", GetIconHtml(DieType.Difficulty));
            result = result.Replace("[Purple]", GetIconHtml(DieType.Difficulty));
            result = result.Replace("[C]", GetIconHtml(DieType.Challenge));
            result = result.Replace("[Red]", GetIconHtml(DieType.Challenge));
            result = result.Replace("[F]", GetIconHtml(DieType.Force));
            result = result.Replace("[White]", GetIconHtml(DieType.Force));

            result = result.Replace(":A:", GetIconHtml(DieIconType.Advantage));
            result = result.Replace(":Advantage:", GetIconHtml(DieIconType.Advantage));
            result = result.Replace(":D:", GetIconHtml(DieIconType.Despair));
            result = result.Replace(":Despair:", GetIconHtml(DieIconType.Despair));
            result = result.Replace(":F:", GetIconHtml(DieIconType.Failure));
            result = result.Replace(":Failure:", GetIconHtml(DieIconType.Failure));
            result = result.Replace(":S:", GetIconHtml(DieIconType.Success));
            result = result.Replace(":Success:", GetIconHtml(DieIconType.Success));
            result = result.Replace(":Th:", GetIconHtml(DieIconType.Threat));
            result = result.Replace(":Threat:", GetIconHtml(DieIconType.Threat));
            result = result.Replace(":Tr:", GetIconHtml(DieIconType.Trimumph));
            result = result.Replace(":Triumph:", GetIconHtml(DieIconType.Trimumph));

            return (MarkupString) result;
        }

        public static string GetIconHtml(ForceIconType type) => string.Format(IconHtmlTemplate, GetForceIconClass(type));

        public static string GetIconHtml(DieType type, bool outline = false) => string.Format(IconHtmlTemplate, GetDieClass(type, outline));

        public static string GetIconHtml(DieIconType type) => string.Format(IconHtmlTemplate, GetDieIconClass(type));

        public static string GetDieClass(DieType type, bool outline) => (type, outline) switch
        {
            (DieType.Ability, false) => "ffi-d8 ffi-swrpg-ability",
            (DieType.Proficiency, false) => "ffi-d12 ffi-swrpg-proficiency",
            (DieType.Boost, false) => "ffi-d6 ffi-swrpg-boost",
            (DieType.Difficulty, false) => "ffi-d8 ffi-swrpg-difficulty",
            (DieType.Challenge, false) => "ffi-d12 ffi-swrpg-challenge",
            (DieType.Setback, false) => "ffi-d6 ffi-swrpg-setback",
            (DieType.Force, false) => "ffi-d12 colorWhite",

            (DieType.Ability, _) => "ffi-d8-outline ffi-swrpg-ability",
            (DieType.Proficiency, _) => "ffi-d12-outline ffi-swrpg-proficiency",
            (DieType.Boost, _) => "ffi-d6-outline ffi-swrpg-boost",
            (DieType.Difficulty, _) => "ffi-d8-outline ffi-swrpg-difficulty",
            (DieType.Challenge, _) => "ffi-d12-outline ffi-swrpg-challenge",
            (DieType.Setback, _) => "ffi-d6-outline ffi-swrpg-setback",
            (DieType.Force, _) => "ffi-d12-outline ffi-swrpg-force",
            _ => ""
        };

        public static string GetForceIconClass(ForceIconType type) => type switch
        {
            ForceIconType.Dark => "ffi-swrpg-force-outline colorWhite",
            ForceIconType.Light => "ffi-swrpg-force colorWhite",
            ForceIconType.Split => "ffi-swrpg-force-split colorWhite",
            _ => ""
        };

        public static string GetDieIconClass(DieIconType type) => type switch
        {
            DieIconType.Advantage => "ffi-swrpg-advantage",
            DieIconType.Despair => "ffi-swrpg-despair",
            DieIconType.Failure => "ffi-swrpg-failure",
            DieIconType.ForceLight => "ffi-swrpg-force",
            DieIconType.ForceDark => "ffi-swrpg-force-outline",
            DieIconType.Success => "ffi-swrpg-success",
            DieIconType.Threat => "ffi-swrpg-threat",
            DieIconType.Trimumph => "ffi-swrpg-triumph",
            _ => string.Empty
        };

        public enum DieIconType
        {
            Advantage,
            Despair,
            Failure,
            ForceLight,
            ForceDark,
            ForceSplit,
            Success,
            Threat,
            Trimumph
        }

        public enum ForceIconType
        {
            Dark,
            Light,
            Split
        }

        public enum DieType
        {
            Ability,
            Proficiency,
            Boost,
            Difficulty,
            Challenge,
            Setback,
            Force
        }
    }
}

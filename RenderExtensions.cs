using Microsoft.AspNetCore.Components;

namespace CharacterSheet
{
    public static class RenderExtensions
    {
        private const string IconHtmlTemplate = @"<i class=""ffi {0}""></i>";

        public static MarkupString RenderWithIcons(this string text)
        {
            var result = text.Replace("(Dk)", GetIconHtml(ForceIconType.Dark));
            result = result.Replace("(Lt)", GetIconHtml(ForceIconType.Light));
            result = result.Replace("(Sp)", GetIconHtml(ForceIconType.Split));

            result = result.Replace("[Sb]", GetIconHtml(DieType.Setback));
            result = result.Replace("[Bo]", GetIconHtml(DieType.Boost));
            result = result.Replace("[Ab]", GetIconHtml(DieType.Ability));
            result = result.Replace("[Pr]", GetIconHtml(DieType.Proficiency));
            result = result.Replace("[Df]", GetIconHtml(DieType.Difficulty));
            result = result.Replace("[Ch]", GetIconHtml(DieType.Challenge));

            result = result.Replace(":Ad:", GetIconHtml(DieIconType.Despair));
            result = result.Replace(":De:", GetIconHtml(DieIconType.Despair));
            result = result.Replace(":Fa:", GetIconHtml(DieIconType.Despair));
            result = result.Replace(":Su:", GetIconHtml(DieIconType.Despair));
            result = result.Replace(":Th:", GetIconHtml(DieIconType.Despair));
            result = result.Replace(":Tr:", GetIconHtml(DieIconType.Despair));

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
            (DieType.Force, false) => "ffi-d12 ffi-swrpg-force",

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
            ForceIconType.Dark => "ffi-swrpg-force-outline",
            ForceIconType.Light => "ffi-swrpg-force",
            ForceIconType.Split => "ffi-swrpg-force-split",
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

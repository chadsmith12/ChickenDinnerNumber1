using System.ComponentModel.DataAnnotations;

namespace ChickenDinnerNumber1.Enums
{
    public enum PubgRegion
    {
        [Display(Description = "XBox - Asia")]
        XboxAsia,
        [Display(Description = "XBox - Europe")]
        XboxEurope,
        [Display(Description = "XBox - North America")]
        XboxNorthAmerica,
        [Display(Description = "XBox - Oceania")]
        XboxOceania,
        [Display(Description = "PC - Korea/Japan")]
        PcKorea,
        [Display(Description = "PC - North America")]
        PcNorthAmerica,
        [Display(Description = "PC - Europe")]
        PcEurope,
        [Display(Description = "PC - Oceania")]
        PcOceania,
        [Display(Description = "PC - Kakao")]
        PcKakao,
        [Display(Description = "PC - South East Asia")]
        PcSouthEastAsia,
        [Display(Description = "PC - South and Central America")]
        PcSouthCentralAmerica,
        [Display(Description = "PC - Asia")]
        PcAsia
    }

}
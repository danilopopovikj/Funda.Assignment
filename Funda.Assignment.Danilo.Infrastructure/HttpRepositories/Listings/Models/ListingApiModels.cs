namespace Funda.Assignment.Danilo.Infrastructure.HttpRepositories.Listings.Models
{
    public class GetListingsResponse
    {
        public int? AccountStatus { get; set; }
        public bool EmailNotConfirmed { get; set; }
        public bool ValidationFailed { get; set; }
        public object ValidationReport { get; set; } = default!;
        public int? Website { get; set; }
        public Metadata Metadata { get; set; } = default!;
        public List<ApiListing> Objects { get; set; } = default!;
        public Paging Paging { get; set; } = default!;
        public int TotaalAantalObjecten { get; set; }
    }

    public class Metadata
    {
        public string ObjectType { get; set; } = default!;
        public string Omschrijving { get; set; } = default!;
        public string Titel { get; set; } = default!;
    }

    public class ApiListing
    {
        public string AangebodenSindsTekst { get; set; } = default!;
        public string AanmeldDatum { get; set; } = default!;
        public object AantalBeschikbaar { get; set; } = default!;
        public int? AantalKamers { get; set; }
        public object AantalKavels { get; set; } = default!;
        public string Aanvaarding { get; set; } = default!;
        public string Adres { get; set; } = default!;
        public int? Afstand { get; set; }
        public string BronCode { get; set; } = default!;
        public List<object> ChildrenObjects { get; set; } = default!;
        public object DatumAanvaarding { get; set; } = default!;
        public object DatumOndertekeningAkte { get; set; } = default!;
        public string Foto { get; set; } = default!;
        public string FotoLarge { get; set; } = default!;
        public string FotoLargest { get; set; } = default!;
        public string FotoMedium { get; set; } = default!;
        public string FotoSecure { get; set; } = default!;
        public object GewijzigdDatum { get; set; } = default!;
        public int? GlobalId { get; set; }
        public string GroupByObjectType { get; set; } = default!;
        public bool Heeft360GradenFoto { get; set; }
        public bool HeeftBrochure { get; set; }
        public bool HeeftOpenhuizenTopper { get; set; }
        public bool HeeftOverbruggingsgrarantie { get; set; }
        public bool HeeftPlattegrond { get; set; }
        public bool HeeftTophuis { get; set; }
        public bool HeeftVeiling { get; set; }
        public bool HeeftVideo { get; set; }
        public object HuurPrijsTot { get; set; } = default!;
        public object Huurprijs { get; set; } = default!;
        public object HuurprijsFormaat { get; set; } = default!;
        public string Id { get; set; } = default!;
        public object InUnitsVanaf { get; set; } = default!;
        public bool IndProjectObjectType { get; set; }
        public object IndTransactieMakelaarTonen { get; set; } = default!;
        public bool IsSearchable { get; set; }
        public bool IsVerhuurd { get; set; }
        public bool IsVerkocht { get; set; }
        public bool IsVerkochtOfVerhuurd { get; set; }
        public int? Koopprijs { get; set; }
        public string KoopprijsFormaat { get; set; } = default!;
        public int? KoopprijsTot { get; set; }
        public object Land { get; set; } = default!;
        public int MakelaarId { get; set; }
        public string MakelaarNaam { get; set; } = default!;
        public string MobileURL { get; set; } = default!;
        public object Note { get; set; } = default!;
        public List<object> OpenHuis { get; set; } = default!;
        public int? Oppervlakte { get; set; }
        public int? Perceeloppervlakte { get; set; }
        public string Postcode { get; set; } = default!;
        public Prijs Prijs { get; set; } = default!;
        public string PrijsGeformatteerdHtml { get; set; } = default!;
        public string PrijsGeformatteerdTextHuur { get; set; } = default!;
        public string PrijsGeformatteerdTextKoop { get; set; } = default!;
        public List<string> Producten { get; set; } = default!;
        public Project Project { get; set; } = default!;
        public object ProjectNaam { get; set; } = default!;
        public PromoLabel PromoLabel { get; set; } = default!;
        public string PublicatieDatum { get; set; } = default!;
        public int? PublicatieStatus { get; set; }
        public object SavedDate { get; set; } = default!;
        public int? SoortAanbod { get; set; }
        public object StartOplevering { get; set; } = default!;
        public object TimeAgoText { get; set; } = default!;
        public object TransactieAfmeldDatum { get; set; } = default!;
        public object TransactieMakelaarId { get; set; } = default!;
        public object TransactieMakelaarNaam { get; set; } = default!;
        public int? TypeProject { get; set; }
        public string URL { get; set; } = default!;
        public string VerkoopStatus { get; set; } = default!;
        public double WGS84_X { get; set; }
        public double WGS84_Y { get; set; }
        public int? WoonOppervlakteTot { get; set; }
        public int? Woonoppervlakte { get; set; }
        public string Woonplaats { get; set; } = default!;
        public List<int?> ZoekType { get; set; } = default!;
    }

    public class Paging
    {
        public int? AantalPaginas { get; set; }
        public int? HuidigePagina { get; set; }
        public string VolgendeUrl { get; set; } = default!;
        public string VorigeUrl { get; set; } = default!;
    }

    public class Prijs
    {
        public bool GeenExtraKosten { get; set; }
        public string HuurAbbreviation { get; set; } = default!;
        public object Huurprijs { get; set; } = default!;
        public string HuurprijsOpAanvraag { get; set; } = default!;
        public object HuurprijsTot { get; set; } = default!;
        public string KoopAbbreviation { get; set; } = default!;
        public int? Koopprijs { get; set; }
        public string KoopprijsOpAanvraag { get; set; } = default!;
        public int? KoopprijsTot { get; set; }
        public object OriginelePrijs { get; set; } = default!;
        public string VeilingText { get; set; } = default!;
    }

    public class Project
    {
        public object AantalKamersTotEnMet { get; set; } = default!;
        public object AantalKamersVan { get; set; } = default!;
        public object AantalKavels { get; set; } = default!;
        public object Adres { get; set; } = default!;
        public object FriendlyUrl { get; set; } = default!;
        public object GewijzigdDatum { get; set; } = default!;
        public object GlobalId { get; set; } = default!;
        public string HoofdFoto { get; set; } = default!;
        public bool IndIpix { get; set; }
        public bool IndPDF { get; set; }
        public bool IndPlattegrond { get; set; }
        public bool IndTop { get; set; }
        public bool IndVideo { get; set; }
        public string InternalId { get; set; } = default!;
        public object MaxWoonoppervlakte { get; set; } = default!;
        public object MinWoonoppervlakte { get; set; } = default!;
        public object Naam { get; set; } = default!;
        public object Omschrijving { get; set; } = default!;
        public List<object> OpenHuizen { get; set; } = default!;
        public object Plaats { get; set; } = default!;
        public object Prijs { get; set; } = default!;
        public object PrijsGeformatteerd { get; set; } = default!;
        public object PublicatieDatum { get; set; } = default!;
        public int? Type { get; set; }
        public string Woningtypen { get; set; }= default!;
    }

    public class PromoLabel
    {
        public bool HasPromotionLabel { get; set; }
        public List<string> PromotionPhotos { get; set; } = default!;
        public List<string> PromotionPhotosSecure { get; set; } = default!;
        public int? PromotionType { get; set; }
        public int? RibbonColor { get; set; }
        public string RibbonText { get; set; } = default!;
        public string Tagline { get; set; } = default!;
    }
}

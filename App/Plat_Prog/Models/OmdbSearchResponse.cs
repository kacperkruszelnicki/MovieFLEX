namespace Plat_prog.Models
{
    public class OmdbSearchResponse
    {
        public List<Movie> Movies { get; set; } = new();

        public int TotalResults { get; set; }
    }
}

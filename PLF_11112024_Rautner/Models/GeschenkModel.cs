using System.Drawing;

namespace PLF_11112024_Rautner.Models
{
    public class GeschenkModel
    {
        //Getter & Setter
        public int Id { get; set; }
        public string? CreatorName { get; set; }
        public bool Erledigt { get; set; } = false;
        public string Title { get; set; } = string.Empty;
        public string For { get; set; } = string.Empty;
        public string Color { get; set; } = "#ffffff";
    }
}

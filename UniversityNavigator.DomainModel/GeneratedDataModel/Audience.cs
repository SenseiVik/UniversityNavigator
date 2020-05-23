namespace UniversityNavigator.DomainModel.GeneratedDataModel
{
    public partial class Audience
    {
        public string AudienceId { get; set; }
        public int Floor { get; set; }
        public string Building { get; set; }

        public virtual AudienceImage AudienceImage { get; set; }
        public virtual AudienceQuickSearch AudienceQuickSearch { get; set; }
    }
}

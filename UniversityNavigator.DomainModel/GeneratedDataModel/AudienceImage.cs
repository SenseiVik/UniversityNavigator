namespace UniversityNavigator.DomainModel.GeneratedDataModel
{
    public partial class AudienceImage
    {
        public string Audience { get; set; }
        public string ImagePath { get; set; }

        public virtual Audience AudienceNavigation { get; set; }
    }
}

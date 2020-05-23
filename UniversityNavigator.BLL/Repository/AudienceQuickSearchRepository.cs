using UniversityNavigation.Infrastructure.Repository.Implementation;
using UniversityNavigator.DomainModel.GeneratedDataModel;

namespace UniversityNavigator.BLL.Repository
{
    public class AudienceQuickSearchRepository : BaseUniversalRepository<AudienceQuickSearch>
    {
        public AudienceQuickSearchRepository(UniversityNavigatorContext context) : base(context)
        {

        }
    }
}

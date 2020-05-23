using System.Linq;
using UniversityNavigation.Infrastructure.Repository.Implementation;
using UniversityNavigator.DomainModel.GeneratedDataModel;
using Microsoft.EntityFrameworkCore;

namespace UniversityNavigator.BLL.Repository
{
    public class AudienceImageRepository : BaseUniversalRepository<AudienceImage>
    {
        public AudienceImageRepository(UniversityNavigatorContext context) : base(context)
        {

        }

        
    }
}

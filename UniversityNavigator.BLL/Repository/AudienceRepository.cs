using UniversityNavigation.Infrastructure.Repository.Implementation;
using UniversityNavigator.DomainModel.GeneratedDataModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UniversityNavigator.BLL.Repository
{
    public class AudienceRepository : BaseUniversalRepository<Audience>
    {
        public AudienceRepository(UniversityNavigatorContext context) : base(context)
        {

        }

        public override Audience GetByID(object id)
        {
            return this.dbSet.Include(aud => aud.AudienceImage).FirstOrDefault(aud => aud.AudienceId == id.ToString());
        }
    }
}

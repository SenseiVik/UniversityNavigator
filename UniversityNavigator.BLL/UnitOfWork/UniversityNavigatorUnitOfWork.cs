using System;
using System.Collections.Generic;
using System.Text;
using UniversityNavigator.BLL.Repository;
using UniversityNavigator.DomainModel.GeneratedDataModel;

namespace UniversityNavigator.BLL.UnitOfWork
{
    public class UniversityNavigatorUnitOfWork : IDisposable
    {
        #region Private

        private UniversityNavigatorContext context;

        private AudienceRepository audienceRepository;

        private AudienceImageRepository audienceImageRepository;

        private AudienceQuickSearchRepository audienceQuickSearchRepository;

        #endregion

        #region Public

        public AudienceRepository AudienceRepository
        {
            get
            {
                if (this.audienceRepository == null)
                {
                    this.audienceRepository = new AudienceRepository(this.context);
                }

                return this.audienceRepository;
            }
        }

        public AudienceImageRepository AudienceImageRepository
        {
            get
            {
                if (this.audienceImageRepository == null)
                {
                    this.audienceImageRepository = new AudienceImageRepository(this.context);
                }

                return this.audienceImageRepository;
            }
        }

        public AudienceQuickSearchRepository AudienceQuickSearchRepository
        {
            get
            {
                if (this.audienceQuickSearchRepository == null)
                {
                    this.audienceQuickSearchRepository = new AudienceQuickSearchRepository(this.context);
                }

                return this.audienceQuickSearchRepository;
            }
        }

        #endregion

        public UniversityNavigatorUnitOfWork()
        {
            this.context = new UniversityNavigatorContext();
        }

        public void Save()
        {
            this.context?.SaveChanges();
        }

        public void Dispose()
        {
            this.context?.Dispose();
        }
    }
}

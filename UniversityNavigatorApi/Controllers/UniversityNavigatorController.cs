using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using UniversityNavigation.Infrastructure.Repository.Interface;
using UniversityNavigator.BLL.UnitOfWork;
using UniversityNavigator.DomainModel.GeneratedDataModel;
using UniversityNavigatorApi.ViewModel;

namespace UniversityNavigatorApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityNavigatorController : ControllerBase
    {
        #region System

        private IWebHostEnvironment webHostEnvironment;

        #endregion

        private UniversityNavigatorUnitOfWork unitOfWork;

        public UniversityNavigatorController(IWebHostEnvironment environment, IRepositoryUniversal<Audience> repository)
        {
            this.webHostEnvironment = environment;
        }

        [HttpGet]
        [Route("audience")]
        public async Task<IActionResult> GetAudience()
        {
            return await Task.Factory.StartNew<IActionResult>(() =>
            {
                try
                {
                    using (this.unitOfWork = new UniversityNavigatorUnitOfWork())
                    {
                        var rootPath = Directory.GetParent(this.webHostEnvironment.ContentRootPath).FullName;
                        var resultData = this.unitOfWork.AudienceRepository.Get()
                            .Select(aud => new AudienceViewModel
                            {
                                AudienceId = aud.AudienceId,
                                Floor = aud.Floor,
                                Building = aud.Building,
                                ImageBytes = System.IO.File.ReadAllBytes(Path.Combine(rootPath, aud.AudienceImage.ImagePath))
                            }).ToList();

                        return Ok(resultData);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            });
        }

        [HttpGet]
        [Route("audience/{audienceId}")]
        public async Task<IActionResult> GetAudience(string audienceId)
        {
            return await Task.Factory.StartNew<IActionResult>(() =>
            {
                try
                {
                    using (this.unitOfWork = new UniversityNavigatorUnitOfWork())
                    {
                        var rootPath = Directory.GetParent(this.webHostEnvironment.ContentRootPath).FullName;
                        var resultData = this.unitOfWork.AudienceRepository.Get().Where(aud => aud.AudienceId == audienceId)
                            .Select(aud => new AudienceViewModel
                            {
                                AudienceId = aud.AudienceId,
                                Floor = aud.Floor,
                                Building = aud.Building,
                                ImageBytes = System.IO.File.ReadAllBytes(Path.Combine(rootPath, aud.AudienceImage.ImagePath))
                            }).ToList();

                        return Ok(resultData);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            });
        }

        [HttpGet]
        [Route("audienceimage")]
        public async Task<IActionResult> GetAudienceImage()
        {
            return await Task.Factory.StartNew(() =>
            {
                var imageStream = System.IO.File.OpenRead($"D:\\BadianProject\\UniversityNavigator\\UniversityImages\\Building A\\Floor 1.JPG");
                //return this.File(imageStream, "image/jpeg");
                return this.PhysicalFile($"D:\\BadianProject\\UniversityNavigator\\UniversityImages\\Building A\\Floor 1.JPG", "image/jpeg");
            });
        }

        [HttpGet]
        [Route("audienceimage/{audienceId}")]
        public async Task<IActionResult> GetAudienceImage(string audienceId)
        {
            return await Task.Factory.StartNew<IActionResult>(() =>
            {
                using (this.unitOfWork = new UniversityNavigatorUnitOfWork())
                {
                    var rootPath = Directory.GetParent(this.webHostEnvironment.ContentRootPath).FullName;
                    var imagePath = this.unitOfWork.AudienceRepository.GetByID(audienceId)?.AudienceImage?.ImagePath;
                    if (imagePath == null)
                    {
                        return this.NotFound($"Image of audience with (Identifier={audienceId}) not found");
                    }

                    var imageStream = System.IO.File.OpenRead(Path.Combine(rootPath, imagePath));
                    return this.File(imageStream, "image/jpg");
                }
            });
        }
    }
}

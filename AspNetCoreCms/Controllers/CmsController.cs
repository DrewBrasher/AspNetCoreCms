using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreCms.Models;
using AspNetCoreCms.Models.ContentTypes;
using AspNetCoreCms.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace AspNetCoreCms.Controllers
{
    [Authorize(Policy = "SiteAdmin")]
    public class CmsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthorizationService _authorizationService;
        private readonly ILogger _logger;
        private ISiteRepository siteRepository;
        private ISitePageRepository sitePageRepository;
        private ISectionRepository sectionRepository;
        private IArticleRepository articleRepository;
        private IBrandingRepository brandingRepository;
        private ICarouselRepository carouselRepository;
        private ICarouselSlideRepository carouselSlideRepository;
        private IMenuRepository menuRepository;
        private IMenuItemRepository menuItemRepository;
        private Site site;

        public CmsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAuthorizationService authorizationService,
            ILoggerFactory loggerFactory,
            ISiteRepository siteRepository,
            ISitePageRepository sitePageRepository,
            ISectionRepository sectionRepository,
            IArticleRepository articleRepository,
            IBrandingRepository brandingRepository,
            ICarouselRepository carouselRepository,
            ICarouselSlideRepository carouselSlideRepository,
            IMenuRepository menuRepository,
            IMenuItemRepository menuItemRepository,
            Site site
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorizationService = authorizationService;
            _logger = loggerFactory.CreateLogger<CmsController>();
            this.siteRepository = siteRepository;
            this.sitePageRepository = sitePageRepository;
            this.sectionRepository = sectionRepository;
            this.articleRepository = articleRepository;
            this.brandingRepository = brandingRepository;
            this.carouselRepository = carouselRepository;
            this.carouselSlideRepository = carouselSlideRepository;
            this.menuRepository = menuRepository;
            this.menuItemRepository = menuItemRepository;
            this.site = site;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return RedirectToAction("ShowPage", "Home");
        }

        [AllowAnonymous]
        public async Task<IActionResult> ShowPage(string page = "")
        {
            var model = sitePageRepository.GetByUrl(page);

            if (model != null && model.Carousels.Any())
            {
                foreach (var carousel in model.Carousels)
                {
                    if (carousel.Slides.Any())
                    {
                        carousel.Slides.First().CssClass = "active";
                    }
                }
            }

            if (_signInManager.IsSignedIn(User) && await _authorizationService.AuthorizeAsync(User, "SiteAdmin"))
            {
                return model == null ? View("AddPage", new SitePage { Url = page }): View("EditPAge", model);
            }
            else
            {

                return View("ShowPage", model);
            }
        }

        public IActionResult ManageSites()
        {
            var model = siteRepository.List().ToList();
            return View(model);
        }

        public IActionResult SiteSettings(int? id = null)
        {
            var model = id != null ? siteRepository.GetById(id.Value) : new Site();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult SiteSettings(Site formData)
        {
            if(formData.Id < 1)
            {
                siteRepository.Insert(formData);
            }
            else
            {
                var site = siteRepository.GetById(formData.Id);
                site.DomainName = formData.DomainName;
                site.Title = formData.Title;
                site.Theme = formData.Theme;
                siteRepository.Update(site);
            }

            return RedirectToAction(nameof(ManageSites));
        }

        public IActionResult AddPage(SitePage formData)
        {
            if(formData == null)
            {
                return View();
            }
            
            formData.SiteId = site.Id;
            sitePageRepository.Insert(formData);
            return Redirect($"/{formData.Url}");
        }
        
        public IActionResult Save(string id, string data)
        {
            var idComponents = id.Split('.');
            var entityType = idComponents[0];
            var entityProperty = idComponents[1];
            var entityId = int.Parse(idComponents[2]);

            switch (entityType)
            {
                case "article":
                    var article = articleRepository.GetById(entityId);
                    article.Title = entityProperty == "Title" ? data : article.Title;
                    article.Body = entityProperty == "Body" ? data : article.Body;
                    articleRepository.Update(article);
                    break;
                case "slide":
                    var slide = carouselSlideRepository.GetById(entityId);
                    slide.Content = entityProperty == "Content" ? data : slide.Content;
                    slide.Caption = entityProperty == "Caption" ? data : slide.Caption;
                    carouselSlideRepository.Update(slide);
                    break;
                default:
                    return Json(new { succss = false });
            }

            return Json(new { succss = true });
        }

        [HttpPost]
        public IActionResult Delete(string id, string data)
        {
            var idComponents = id.Split('.');
            var entityType = idComponents[0];
            var entityId = int.Parse(idComponents[1]);

            switch (entityType)
            {
                case "article":
                    var article = articleRepository.GetById(entityId);
                    articleRepository.Delete(article);
                    break;
                case "carousel":
                    var carousel = carouselRepository.GetById(entityId);
                    carousel.Slides.Clear();
                    carouselRepository.Update(carousel);
                    carouselRepository.Delete(carousel);
                    break;
                case "slide":
                    var slide = carouselSlideRepository.GetById(entityId);
                    carouselSlideRepository.Delete(slide);
                    break;
                default:
                    return Json(new { succss = false });
            }

            return Json(new { succss = true });
        }

        [HttpPost]
        public IActionResult AddArticle(int site, int page, int section)
        {
            articleRepository.Insert(new Article
            {
                SiteId = site,
                SitePageId = page,
                SectionId = section,
                Title = "New Article",
                Body = "<p>Your content goes here</p>"
            });

            return Json(new { succss = true });
        }

        [HttpPost]
        public IActionResult AddCarousel(int site, int page, int section)
        {
            carouselRepository.Insert(new Carousel
            {
                SiteId = site,
                SitePageId = page,
                SectionId = section,
                Slides = new List<CarouselSlide>
                {
                    new CarouselSlide
                    { 
                        Content = @"<img src=""/images/placeholder.jpg"" alt=""Default Image"" class=""img-responsive"" />",
                        Caption = "<p>Slide caption goes here.</p>"
                    }
                }
            });

            return Json(new { succss = true });
        }

        [HttpPost]
        public IActionResult AddCarouselSlide(int carouselId)
        {
            carouselSlideRepository.Insert(new CarouselSlide
                    {                        
                        CarouselId = carouselId,
                        Content = @"<img src=""/images/placeholder.jpg"" alt=""Default Image"" class=""img-responsive"" />",
                        Caption = "<p>Slide caption goes here.</p>"
                    });

            return Json(new { succss = true });
        }
        
        // TODO: Replace this with some kind of user management UI
        public async Task<IActionResult> AddClaim(string email, string claimType, string claimValue)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user != null)
            {
                await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim(claimType, claimValue));
            }
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

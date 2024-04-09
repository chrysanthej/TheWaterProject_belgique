using Microsoft.AspNetCore.Mvc;
using TheWaterProject.Models;

namespace TheWaterProject.Components
{
    public class ProjectTypesViewComponent : ViewComponent
    {
        private IWaterRepository _waterRepo;
        //Constructor
        public ProjectTypesViewComponent(IWaterRepository temp) { 
            _waterRepo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedProjectType = RouteData?.Values["projectType"];

            var projectTypes = _waterRepo.Projects
                .Select(x => x.ProjectType)
                .Distinct()
                .OrderBy(x => x);

            return View(projectTypes);
        }
    }
}

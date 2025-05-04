using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models;

public class AddProjectViewModel
{

    public string ProjectImage { get; set; } = null!;

    public string ProjectName { get; set; } = null!;

    public string ClientName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string TimeLeft { get; set; } = null!;

    public IEnumerable<string> Members { get; set; } = [];
    public IEnumerable<SelectListItem> Clients { get; set; } = [];

    public IEnumerable<SelectListItem> Users { get; set; } = [];

    public IEnumerable<SelectListItem> Statuses { get; set; } = [];



}

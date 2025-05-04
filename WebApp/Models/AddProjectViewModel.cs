using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models;

public class AddProjectViewModel
{
    public string? ProjectImage { get; set; }

    public string ProjectName { get; set; } = null!;

    public string ClientName { get; set; } = null!;

    public string? Sescription { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
    public decimal? Budget { get; set; }

    public string ClientId { get; set; } = "";

    public string UserId { get; set; } = "";
    public int StatusId { get; set; } = -1;
}

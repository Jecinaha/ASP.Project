using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Models;

public class AddProjectViewModel
{
    public string ProjectImage { get; set; } = null!;

    public string ProjectName { get; set; } = null!;

    public string ClientName { get; set; } = null!;

    public string Sescription { get; set; } = null!;

    public DateTime? StartDate { get; set; } = null;

    public DateTime? EndDate { get; set; } = null;
    public decimal? Budget { get; set; } = null;

    public string ClientId { get; set; } = "";

    public string UserId { get; set; } = "";
    public int StatusId { get; set; } = -1;
}



namespace Data.Models;
public class RepositoryResult<T>
{
    public bool Succeeded { get; set; }
    public int StatusCoode { get; set; }
    public string? Error { get; set; }
    public T? Result { get; set; }
}



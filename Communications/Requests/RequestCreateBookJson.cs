namespace _03_onlinelibrary_api.Communications.Requests;

public class RequestCreateBookJson
{
  public string Title { get; set; } = string.Empty;

  public string Author { get; set; } = string.Empty;

  public string Gender { get; set; } = string.Empty;

  public double Price { get; set; }
}

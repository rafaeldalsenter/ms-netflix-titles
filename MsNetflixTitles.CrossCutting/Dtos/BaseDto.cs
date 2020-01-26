namespace MsNetflixTitles.CrossCutting.Dtos
{
    public abstract class BaseDto
    {
        public string ErrorMessage { get; set; }

        public bool IsValid() => string.IsNullOrWhiteSpace(ErrorMessage);
    }
}
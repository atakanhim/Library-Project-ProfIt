namespace proje_profit.Models
{
    public class AlertModel
    {
        public string? title { get; set; }
        public Icon? icon { get; set; }
    }
    public enum Icon
    {
        success,
        error,
        warning,
        info,
        question

    }
}

namespace StarPizzaShop.Services
{
    public interface IMailService
    {
        void SenMail(string subject, string message);
    }
}
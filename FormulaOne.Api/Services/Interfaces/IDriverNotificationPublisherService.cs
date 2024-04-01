namespace FormulaOne.Api.Services.Interfaces;

public interface IDriverNotificationPublisherService
{
    Task SentNotification(Guid driverId, string driverName);
}
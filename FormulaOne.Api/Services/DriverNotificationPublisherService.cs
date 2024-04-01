using FormulaOne.Api.Services.Interfaces;
using FormulaOne.Entities.Contracts;
using MassTransit;

namespace FormulaOne.Api.Services;

public class DriverNotificationPublisherService : IDriverNotificationPublisherService
{
    private readonly ILogger<DriverNotificationPublisherService> _logger;
    private readonly IPublishEndpoint _publishEndpoint;
    public DriverNotificationPublisherService(ILogger<DriverNotificationPublisherService> logger, IPublishEndpoint publishEndpoint)
    {
        _logger = logger;
        _publishEndpoint = publishEndpoint;
    }
    
    public async Task SentNotification(Guid driverId, string driverName)
    {
        _logger.LogInformation($"Driver Notification for {driverId} sent");
        await _publishEndpoint.Publish(new DriverNotificationRecord(driverId, driverName));
    }
}
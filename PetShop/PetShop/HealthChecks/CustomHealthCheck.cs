﻿using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PetShop.HealthChecks
{
    public class CustomHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = new CancellationToken())
        {
            var isHealthy = true;

            if(isHealthy)
            {
                return Task.FromResult(HealthCheckResult.Healthy("A healthy result."));
            }

            return Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus, "An unheathy result"));
        }
    }
}

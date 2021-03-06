﻿using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;

namespace FakeSurveyGenerator.API.Builders
{
    public static class ForwardedHeadersBuilder
    {
        public static IServiceCollection AddForwardedHeadersConfiguration(this IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

                foreach (var network in Utilities.GetNetworks(NetworkInterfaceType.Ethernet))
                {
                    options.KnownNetworks.Add(network);
                }
            });

            return services;
        }
    }
}

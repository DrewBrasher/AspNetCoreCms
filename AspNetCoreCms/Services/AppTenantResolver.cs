using AspNetCoreCms.Interfaces;
using AspNetCoreCms.Models;
using Microsoft.AspNetCore.Http;
using SaasKit.Multitenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreCms.Services
{
    public class AppTenantResolver : ITenantResolver<Site>
    {
        IEnumerable<Site> sites;
        public AppTenantResolver(ISiteRepository siteRepository)
        {
            // TODO:  Do something better for creating the first site
            if (!siteRepository.List().Any())
            {
                siteRepository.Insert(new Site());
            }
            sites = siteRepository.List();
        }

        public async Task<TenantContext<Site>> ResolveAsync(HttpContext context)
        {
            TenantContext<Site> tenantContext = null;

            var tenant = sites.FirstOrDefault(t =>
                !string.IsNullOrWhiteSpace(t.DomainName) &&
                t.DomainName.Split(',').Any(h => h.Equals(context.Request.Host.Value.ToLower())));

            if (tenant != null)
            {
                tenantContext = new TenantContext<Site>(tenant);
            }
            else
            {
                tenantContext = new TenantContext<Site>(sites.FirstOrDefault());
            }

            return tenantContext;
        }
    }
}

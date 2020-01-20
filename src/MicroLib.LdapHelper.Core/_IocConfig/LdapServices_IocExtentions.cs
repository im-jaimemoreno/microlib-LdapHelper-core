﻿using System;
using System.Collections.Generic;
using System.Text;
using MicroLib.LdapHelper.Core.Models;
using MicroLib.LdapHelper.Core.Services;
using MicroLib.LdapHelper.Core.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroLib.LdapHelper.Core._IocConfig
{
    public static class LdapServices_IocExtentions
    {
        public static void AddLdapHelperServices(this IServiceCollection services, LdapSettings ldapSettings)
        {
            services.AddScoped<ILdapBaseService<LdapUser>, LdapService>();
            services.Configure<LdapSettings>(options =>
            {
                options.ServerName = ldapSettings.ServerName;
                options.ServerPort = ldapSettings.ServerPort;
                options.UseSSL = ldapSettings.UseSSL;
                options.UpnSuffixes = ldapSettings.UpnSuffixes;

                options.Credentials.DomainUserName = ldapSettings.Credentials.DomainUserName;
                options.Credentials.Password = ldapSettings.Credentials.Password;

                options.SearchBase = ldapSettings.SearchBase;
                options.ContainerName = ldapSettings.ContainerName;
                options.DomainName = ldapSettings.DomainName;
                options.DomainDistinguishedName = ldapSettings.DomainDistinguishedName;
            });
        }
    }
}

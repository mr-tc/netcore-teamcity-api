﻿using NetCoreTeamCity.Clients;
using NetCoreTeamCity.Services;

namespace NetCoreTeamCity.Api
{
    public class TeamCity : ITeamCity
    {
        public TeamCity(string host, string userName, string password, bool usingSSL = true)
        {
            var connectionConfig = new TeamCityConnectionSettingsBuilder().ToHost(host).UsingSSL().AsUser(userName, password).Build();
            var bootstrapper = new BootStrapper(connectionConfig);
            Builds = bootstrapper.Get<IBuildService>();
        }

        public IBuildService Builds { get; }
    }
}

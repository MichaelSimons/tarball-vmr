// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace Microsoft.AspNetCore.SignalR.Internal
{
    internal class HubCallerClients : IHubCallerClients
    {
        private readonly string _connectionId;
        private readonly IHubClients _hubClients;
        private readonly string[] _currentConnectionId;

        public HubCallerClients(IHubClients hubClients, string connectionId)
        {
            _connectionId = connectionId;
            _hubClients = hubClients;
            _currentConnectionId = new[] { _connectionId };
        }

        public IClientProxy Caller => _hubClients.Client(_connectionId);

        public IClientProxy Others => _hubClients.AllExcept(_currentConnectionId);

        public IClientProxy All => _hubClients.All;

        public IClientProxy AllExcept(IReadOnlyList<string> excludedConnectionIds)
        {
            return _hubClients.AllExcept(excludedConnectionIds);
        }

        public IClientProxy Client(string connectionId)
        {
            return _hubClients.Client(connectionId);
        }

        public IClientProxy Group(string groupName)
        {
            return _hubClients.Group(groupName);
        }

        public IClientProxy Groups(IReadOnlyList<string> groupNames)
        {
            return _hubClients.Groups(groupNames);
        }

        public IClientProxy OthersInGroup(string groupName)
        {
            return _hubClients.GroupExcept(groupName, _currentConnectionId);
        }

        public IClientProxy GroupExcept(string groupName, IReadOnlyList<string> excludedConnectionIds)
        {
            return _hubClients.GroupExcept(groupName, excludedConnectionIds);
        }

        public IClientProxy User(string userId)
        {
           return _hubClients.User(userId);
        }

        public IClientProxy Clients(IReadOnlyList<string> connectionIds)
        {
            return _hubClients.Clients(connectionIds);
        }

        public IClientProxy Users(IReadOnlyList<string> userIds)
        {
            return _hubClients.Users(userIds);
        }
    }
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

package com.microsoft.signalr;

/**
 * Indicates the state of the {@link HubConnection}.
 */
public enum HubConnectionState {
    CONNECTED,
    DISCONNECTED,
    CONNECTING,
}
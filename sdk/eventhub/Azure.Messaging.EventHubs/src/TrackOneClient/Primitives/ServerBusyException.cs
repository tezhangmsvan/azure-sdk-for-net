﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace TrackOne
{
    /// <summary>
    /// The exception that is thrown when a server is busy.  Callers should wait a while and retry the operation.
    /// </summary>
    internal sealed class ServerBusyException : EventHubsException
    {
        internal ServerBusyException(string message)
            : this(message, null)
        {
        }

        internal ServerBusyException(string message, Exception innerException)
            : base(true, message, innerException)
        {
        }
    }
}

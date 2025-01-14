﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace TrackOne
{
    /// <summary>
    /// Exception for signaling general communication errors related to messaging operations.
    /// </summary>
    internal class EventHubsCommunicationException : EventHubsException
    {
        /// <summary></summary>
        /// <param name="message"></param>
        protected internal EventHubsCommunicationException(string message)
            : this(message, null)
        {
        }

        /// <summary></summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        protected internal EventHubsCommunicationException(string message, Exception innerException)
            : base(true, message, innerException)
        {
        }
    }
}

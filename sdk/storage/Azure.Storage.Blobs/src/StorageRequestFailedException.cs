﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Convert StorageErrors into StorageRequestFailedExceptions.
    /// </summary>
    internal partial class StorageError
    {
        /// <summary>
        /// Additional error information.
        /// </summary>
        public IDictionary<string, string> AdditionalInformation { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Get any additional XML elements for the error.
        /// </summary>
        /// <param name="root">The XML element</param>
        /// <param name="error">The StorageError</param>
        static partial void CustomizeFromXml(XElement root, StorageError error)
        {
            foreach (XElement element in root.Elements())
            {
                switch (element.Name.LocalName)
                {
                    case Constants.Xml.Code:
                    case Constants.Xml.Message:
                        continue;
                    default:
                        error.AdditionalInformation[element.Name.LocalName] = element.Value;
                        break;
                }
            }
        }

        /// <summary>
        /// Create an exception corresponding to the StorageError.
        /// </summary>
        /// <param name="response">The failed response.</param>
        /// <returns>A StorageRequestFailedException.</returns>
        public Exception CreateException(Azure.Response response)
            => new StorageRequestFailedException(response, Message, null, Code, AdditionalInformation);
    }

    /// <summary>
    /// Convert ConditionNotMetErrors into StorageRequestFailedExceptions.
    /// </summary>
    internal partial class ConditionNotMetError
    {
        /// <summary>
        /// Create an exception corresponding to the ConditionNotMetError.
        /// </summary>
        /// <param name="response">The failed response.</param>
        /// <returns>A StorageRequestFailedException.</returns>
        public Exception CreateException(Azure.Response response)
            => new StorageRequestFailedException(response, null, null, ErrorCode);
    }

    /// <summary>
    /// Convert DataLakeStorageError into StorageRequestFailedExceptions.
    /// </summary>
    internal partial class DataLakeStorageError
    {
        /// <summary>
        /// Create an exception corresponding to the DataLakeStorageError.
        /// </summary>
        /// <param name="response">The failed response.</param>
        /// <returns>A StorageRequestFailedException.</returns>
        public Exception CreateException(Azure.Response response)
            => new StorageRequestFailedException(response, Error.Message, null, Error.Code);
    }
}

﻿namespace XPlat.API.Storage
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines an interface for an application storage item.
    /// </summary>
    public interface IAppStorageItem
    {
        /// <summary>
        /// Gets the date the item was created.
        /// </summary>
        DateTime DateCreated { get; }

        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the full path to the item.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Gets a value indicating whether the item exists.
        /// </summary>
        bool Exists { get; }

        /// <summary>
        /// Gets the parent folder for the item.
        /// </summary>
        IAppFolder Parent { get; }

        /// <summary>
        /// Renames the current item.
        /// </summary>
        /// <param name="desiredName">
        /// The desired, new name of the item.
        /// </param>
        /// <returns>
        /// An object that is used to manage the asynchronous operation.
        /// </returns>
        Task RenameAsync(string desiredName);

        /// <summary>
        /// Renames the current item. This method also specifies what to do if an existing item in the current item's location has the same name.
        /// </summary>
        /// <param name="desiredName">
        /// The desired, new name of the current item. If there is an existing item in the current item's location that already has the specified desiredName, the specified NameCollisionOption determines how Windows responds to the conflict.
        /// </param>
        /// <param name="option">
        /// The enum value that determines how Windows responds if the desiredName is the same as the name of an existing item in the current item's location.
        /// </param>
        /// <returns>
        /// An object that is used to manage the asynchronous operation.
        /// </returns>
        Task RenameAsync(string desiredName, FileStoreNameCollisionOption option);

        /// <summary>
        /// Deletes the current item.
        /// </summary>
        /// <returns>
        /// An object that is used to manage the asynchronous operation.
        /// </returns>
        Task DeleteAsync();

        /// <summary>
        /// Gets the properties of the current item (like a file or folder).
        /// </summary>
        /// <returns>
        /// When this method completes successfully, it returns the properties of the current item as a Dictionary.
        /// </returns>
        Task<IDictionary<string, object>> GetPropertiesAsync();

        /// <summary>
        /// Determines whether the current IAppStorageItem matches the specified FileStoreItemTypes value.
        /// </summary>
        /// <param name="type">
        /// The value to match against.
        /// </param>
        /// <returns>
        /// True if the IAppStorageItem matches the specified value; otherwise false.
        /// </returns>
        bool IsOfType(FileStoreItemTypes type);
    }
}
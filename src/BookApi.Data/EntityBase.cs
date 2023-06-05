﻿// Copyright (c) Dennis Shevtsov. All rights reserved.
// Licensed under the MIT License.
// See LICENSE in the project root for license information.

namespace BookApi.Data
{
  /// <summary>Represents an entity base.</summary>
  public abstract class EntityBase : IUpdatable<object>
  {
    /// <summary>Gets an object that represents an ID of an entity.</summary>
    public Guid Id { get; protected set; }

    /// <summary>Updates this entity.</summary>
    /// <param name="newEntity">An object that represents an entity from which this entity should be updated.</param>
    /// <param name="properties">An object that represents a collection of properties to update.</param>
    public void Update(object newEntity, IEnumerable<string> properties)
    {
      foreach (var property in properties)
      {
          Update(newEntity, property);
      }
    }

    protected virtual void Update(object newEntity, string property)
    {
      var originalProperty = GetType().GetProperty(property)!;
      var newProperty = newEntity.GetType().GetProperty(property)!;

      var originalValue = originalProperty.GetValue(this);
      var newValue = newProperty.GetValue(newEntity);

      if (!object.Equals(originalValue, newValue))
      {
        originalProperty.SetValue(this, newValue);
      }
    }

    /// <summary>Creates a copy of an entity.</summary>
    /// <param name="entity">An object that represents an entity to copy.</param>
    /// <returns>An object that represents an instance of an entity copy.</returns>
    /// <exception cref="System.NotSupportedException">Throws if there is no such entity.</exception>
    public static T2 Create<T1, T2>(T1 entity) where T2 : EntityBase, T1
    {
      ArgumentNullException.ThrowIfNull(entity);

      if (entity.GetType() == typeof(T2))
      {
        return (T2)entity;
      }

      return (T2)typeof(T2).GetConstructor(new[] { typeof(T1) })!
                           .Invoke(new object[] { entity! });
    }
  }
}
﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SiliconStudio.Presentation.Collections
{
    /// <summary>
    /// A class that wraps an instance of the <see cref="ObservableSet{T}"/> class and implement the <see cref="IList"/> interface.
    /// In some scenarii, <see cref="IList"/> does not support range changes on the collection (Especially when bound to a ListCollectionView).
    /// This is why the <see cref="ObservableSet{T}"/> class does not implement this interface directly. However this wrapper class can be used
    /// when the <see cref="IList"/> interface is required.
    /// </summary>
    /// <typeparam name="T">The type of item contained in the <see cref="ObservableSet{T}"/>.</typeparam>
    public class NonGenericObservableSetWrapper<T> : NonGenericObservableCollectionWrapper<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NonGenericObservableSetWrapper{T}"/> class.
        /// </summary>
        /// <param name="list">The <see cref="ObservableSet{T}"/> to wrap.</param>
        public NonGenericObservableSetWrapper(ObservableSet<T> list)
            : base(list)
        {
        }

        public void AddRange(IEnumerable values)
        {
            ((ObservableSet<T>)List).AddRange(values.Cast<T>());
        }

        public void AddRange(IEnumerable<T> values)
        {
            ((ObservableSet<T>)List).AddRange(values);
        }
    }
}
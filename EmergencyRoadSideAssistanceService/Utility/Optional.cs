namespace EmergencyRoadSideAssistanceService.Utility
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// An value which may or may not be usable.
    /// </summary>
    ///
    /// <remarks>
    /// This type is similar to <see cref="System.Nullable{T}"/> except that
    /// <typeparamref name="T"/> may be any type, not just structs, it omits all
    /// garbage-creating functionality like
    /// <see cref="System.Nullable{T}.Equals(object)"/>, it allows setting and
    /// resetting the value, its constructor takes a default parameter, getting
    /// <see cref="Value"/> and casting to <typeparamref name="T"/> only throw an
    /// exception when <code>UNITY_ASSERTIONS</code> is defined, and it includes
    /// overloaded operators for bool, true, and false.
    /// </remarks>
    /// 
    /// <typeparam name="T">
    /// Type of value
    /// </typeparam>
    ///
    /// <author>
    /// https://JacksonDunstan.com/articles/5372
    /// </author>
    ///
    /// <license>
    /// MIT
    /// </license>
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Optional<T>
    {
        /// <summary>
        /// If a value is contained
        /// </summary>
        private bool m_HasValue;

        /// <summary>
        /// The contained value
        /// </summary>
        private T m_Value;

        /// <summary>
        /// Construct with a usable value
        /// </summary>
        /// 
        /// <param name="value">
        /// Usable value
        /// </param>
        public Optional(T value = default(T))
        {
            m_HasValue = true;
            m_Value = value;
        }

        /// <summary>
        /// If there is a usable value
        /// </summary>
        public bool HasValue
        {
            get
            {
                return m_HasValue;
            }
        }

        /// <summary>
        /// Get or set the usable value. When assertions are enabled via
        /// UNITY_ASSERTIONS, getting it when there is no usable value
        /// results in an exception.
        /// </summary>
        public T Value
        {
            get
            {
#if UNITY_ASSERTIONS
            if (!m_HasValue)
            {
                throw new InvalidOperationException(
                    "Optional<T> object must have a value.");
            }
#endif
                return m_Value;
            }
            set
            {
                m_HasValue = true;
                m_Value = value;
            }
        }

        /// <summary>
        /// Get the usable value or the default value if there is no usable value
        /// </summary>
        /// 
        /// <returns>
        /// The usable value or the default value if there is no usable value.
        /// </returns>
        public T GetValueOrDefault()
        {
            return m_Value;
        }

        /// <summary>
        /// Get the usable value or a default value if there is no usable value
        /// </summary>
        /// 
        /// <param name="defaultValue">
        /// Value to return if there is no usable value
        /// </param>
        /// 
        /// <returns>
        /// The usable value or <paramref name="defaultValue"/> if there is no
        /// usable value.
        /// </returns>
        public T GetValueOrDefault(T defaultValue)
        {
            return m_HasValue ? m_Value : defaultValue;
        }

        /// <summary>
        /// Clear any usable value
        /// </summary>
        public void Reset()
        {
            m_HasValue = false;
            m_Value = default(T);
        }

        /// <summary>
        /// Get or set the usable value. When assertions are enabled via
        /// UNITY_ASSERTIONS and there is no usable value, an exception is thrown.
        /// </summary>
        /// 
        /// <param name="optional">
        /// Value to convert
        /// </param>
        /// 
        /// <returns>
        /// True if there is a usable value. Otherwise false.
        /// </returns>
        public static explicit operator T(Optional<T> optional)
        {
            return optional.Value;
        }

        /// <summary>
        /// Construct with a usable value
        /// </summary>
        /// 
        /// <param name="value">
        /// Usable value
        /// </param>
        public static explicit operator Optional<T>(T value)
        {
            return new Optional<T>(value);
        }

        /// <summary>
        /// Convert to a bool: (bool)opt
        /// </summary>
        /// 
        /// <param name="optional">
        /// Value to convert
        /// </param>
        /// 
        /// <returns>
        /// True if there is a usable value. Otherwise false.
        /// </returns>
        public static implicit operator bool(Optional<T> optional)
        {
            return optional.m_HasValue;
        }

        /// <summary>
        /// Convert to truth: if (opt)
        /// </summary>
        /// 
        /// <param name="optional">
        /// Value to convert
        /// </param>
        /// 
        /// <returns>
        /// True if there is a usable value. Otherwise false.
        /// </returns>
        public static bool operator true(Optional<T> optional)
        {
            return optional.m_HasValue;
        }

        /// <summary>
        /// Convert to falsehood: if (!opt)
        /// </summary>
        /// 
        /// <param name="optional">
        /// Value to convert
        /// </param>
        /// 
        /// <returns>
        /// False if there is a usable value. Otherwise true.
        /// </returns>
        public static bool operator false(Optional<T> optional)
        {
            return !optional.m_HasValue;
        }
    }
}

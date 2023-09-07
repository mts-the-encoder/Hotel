﻿using System.Globalization;
using static System.String;

namespace Data.Exceptions;

public class ValidationException : Exception
    {
        public dynamic? validationObject { get; set; }

        public ValidationException() : base() { }

        public ValidationException(string message) : base(message) { }

        public ValidationException(string message, params object[] args) : base(Format(CultureInfo.CurrentCulture, message, args))
        {
        }

        public ValidationException(string message, dynamic fields) : base(message)
        {
            validationObject = fields;
        }
    }
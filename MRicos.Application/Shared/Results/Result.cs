using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace MRicos.Application.Shared.Results
{
    public class Result
    {
        protected Result(bool isSucess, Error error)
        {
            switch (isSucess)
            {
                case true when error != Error.None:
                    throw new InvalidOperationException("A successful result cannot contain an error.");
                case false when error == Error.None:
                    throw new InvalidOperationException("A failed result must contain an error.");

                default:
                    IsSuccess = isSucess;
                    Error = error;
                    break;
            }
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }
        public static Result Success() => new(true, Error.None);
        public static Result Failure(Error error) => new(false, error);

        public static Result<T> Success<T>(T value) => new(true, Error.None, value);
        public static Result<T> Failure<T>(Error error) => new(false, error, default);

        public static Result<T> Create<T>(T? value) =>
            value is not null
                ? Success(value)
                : Failure<T>(Error.NullValue);

    }
    public class Result<T> : Result
    {
        protected internal Result(bool isSucess, Error error, T? value)
            : base(isSucess, error)
        {
            Value = value;
        }

        public T? Value { get; }
    }
}
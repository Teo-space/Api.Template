public record Result<T>
{
    public required T Value { get; init; }
    public required bool Success { get; init; }
    public required string Type { get; init; }
    public required string Detail { get; init; }
    public required IReadOnlyCollection<FieldError> Errors { get; init; } = new List<FieldError>();



    public static implicit operator T(Result<T> Result) => Result.Value;
    public static explicit operator Result<T>(T o) => Results.Ok<T>(o);

    public static implicit operator string(Result<T> Result)
        => $"Result<{typeof(T)}>(Success:{Result.Success}, Type: {Result.Type}) Value: {Result?.Value?.ToString()}";

    public override string ToString()
    {
        return @$"Result<{typeof(T)}>()
Type: {this.Type}
Success:{this.Success}
Detail: {this.Detail}
Value: {this?.Value?.ToString()}";
    }
}

public record Result
{
    public required bool Success { get; init; }
    public required string Type { get; init; }
    public required string Detail { get; init; }
    public required IReadOnlyCollection<FieldError> Errors { get; init; } = new List<FieldError>();

    public static implicit operator string(Result Result)
        => $"Result(Success:{Result.Success}, Type: {Result.Type}, Detail: {Result.Detail}, Errors: {Result.Errors.Count}) ";

    public override string ToString()
    {
        return @$"Result
Type: {this.Type}
Success:{this.Success}
Detail: {this.Detail}
Errors: {this.Errors.Count}";
    }
}
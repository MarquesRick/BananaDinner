using ErrorOr;

namespace BananaDinner.Domain.Common.Errors;

/// <summary>
/// Partial class for errors on ErrorOr for Authentication.
/// </summary>
public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCredentials",
            description: "Invalid credentials.");
    }
}

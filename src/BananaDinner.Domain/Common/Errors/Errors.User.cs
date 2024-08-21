using ErrorOr;

namespace BananaDinner.Domain.Common.Errors;

/// <summary>
/// Partial class for errors on ErrorOr for User Duplicate.
/// </summary>
public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email is already in use.");
    }
}

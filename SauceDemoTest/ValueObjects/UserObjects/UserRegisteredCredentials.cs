using SauceDemoTest.Models;

namespace SauceDemoTest.ValueObjects.UserObjects;

public static class UserRegisteredCredentials
{
    public static readonly UserCredentials UserCredentialsStandard =
        new UserCredentials("standard_user", "secret_sauce", "standard", "user", "345678");
    public static readonly UserCredentials UserCredentialsLocked =
        new UserCredentials("locked_out_user", "secret_sauce", "standard", "user", "345678");
    public static readonly UserCredentials UserCredentialsProblem =
        new UserCredentials("problem_user", "secret_sauce", "standard", "user", "345678");
}
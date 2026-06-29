namespace SauceDemoFramework.TestData
{
    public class LoginData
    {
        public static object[] UC1 =
        {
            new object[] { "", "", "Epic sadface: Username is required" }
        };

        public static object[] UC2 =
        {
            new object[] { "standard_user", "", "Epic sadface: Password is required" }
        };

        public static object[] UC3 =
        {
            new object[] { "standard_user", "secret_sauce" },
            new object[] { "problem_user", "secret_sauce" }
        };
    }
}
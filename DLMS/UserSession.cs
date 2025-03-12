using DLMS_Business;

namespace DLMS
{
    public static class UserSession
    {
        public static User LoggedInUser { get; set; }
        public static bool IsLoggedIn { get; set; } = false;
    }
}

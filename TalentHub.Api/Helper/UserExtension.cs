using System.Security.Claims;

namespace TalentHub.Api.Helpers
{
    public static class UserExtensions
    {
        public static bool IsAuthorizedForAcademy(this ClaimsPrincipal user, Guid academyId)
        {
            var academyIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            // Check if same academy OR Admin
            return academyIdClaim == academyId.ToString() || user.IsInRole("Admin");
        }
    }
}

using Microsoft.AspNetCore.Identity;
using FinRust.Application.Common.Models;
using System.Linq;

namespace FinRust.Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}
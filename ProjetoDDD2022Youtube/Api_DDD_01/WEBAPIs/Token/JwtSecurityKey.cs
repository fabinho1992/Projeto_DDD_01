using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WeBAPIs.Token
{
    public class JwtSecurityKey // Chave do token
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)); 
        }
    }
}

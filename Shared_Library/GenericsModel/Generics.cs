using Shared_Library.Model;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Shared_Library.GenericsModel
{
    public static class Generics
    {
        public static ClaimsPrincipal SetClaimPrincipal(UserSession model)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(
                new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, model.Id!),
                    new(ClaimTypes.Name, model.Name!),
                    new(ClaimTypes.Email, model.Email!),
                    new(ClaimTypes.Role, model.Role!),
                }, "JwtAuth"));
        }

        public static UserSession GetClaimsFromToken(string jwtToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);
            var claims = token.Claims;

            string Id = claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value!;
            string Name = claims.First(c => c.Type == ClaimTypes.Name).Value!;
            string Email = claims.First(c => c.Type == ClaimTypes.Email).Value!;
            string Role = claims.First(c => c.Type == ClaimTypes.Role).Value!;

            return new UserSession(Id, Name, Email, Role);
        }

        public static JsonSerializerOptions JsonOptions()
        {
            var options = new JsonSerializerOptions();
            options.AllowTrailingCommas = true;
            options.PropertyNameCaseInsensitive = true;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

            // Additional handling for unmapped members
            options.Converters.Add(new UnmappedMemberConverter());

            return options;
        }

        public static string SerializeObj<T>(T modelObject) => JsonSerializer.Serialize(modelObject, JsonOptions());
        public static T DeserializeJsonString<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString, JsonOptions())!;
        public static IList<T> DeserializeJsonStringList<T>(string jsonString) => JsonSerializer.Deserialize<IList<T>>(jsonString, JsonOptions())!;

        public static StringContent GenerateStringContent(string serialiazedObj) => new(serialiazedObj, System.Text.Encoding.UTF8, "application/json");

        public class UnmappedMemberConverter : JsonConverter<object>
        {
            public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                // Skip the current JSON token
                reader.Skip();
                return null; // Return null or throw an exception based on your requirements
            }

            public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
            {
                // Do nothing or throw an exception based on your requirements
            }
        }
    }
}

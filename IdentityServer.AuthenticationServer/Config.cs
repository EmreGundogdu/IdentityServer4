using IdentityServer4.Models;

namespace IdentityServer.AuthenticationServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("resource_api1")
                {
                    Scopes={"api1.read"},
                    ApiSecrets = new[]{new Secret("secretapi1.".Sha256())} //Introspection Endpoint ile giriş yaparken kullanacağımız password için
                },
                new ApiResource("resource_api2")
                {
                    Scopes={"api2.write","api2.update"},
                     ApiSecrets = new[]{new Secret("secretapi2.".Sha256())} //Introspection Endpoint ile giriş yaparken kullanacağımız password için
                }
            };
        }
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("api1.read","API 1 için okuma izni"),
                new ApiScope("api1.write","API 1 için yazma izni"),
                new ApiScope("api1.update","API 1 için update izni"),
                 new ApiScope("api2.read","API 2 için okuma izni"),
                new ApiScope("api2.write","API 2 için yazma izni"),
                new ApiScope("api2.update","API 2 için update izni")
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client()
                {
                    ClientId="Client1",
                    ClientName = "Client 1 app uygulaması",
                    ClientSecrets=new[]{new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={ "api1.read", "api1.write", "api1.update" }
                },
                new Client()
                {
                    ClientId="Client2",
                    ClientName = "Client 2 app uygulaması",
                    ClientSecrets=new[]{new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={ "api2.read","api2.write","api2.update"}
                },
                 new Client()
                {
                    ClientId="Client3",
                    ClientName = "Client 3 app uygulaması",
                    ClientSecrets=new[]{new Secret("secret".Sha256())},
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    AllowedScopes={ "api1.update", "api1.write", "api2.write","api2.update"}
                }
            };
        }
    }
}

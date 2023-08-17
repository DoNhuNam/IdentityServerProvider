using IdentityServer4.Models;
using IdentityServer4;

namespace IdentityServerProvider.Configuration
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResource()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new[]
            {
                new ApiResource()
                {
                    Name = "api",
                    DisplayName = "Api",
                    //Scopes = ,
                    //UserClaims = ,
                    //ApiSecrets = 
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>
            {
                new ApiScope("full_access", "Full Access")
            };
        }

        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientUrls = null)
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "webportalMVC",
                    ClientSecrets =
                        {
                            new Secret("secret".Sha256())
                        },
                    RequireClientSecret = true,
                    ClientName = "Web App MVC",
                    Description = "",
                    //ClientUri = "",
                    //LogoUri = "",
                    RequireConsent = false,
                    //AllowRememberConsent = true,
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    //AllowPlainTextPkce = false,
                    //RequireRequestObject = false,
                    AllowAccessTokensViaBrowser = true,
                    RedirectUris =
                        {
                           "https://localhost:5002/signin-oidc"
                        },
                    PostLogoutRedirectUris =
                        {
                           "https://localhost:5002/signout-callback-oidc"
                        },
                  //  FrontChannelLogoutUri = "https://localhost:5002/signout-oidc",
                    //FrontChannelLogoutSessionRequired = false,
                    //BackChannelLogoutUri = "",
                    //BackChannelLogoutSessionRequired = true,
                    AllowOfflineAccess = true,
                    AllowedScopes =  new List<string>
                        {
                            IdentityServerConstants.StandardScopes.OpenId,
                            IdentityServerConstants.StandardScopes.Profile,
                            IdentityServerConstants.StandardScopes.OfflineAccess,
                            "full_access",
                        },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    //IdentityTokenLifetime = ,
                    //AllowedIdentityTokenSigningAlgorithms = ,
                    //AccessTokenLifetime = ,
                    //AuthorizationCodeLifetime = ,
                    //AbsoluteRefreshTokenLifetime = ,
                    //SlidingRefreshTokenLifetime = ,
                    //ConsentLifetime = ,
                    //RefreshTokenUsage = ,
                    //UpdateAccessTokenClaimsOnRefresh = false,
                    //RefreshTokenExpiration = ,
                   // AccessTokenType = ,
                    //EnableLocalLogin = true,
                    //IdentityProviderRestrictions = ,
                    //IncludeJwtId = ,
                    //Claims = ,
                    //AlwaysSendClientClaims = ,
                    //ClientClaimsPrefix = ,
                    //PairWiseSubjectSalt = ,
                    //UserSsoLifetime = ,
                    //UserCodeType = ,
                    //DeviceCodeLifetime = ,
                    //AllowedCorsOrigins ={ "https://localhost:5002" },
                    //Properties = 


                    //ClientId = "app",
                    //ClientSecrets = { new Secret("secret".Sha256()) },

                    //AllowedGrantTypes = GrantTypes.Code,
                    //RequireConsent = false,
                    //RequirePkce = true,
                    //AllowOfflineAccess = true,

                    //// where to redirect to after login
                    //RedirectUris = { "https://localhost:5002/signin-oidc" },

                    //// where to redirect to after logout
                    //PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                    //AllowedScopes = new List<string>
                    //{
                    //    IdentityServerConstants.StandardScopes.OpenId,
                    //    IdentityServerConstants.StandardScopes.Profile,
                    //    IdentityServerConstants.StandardScopes.OfflineAccess,
                    //    "full_access"
                    //}
                },

                new Client
                {
                    ClientId = "identity_swaggerui",
                    ClientName = "Identity UI",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,
                    RequireConsent = false,
                    RedirectUris = { "http://localhost:5000/swagger/oauth2-redirect.html" },
                    PostLogoutRedirectUris = { "http://localhost:5000/swagger/oauth2-redirect.html" },
                    AllowedCorsOrigins = { "http://localhost:5000" },
                    AllowedScopes =
                    {
                             IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                            "full_access",
                    },
                }

                //new Client
                //{
                //    ClientId = "exam_web_app",
                //    ClientName = "Exam Web App Client",
                //    ClientSecrets = new List<Secret>
                //        {
                //            new Secret("secret".Sha256())
                //        },
                //    ClientUri = $"{clientUrls["ExamWebApp"]}", // public uri of the client
                //    AllowedCorsOrigins = { clientUrls["ExamWebApp"] },
                //    AllowedGrantTypes = GrantTypes.Code, //flow Authorize code
                //    AllowAccessTokensViaBrowser = false,
                //    RequireConsent = false,
                //    AllowOfflineAccess = true,
                //    AlwaysIncludeUserClaimsInIdToken = true,
                //    RedirectUris = new List<string>
                //        {
                //            $"{clientUrls["ExamWebApp"]}/authentication/login-callback"
                //        },
                //    PostLogoutRedirectUris = new List<string>
                //        {
                //            $"{clientUrls["ExamWebApp"]}/authentication/logout-callback"
                //        },
                //    AllowedScopes = new List<string>
                //        {
                //            IdentityServerConstants.StandardScopes.OpenId,
                //            IdentityServerConstants.StandardScopes.Profile,
                //            IdentityServerConstants.StandardScopes.OfflineAccess,
                //            "full_access",
                //        },
                //    AccessTokenLifetime = 60 * 60 * 2, // 2 hours
                //    IdentityTokenLifetime = 60 * 60 * 2, // 2 hours
                //    RequireClientSecret = true, // !Important for authorization
                    

                //},

                //new Client
                //{
                //    ClientId = "exam_web_admin",
                //    ClientName = "Exam Web Admin Client",
                //    ClientSecrets = new List<Secret>
                //        {
                //            new Secret("secret".Sha256())
                //        },
                //    ClientUri = $"{clientUrls["ExamWebAdmin"]}", // public uri of the client
                //    AllowedCorsOrigins = { clientUrls["ExamWebAdmin"] },
                //    AllowedGrantTypes = GrantTypes.Code,
                //    AllowAccessTokensViaBrowser = false,
                //    RequireConsent = false,
                //    AllowOfflineAccess = true,
                //    AlwaysIncludeUserClaimsInIdToken = true,
                //    RedirectUris = new List<string>
                //        {
                //            $"{clientUrls["ExamWebAdmin"]}/authentication/login-callback"
                //        },
                //    PostLogoutRedirectUris = new List<string>
                //        {
                //            $"{clientUrls["ExamWebAdmin"]}/authentication/logout-callback"
                //        },
                //    AllowedScopes = new List<string>
                //        {
                //            IdentityServerConstants.StandardScopes.OpenId,
                //            IdentityServerConstants.StandardScopes.Profile,
                //            IdentityServerConstants.StandardScopes.OfflineAccess,
                //            "full_access",
                //        },
                //    AccessTokenLifetime = 60 * 60 * 2, // 2 hours
                //    IdentityTokenLifetime = 60 * 60 * 2, // 2 hours
                //    RequireClientSecret = true, // !Important for authorization

                //},

                
            };
        }
    }
}

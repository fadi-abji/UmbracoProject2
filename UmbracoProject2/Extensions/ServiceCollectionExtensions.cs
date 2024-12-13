using Blazor.Analytics;
using Blazr.RenderState;
using Blazr.RenderState.Server;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Reflection;
using System.Security.Claims;
using Telerik.Blazor.Services;
using UmbracoProject2.Services;
using WebOptimizer;
//using Wengine.Base.Extensions;
using Wengine.Business;
using Wengine.Business.Helpers;
using Wengine.Business.Identity.Providers;
using Wengine.Business.Messaging.Api;
using Wengine.Business.Messaging.Hubs;
using Wengine.Business.Messaging.Interface;
using Wengine.Business.Messaging.Services;
using Wengine.Business.ServersideApi;
using Wengine.Business.ServerSideApi;
using Wengine.Business.Services;
using Wengine.Business.Settings;
using Wengine.Business.Templates;
using Wengine.Business.WebWorkers;
using Wengine.Components.Base;
using Wengine.Components.Base.Extensions;
using Wengine.Components.Base.Options;
using Wengine.Components.Base.Services;
using Wengine.Components.Base.TelerikResources;
using Wengine.Components.Core;
using Wengine.Core;
using Wengine.Core.Api;
using Wengine.Core.Culture.Api;
using Wengine.Core.Identity;
using Wengine.Core.Identity.Api;
using Wengine.Core.Internationalization;
using Wengine.Core.Messaging.Api;
using Wengine.Core.Messaging.Interface;
using Wengine.Core.Messaging.Services;
using Wengine.Core.Navigation.Interface;
using Wengine.Core.Policies;
using Wengine.Core.Settings;
using Wengine.Core.Translate.Api;
using Wengine.DTO;
using Wengine.Mail.Api;
using Wengine.Mail.Business.Api;
using Wengine.Mail.Business.Services;
using Wengine.Monitor.Api;
using Wengine.Monitor.Business.Services;

namespace Microsoft.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWengineServerSideForUmbraco(this IServiceCollection services, Action<WengineOptions>? wengineOptions = null)
        {
            services.AddWengineBase(wengineOptions);
            WengineOptions options = new WengineOptions();
            ServiceProvider provider = services.BuildServiceProvider();
            if (wengineOptions != null)
            {
                wengineOptions(options);
            }
            else
            {
                options = provider.GetService<IOptions<WengineOptions>>()?.Value;
            }

            services.AddServerSideBlazor().AddHubOptions(delegate (HubOptions hubOptions)
            {
                hubOptions.MaximumReceiveMessageSize = options.BlazorMaximumReceiveMessageSize;
                if (options.IsDebug)
                {
                    hubOptions.EnableDetailedErrors = true;
                }
            });
            services.AddResponseCompression(delegate (ResponseCompressionOptions opts)
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new string[1] { "application/octet-stream" });
            });
            services.AddSingleton<IMailApi, MailServerSideApi>();
            services.AddScoped<ICultureApi, CultureServerSideApi>();
            services.AddScoped<ITranslationApi, TranslationServerSideApi>();
            services.AddScoped<IIdentityApi, IdentityServerSideApi>();
            services.AddScoped<IParseExcelService, ParseExcelService>();
            services.AddScoped<IAuthorizeApi, AuthorizeServerSideApi>();
            services.AddScoped<IArticleApi, ArticleServerSideApi>();
            services.AddScoped<IMediaApi, MediaServerSideApi>();
            services.AddScoped<IMiscApi, MiscServerSideApi>();
            services.AddScoped<INewsApi, NewsServerSideApi>();
            services.AddScoped<ITemplateApi, TemplateServerSideApi>();
            services.AddScoped<IGuiPageApi, GuiPageServerSideApi>();
            services.AddScoped<IConfigurationApi, ConfigurationServerSideApi>();
            services.AddScoped<ISerializationApi, SerializationServerSideApi>();
            services.AddScoped<ILoginTrackingApi, LoginTrackingServerSideApi>();
            services.AddScoped<IBugreportApi, BugreportsServerSideApi>();
            services.AddScoped<IDeniedRoutesApi, DeniedRoutesServerSideApi>();
            services.AddSingleton<IDbCache, DbCache>();
            if (options.Modules.MessagingEnabled)
            {
                services.AddScoped<IMessageApi, MessageServerSideApi>();
                services.AddScoped<IWengineMessageApi, WengineMessageApi>();
            }

            if (options.Modules.MonitorEnabled)
            {
                services.AddSingleton<IMonitorApi, MonitorServerSideApi>();
            }

            if (options.Modules.ProjectsEnabled)
            {
                services.AddScoped<IProjectApi, ProjectServerSideApi>();
            }

            return services;
        }

        private static IServiceCollection AddWengineBase(this IServiceCollection services, Action<WengineOptions>? wengineOptions = null)
        {
            services.ConfigureApplicationCookie(delegate (CookieAuthenticationOptions options)
            {
                options.LoginPath = "/login";
                options.LogoutPath = "/logout";
                options.AccessDeniedPath = "/accessdenied";
            });
            services.AddScoped<IAppData, AppData>();
            services.AddScoped<IIdentityRoles, IdentityRoles>();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<Wengine.DAL.WengineUser>>();
            services.AddSingleton<IDTOHelper, DTOHelper>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IIdentityService, UmbracoIdentityService>();
            services.AddScoped<IAuthorizeService, UmbracoAuthorizeService>();
            services.AddScoped<IClaimsTransformation, WengineClaimsTransformer>();
            services.AddScoped<ICultureService, CultureService>();
            services.AddScoped<IMediaService, MediaService>();
            services.AddScoped<IMiscService, MiscService>();
            services.AddScoped<IMiscService, MiscService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<ITemplateRendererService, TemplateRendererService>();
            services.AddScoped<IGuiPageService, GuiPageService>();
            services.AddScoped<WengineRazorLightProject>();
            services.AddScoped<AspNetMemoryCachingProvider>();
            services.AddScoped<ITemplateRenderer, RazorRenderer>();
            services.AddScoped<ITranslationService, TranslationService>();
            services.AddScoped<ISerializationService, SerializationService>();
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddSingleton<ILoginTrackingService, LoginTrackingService>();
            services.AddSingleton<IBugreportsService, BugreportsService>();
            services.AddScoped<I18n, I18n>();
            services.AddScoped<II18nService, I18nService>();
            services.AddScoped<II18nRetrieveService, I18nRetrieveService>();
            services.AddScoped<IStringLocalizer, I18nStringLocalizer>();
            services.AddSingleton<IConfigurationService, ConfigurationService>();
            services.AddTelerikBlazor();
            services.AddSingleton<ITelerikStringLocalizer, TelerikResxLocalizer>();
            services.AddScoped<ISessionData, SessionData>();
            services.AddSingleton<IServerData, ServerData>();
            services.AddSingleton<IDeniedRoutesService, DeniedRoutesService>();
            services.AddSingleton<IStringLocalizerFactory, WxrStringLocalizerFactory>();
            services.AddScoped<IJsHelper, JsHelper>();
            services.AddScoped<IMasterValidator, MasterValidator>();
            services.AddLocalization(delegate (LocalizationOptions options)
            {
                options.ResourcesPath = "Resources";
            });
            services.AddScoped<INavigationApi, NavigationServerSideApi>();
            services.AddScoped<INavigationService, NavigationService>();
            services.AddScoped<ISiteMapService, SiteMapService>();
            services.AddScoped<NavigationTrackerService>();
            services.AddHostedService<WebWorker>();
            ServiceProvider provider = services.BuildServiceProvider();
            if (provider.GetService<IWenginePolicies>() == null)
            {
                services.AddSingleton<IWenginePolicies, WengineDefaultPolicies>();
            }

            WengineOptions options2 = new WengineOptions();
            if (wengineOptions != null)
            {
                wengineOptions(options2);
            }
            else
            {
                options2 = provider.GetService<IOptions<WengineOptions>>()?.Value;
            }

            if (options2.Logging.Configuration != null)
            {
                services.AddLogging(options2.Logging.Configuration);
            }

            if (options2.IdentityOptions != null)
            {
                services.Configure(options2.IdentityOptions);
            }

            if (options2.RequestLocalizationOptions != null)
            {
                services.Configure(options2.RequestLocalizationOptions);
            }

            if (options2.RewriteOptions != null)
            {
                services.Configure(options2.RewriteOptions);
            }

            if (options2.Modules.MailgunEmailSenderOptions != null)
            {
                services.Configure(options2.Modules.MailgunEmailSenderOptions);
            }

            if (options2.Modules.SendgridEmailSenderOptions != null)
            {
                services.Configure(options2.Modules.SendgridEmailSenderOptions);
            }

            if (options2.Modules.SmtpEmailSenderOptions != null)
            {
                services.Configure(options2.Modules.SmtpEmailSenderOptions);
            }

            if (options2.Modules.MessagingEnabled)
            {
                services.AddScoped<MessageHub>();
                services.AddScoped<IUserTracker, UserTracker>();
                services.AddScoped<IMessageService, MessageService>();
                services.AddScoped<MessageClientHubService>();
                services.AddScoped<MessageClientService>();
            }

            services.AddScoped<IProjectHelper, ProjectHelper>();
            services.AddScoped<IProjectService, ProjectService>();
            if (options2.Modules.GoogleAnalyticsEnabled)
            {
                services.AddGoogleAnalytics(options2.Middleware.GoogleTag);
            }

            if (options2.Modules.MonitorEnabled)
            {
                services.AddSingleton<IMonitorService, MonitorService>();
            }

            switch (options2.Modules.EmailSender)
            {
                case EmailSender.Mailgun:
                    services.AddSingleton<IEmailSender, MailgunEmailSender>();
                    break;
                case EmailSender.Sendgrid:
                    services.AddSingleton<IEmailSender, SendgridEmailSender>();
                    break;
                case EmailSender.Smtp:
                    services.AddSingleton<IEmailSender, SmtpEmailSender>();
                    break;
            }

            services.AddMemoryCache();
            services.AddWengineBlazorServices();
            services.AddHttpContextAccessor();
            services.AddScoped<IBlazrRenderStateService, ServerRenderStateService>();
            services.AddWengineValidators();
            services.AddWenginePolicies(options2);
            services.AddSingleton(new HttpClient());
            services.AddWebOptimizer(delegate (IAssetPipeline pipeline)
            {
                IAsset asset = pipeline.AddCssBundle("/css/wengine-bundle.css", "_content/Wengine.Components.Core/css/bootstrap/bootstrap.min.css", "_content/Wengine.Components.Core/css/bracket.css", "_content/Wengine.Components.Core/css/bracket.simple-white.css", "_content/Telerik.UI.for.Blazor/css/kendo-theme-bootstrap/all.css", "_content/Wengine.Components.Core/css/lightbox.css", "_content/Wengine.Components.Core/css/wengine/wxr-var.css", "/css/SiteVar.css", "_content/Wengine.Components.Core/css/wengine/wxr-icons.css", "_content/Wengine.Components.Core/css/wengine/wxr-telerik.css", "_content/Wengine.Components.Core/css/wengine/wxr-utils.css", "_content/Wengine.Components.Core/css/wengine/wxr-forms.css", "_content/Wengine.Components.Core/css/wengine/wxr-app.css", "_content/Wengine.Components.Core/css/wengine/wxr-pages.css");
                if (!options2.Site.ApplicationCssPath.IsNullOrWhiteSpace())
                {
                    asset.TryAddSourceFile(options2.Site.ApplicationCssPath);
                }

                IAsset asset2 = pipeline.AddJavaScriptBundle("/js/wengine-bundle.js", "_content/Wengine.Components.Core/js/jquery/jquery.min.js", "_content/Wengine.Components.Core/js/bootstrap/bootstrap.bundle.min.js", "_content/Wengine.Components.Core/lib/bootstrap-slider/bootstrap-slider.min.js", "_content/Telerik.UI.for.Blazor/js/telerik-blazor.js", "_content/Wengine.Components.Core/js/wxr-bracket.js", "_content/Wengine.Components.Core/js/lightbox.min.js", "_content/Wengine.Components.Core/js/qrcode.min.js", "_content/Wengine.Components.Core/js/wxr-app.js");
                if (!options2.Site.ApplicationScriptPath.IsNullOrWhiteSpace())
                {
                    asset2.TryAddSourceFile(options2.Site.ApplicationScriptPath);
                }

                pipeline.MinifyCssFiles();
                pipeline.MinifyJsFiles("js/**/*.js", "_content/Wengine.Components.Core/**.js");
            });
            //services.AddIdentity<Wengine.DAL.WengineUser, Wengine.DAL.WengineRole>().AddDefaultUI().AddPasswordValidator<WengineUserPasswordValidator<Wengine.DAL.WengineUser>>()
            //    .AddDefaultTokenProviders()
            //    .AddErrorDescriber<I18nIdentityErrorDescriber>()
            //    .AddEntityFrameworkStores<WengineContext>();
            services.AddRazorPages().AddViewLocalization().AddDataAnnotationsLocalization();
            services.AddRazorComponents().AddInteractiveServerComponents();
            //services.AddScoped<SignInManager<Wengine.DAL.WengineUser>, WengineSignInManager>();
            //services.AddAuthorization(delegate (AuthorizationOptions options)
            //{
            //    options.AddPolicy("AdminPages", delegate (AuthorizationPolicyBuilder policy)
            //    {
            //        policy.RequireRole("Admin", "SuperAdmin");
            //    });
            //});
            //if (options2.Site.UseConsentCookie)
            {
                services.Configure(delegate (CookiePolicyOptions options)
                {
                    options.CheckConsentNeeded = (HttpContext context) => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });
            }

            if (wengineOptions != null)
            {
                services.Configure(wengineOptions);
            }

            return services;
        }

        public static IServiceCollection AddWengineValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.Load("Wengine.Core"));
            services.AddValidatorsFromAssembly(Assembly.GetEntryAssembly());
            services.AddFluentValidationClientsideAdapters();
            return services;
        }

        public static void AddWenginePolicies(this IServiceCollection services, WengineOptions wengineOptions)
        {
            WengineOptions wengineOptions2 = wengineOptions;
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            IWenginePolicies policiesService = (IWenginePolicies)serviceProvider.GetService(typeof(IWenginePolicies));
            services.AddAuthorization(delegate (AuthorizationOptions options)
            {
                foreach (string permission in policiesService.GetPermissions())
                {
                    options.AddPolicy(permission, delegate (AuthorizationPolicyBuilder policy)
                    {
                        policy.RequireClaim(permission, permission);
                    });
                }

                List<string> adminClaims = policiesService.GetPermissionModules(wengineOptions2.Modules.ProspectsEnabled).SelectMany<KeyValuePair<string, List<PermissionItem>>, string>((KeyValuePair<string, List<PermissionItem>> o) => from x in o.Value
                                                                                                                                                                                                                                           where x.IsAdministrative
                                                                                                                                                                                                                                           select x into p
                                                                                                                                                                                                                                           select p.Name).ToList();
                options.AddPolicy("WengineViewAdminSection", delegate (AuthorizationPolicyBuilder builder)
                {
                    builder.RequireAuthenticatedUser().RequireAssertion((AuthorizationHandlerContext handler) => handler.User.Claims.Any((Claim o) => adminClaims.Contains(o.Value)));
                });
                foreach (KeyValuePair<string, AuthorizationPolicy> policy in policiesService.GetPolicies())
                {
                    options.AddPolicy(policy.Key, policy.Value);
                }
            });
            foreach (Type handler in policiesService.GetHandlers())
            {
                services.AddSingleton(typeof(IAuthorizationHandler), handler);
            }
        }

        public static IServiceCollection AddWengineComponents(this IServiceCollection services)
        {
            services.AddCascadingAuthenticationState();
            return services.AddBlazoredToast();
        }

        private static IServiceCollection AddBlazoredToast(this IServiceCollection services)
        {
            return services.AddScoped<IToastService, ToastService>();
        }
    }

}
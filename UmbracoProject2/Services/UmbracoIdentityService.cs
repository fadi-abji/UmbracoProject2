using System.Security.Claims;
using Wengine.Base;
using Wengine.Business.Services;
using Wengine.Components.Base;
using Wengine.Core.Identity.Models;
using Wengine.Core.Models;
using Wengine.DAL;
using Wengine.DTO;

namespace UmbracoProject2.Services
{
    public class UmbracoIdentityService : IIdentityService
    {
        public event EventHandler<SenderChangeEventArgs<string>> ClaimsHasUpdated;

        public Task<WxrResponse> ActivateUser(ActivateUserModel model)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.Prospect>> ApproveProspect(Guid uid, string approvedBy = null, string approveRoleName = "Admin")
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> ChangePassword(ChangeUserPasswordModel model)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> ChangeUser(ChangeUserInfoModel model)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> ConfirmProspect(Guid uid)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> ConfirmProspectEmail(Wengine.DTO.Prospect bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.Prospect>> CreateProspect(Wengine.DTO.Prospect bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeleteCompany(Wengine.DTO.Company bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeleteCompanyCompanyType(Wengine.DTO.CompanyCompanyType bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeleteCompanyType(Wengine.DTO.CompanyType bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeletePerson(Wengine.DTO.Person bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeletePersonPersonTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeletePersonType(Wengine.DTO.PersonType bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeleteProspect(Wengine.DTO.Prospect bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeleteProspectProject(Wengine.DTO.ProspectProject bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeleteProspectStatus(Wengine.DTO.ProspectStatus bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeleteProspectType(Wengine.DTO.ProspectType prospectType)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeleteSalesAdvisor(Wengine.DTO.SalesAdvisor bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeleteSalesAdvisorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeleteUser(string user, bool allowSpecialRoles)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeleteUser(Wengine.DTO.WengineUser user)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> DeleteWengineRole(Wengine.DTO.WengineRole role)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<WengineUserLookup>> GetActivationUser(Guid uid)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.Company>>> GetCompanies(ServiceOptions<CompanySearchCriteria, Wengine.DAL.Company> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.Company>>> GetCompaniesByType(string type, bool includeObsolete = false)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.Company>>> GetCompaniesByTypeId(int type, bool includeObsolete = false)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<CompanyRelated>>> GetCompaniesRelated(ServiceOptions<CompanySearchCriteria, Wengine.DAL.Company> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.Company>> GetCompanyById(int id, bool includeObsolete = false)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.Company>> GetCompanyByName(string name, bool includeObsolete = false)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.CompanyCompanyType>>> GetCompanyCompanyTypes(ServiceOptions<CompanyCompanyTypeSearchCriteria, Wengine.DAL.CompanyCompanyType> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.CompanyCompanyType>>> GetCompanyCompanyTypesForCompany(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Differences<CompanyRelated>>> GetCompanyDifferences(List<CompanyRelated> companies)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<CompanyLookup>> GetCompanyLookupById(int id, bool includeObsolete = false)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<CompanyLookup>>> GetCompanyLookups(ServiceOptions<CompanySearchCriteria, Wengine.DAL.Company> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<CompanyLookup>>> GetCompanyLookupsByTypeId(int typeId, bool includeObsolete = false)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<CompanyRelated>> GetCompanyRelatedById(int id, bool includeObsolete = false)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.CompanyType>> GetCompanyTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.CompanyType>> GetCompanyTypeByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.CompanyType>>> GetCompanyTypes(ServiceOptions<CompanyTypeSearchCriteria, Wengine.DAL.CompanyType> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.CompanyType>>> GetCompanyTypesForCompany(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<string>> GetPasswordRecoveryLink(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.Person>> GetPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.Person>> GetPersonByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<PersonLookup>> GetPersonLookupById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<PersonLookup>>> GetPersonLookups(ServiceOptions<PersonSearchCriteria, Wengine.DAL.Person> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.PersonPersonType>>> GetPersonPersonTypes(ServiceOptions<PersonPersonTypeSearchCriteria, Wengine.DAL.PersonPersonType> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.PersonPersonType>>> GetPersonPersonTypesForPerson(int personId)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.Person>>> GetPersons(ServiceOptions<PersonSearchCriteria, Wengine.DAL.Person> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.Person>>> GetPersonsByCompanyId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.Person>>> GetPersonsByTypeId(int? typeId)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.PersonType>> GetPersonTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.PersonType>> GetPersonTypeByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.PersonType>>> GetPersonTypes(ServiceOptions<PersonTypeSearchCriteria, Wengine.DAL.PersonType> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.PersonType>>> GetPersonTypesForPerson(int personId)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.Prospect>> GetProspectById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.Prospect>> GetProspectByUid(Guid uid)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.ProspectProject>> GetProspectProjectById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.ProspectProject>>> GetProspectProjects(ServiceOptions<ProspectProjectSearchCriteria, Wengine.DAL.ProspectProject> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.Prospect>>> GetProspects(ServiceOptions<ProspectSearchCriteria, Wengine.DAL.Prospect> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.Prospect>>> GetProspectsByType(int? type)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.ProspectStatus>> GetProspectStatusById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.ProspectStatus>>> GetProspectStatuses(ServiceOptions<ProspectStatusSearchCriteria, Wengine.DAL.ProspectStatus> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.ProspectType>> GetProspectTypeById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.ProspectType>>> GetProspectTypes(ServiceOptions<ProspectTypeSearchCriteria, Wengine.DAL.ProspectType> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.SalesAdvisor>> GetSalesAdvisorByCountry(string countryCode)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.SalesAdvisor>> GetSalesAdvisorById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<SalesAdvisorLookup>> GetSalesAdvisorLookupByCountry(string countryCode)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<SalesAdvisorLookup>> GetSalesAdvisorLookupById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<SalesAdvisorLookup>>> GetSalesAdvisorLookups(ServiceOptions<SalesAdvisorSearchCriteria, Wengine.DAL.SalesAdvisor> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.SalesAdvisor>>> GetSalesAdvisors(ServiceOptions<SalesAdvisorSearchCriteria, Wengine.DAL.SalesAdvisor> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.SalesAdvisor>>> GetSalesAdvisorsByPersonId(int personId)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.Subscription>>> GetSubscriptions(ServiceOptions<SubscriptionSearchCriteria, Wengine.DAL.Subscription> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.UserAction>> GetUserActionByUid(Guid uid)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.UserAction>>> GetUserActions(ServiceOptions<UserActionSearchCriteria, Wengine.DAL.UserAction> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetUserActivationMailModel(WengineUserLookup user, Wengine.DAL.UserAction action, IAppSettings appSettings)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.WengineUser>> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.WengineUser>> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<WengineUserLookup>> GetUserLookupById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<WengineUserLookup>> GetUserLookupByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<WengineUserLookup>>> GetUserLookups(ServiceOptions<WengineUserSearchCriteria, Wengine.DAL.WengineUser> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<WengineUserLookup>>> GetUserLookupsForUser(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetUserPasswordRecoveryMailModel(WengineUserLookup user, Wengine.DAL.UserAction action, IAppSettings appSettings)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<IList<string>>> GetUserRoles(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.WengineUser>>> GetUsers(ServiceOptions<WengineUserSearchCriteria, Wengine.DAL.WengineUser> serviceOptions)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.WengineRole>> GetWengineRoleById(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<List<Wengine.DTO.WengineRole>>> GetWengineRoles()
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> RegisterUser(RegisterUserModel user)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.Prospect>> RejectProspect(Guid uid, string rejectedBy = null, string approveRoleName = "Admin")
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> ResendActivationMail(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> ResendConfirmEmailProspectEmail(Wengine.DTO.Prospect bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.Company>> SaveCompany(Wengine.DTO.Company bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<CompanyRelated>> SaveCompany(CompanyRelated bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.CompanyCompanyType>> SaveCompanyCompanyType(Wengine.DTO.CompanyCompanyType bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<DifferencesResponse>> SaveCompanyDifferences(Differences<CompanyRelated> difference)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.CompanyType>> SaveCompanyType(Wengine.DTO.CompanyType bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.Person>> SavePerson(Wengine.DTO.Person bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> SavePersonPersonType(Wengine.DTO.PersonPersonType personPersonType)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.PersonType>> SavePersonType(Wengine.DTO.PersonType personType)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.Prospect>> SaveProspect(Wengine.DTO.Prospect bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.ProspectProject>> SaveProspectProject(Wengine.DTO.ProspectProject bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.ProspectStatus>> SaveProspectStatus(Wengine.DTO.ProspectStatus bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.ProspectType>> SaveProspectType(Wengine.DTO.ProspectType bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.SalesAdvisor>> SaveSalesAdvisor(Wengine.DTO.SalesAdvisor bm)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.UserAction>> SaveUserAction(Wengine.DTO.UserAction userAction)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.WengineRole>> SaveWengineRole(Wengine.DTO.WengineRole role)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> SendActivationMail(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> SendPasswordRecoveryMail(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> SetLockout(string user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DTO.Company>> UpdateCompany(CompanyModel model)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> UpdateUser(UserModel model, bool allowSpecialRoles, bool sendActivationMail = true, bool existingPerson = false)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> UpdateUserPassword(ResetPasswordModel model)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> ValidateUpdateUserPasswordToken(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}

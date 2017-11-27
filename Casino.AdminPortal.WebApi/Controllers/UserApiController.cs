using Casino.AdminPortal.Shared;
using Casino.AdminPortal.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Casino.AdminPortal.WebApi.Controllers
{
    public class UserApiController : ApiController
    {
        [HttpGet]
        public UserModelApi GetUserByEmailID(string email)
        {
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            OperationResult<IUserDTO> resultAllCustomers = userFacade.GetUserByEmailId(email);
            UserModelApi User = new UserModelApi();
            if (resultAllCustomers.IsValid())
            {

                User.Name = resultAllCustomers.Data.Name;
                User.EmailId = resultAllCustomers.Data.EmailId;
                User.AccountBalance = resultAllCustomers.Data.AccountBalance;
                User.BlockedAmount = resultAllCustomers.Data.BlockedAmount;

            }
            else
            {
                // IList<EmployeePortalValidationFailure> resultFail = resultAllCustomers.ValidationResult.Errors;

            }
            return User;

        }

        [HttpPatch]
        public UserModelApi BlockBetAmount(string email, decimal betAmount)
        {
            IUserFacade noticeFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            OperationResult<IUserDTO> resultActive = noticeFacade.BlockBetAmount(email, betAmount);
            UserModelApi user = null;

            if (resultActive.IsValid())
            {
                user = new UserModelApi();
                user.Name = resultActive.Data.Name;
                user.EmailId = resultActive.Data.EmailId;
                user.AccountBalance = resultActive.Data.AccountBalance;
                user.BlockedAmount = resultActive.Data.BlockedAmount;

            }

            else
            {

            }
            return user;
        }

        [HttpPatch]
        public UserModelApi AddWinningPrize(string email,decimal betAmount, decimal multiplyFactor)
        {
            IUserFacade noticeFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            OperationResult<IUserDTO> resultActive = noticeFacade.AddWinningPrize(email,betAmount, multiplyFactor);
            UserModelApi user = null;
            if (resultActive.IsValid())
            {
                user = new UserModelApi();
                user.Name = resultActive.Data.Name;
                user.EmailId = resultActive.Data.EmailId;
                user.AccountBalance = resultActive.Data.AccountBalance;
                user.BlockedAmount = resultActive.Data.BlockedAmount;

            }

            else
            {

            }
            return user;
        }

    }
}

using Casino.AdminPortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Business
{
    public class UserBDC : BDCBase, IUserBDC
    {
        public UserBDC()
            : base(BDCType.UserBDC)
        {

        }

        public OperationResult<IUserDTO> CreateAUser(IUserDTO userDTO)
        {
            OperationResult<IUserDTO> createUserReturnValue = null;
            IUserDAC userDAC = null;
            IUserDTO UserDTO = null;

            try
            {
                AdminPortalValidationResult validationResult = Validator<UserValidator, IUserDTO>.Validate(userDTO, "CreateUserEmail");
                if (!validationResult.IsValid)
                {
                    createUserReturnValue = OperationResult<IUserDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                    UserDTO = userDAC.CreateAUser(userDTO);
                    if (UserDTO != null)
                    {
                        createUserReturnValue = OperationResult<IUserDTO>.CreateSuccessResult(UserDTO, "User Creation Successfull");
                    }
                    else
                    {
                        createUserReturnValue = OperationResult<IUserDTO>.CreateFailureResult("Error! Cannot create a customer");
                    }
                }
            }
            catch (DACException dacEx)
            {
                createUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                createUserReturnValue = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return createUserReturnValue;
        }

        public OperationResult<IList<IUserDTO>> GetAllUser()
        {
            OperationResult<IList<IUserDTO>> retVal = null;
            IUserDAC userDAC = null;
            IList<IUserDTO> all = null;

            try
            {
                userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                all = userDAC.GetAllUser();
                retVal = OperationResult<IList<IUserDTO>>.CreateSuccessResult(all);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IList<IUserDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IList<IUserDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;

        }

        public OperationResult<IUserDTO> GetUserByEmailId(string emailId)
        {
            OperationResult<IUserDTO> retVal = null;
            IUserDAC userDAC = null;
            IUserDTO all = null;

            try
            {
                userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                all = userDAC.GetUserByEmailId(emailId);
                retVal = OperationResult<IUserDTO>.CreateSuccessResult(all);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }

        public OperationResult<IList<IUserDTO>> SearchUser(string nameSearch, string contactSearch, string emailSearch)
        {
            OperationResult<IList<IUserDTO>> updateReturnValue = null;
            IUserDAC userDAC = null;
            IList<IUserDTO> returnedUserDTO = null;
            try
            {
                userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                returnedUserDTO = userDAC.SearchUser(nameSearch, contactSearch, emailSearch);

                if (returnedUserDTO != null)
                {
                    updateReturnValue = OperationResult<IList<IUserDTO>>.CreateSuccessResult(returnedUserDTO, "User Searched successfully");
                }
                else
                {
                    updateReturnValue = OperationResult<IList<IUserDTO>>.CreateFailureResult("User Searching failed!");
                }
            }
            catch (DACException dacEx)
            {
                updateReturnValue = OperationResult<IList<IUserDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                updateReturnValue = OperationResult<IList<IUserDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return updateReturnValue;

        
        }
    
        public OperationResult<IUserDTO> AddUserMoney(string emailId, decimal rechargeAmount)
        {
            OperationResult<IUserDTO> retVal = null;
            IUserDAC userDAC = null;
            IUserDTO all = null;

            try
            {
                userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                all = userDAC.AddUserMoney(emailId, rechargeAmount);
                retVal = OperationResult<IUserDTO>.CreateSuccessResult(all);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }

        public OperationResult<IUserDTO> GetUserByContactNumber(string contactNumber)
        {
            OperationResult<IUserDTO> retVal = null;
            IUserDAC userDAC = null;
            IUserDTO all = null;

            try
            {
                userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                all = userDAC.GetUserByContactNumber(contactNumber);
                retVal = OperationResult<IUserDTO>.CreateSuccessResult(all);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }

        public OperationResult<IUserDTO> BlockBetAmount(string emailId, decimal betAmount)
        {
            OperationResult<IUserDTO> retVal = null;
            IUserDAC userDAC = null;
            IUserDTO all = null;

            try
            {
                userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                all = userDAC.BlockBetAmount(emailId,betAmount);
                retVal = OperationResult<IUserDTO>.CreateSuccessResult(all);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }

        public OperationResult<IUserDTO> AddWinningPrize(string emailId, decimal betAmount, decimal multiplyFactor)
        {
            OperationResult<IUserDTO> retVal = null;
            IUserDAC userDAC = null;
            IUserDTO all = null;

            try
            {
                userDAC = (IUserDAC)DACFactory.Instance.Create(DACType.UserDAC);
                all = userDAC.AddWinningPrize(emailId,betAmount,multiplyFactor);
                retVal = OperationResult<IUserDTO>.CreateSuccessResult(all);
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IUserDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IUserDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return retVal;
        }
    
    }
}

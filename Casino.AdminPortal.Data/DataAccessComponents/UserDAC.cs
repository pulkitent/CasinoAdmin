using Casino.AdminPortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.AdminPortal.EntityDataModel.EntityModel;
using Casino.AdminPortal.EntityDataModel;

namespace Casino.AdminPortal.Data
{
    public class UserDAC : DACBase, IUserDAC
    {
        public UserDAC()
            : base(DACType.UserDAC)
        {

        }

        public IUserDTO CreateAUser(IUserDTO customer)
        {
            IUserDTO createUserRetVal = null;
            try
            {
                using (CasinoPortalEntities context = new CasinoPortalEntities())
                {
                    Player user = new Player();
                    customer.BlockedAmount = 0;
                    customer.AccountBalance = 500;
                    EntityConverter.FillEntityFromDTO(customer, user);
                    context.Players.Add(user);

                    if (context.SaveChanges() > 0)
                    {
                        createUserRetVal = customer;
                        createUserRetVal.PlayerId = user.PlayerId;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return createUserRetVal;
        }

        public IList<IUserDTO> GetAllUser()
        {
            List<IUserDTO> all = null;
            try
            {
                using (CasinoPortalEntities context = new CasinoPortalEntities())
                {

                    all = new List<IUserDTO>();

                    foreach (Player v in context.Players)
                    {
                        IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityDataModel.EntityConverter.FillDTOFromEntity(v, userDTO);
                        all.Add(userDTO);

                    }
                    return all;
                }


            }

            catch (Exception exception)
            {
                ExceptionManager.HandleException(exception);
                throw new DACException(exception.Message);
            }
        }

        public IUserDTO GetUserByEmailId(string emailId)
        {
            IUserDTO userDTO = null;

            try
            {


                using (CasinoPortalEntities context = new CasinoPortalEntities())
                {

                    //var userId = context.Employees.Where(m => m.Email == emailId).Select(m => m.EmployeeId).SingleOrDefault();
                    Player user = context.Players.FirstOrDefault(m => m.EmailId == emailId);
                    //
                    if (user != null)
                    {
                        userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityDataModel.EntityConverter.FillDTOFromEntity(user, userDTO);
                        return userDTO;
                    }

                }
                return userDTO;
            }

            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
        }

        public IList<IUserDTO> SearchUser(string nameSearch, string contactSearch, string emailSearch)
        {

            IList<IUserDTO> returnedList = null;
            try
            {
                using (CasinoPortalEntities context = new CasinoPortalEntities())
                {
                    IList<SearchEmployee_Result> userList = new List<SearchEmployee_Result>();
                    userList = (IList<SearchEmployee_Result>)context.SearchEmployee(nameSearch, emailSearch, contactSearch).ToList();
                    if (userList.Count > 0)
                    {
                        returnedList = new List<IUserDTO>();
                        foreach (var user in userList)
                        {
                            IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                            EntityDataModel.EntityConverter.FillDTOFromEntity(user, userDTO);
                            returnedList.Add(userDTO);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionManager.HandleException(exception);
                throw new DACException(exception.Message);
            }
            return returnedList;
        }

        public IUserDTO AddUserMoney(string emailId, decimal rechargeAmount)
        {
            IUserDTO userDTO = null;
            try
            {
                //userDTO = GetUserByEmailId(emailId);
                //userDTO.AccountBalance+=rechargeAmount;
                using (CasinoPortalEntities context = new CasinoPortalEntities())
                {
                    //var userId = context.Employees.Where(m => m.Email == emailId).Select(m => m.EmployeeId).SingleOrDefault();
                    Player user = context.Players.FirstOrDefault(m => m.EmailId == emailId);
                    if (user != null)
                    {
                        user.AccountBalance += rechargeAmount;
                        userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityDataModel.EntityConverter.FillDTOFromEntity(user, userDTO);
                        if (context.SaveChanges() > 0)
                        {
                            return userDTO;
                        }
                        return userDTO;
                    }

                }
                return userDTO;


            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
        }

        public IUserDTO GetUserByContactNumber(string contactNumber)
        {
            IUserDTO userDTO = null;

            try
            {


                using (CasinoPortalEntities context = new CasinoPortalEntities())
                {
                    Player user = context.Players.FirstOrDefault(m => m.ContactNumber == contactNumber);
                    if (user != null)
                    {
                        userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityDataModel.EntityConverter.FillDTOFromEntity(user, userDTO);
                        return userDTO;
                    }

                }
                return userDTO;
            }

            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
        }

        public IUserDTO BlockBetAmount(string emailId, decimal betAmount)
        {
            IUserDTO userDTO = null;
            try
            {
                using (CasinoPortalEntities context = new CasinoPortalEntities())
                {
                    Player user = context.Players.FirstOrDefault(m => m.EmailId == emailId);
                    if (user != null)
                    {
                        decimal currentBalance = user.AccountBalance;
                        if (currentBalance >= betAmount)
                        {
                            user.AccountBalance -= betAmount;
                            user.BlockedAmount = (int)betAmount;
                            userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                            EntityDataModel.EntityConverter.FillDTOFromEntity(user, userDTO);
                            if (context.SaveChanges() > 0)
                            {
                                return userDTO;
                            }
                            return userDTO;
                        }

                    }

                }
                return userDTO;


            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

        }

        public IUserDTO AddWinningPrize(string emailId, decimal betAmount, decimal multiplyFactor)
        {
            IUserDTO userDTO = null;
            try
            {
                using (CasinoPortalEntities context = new CasinoPortalEntities())
                {
                    Player user = context.Players.FirstOrDefault(m => m.EmailId == emailId);
                    if (user != null)
                    {
                        user.AccountBalance += (decimal)(user.BlockedAmount * multiplyFactor);
                        user.BlockedAmount = 0;
                        userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
                        EntityDataModel.EntityConverter.FillDTOFromEntity(user, userDTO);
                        if (context.SaveChanges() > 0)
                        {
                            return userDTO;
                        }

                    }

                }
                return userDTO;


            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
        }

    }
}

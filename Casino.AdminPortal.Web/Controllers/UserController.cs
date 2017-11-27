using Casino.AdminPortal.Shared;
using Casino.AdminPortal.Web.Models;
using Nagarro.EmployeePortal.Web.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Casino.AdminPortal.Web.Controllers
{
    public class UserController : Controller
    {
        // IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
        //IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
        // GET: User

        public int calculateAge(System.DateTime DateOfBirth)
        {
            int age = ((DateTime.Now.Year - DateOfBirth.Year) * 372 + (DateTime.Now.Month - DateOfBirth.Month) * 31 + (DateTime.Now.Day - DateOfBirth.Day)) / 372;
            return age;
        }

        public PartialViewResult Index()
        {
            return PartialView();
        }

        public byte[] convertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        [HttpGet]
        public PartialViewResult CreateAUser()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult CreateAUser(UserViewModels user)
        {
            IUserFacade customerFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            IUserDTO createCustomerDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            HttpPostedFileBase file = Request.Files["ImageData"];
            user.IdentityProof = convertToBytes(file);
            if (ModelState.IsValid)
            {
                DTOConverter.FillDTOFromViewModel(createCustomerDTO, user);
                OperationResult<IUserDTO> resultCreate = customerFacade.CreateAUser(createCustomerDTO);
                if (resultCreate.IsValid())
                {
                    return View("../Home/Index");
                }

                else
                {
                    IList<AdminPortalValidationFailure> resultFail = resultCreate.ValidationResult.Errors;
                    foreach (var item in resultFail)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return View();

                }

            }
            return View();
        }

        [HttpGet]
        public ActionResult GetAllUsers(int? page)
        {
            IUserFacade noticeFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            OperationResult<IList<IUserDTO>> resultActive = noticeFacade.GetAllUser();
            IList<UserViewModels> allUser = new List<UserViewModels>();

            if (resultActive.IsValid())
            {
                foreach (IUserDTO item in resultActive.Data)
                {
                    UserViewModels user = new UserViewModels();
                    DTOConverter.FillViewModelFromDTO(user, item);
                    allUser.Add(user);
                }

            }

            int pageSize = 5;
            int pageIndex = page ?? 1;
            return View("GetAllUsers",allUser.ToPagedList(pageIndex, pageSize));
            //return View("GetAllUsers", allUser);
        }

        public ActionResult SearchUser(string nameSearch, string contactSearch, string emailSearch)
        {
            if (nameSearch.Length == 0 && contactSearch.Length == 0 && emailSearch.Length == 0)
            {
                //return this.GetAllUsers();
            }
            else
            {
                if (nameSearch != null && nameSearch.Length == 0)
                {
                    nameSearch = null;
                }

                if (contactSearch != null && contactSearch.Length == 0)
                {
                    contactSearch = null;
                }

                if (emailSearch != null && emailSearch.Length == 0)
                {
                    emailSearch = null;
                }
            }
                IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
                OperationResult<IList<IUserDTO>> resultAllCustomers = userFacade.SearchUser(nameSearch, contactSearch, emailSearch);
                List<UserViewModels> result = new List<UserViewModels>();
                if (resultAllCustomers.IsValid())
                {
                    foreach (var item in resultAllCustomers.Data)
                    {
                        UserViewModels userData = new UserViewModels();
                        DTOConverter.FillViewModelFromDTO(userData, item);
                        result.Add(userData);
                    }
                }
                //return View("GetAllUsers", result);
                int pageSize = 5;
                int pageNumber = 1;
                return View("GetAllUsers", result.ToPagedList(pageNumber,pageSize));
              
        }

        public ActionResult AddMoney(string EmailId, decimal RechargeAmount)
        {
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserFacade);
            OperationResult<IUserDTO> resultVal = userFacade.AddUserMoney(EmailId, RechargeAmount);
            return RedirectToAction("GetAllUsers", "User");
        }


    }
}
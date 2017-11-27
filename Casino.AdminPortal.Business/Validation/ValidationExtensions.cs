using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casino.AdminPortal.Shared;
using FluentValidation;
using FluentValidation.Results;

namespace Casino.AdminPortal.Business
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static AdminPortalValidationResult ToValidationResult(this ValidationResult result)
        {
            IList<AdminPortalValidationFailure> errors = new List<AdminPortalValidationFailure>();

            foreach (ValidationFailure failure in result.Errors)
            {
                errors.Add(failure.ToValidationFailure());
            }

            return new AdminPortalValidationResult(errors);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="failure"></param>
        /// <returns></returns>
        public static AdminPortalValidationFailure ToValidationFailure(this ValidationFailure failure)
        {
            return new AdminPortalValidationFailure(failure.PropertyName, failure.ErrorMessage, failure.AttemptedValue);
        }


    }

}

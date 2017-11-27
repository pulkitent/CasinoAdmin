using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.AdminPortal.Shared
{
    public class AdminPortalValidationResult
    {
        public IList<AdminPortalValidationFailure> Errors { get; private set; }

        public bool IsValid
        {
            get { return Errors == null || Errors.Count == 0; }
        }

        public AdminPortalValidationResult(IList<AdminPortalValidationFailure> failures)
        {
            Errors = failures;
        }

        public AdminPortalValidationResult()
        {
            Errors = new List<AdminPortalValidationFailure>();
        }
    }
}

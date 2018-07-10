using System.Collections.Generic;
using System.Linq;

namespace SevenShifts.Domain.Contracts
{
    public class ValidationObjectResult
    {
        #region Constructors
        public ValidationObjectResult()
        {
            this.ValidationMessages = new List<string>();
        }

        public ValidationObjectResult(params string[] validationMessages)
        {
            this.ValidationMessages = validationMessages.ToList();
        }
        #endregion

        #region Properties
        public bool IsValid { get { return !ValidationMessages.Any(); } }
        public List<string> ValidationMessages { get; set; }
        #endregion
    }
}
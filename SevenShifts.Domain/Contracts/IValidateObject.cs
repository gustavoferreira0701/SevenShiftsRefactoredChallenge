using System;
using System.Collections.Generic;
using System.Text;

namespace SevenShifts.Domain.Contracts
{
    public interface IValidateObject
    {
        ValidationObjectResult Validate();
    }
}

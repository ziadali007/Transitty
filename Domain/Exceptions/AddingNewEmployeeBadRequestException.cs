using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class AddingNewEmployeeBadRequestException(string message) : Exception(message)
    {
    }
}

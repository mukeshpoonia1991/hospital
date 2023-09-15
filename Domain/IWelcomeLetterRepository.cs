using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain
{
    public interface IWelcomeLetterRepository
    {
        void Add(WelcomeLetterModel welcomeLetter);
    }
}

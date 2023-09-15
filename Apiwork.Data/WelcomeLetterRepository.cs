using Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data
{
    public class WelcomeLetterRepository : IWelcomeLetterRepository
    {
        private List<WelcomeLetterModel> _welcomeLetters = new List<WelcomeLetterModel>();

        public void Add(WelcomeLetterModel welcomeLetter)
        {
            _welcomeLetters.Add(welcomeLetter);
        }
    }

}

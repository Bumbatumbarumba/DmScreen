using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmScreen.services
{
    class CampaignDirectoryExistsError : Exception
    {
        public CampaignDirectoryExistsError(string message) : base(message) { }
    }
}

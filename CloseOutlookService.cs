using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseHangingOutlookService
{
    public class CloseOutlookService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
        public bool CloseHangingOutlook() 
        {
            // TODO: Implement check if outlook.exe is hung in shutdown and if so terminate the process
            return false;
        }
    }
}

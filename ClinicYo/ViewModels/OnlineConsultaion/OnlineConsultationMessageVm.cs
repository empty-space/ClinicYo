using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicYo.ViewModels.OnlineConsultaion
{
    public class OnlineConsultationMessageVm
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int userId { get; set; }
        public string senderName { get; set; }        
    }
}

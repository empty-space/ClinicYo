using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicYo.ViewModels.OnlineConsultaion
{
    public class OnlineConsultationVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsClosed { get; set; }
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        public List<OnlineConsultationMessageVm> Messages { get; set; }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedResearchApp.MedApp
{
    class Patient
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientDisease { get; set; }
        public string DiseaseCause { get; set; }
        public string DiseaseSeverity { get; set; }
        public string DiseaseSymptom { get; set; }
        public string DiseaseDesc { get; set; }
    }
}

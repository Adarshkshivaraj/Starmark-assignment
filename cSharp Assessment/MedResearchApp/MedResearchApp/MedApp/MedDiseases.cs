using MedResearchApp.MedApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedResearchApp.Application
{
    interface IDataReader
    {
        void AddNewPatient(Patient pnt);
        Patient[] GetAllPatient();
    }
    class MedicalRecord : IDataReader
    {
        private ArrayList _ReportOfPatient = new ArrayList();
        public void AddNewPatient(Patient pnt)
        {
            _ReportOfPatient.Add(pnt);
        }
        public Patient[] GetAllPatient()
        {
            Patient[] arr = new Patient[_ReportOfPatient.Count];
            for (int i = 0; i < _ReportOfPatient.Count; i++)
            {
                if (_ReportOfPatient[i] is Patient)
                {
                    arr[i] = _ReportOfPatient[i] as Patient;
                }
            }
            return arr;
        }
    }
}

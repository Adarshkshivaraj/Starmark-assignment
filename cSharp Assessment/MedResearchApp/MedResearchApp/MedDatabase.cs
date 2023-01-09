using MedResearchApp.Application;
using MedResearchApp.MedApp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace MedResearchApp
{
    class MedDatabase
    {
        static IDataReader data = new MedicalRecord();
        private static void AddPatientDetails()
        {
            string PatientDisease = Utilities.Prompt("Enter Patient Disease Name");
            string DiseaseCause = Utilities.Prompt("Enter Disease Cause \nExternal factor and Internal Disorder ");
            string DiseaseSeverity = Utilities.Prompt("Enter Patient Disease Severity \nrange from high to low");
            data.AddNewPatient(new Patient { PatientDisease = PatientDisease, DiseaseCause = DiseaseCause, DiseaseSeverity = DiseaseSeverity });
            Console.WriteLine("Patient Details Added Succfully");
        }
        private static void AddDiseaseDetails()
        {
            string DiseaseSymptom = Utilities.Prompt("Enter the Symptom of the Disease");
        Words:
            string DiseaseDesc = Utilities.Prompt("Enter the description of the disease");
            if (DiseaseDesc.Length < 30)
            {
                goto Words;
            }
            data.AddNewPatient(new Patient { DiseaseSymptom = DiseaseSymptom, DiseaseDesc = DiseaseDesc });
            Console.WriteLine("Symptoms added successfully");
        }
        private static void ViewpatientReport()
        {
            var repo = data.GetAllPatient();
            Disp(repo);
        }
        public static void Disp(Array pnt)
        {
            foreach (var patient in pnt)
            {
                Console.WriteLine((patient as Patient).PatientDisease);
                Console.WriteLine((patient as Patient).DiseaseCause);
                Console.WriteLine((patient as Patient).DiseaseSeverity);
            }
        }
        enum Options
        {
            Add = 1, Upadate = 2, ViewPatient = 3
        }   
        public const string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~MEDICAL RESEARCH APPLICATION~~~~~~~~~~~~~~~~~~~\nADD DISEASE DETAILS------------------------------------>PRESS 1\nADD SYMPTOM TO DISEASE--------------------------------->PRESS 2\nTO CHECK PATIENT DETAILS------------------------------->PRESS 3\nPS: ANY OTHER KEY IS CONSIDERED AS EXIT........................";
        private static bool processMenu(Options choice)
        {
            switch (choice)
            {
                case Options.Add:
                    AddPatientDetails();
                    break;

                case Options.Upadate:
                    AddDiseaseDetails();
                    break;

                case Options.ViewPatient:
                    ViewpatientReport();
                    break;

                default:
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            bool processing = true;
            do
            {
                Options choice = (Options)Utilities.GetNumber(menu);
                processing = processMenu(choice);
                Utilities.Prompt("press Enter to continue");
                Console.Clear();
            } while (processing);
            Console.WriteLine("Thanks for Using our Application!!!");
        }

    }
    internal class Utilities
    {
        internal static string Prompt(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        internal static int GetNumber(string question)
        {
            bool processing = false;
            int result;
            do
            {
                Console.WriteLine(question);
                processing = int.TryParse(Console.ReadLine(), out result);
            } while (!processing);
            return result;
        }

        public static void LogMessage(string message)
        {
            EventLog eventLog = new EventLog("Starmark", Environment.MachineName, Assembly.GetExecutingAssembly().FullName);
            eventLog.WriteEntry(message, EventLogEntryType.Error);
        }
    }
}

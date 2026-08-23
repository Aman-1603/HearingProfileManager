using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using HearingProfileManager.Models;

namespace HearingProfileManager.ViewModels
{
    public class PatientViewModel : INotifyPropertyChanged
    {
        // List that auto updates the UI
        public ObservableCollection<Patient> Patients { get; set; }

        // Form input fields
        private string inputName;
        private string inputAge;
        private string inputLevel;

        public string InputName
        {
            get { return inputName; }
            set { inputName = value; OnPropertyChanged(nameof(InputName)); }
        }

        public string InputAge
        {
            get { return inputAge; }
            set { inputAge = value; OnPropertyChanged(nameof(InputAge)); }
        }

        public string InputLevel
        {
            get { return inputLevel; }
            set { inputLevel = value; OnPropertyChanged(nameof(InputLevel)); }
        }

        // Which patient is selected in the list
        private Patient selectedPatient;
        public Patient SelectedPatient
        {
            get { return selectedPatient; }
            set { selectedPatient = value; OnPropertyChanged(nameof(SelectedPatient)); }
        }

        // Buttons
        public ICommand AddPatientCommand { get; }
        public ICommand DeletePatientCommand { get; }

        public PatientViewModel()
        {
            Patients = new ObservableCollection<Patient>();
            AddPatientCommand = new RelayCommand(AddPatient);
            DeletePatientCommand = new RelayCommand(DeletePatient);
        }

        private void AddPatient()
        {
            if (string.IsNullOrEmpty(InputName)) return;
            if (!int.TryParse(InputAge, out int age)) return;

            var patient = new Patient(InputName, age, InputLevel ?? "Mild");
            Patients.Add(patient);

            // Clear the form
            InputName = "";
            InputAge = "";
            InputLevel = "";
        }

        private void DeletePatient()
        {
            if (SelectedPatient != null)
                Patients.Remove(SelectedPatient);
        }

        // LINQ filter — used in interview to show LINQ knowledge
        public ObservableCollection<Patient> GetByLevel(string level)
        {
            var filtered = Patients
                .Where(p => p.HearingLossLevel == level)
                .ToList();
            return new ObservableCollection<Patient>(filtered);
        }

        // This tells the UI when a property changes
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
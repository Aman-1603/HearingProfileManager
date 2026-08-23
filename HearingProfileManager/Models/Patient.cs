namespace HearingProfileManager.Models
{
    public class Patient
    {
        private string name;
        private int age;
        private string hearingLossLevel;

        public Patient(string n, int a, string level)
        {
            name = n;
            age = a;
            hearingLossLevel = level;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("Name cannot be empty");
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 120)
                    throw new Exception("Invalid age");
                age = value;
            }
        }

        public string HearingLossLevel
        {
            get { return hearingLossLevel; }
            set { hearingLossLevel = value; }
        }

        public string GetSummary()
        {
            return $"{name} | Age: {age} | Loss: {hearingLossLevel}";
        }
    }
}
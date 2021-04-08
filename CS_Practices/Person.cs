namespace Practice_3
{
    public class Person
    {
        public Person(string name, string secondName, string surname)
        {
            Name = name;
            SecondName = secondName;
            Surname = surname;
        }
        
        private string _name;
        private string _secondName;
        private string _surname;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string SecondName
        {
            get => _secondName;
            set => _secondName = value;
        }

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }
    }
    
}
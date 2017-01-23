using System;
using TotoMorti.Models.Abstract;

namespace TotoMorti.Models
{
    public class Celebrity : BaseModel
    {
        private DateTime _birthdate;
        private DateTime _deathdate;
        private string _imageurl;
        private string _name;
        private string _surname;

        public Celebrity()
        {
            CelebrityGuid = Guid.NewGuid();
        }

        public Guid CelebrityGuid { get; set; }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string ImageUrl
        {
            get { return _imageurl; }
            set
            {
                _imageurl = value;
                OnPropertyChanged();
            }
        }

        public DateTime BirthDate
        {
            get { return _birthdate; }
            set
            {
                _birthdate = value;
                OnPropertyChanged();
            }
        }

        public DateTime DeathDate
        {
            get { return _deathdate; }
            set
            {
                _deathdate = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get
            {
                var age = DateTime.Now.Year - BirthDate.Year;
                if (BirthDate > DateTime.Now.AddYears(-age))
                    age--;
                return age;
            }
        }

        public string FullName => $"{Name} {Surname}";
    }
}
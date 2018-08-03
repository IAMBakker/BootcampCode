using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Model
{
    public class UserAccount
    {
        public String email { get; set; }
        public int gender { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String password { get; set; }
        public String birthDay { get; set; }
        public String birthMonth { get; set; }
        public String birthYear { get; set; }
        public bool newsLetter { get; set; }
        public bool specialOffers { get; set; }

        public UserAccount()
        {
        }

        public UserAccount(String email, int gender, String firstName, String lastName, String password,
            String birthDay, String birthMonth, String birthYear, bool newsLetter, bool specialOffers)
        {
            this.email = email;
            this.gender = gender;
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
            this.birthDay = birthDay;
            this.birthMonth = birthMonth;
            this.birthYear = birthYear;
            this.newsLetter = newsLetter;
            this.specialOffers = specialOffers;
        }
        public class Builder
        {
            private String email;
            private int gender;
            private String firstName;
            private String lastName;
            private String password;
            private String birthDay;
            private String birthMonth;
            private String birthYear;
            private bool newsLetter;
            private bool specialOffers;
            public Builder(String firstName, String lastName)
            {
                this.firstName = firstName;
                this.lastName = lastName;
            }
            public Builder withEmail(String email)
            {
                this.email = email;
                return this;
            }
            public Builder withBirthDate(int day, int month, int year)
            {
                this.birthDay = day.ToString();
                this.birthMonth = month.ToString();
                this.birthYear = year.ToString();
                return this;
            }
            public Builder withPassword(String password)
            {
                this.password = password;
                return this;
            }
            public Builder signUpToNewsLetter()
            {
                this.newsLetter = true;
                return this;
            }
            public Builder wantsSpecialOffers()
            {
                this.specialOffers = true;
                return this;
            }
            public UserAccount build()
            {
                return new UserAccount(email, gender, firstName, lastName, password,
                    birthDay, birthMonth, birthYear, newsLetter, specialOffers);
            }
        }
    }
}

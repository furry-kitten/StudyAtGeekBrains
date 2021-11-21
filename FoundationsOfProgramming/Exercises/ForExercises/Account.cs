namespace FoundationsOfProgramming.Exercises.ForExercises
{
    public class Account
    {
        private string login;

        private string password;

        private readonly char symbolForHide = '*';

        private bool needToHide = true;

        public Account(string login, string password) {
            this.login = login;
            this.password = password;
        }

        internal Account(string login, string password, char symbolForHide) {
            this.login = login;
            this.password = password;
            this.symbolForHide = symbolForHide;
        }

        internal Account(string login, string password, bool needToHide, char symbolForHide = '*') {
            this.login = login;
            this.password = password;
            this.symbolForHide = symbolForHide;
            this.needToHide = needToHide;
        }

        public string Login {
            get => Hide(login);
            set => login = value;
        }

        public string Password {
            get => Hide(password);
            set => password = value;
        }

        internal string LoginVisible {
            get => login;
            set => login = value;
        }

        internal string PasswordVisible {
            get => password;
            set => password = value;
        }


        private string Hide(string text) => needToHide ? new string ('*', text.Length) : text;
    }
}

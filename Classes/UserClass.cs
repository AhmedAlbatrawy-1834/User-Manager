namespace Classes
{
    public class User
    {
        private string _name=null;
        private string _phone=null;
        private string _email=null;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public override string ToString()
        {
            return $"Name: {Name}\nPhone: {Phone}\nEmail: {Email}";
        }

    }
}

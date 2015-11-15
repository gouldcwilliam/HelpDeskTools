namespace Shared
{
	public class UserDetails
    {
        public string name { get; set; }
        public string birthday { get; set; }

        public UserDetails()
        {
            name = string.Empty;
            birthday = string.Empty;
        }

        public UserDetails(string n, string b)
        {
            name = n;
            birthday = b;
        }

        public override string ToString()
        {
            return string.Format("{0}\n{1}", name, birthday);
        }
    }
}

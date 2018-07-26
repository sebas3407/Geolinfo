using System;
namespace Lands.Models
{
    public class Border
    {
		public Border(string alpha3Code, string name)
		{
			Code = alpha3Code;
			Name = name;
		}

		public String Code
        {
            get;
            set;
        }

        public String Name
        {
            get;
            set;
        }
    }
}

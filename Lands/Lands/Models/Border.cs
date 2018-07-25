using System;
namespace Lands.Models
{
    public class Border
    {
		private string alpha3Code;

		public Border(string alpha3Code, string name)
		{
			this.alpha3Code = alpha3Code;
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

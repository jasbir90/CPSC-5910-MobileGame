using System;
using System.Collections.Generic;

namespace CadmusDND
{
    public class ItemAPIResponseModel
    {
        public string msg{
            get;
            set;
        }
		public string errorCode
		{
			get;
			set;
		}

        public List<APIDataModel> data
		{
			get;
			set;
		}

	}
}

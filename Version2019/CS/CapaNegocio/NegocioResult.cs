using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
	public class NegocioResult
	{
		public String successMsg;
		public List<String> errorMsgs;

		public NegocioResult()
		{
			successMsg = "";
			errorMsgs = new List<String>();
		}

		public void SetSuccessMessage(String msg)
		{
			successMsg = msg;
		}

		public void AddError(String msg)
		{
			errorMsgs.Add(msg);
		}

		public bool IsOK
		{
			get
			{
				return errorMsgs.Count == 0;
			}
		}

		public void AddResult(NegocioResult other)
		{
			foreach (String err in other.errorMsgs)
			{
				errorMsgs.Add(err);
			}
		}

		public String GetMessage()
		{
			String result = "";
			if(IsOK)
			{
				result = successMsg;
			}
			else
			{
				for(int i = 0; i < errorMsgs.Count; i++)
				{
					if(i != 0)
					{
						result += "\r\n";
					}
					result += errorMsgs[i];
				}
			}
			return result;
		}
	}
}

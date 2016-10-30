using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectoSpecFlow
{
    public class Constants
    {
        public static readonly string APPNAME = "Mayo Clinic";
		public static readonly string NATIVEAPP = "NATIVE_APP";
		public static readonly string WEBVIEW = "WEBVIEW";
		public static readonly string VISUAL = "VISUAL";
		public static readonly string IOS = "IOS";
		public static readonly string ANDROID = "ANDROID";
		public static readonly string MAYO_USERNAME = "ppimn03303925";
		public static readonly string MAYO_PASSWORD = "testing1";
		public static readonly string UNKNOWN = "Unknown";
		public static readonly string UNHANDLEDEX = "Unhandled Exception Encountered";
		public static readonly string COMPLETED = "Completed";
		public static readonly string PASS = "Pass";
		public static readonly string FAIL = "Fail";

		public enum Rotation
		{
			PORTRAIT, LANDSCAPE
		}
	}
}

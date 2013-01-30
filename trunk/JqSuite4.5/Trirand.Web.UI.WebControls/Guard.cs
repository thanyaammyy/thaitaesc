using System;
namespace Trirand.Web.UI.WebControls
{
	public static class Guard
	{
		public static void IsNull(object parameter, string parameterName)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(parameterName, " cannot be null.");
			}
		}
		public static void IsNull(object parameter, string parameterName, string message)
		{
			if (parameter == null)
			{
				throw new ArgumentNullException(parameterName, " " + message);
			}
		}
		public static void IsNullOrEmpty(string parameter, string parameterName)
		{
			if (string.IsNullOrEmpty(parameter))
			{
				throw new ArgumentException(parameterName, " cannot be null or empty.");
			}
		}
		public static void IsNullOrEmpty(string parameter, string parameterName, string message)
		{
			if (string.IsNullOrEmpty(parameter))
			{
				throw new ArgumentException(parameterName, " " + message);
			}
		}
		public static void IsEqual(object object1, object object2, string message)
		{
			if (object1.Equals(object2))
			{
				throw new ArgumentException(message);
			}
		}
		public static void IsTrue(bool condition, string message)
		{
			if (condition)
			{
				throw new ArgumentException(message);
			}
		}
		public static void IsNotNullOrEmpty(string parameter, string parameterName)
		{
			if (string.IsNullOrEmpty(parameter))
			{
				throw new ArgumentNullException(parameterName, " cannot be null or empty.");
			}
		}
		public static void IsNotNullOrEmpty(string parameter, string parameterName, string message)
		{
			if (string.IsNullOrEmpty(parameter))
			{
				throw new ArgumentNullException(parameterName, " " + message);
			}
		}
	}
}

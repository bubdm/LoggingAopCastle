using System;
using System.Linq;
using System.Text;
using Castle.Core.Logging;
using Castle.DynamicProxy;

namespace LoggingAopCastle.LogHelpers
{
    public static class LogExtensions
    {
        public static void LogError(this ILogger logger, IInvocation invocation, Exception ex)
        {
            var invocationString = logger.CreateInvocationLogString(invocation);

            logger.ErrorFormat(invocationString +
                               Environment.NewLine + Environment.NewLine + "~~ Start of exception report ~~" +
                               Environment.NewLine + Environment.NewLine +
                               "Error occurred whilst executing: " + invocationString + Environment.NewLine +
                               "Exception type: " + ex.GetType().Name + Environment.NewLine +
                               "Message: " + ex.Message + Environment.NewLine +
                               "------------------------" + Environment.NewLine + "Contents of stack trace:" +
                               Environment.NewLine + ex.StackTrace + Environment.NewLine +
                               "------------------------" + Environment.NewLine + Environment.NewLine +
                               "~~ End of exception report ~~" + Environment.NewLine);
        }

        public static String CreateInvocationLogString(this ILogger logger, IInvocation invocation)
        {
            StringBuilder sb = new StringBuilder(100);
            sb.AppendFormat("{0}.{1}(", invocation.TargetType.Name, invocation.Method.Name);
            foreach (object argument in invocation.Arguments)
            {
                String argumentDescription = argument == null ? "null" : logger.DumpObject(argument);
                sb.Append(argumentDescription).Append(",");
            }
            if (invocation.Arguments.Count() > 0) sb.Length--;
            sb.Append(")");
            return sb.ToString();
        }

        private static string DumpObject(this ILogger logger, object argument)
        {
            Type objtype = argument.GetType();

            return objtype.Name + " " + "'" + argument + "'";
        }
    }
}

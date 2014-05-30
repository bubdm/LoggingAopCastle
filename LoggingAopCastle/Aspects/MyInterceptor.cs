using System;
using System.IO;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using LoggingAopCastle.LogHelpers;

namespace LoggingAopCastle.Aspects
{
    public class MyInterceptor : IInterceptor
    {
        private readonly ILogger _logger;
        private string _projectName;

        public MyInterceptor(ILogger logger)
        {
            _logger = logger;
        }
 
        public void Intercept(IInvocation invocation)
        {
            _projectName = Path.GetFileName(invocation.TargetType.Namespace);
            var invocationString = _logger.CreateInvocationLogString(invocation);
            

            if (_logger.IsDebugEnabled) _logger.Debug(_projectName + ": Calling method " + invocationString);
            try
            {
                if (_logger.IsInfoEnabled) _logger.Info(" " + _projectName + ": Entering method " + invocation.TargetType.Name + "."+ invocation.Method.Name);

                invocation.Proceed();
                bool hasReturnValue = invocation.ReturnValue != null;

                if (hasReturnValue && _logger.IsDebugEnabled)
                {
                     _logger.Debug(_projectName + ": Method " + invocationString + " returned " + invocation.ReturnValue.GetType() +" '"+invocation.ReturnValue.ToString()+"'");                    
                }
                 
                if (_logger.IsInfoEnabled) _logger.Info(" " + _projectName + ": Exiting method " + invocation.TargetType.Name + "." + invocation.Method.Name);
            }
            catch (Exception ex)
            { 

                if (_logger.IsErrorEnabled) _logger.LogError(invocation, ex);
            }
        } 
    }
}

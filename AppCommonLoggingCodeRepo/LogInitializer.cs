using Common.Logging;
using Common.Logging.Configuration;
using Common.Logging.Factory;
using Common.Logging.Log4Net;
using log4net.Config;
using log4net.Core;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace AppCommonLoggingCode2
{
    internal static class LogInitializer
    {
        internal static void Initialize()
        {
            var configFile = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config"));
            var myRepo = log4net.LogManager.CreateRepository("my-repo");
            XmlConfigurator.ConfigureAndWatch(myRepo, configFile);

            var loggerFactoryAdapter = new RepositoryLog4NetLoggerFactoryAdapter(myRepo.Name);
            LogManager.Adapter = loggerFactoryAdapter;
        }
    }

    public class RepositoryLog4NetLoggerFactoryAdapter : AbstractCachingLoggerFactoryAdapter
    {
        private readonly ILoggerRepository repository;
        public RepositoryLog4NetLoggerFactoryAdapter(string repositoryName)
        {
            this.repository = log4net.LogManager.GetRepository(repositoryName);
        }

        protected override ILog CreateLogger(string name)
        {
            return new Log4NetLogger(repository.GetLogger(name));
        }
    }

    ///<summary>
    ///<see cref="Common.Logging.Log4Net.Log4NetLogger"/> which does not have a public constructor
    ///</summary>
    public class Log4NetLogger : AbstractLogger
    {
        private readonly ILogger _logger;

        private static Type callerStackBoundaryType;

        public override bool IsTraceEnabled => _logger.IsEnabledFor(Level.Trace);

        public override bool IsDebugEnabled => _logger.IsEnabledFor(Level.Debug);

        public override bool IsInfoEnabled => _logger.IsEnabledFor(Level.Info);

        public override bool IsWarnEnabled => _logger.IsEnabledFor(Level.Warn);

        public override bool IsErrorEnabled => _logger.IsEnabledFor(Level.Error);

        public override bool IsFatalEnabled => _logger.IsEnabledFor(Level.Fatal);

        public override IVariablesContext GlobalVariablesContext => new Log4NetGlobalVariablesContext();

        public override IVariablesContext ThreadVariablesContext => new Log4NetThreadVariablesContext();

        public override INestedVariablesContext NestedThreadVariablesContext => new Log4NetNestedThreadVariablesContext();

        public Log4NetLogger(ILogger logger)
        {
            _logger = logger;
        }

        protected override void WriteInternal(LogLevel logLevel, object message, Exception exception)
        {
            if (callerStackBoundaryType == null)
            {
                lock (GetType())
                {
                    StackTrace stack = new StackTrace();
                    Type thisType = GetType();
                    callerStackBoundaryType = typeof(AbstractLogger);
                    for (int i = 1; i < stack.FrameCount; i++)
                    {
                        if (!IsInTypeHierarchy(thisType, stack.GetFrame(i).GetMethod().DeclaringType))
                        {
                            callerStackBoundaryType = stack.GetFrame(i - 1).GetMethod().DeclaringType;
                            break;
                        }
                    }
                }
            }
            Level level = GetLevel(logLevel);
            _logger.Log(callerStackBoundaryType, level, message, exception);
        }

        private bool IsInTypeHierarchy(Type currentType, Type checkType)
        {
            while (currentType != null && currentType != typeof(object))
            {
                if (currentType == checkType)
                {
                    return true;
                }
                currentType = currentType.BaseType;
            }
            return false;
        }

        public static Level GetLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.All:
                    return Level.All;
                case LogLevel.Trace:
                    return Level.Trace;
                case LogLevel.Debug:
                    return Level.Debug;
                case LogLevel.Info:
                    return Level.Info;
                case LogLevel.Warn:
                    return Level.Warn;
                case LogLevel.Error:
                    return Level.Error;
                case LogLevel.Fatal:
                    return Level.Fatal;
                default:
                    throw new ArgumentOutOfRangeException("logLevel", logLevel, "unknown log level");
            }
        }
    }
}

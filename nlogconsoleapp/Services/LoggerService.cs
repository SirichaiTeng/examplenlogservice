﻿using NLog;
using nlogconsoleapp.IServices;

namespace nlogconsoleapp.Services;

public class LoggerService : ILoggerService
{
    private static Logger logger = LogManager.GetCurrentClassLogger();
    public void LogDebug(string message) => logger.Debug(message);

    public void LogError(string message) => logger.Error(message);

    public void LogInfo(string message) => logger.Info(message);

    public void LogWarn(string message) => logger.Warn(message);

}

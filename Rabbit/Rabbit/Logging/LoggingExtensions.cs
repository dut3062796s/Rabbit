using System;

namespace Rabbit.Logging {
    /// <summary>
    /// ��־��¼����չ������
    /// </summary>
    public static class LoggingExtenions {
        #region Public Method

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="message">��Ϣ��</param>
        public static void Debug(this ILogger logger, string message) {
            FilteredLog(logger, LogLevel.Debug, null, message, null);
        }

        /// <summary>
        /// ��¼һ����Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="message">��Ϣ��</param>
        public static void Information(this ILogger logger, string message) {
            FilteredLog(logger, LogLevel.Information, null, message, null);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="message">��Ϣ��</param>
        public static void Warning(this ILogger logger, string message) {
            FilteredLog(logger, LogLevel.Warning, null, message, null);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="message">��Ϣ��</param>
        public static void Error(this ILogger logger, string message) {
            FilteredLog(logger, LogLevel.Error, null, message, null);
        }

        /// <summary>
        /// ��¼һ�������Ĵ�����Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="message">��Ϣ��</param>
        public static void Fatal(this ILogger logger, string message) {
            FilteredLog(logger, LogLevel.Fatal, null, message, null);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Debug(this ILogger logger, Exception exception, string message) {
            FilteredLog(logger, LogLevel.Debug, exception, message, null);
        }

        /// <summary>
        /// ��¼һ����Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Information(this ILogger logger, Exception exception, string message) {
            FilteredLog(logger, LogLevel.Information, exception, message, null);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Warning(this ILogger logger, Exception exception, string message) {
            FilteredLog(logger, LogLevel.Warning, exception, message, null);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Error(this ILogger logger, Exception exception, string message) {
            FilteredLog(logger, LogLevel.Error, exception, message, null);
        }

        /// <summary>
        /// ��¼һ�������Ĵ�����Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Fatal(this ILogger logger, Exception exception, string message) {
            FilteredLog(logger, LogLevel.Fatal, exception, message, null);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="message">��Ϣ��</param>
        public static void Debug(this ILogger logger, Func<string> message) {
            FilteredLog(logger, LogLevel.Debug, null, message);
        }

        /// <summary>
        /// ��¼һ����Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="message">��Ϣ��</param>
        public static void Information(this ILogger logger, Func<string> message) {
            FilteredLog(logger, LogLevel.Information, null, message);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="message">��Ϣ��</param>
        public static void Warning(this ILogger logger, Func<string> message) {
            FilteredLog(logger, LogLevel.Warning, null, message);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="message">��Ϣ��</param>
        public static void Error(this ILogger logger, Func<string> message) {
            FilteredLog(logger, LogLevel.Error, null, message);
        }

        /// <summary>
        /// ��¼һ�������Ĵ�����Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="message">��Ϣ��</param>
        public static void Fatal(this ILogger logger, Func<string> message) {
            FilteredLog(logger, LogLevel.Fatal, null, message);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Debug(this ILogger logger, Exception exception, Func<string> message) {
            FilteredLog(logger, LogLevel.Debug, exception, message);
        }

        /// <summary>
        /// ��¼һ����Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Information(this ILogger logger, Exception exception, Func<string> message) {
            FilteredLog(logger, LogLevel.Information, exception, message);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Warning(this ILogger logger, Exception exception, Func<string> message) {
            FilteredLog(logger, LogLevel.Warning, exception, message);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Error(this ILogger logger, Exception exception, Func<string> message) {
            FilteredLog(logger, LogLevel.Error, exception, message);
        }

        /// <summary>
        /// ��¼һ�������Ĵ�����Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Fatal(this ILogger logger, Exception exception, Func<string> message) {
            FilteredLog(logger, LogLevel.Fatal, exception, message);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Debug(this ILogger logger, Func<Exception> exception, Func<string> message) {
            FilteredLogFuncException(logger, LogLevel.Debug, exception, message);
        }

        /// <summary>
        /// ��¼һ����Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Information(this ILogger logger, Func<Exception> exception, Func<string> message) {
            FilteredLogFuncException(logger, LogLevel.Information, exception, message);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Warning(this ILogger logger, Func<Exception> exception, Func<string> message) {
            FilteredLogFuncException(logger, LogLevel.Warning, exception, message);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Error(this ILogger logger, Func<Exception> exception, Func<string> message) {
            FilteredLogFuncException(logger, LogLevel.Error, exception, message);
        }

        /// <summary>
        /// ��¼һ�������Ĵ�����Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="message">��Ϣ��</param>
        public static void Fatal(this ILogger logger, Func<Exception> exception, Func<string> message) {
            FilteredLogFuncException(logger, LogLevel.Fatal, exception, message);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="format">��¼��ʽ��</param>
        /// <param name="args">������</param>
        public static void Debug(this ILogger logger, string format, params object[] args) {
            FilteredLog(logger, LogLevel.Debug, null, format, args);
        }

        /// <summary>
        /// ��¼һ����Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="format">��¼��ʽ��</param>
        /// <param name="args">������</param>
        public static void Information(this ILogger logger, string format, params object[] args) {
            FilteredLog(logger, LogLevel.Information, null, format, args);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="format">��¼��ʽ��</param>
        /// <param name="args">������</param>
        public static void Warning(this ILogger logger, string format, params object[] args) {
            FilteredLog(logger, LogLevel.Warning, null, format, args);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="format">��¼��ʽ��</param>
        /// <param name="args">������</param>
        public static void Error(this ILogger logger, string format, params object[] args) {
            FilteredLog(logger, LogLevel.Error, null, format, args);
        }

        /// <summary>
        /// ��¼һ�������Ĵ�����Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="format">��¼��ʽ��</param>
        /// <param name="args">������</param>
        public static void Fatal(this ILogger logger, string format, params object[] args) {
            FilteredLog(logger, LogLevel.Fatal, null, format, args);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="format">��¼��ʽ��</param>
        /// <param name="args">������</param>
        public static void Debug(this ILogger logger, Exception exception, string format, params object[] args) {
            FilteredLog(logger, LogLevel.Debug, exception, format, args);
        }

        /// <summary>
        /// ��¼һ����Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="format">��¼��ʽ��</param>
        /// <param name="args">������</param>
        public static void Information(this ILogger logger, Exception exception, string format, params object[] args) {
            FilteredLog(logger, LogLevel.Information, exception, format, args);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="format">��¼��ʽ��</param>
        /// <param name="args">������</param>
        public static void Warning(this ILogger logger, Exception exception, string format, params object[] args) {
            FilteredLog(logger, LogLevel.Warning, exception, format, args);
        }

        /// <summary>
        /// ��¼һ��������Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="format">��¼��ʽ��</param>
        /// <param name="args">������</param>
        public static void Error(this ILogger logger, Exception exception, string format, params object[] args) {
            FilteredLog(logger, LogLevel.Error, exception, format, args);
        }

        /// <summary>
        /// ��¼һ�������Ĵ�����Ϣ��
        /// </summary>
        /// <param name="logger">��־��¼����</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="format">��¼��ʽ��</param>
        /// <param name="args">������</param>
        public static void Fatal(this ILogger logger, Exception exception, string format, params object[] args) {
            FilteredLog(logger, LogLevel.Fatal, exception, format, args);
        }

        #endregion Public Method

        #region Private Method

        private static void FilteredLogFuncException(ILogger logger, LogLevel level, Func<Exception> exception, Func<string> message)
        {
            if (logger.IsEnabled(level))
                logger.Log(level, exception==null?null:exception.Invoke(), message==null?null:message.Invoke());
        }

        private static void FilteredLog(ILogger logger, LogLevel level, Exception exception, Func<string> message)
        {
            if (logger.IsEnabled(level))
                logger.Log(level, exception, message==null?null:message.Invoke());
        }

        private static void FilteredLog(ILogger logger, LogLevel level, Exception exception, string format, object[] objects) {
            if (logger.IsEnabled(level)) {
                logger.Log(level, exception, format, objects);
            }
        }

        #endregion Private Method
    }
}
using System;

namespace Rabbit.Logging {
    /// <summary>
    /// һ���յ���־��¼����
    /// </summary>
    public class NullLogger : ILogger {
        #region Field

        #endregion Field

        #region Property

        /// <summary>
        /// ��¼��ʵ����
        /// </summary>
        public static ILogger Instance {
            get {
                return new NullLogger();
            }
        }

        #endregion Property

        #region Implementation of ILogger

        /// <summary>
        /// �ж���־��¼���Ƿ�����
        /// </summary>
        /// <param name="level">��־�ȼ���</param>
        /// <returns>�����������true�����򷵻�false��</returns>
        public bool IsEnabled(LogLevel level) {
            return false;
        }

        /// <summary>
        /// ��¼��־��
        /// </summary>
        /// <param name="level">��־�ȼ���</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="format">��ʽ��</param>
        /// <param name="args">������</param>
        public void Log(LogLevel level, Exception exception, string format, params object[] args) {
        }

        #endregion Implementation of ILogger
    }
}
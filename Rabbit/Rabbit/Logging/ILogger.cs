using System;

namespace Rabbit.Logging
{
    /// <summary>
    /// ��־�ȼ���
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// ׷�١�
        /// </summary>
        Trace,

        /// <summary>
        /// ���ԡ�
        /// </summary>
        Debug,

        /// <summary>
        /// ��Ϣ��
        /// </summary>
        Information,

        /// <summary>
        /// ���档
        /// </summary>
        Warning,

        /// <summary>
        /// ����
        /// </summary>
        Error,

        /// <summary>
        /// ��������
        /// </summary>
        Fatal
    }

    /// <summary>
    /// һ���������־��¼���ӿڡ�
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// �ж���־��¼���Ƿ�����
        /// </summary>
        /// <param name="level">��־�ȼ���</param>
        /// <returns>�����������true�����򷵻�false��</returns>
        bool IsEnabled(LogLevel level);

        /// <summary>
        /// ��¼��־��
        /// </summary>
        /// <param name="level">��־�ȼ���</param>
        /// <param name="exception">�쳣��</param>
        /// <param name="format">��ʽ��</param>
        /// <param name="args">������</param>
        void Log(LogLevel level, Exception exception, string format, params object[] args);
    }
}
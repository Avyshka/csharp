/**
 * @author Aivar Sergeev
 * @description
 * 
 * 1. �) �������� � ��������� ����������� ������� ���������� �������� ������.
 *    �) �������� ���� � ������� ��������. ��� ������� ���������� ���������,
 *       ����� ����� ������ �������� �����. ����� ������ ����������� ��������
 *       ��� ����� �� ����������� ���������� �����.
 *    �) * �������� ������ ����������, ������� �������� ��������� ����.
 * 
 * 2. ��������� Windows Forms, ����������� ���� ������� �����. ���������
 *    ���������� ����� �� 1 �� 100, � ������� �������� ��� ������� ��
 *    ����������� ����� �������. ��� ����� ������ �� �������� ������������
 *    ������� TextBox.
 */
using System;
using System.Windows.Forms;

namespace Lesson7
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
            Application.Run(new Form1());
        }
    }
}

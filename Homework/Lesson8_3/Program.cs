/**
 * @author Aivar Sergeev
 * @description
 * 3.
 * �) ������� ����������, ���������� �� �����, ������� � ���� ������ 
 *    �� ��������� ������ (�� ������� ���� ������, ��������� � ���������������
 *    �������, �������� ������� �������� ����� � �.�.).
 * �) �������� ��������� ���������, �������� �����, ������� ���� ���������
 *    � ������� ������ �������������� ��������� �� ���� ����������.
 * �) �������� � ���������� ���� �� ��������� � ����������� � ���������
 *    (�����, ������, ��������� ����� � ��.).
 * �)* �������� ����� ���� Save As, � ������� ����� ������� ���
 *     ��� ���������� ���� ������ (������� SaveFileDialog).
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson8_3
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
            Application.Run(new Form1());
        }
    }
}

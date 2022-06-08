using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Employees
{
    internal static class Helper
    {
        public static Frame MainFrame;
    }
    internal class DbContext
    {
        private static DbContext _context;

        public static DbContext getInstance()
        {
            if (_context == null)
                _context = new DbContext();
            return _context;
        }
    }
}

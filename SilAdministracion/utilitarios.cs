using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SilAdministracion
{
    class utilitarios
    {

        public static bool IsNumeric(string input)
        {
            int dummy;
            return int.TryParse(input, out dummy);
        }

        public static void ScrollToUp(TabPage p, Control c)
        {
            p.ScrollControlIntoView(c);

            //using (Control c = new Control() { Parent = p, Dock = DockStyle.Top })
            //{
            //    p.ScrollControlIntoView(c);
            //    c.Parent = null;
            //}
        }

        public static void ScrollToUp(TabPage p)
        {
           // p.ScrollControlIntoView(c);

            using (Control c = new Control() { Parent = p, Dock = DockStyle.Top })
            {
                p.ScrollControlIntoView(c);
                c.Parent = null;
            }
        }
    }
}

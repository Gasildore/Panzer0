using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panzer0.Map
{
    internal class TankView
    {
        public static readonly string[] Up =
        {
            "╭─╿─╮",
            "║ 0 ║",
            "╰───╯"
        };

        public static readonly string[] Down =
        {
            "╭───╮",
            "║ 0 ║",
            "╰─╽─╯"
        };

        public static readonly string[] Left =
        {
            "╭═══╮",
            "╾─0 │",
            "╰═══╯"
        };

        public static readonly string[] Right =
        {
            "╭═══╮",
            "│ 0─╼",
            "╰═══╯"
        };
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Smartboard.Business.Entities
{
    public class Thumbnail
    {
        public int BookId
        { get; set; }

        public int PageId
        { get; set; }

        public Image Image
        { get; set; }
    }
}

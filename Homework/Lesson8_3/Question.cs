using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8_3
{
    public class Question
    {
        public string Text { get; set; }
        public bool TrueFalse { get; set; }

        public Question(string text, bool trueFalse)
        {
            this.Text = text;
            this.TrueFalse = trueFalse;
        }

        public Question() { }
    }
}

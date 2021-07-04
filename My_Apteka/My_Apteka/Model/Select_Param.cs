using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace My_Apteka
{
    internal class Select_Param
    {
        private List<Apt> apts;

        public Select_Param(List<Apt> apts)
        {
            this.apts = apts;
        }

        internal List<Apt> Select_Node(TextBox textBox_Select)
            {
                var select = from node in apts
                             where node.Node.ToString().Contains(textBox_Select.Text)
                             select node;
            return select.ToList();
            }

        internal List<Apt> Select_UR(TextBox textBox_Select)
        {
            string text = textBox_Select.Text;
            text = text.ToUpper();
                var select = from node in apts
                             where node.UR.Contains(text)
                             select node;
                return select.ToList();
        }

        internal List<Apt> Select_ADDress(TextBox textBox_Select)
        {
            string text = textBox_Select.Text;

            if (text.Length != 0)
            {
                text = char.ToUpper(text[0]).ToString() + text.Substring(1);
            }
            var select = from node in apts
                         where node.Address.Contains(text)
                         select node;
            return select.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndDirectories
{
    internal class Book
    {
        public int Id { get; set; }
        public Guid ISBN { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public int NumberOfPages { get; set; }
        public short NumberOfCopies { get; set; }
        public short NumberOfBorrowedOut { get; set; }
        public DateTime DatePublished { get; set; }


        public string ToCSV()
        {
            string str;
            str = string.Format("{0},{1},{2},{3},{4}", Id, ISBN, Author, Name, DatePublished);
            return str;
        }
        public string ToFixedLength()
        {
            string str = "";
            string id = Id.ToString();
            if (id.Length <= 20)
            {
                str += id;
                for (int i = id.Length; i < 20; i++)
                {
                    str += " ";
                }
            }
            else
            {
                string id2 = "";
                for (int i = 0; i < 20; i++)
                {
                    id2 += id[i];
                }
                str += id2;
            }

            if (Author.Length <= 20)
            {
                str += Author;
                for (int i = Author.Length; i < 20; i++)
                {
                    str += " ";
                }
            }
            else
            {
                string Author2 = "";
                for (int i = 0; i < 20; i++)
                {
                    Author2 += Author[i];
                }
                str += Author2;
            }

            if (Name.Length <= 20)
            {
                str += Name;
                for (int i = Name.Length; i < 20; i++)
                {
                    str += " ";
                }
            }
            else
            {
                string Name2 = "";
                for (int i = 0; i < 20; i++)
                {
                    Name2 += Name[i];
                }
                str += Name2;
            }

            string nop = NumberOfPages.ToString();
            if (nop.Length <= 5)
            {
                str += nop;
                for (int i = nop.Length; i < 5; i++)
                {
                    str += " ";
                }
            }
            else
            {
                string nop2 = "";
                for (int i = 0; i < 5; i++)
                {
                    nop2 += nop[i];
                }
                str += nop2;
            }

            string noc = NumberOfCopies.ToString();
            if (noc.Length <= 5)
            {
                str += noc;
                for (int i = noc.Length; i < 5; i++)
                {
                    str += " ";
                }
            }
            else
            {
                string noc2 = "";
                for (int i = 0; i < 5; i++)
                {
                    noc2 += noc[i];
                }
                str += noc2;
            }

            string nobo = NumberOfBorrowedOut.ToString();
            if (nobo.Length <= 5)
            {
                str += nobo;
                for (int i = nobo.Length; i < 5; i++)
                {
                    str += " ";
                }
            }
            else
            {
                string nobo2 = "";
                for (int i = 0; i < 5; i++)
                {
                    nobo2 += nobo[i];
                }
                str += nobo2;
            }

            string dp = DatePublished.ToString();
            if (dp.Length <= 20)
            {
                str += dp;
                for (int i = dp.Length; i < 20; i++)
                {
                    str += " ";
                }
            }
            else
            {
                string dp2 = "";
                for (int i = 0; i < 20; i++)
                {
                    dp2 += dp[i];
                }
                str += dp2;
            }

            return str;
        }
    }
}

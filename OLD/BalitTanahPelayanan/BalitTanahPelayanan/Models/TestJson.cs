using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BalitTanahPelayanan.Models
{
    public class TestJson
    {
        public List<Content2> data0 { get; set; }
        public List<Content3> data { get; set; }
        public List<Content4> data2 { get; set; }
        public List<Content5> data3 { get; set; }
        public List<Content6> data4 { get; set; }
    }


    public class Content2
    {
        public string HeaderSlider1 { get; set; }
        public string ParagrafSlider1 { get; set; }
        public string ImageSlider { get; set; }

        public string HeaderSlider2 { get; set; }
        public string ParagrafSlider2 { get; set; }
        public string ImageSlider2 { get; set; }

        public string HeaderSlider3 { get; set; }
        public string ParagrafSlider3 { get; set; }
        public string ImageSlider3 { get; set; }
    }

    //content 3
    public class Content3
    {
        public string Header { get; set; }
        public string paragraf { get; set; }

        public string Header2 { get; set; }
        public string paragraf2 { get; set; }

        public string Header3 { get; set; }
        public string paragraf3 { get; set; }

    }

    public class Content4
    {
        public string Content { get; set; }
        public string Content2 { get; set; }
        public string Desco { get; set; }
        public string image { get; set; }
    }

    public class Content5
    {
        public string HeaderList { get; set; }
        public string paragraf1List { get; set; }
        public string paragraf2List { get; set; }
        public string paragraf3List { get; set; }


    }

    public class Content6
    {
        public string ContentUnder { get; set; }
        public string Content2Under { get; set; }
        public string DescUnder { get; set; }
        public string imageUnder { get; set; }
    }
}
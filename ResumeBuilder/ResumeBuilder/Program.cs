using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static StringWriter stringWriter;
        static HtmlTextWriter writer;
        static void Main()
        {
            stringWriter = new StringWriter();
            writer = new HtmlTextWriter(stringWriter);
            string htmlCode = "";

            WriteHeader();
            WriteEducation();
            WriteWorkExperience();
            WriteAwards();

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Denny\Documents\BitchinTestFolder\HelloWorld.html"))
            {
                file.WriteLine(stringWriter.ToString());
            }
        }

        private static string WriteHeader()
        {
            // Put HtmlTextWriter in using block because it needs to call Dispose.
            using (writer)
            {
                // Some strings for the attributes.
                string name = "Dennis Wessel";
                string[] address = { "216 Pilgrim Ln", "Upper Darby, PA" };
                string phone = "302-757-6434";

                //Center
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "header");
                writer.RenderBeginTag(HtmlTextWriterTag.Center);

                //Name
                writer.RenderBeginTag(HtmlTextWriterTag.H1);
                writer.Write(name);
                writer.RenderEndTag();

                //Address
                foreach (string addressLine in address)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.H3);
                    writer.Write(addressLine);
                    writer.RenderEndTag();
                }

                //Phone #
                writer.RenderBeginTag(HtmlTextWriterTag.Span);
                writer.Write(phone);
                writer.RenderEndTag();

                writer.RenderEndTag(); //End Center

                //Write a line at the bottom
                writer.RenderBeginTag(HtmlTextWriterTag.Hr);
            }
            // Return the result.
            return stringWriter.ToString();
        }

        private static string WriteEducation()
        {
            using (writer)
            {
                // Some strings for the attributes.
                string[] school = { "University Of Delaware", "Salesianum" };
                string[] schoolWebsite = { "www.udel.edu", "www.Salesianum.org" };
                string[] graduated = { "Winter 2015", "Spring 2011" };

                //Div
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "education");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);

                writer.RenderBeginTag(HtmlTextWriterTag.H2);
                writer.Write("Education");
                writer.RenderEndTag();//H2
                for (int i = 0; i < school.Length; i++)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.Div);

                    writer.AddAttribute(HtmlTextWriterAttribute.Href, schoolWebsite[i]);
                    writer.RenderBeginTag(HtmlTextWriterTag.A);
                    writer.Write(school[i]);
                    writer.RenderEndTag();//A

                    writer.Write("\t-\tGraduated " + graduated[i]);

                    writer.RenderEndTag();//Div
                }

                writer.RenderEndTag();//Div

                //Write a line at the bottom
                writer.RenderBeginTag(HtmlTextWriterTag.Hr);
            }
            // Return the result.
            return stringWriter.ToString();
        }


        private static string WriteWorkExperience()
        {
            using (writer)
            {
                string[] employer = { "eMoney Advisor", "Highmark Health", "JP Morgan Chase" };
                string[] description = { "Developed scripts in C# to scrape account data from banking websites",
                "Wrote Cobol for Mainframe applications that resolved insurance payments",
                "Developed inhouse software in C# to make reconciliations for the loan team"};
                string[] employmentPeriod = { "February 2016 - July 2016", "June 2015 - August 2015", "June 2013 - August 2014" };

                //Div
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "experience");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);

                writer.RenderBeginTag(HtmlTextWriterTag.H2);
                writer.Write("Field Experience");
                writer.RenderEndTag();//H2
                for (int i = 0; i < employer.Length; i++)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.H3);
                    writer.RenderBeginTag(HtmlTextWriterTag.B);
                    writer.Write(employer[i]);
                    writer.RenderEndTag();//B
                    writer.Write(String.Format(" :\t\t{0}", employmentPeriod[i]));
                    writer.RenderEndTag(); // H3

                    writer.RenderBeginTag(HtmlTextWriterTag.H5);
                    writer.Write(String.Format("\t\t{0}", description[i]));
                    writer.RenderEndTag();//H5
                    writer.RenderBeginTag(HtmlTextWriterTag.Br);
                    writer.RenderEndTag();
                }

                writer.RenderEndTag();//Div
                //Write a line at the bottom
                writer.RenderBeginTag(HtmlTextWriterTag.Hr);
            }
            // Return the result.
            return stringWriter.ToString();
        }

        private static string WriteAwards()
        {
            using (writer)
            {
                string[] awardName = { "Philly's Beautiful Code Award", "50 Push Ups" };
                string[] description = { "Recognized as a programmer in the Philadelphia who makes software developers weep happy tears at the sight of his code",
                "DS award given to any employee that can do 50 push ups"};
                string[] dateWon = { "September 2000", "March 2016" };

                //Div
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "awards");
                writer.RenderBeginTag(HtmlTextWriterTag.Div);

                writer.RenderBeginTag(HtmlTextWriterTag.H2);
                writer.Write("Awards and Honors");
                writer.RenderEndTag();//H2
                for (int i = 0; i < awardName.Length; i++)
                {
                    writer.RenderBeginTag(HtmlTextWriterTag.H4);
                    writer.Write(awardName[i]);
                    writer.RenderEndTag();//H4
                    writer.RenderBeginTag(HtmlTextWriterTag.H5);
                    writer.Write(String.Format("\t-\t{0}. Awarded: {1}", description[i], dateWon[i]));
                    writer.RenderEndTag(); // H3

                }

                writer.RenderEndTag();//Div
            }

            return writer.ToString();
        }

    }
}

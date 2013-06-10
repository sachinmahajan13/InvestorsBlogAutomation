using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace InvestorBlogAutomation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //


       


            // Create a request using a URL that can receive a post. 
            WebRequest request = WebRequest.Create("https://api.hubapi.com/blog/v1/0d61e4ca-e395-4c1c-8766-afaa48bf68db/posts.atom?access_token=demooooo-oooo-oooo-oooo-oooooooooooo");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "<?xml version=\"1.0\" encoding=\"utf-8\"?> <entry xmlns=\"http://www.w3.org/2005/Atom\">  <title>find this one</title> <author> <name>Test Author</name><email>sachin@synoris.com</email> </author>  <summary>testing hapihp summary</summary> <content type=\"html\"><![CDATA[this is the content for testing hapihp]]></content> <category term=\"hapihp tag 1\" /><category term=\"hapihp tag 2\" /> </entry>";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/atom+xml";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

        }

        private void CreateBlogPost()
        {

        }
    }
}

using JoeBlogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wordpress_post
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string link = "https://site.com";
            string username = "admin";
            string password = "password";
            // webBrowser1.Navigate(url); -- IE --
            var wp = new WordPressWrapper(link + "/xmlrpc.php", username, password);

            var a = new Comment();





            a.AuthorEmail = "ali@test.com";


            a.AuthorName = "test Blogs";


            a.Content = "This is comment";


            a.AuthorUrl = "www.test.com";


            wp.NewComment(11, null, a.Content, a.AuthorName, a.AuthorUrl, a.AuthorEmail);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string link = "https://site.com";
            string username = "admin";
            string password = "password";
            // webBrowser1.Navigate(url); -- IE -- 

            var wp = new WordPressWrapper(link + "/xmlrpc.php", username, password);

            /* image upload
                byte[] imageData = System.IO.File.ReadAllBytes("image.png");
                var image = wp.NewMediaObject(new MediaObject { Bits = imageData, Name = "image" });
                str = str.Replace("[SCREENSHOT1]", image.URL);
            */
            var post = new Post();
            post.DateCreated = DateTime.Today.AddHours(0);
            post.Title = "title";
            post.Body = "postContent";
            //post.Tags = tags.Split(',');






            //if (checkBox1.Checked == true)
            //{
            //    ////Let distraction come --- custom fields///
            //    var cfs = new CustomField[]
            //    {
            //        new CustomField()
            //        {
            //            Key = "_aioseop_title",
            //            Value = aioTitle
            //        },
            //        new CustomField()
            //        {
            //            Key = "_aioseop_description",
            //            Value = aioContent
            //        },
            //        new CustomField()
            //        {
            //            Key = "_aioseop_keywords",
            //            Value = aioTags
            //        }
            //    };

            //    post.CustomFields = cfs;

                //...  */
            //}
            wp.NewPost(post, false);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JoeBlogs;

namespace JoeBlogsWordpressWrapperTests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (this.checkBox1.Checked == true)
            {
                this.maskedTextBox5.Enabled = true;
                this.maskedTextBox6.Enabled = true;
                this.richTextBox2.Enabled = true;
            }
            else
            {
                this.maskedTextBox5.Enabled = false;
                this.maskedTextBox6.Enabled = false;
                this.richTextBox2.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(this.checkBox1.Checked == true)
            {
                this.maskedTextBox5.Enabled = true;
                this.maskedTextBox6.Enabled = true;
                this.richTextBox2.Enabled = true;
            }
            else
            {
                this.maskedTextBox5.Enabled = false;
                this.maskedTextBox6.Enabled = false;
                this.richTextBox2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = this.maskedTextBox7.Text;
            string post = this.richTextBox1.Text;
            string tags = this.maskedTextBox4.Text;

            string aioTitle = this.maskedTextBox5.Text;
            string aioContent = this.richTextBox2.Text;
            string aioTags = this.maskedTextBox6.Text;

            /////////////////////////////////////////////////////////////////////////////////////////////////

            if (this.richTextBox1.Text != "" && this.maskedTextBox4.Text != "" && this.maskedTextBox7.Text != "")
            {
                if (checkBox1.Checked == true)
                {
                    if (richTextBox2.Text != "" && maskedTextBox5.Text != "" && maskedTextBox6.Text != "")
                        postToWordpress(title, post, tags, aioTitle, aioContent, aioTags);
                    else
                        MessageBox.Show("Complete AIO SEO fields..._|_");
                }
                else
                    postToWordpress(title, post, tags, null, null, null);

            }
            else
                MessageBox.Show("Insert post and tags motha... :)");
        }

        private void postToWordpress(string title, string postContent, string tags, string aioTitle, string aioContent, string aioTags)
        {
            string link = this.maskedTextBox1.Text;
            string username = this.maskedTextBox2.Text;
            string password = this.maskedTextBox3.Text;
            // webBrowser1.Navigate(url); -- IE -- 
            
            var wp = new WordPressWrapper(link + "/xmlrpc.php", username, password);
            
            /* image upload
                byte[] imageData = System.IO.File.ReadAllBytes("image.png");
                var image = wp.NewMediaObject(new MediaObject { Bits = imageData, Name = "image" });
                str = str.Replace("[SCREENSHOT1]", image.URL);
            */
            var post = new Post();
            post.DateCreated = DateTime.Today.AddHours(0);
            post.Title = title;
            post.Body = postContent;
            post.Tags = tags.Split(',');
           
           



            
            if (checkBox1.Checked == true)
            {
                ////Let distraction come --- custom fields///
                var cfs = new CustomField[] 
                { 
                    new CustomField() 
                    { 
                        Key = "_aioseop_title", 
                        Value = aioTitle 
                    },
                    new CustomField()
                    {
                        Key = "_aioseop_description",
                        Value = aioContent
                    },
                    new CustomField()
                    {
                        Key = "_aioseop_keywords",
                        Value = aioTags
                    }
                };

                post.CustomFields = cfs;

                //...  */
            }
            wp.NewPost(post, false);

            

            // save
            if(System.IO.File.Exists("links.txt"))
            {
                string buff = System.IO.File.ReadAllText("links.txt");
                buff = buff + System.Environment.NewLine + wp.GetPost(post.PostID).ToString();
                System.IO.File.WriteAllText("links.txt", buff);
             }
             
            MessageBox.Show("Posted :)");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string link = this.maskedTextBox1.Text;
            string username = this.maskedTextBox2.Text;
            string password = this.maskedTextBox3.Text;
            // webBrowser1.Navigate(url); -- IE --
            var wp = new WordPressWrapper(link + "/xmlrpc.php", username, password);

            var a = new Comment();



            

            a.AuthorEmail= "alex@test.com";


            a.AuthorName = "test Blogs";


            a.Content = "This is a bit of text for the comment";


            a.AuthorUrl= "www.test.com";


            wp.NewComment(11, null, a.Content, a.AuthorName, a.AuthorUrl, a.AuthorEmail);


            //add coment


            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

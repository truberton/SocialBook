using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;
using Android.Content;

namespace SocialBook
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public List<SocialPost> postList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var listView = FindViewById<ListView>(Resource.Id.listView1);

            postList = new List<SocialPost>();
            SocialPost post1 = new SocialPost
            {
                Name = "John Smith",
                Message = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHH!!!!!!!!!!!!",
                CommentNumber = "0 Comments",
                Likes = "0 Likes",
                Date = DateTime.Now.ToString("dd/MM/yy HH:mm"),
                Comments = new List<CommentData>
                {
                    new CommentData
                    {
                        Name = "Jake",
                        Message = "REEEEEEEEEEEEEEEEEEEEEEEEEE"
                    },
                    new CommentData
                    {
                        Name = "Peeter",
                        Message = "You suck"
                    }
                }
            };
            postList.Add(post1);
            SocialPost post2 = new SocialPost
            {
                Name = "Gert-Andry Kääramees",
                Message = "oiHAIUSgbuyagbrAGBWRAiuwgrbAWMhvNIANWRgbIAGrniBINUVriANgrAIWNRgbIULARvgbIAWRGnIUGRbNGRIUgb",
                CommentNumber = "200 Comments",
                Likes = "200 Likes",
                Date = DateTime.Now.ToString("dd/MM/yy HH:mm"),
                Comments = new List<CommentData>
                {
                    new CommentData
                    {
                        Name = "Poppy",
                        Message = "AOIhgsiugb<oue"
                    },
                    new CommentData
                    {
                        Name = "Karl",
                        Message = "Buy my phone"
                    }
                }
            };
            postList.Add(post2);

            listView.Adapter = new Adapter(this, postList);
            listView.ItemClick += ListView_Click;
        }

        private void ListView_Click(object sender, AdapterView.ItemClickEventArgs e)
        {
            var commentActivity = new Intent(this, typeof(CommentActivity));
            Values.comments = postList[e.Position].Comments;
            StartActivity(commentActivity);
        }
    }
}
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;

namespace SocialBook
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var listView = FindViewById<ListView>(Resource.Id.listView1);

            List<SocialPost> postList = new List<SocialPost>();
            SocialPost post1 = new SocialPost
            {
                Status = "Just arrived in Tallinn",
                Message = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAHHHH!!!!!!!!!!!!",
                Comments = "0 Comments",
                Likes = "0 Likes",
                Date = DateTime.Now.ToString("dd/MM/yy HH:mm")
            };
            postList.Add(post1);

            listView.Adapter = new Adapter(this, postList);
        }
    }
}
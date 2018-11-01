﻿using System;
using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;

namespace SocialBook
{
    public class Adapter : BaseAdapter<SocialPost>
    {
        List<SocialPost> posts;
        Activity context;

        public Adapter(Activity context, List<SocialPost> items) : base()
        {
            this.context = context;
            this.posts = items;
        }

        public override SocialPost this[int position]
        {
            get { return posts[position]; }
        }

        public override int Count { get { return posts.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            bool liked = false;
            View view = convertView;

            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.social_base, null);
            }
            var imageBtn = view.FindViewById<ImageButton>(Resource.Id.imageButton1);
            imageBtn.Focusable = false;
            

            view.FindViewById<TextView>(Resource.Id.statusTitle).Text = posts[position].Name;
            view.FindViewById<TextView>(Resource.Id.message).Text = posts[position].Message;
            view.FindViewById<TextView>(Resource.Id.comments).Text = posts[position].CommentNumber;
            view.FindViewById<TextView>(Resource.Id.likes).Text = posts[position].Likes + " Likes";
            view.FindViewById<TextView>(Resource.Id.date).Text = posts[position].Date;

            imageBtn.Click += (sender, e) =>
            {
                switch (liked)
                {
                    case false:
                        posts[position].Likes++;
                        view.FindViewById<TextView>(Resource.Id.likes).Text = posts[position].Likes + " Likes";
                        liked = true;
                        break;
                    case true:
                        posts[position].Likes--;
                        view.FindViewById<TextView>(Resource.Id.likes).Text = posts[position].Likes + " Likes";
                        liked = false;
                        break;
                    default:
                        break;
                }
            };
            //view.FindViewById<RelativeLayout>(Resource.Id.relativeLayout1).SetBackgroundColor(Android.Graphics.Color.ParseColor("#448bff"));

            return view;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using System.IO;



namespace VTUMCASyllabus
{
    [Activity(Label = "SyllabusActivity")]
    public class SyllabusActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.syllabus);
            // Create your application here
           
            TextView text_subject = FindViewById<TextView>(Resource.Id.text_subject);
            TextView text_semister = FindViewById<TextView>(Resource.Id.text_semister);

            WebView webcontent = FindViewById<WebView>(Resource.Id.web_content);

            string contents;      
            string sem = Intent.GetStringExtra("sem");
            text_semister.Text = sem;
            string sub = Intent.GetStringExtra("sub");
            text_subject.Text = sub;
            try
            {
                using (StreamReader sr = new StreamReader(Assets.Open(sem + "/" + sub + ".txt")))
                {
                    contents = sr.ReadToEnd();
                }
                webcontent.LoadData(contents, "text/html", null);
            }
            catch(Java.IO.FileNotFoundException ex)
            {
                Toast toast = Toast.MakeText(this, ex.Message.ToString(), ToastLength.Short);
                toast.Show();
            }
            
        }
    }
}
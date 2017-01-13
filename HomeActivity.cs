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
using Android.Gms.Ads;

namespace VTUMCASyllabus
{
    [Activity]
    class HomeActivity : Android.App.Activity
    {
        AdView _bannerad;
        string semister;
        string subject;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.home);
          
            var semister_list = new string[] { "Semister 1", "Semister 2", "Semister 3", "Semister 4", "Semister 5", "Semister 6" };

            Spinner semister_spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            semister_spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, semister_list);
            semister_spinner.ItemSelected += Semister_spinner_ItemSelected;


            Button btn_notes = FindViewById<Button>(Resource.Id.btn_notes);
            btn_notes.Click += delegate {
                Toast toast = Toast.MakeText(this,"No Notes..",ToastLength.Short);
                toast.Show();
            };

            Button btn_syllabus = FindViewById<Button>(Resource.Id.btn_syllabus);
            btn_syllabus.Click += delegate
            {
                var activity = new Intent(this, typeof(SyllabusActivity));
                activity.PutExtra("sem", semister);
                activity.PutExtra("sub", subject);
                StartActivity(activity);
            };
            //--------------------------
            _bannerad = AdWrapper.ConstructStandardBanner(this, AdSize.SmartBanner, "ca-app-pub-3096368493625669/2811792034");
            _bannerad.CustomBuild();
            var layout = FindViewById<LinearLayout>(Resource.Id.linearLayout_adview);
            layout.AddView(_bannerad);
         }
        protected override void OnResume()
        {
            if (_bannerad != null) _bannerad.Resume();
            base.OnResume();
        }
        protected override void OnPause()
        {
            if (_bannerad != null) _bannerad.Pause();
            base.OnPause();
        }
        public override void OnBackPressed()
        {
            this.FinishAffinity();
            
        }
        private void subject_spinner_Itemselected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner subject_spinner = FindViewById<Spinner>(Resource.Id.spinner2);
            int i = e.Position;
            subject = subject_spinner.GetItemAtPosition(i).ToString();
        }

        private void Semister_spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner semister_spinner = FindViewById<Spinner>(Resource.Id.spinner1);
#pragma warning disable CS0162 // Unreachable code detected
            int i = e.Position;
#pragma warning restore CS0162 // Unreachable code detected
             semister = semister_spinner.GetItemAtPosition(i).ToString();

            Spinner subject_spinner = FindViewById<Spinner>(Resource.Id.spinner2);
            switch (semister)
            {
                case "Semister 1":
                    var subject_list = Resources.GetStringArray(Resource.Array.semister1);
                    subject_spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, subject_list);
                    break;

                case "Semister 2":
                    var subject_list2 = Resources.GetStringArray(Resource.Array.semister2);
                    subject_spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, subject_list2);
                    break;
                case "Semister 3":
                    var subject_list3 = Resources.GetStringArray(Resource.Array.semister3);
                    subject_spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, subject_list3);
                    break;
                case "Semister 4":
                    var subject_list4 = Resources.GetStringArray(Resource.Array.semister4);
                    subject_spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, subject_list4);
                    break;
                case "Semister 5":
                    var subject_list5 = Resources.GetStringArray(Resource.Array.semister5);
                    subject_spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, subject_list5);
                    break;
                case "Semister 6":
                    var subject_list6 = Resources.GetStringArray(Resource.Array.semister6);
                    subject_spinner.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, subject_list6);
                    break;
            }

            subject_spinner.ItemSelected += subject_spinner_Itemselected;  

        }
    }
}
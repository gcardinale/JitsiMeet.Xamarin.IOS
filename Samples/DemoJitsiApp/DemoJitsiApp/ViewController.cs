﻿using Foundation;
using JitsiXamarinBinding;
using System;
using UIKit;

namespace DemoJitsiApp
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var view = new JitsiMeetView
            {
                Delegate = new CustomJitsiMeetViewDelegate()
            };
            var options = JitsiMeetConferenceOptions.FromBuilder( builder =>
            {
                builder.ServerURL = new NSUrl("meet.jit.si");
                builder.Room = "SperiamoBene";
                builder.WelcomePageEnabled = true;
            });
            view.Join(options);
            View.AddSubview(view);
            view.Frame = View.Bounds;
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

    public class CustomJitsiMeetViewDelegate: JitsiMeetViewDelegate
    {
        
    }
}
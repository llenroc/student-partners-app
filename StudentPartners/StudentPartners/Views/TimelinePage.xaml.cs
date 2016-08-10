﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentPartners.ViewModels;

using Xamarin.Forms;

namespace StudentPartners.Views
{
    public partial class TimelinePage : ContentPage
    {
        public TimelinePage()
        {
            InitializeComponent();

            BindingContext = new TimelineViewModel();
        }
    }
}

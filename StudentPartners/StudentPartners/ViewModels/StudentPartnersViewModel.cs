﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentPartners.Models;

using Xamarin.Forms;
using StudentPartners.Helpers;
using StudentPartners.Views;

namespace StudentPartners.ViewModels
{
    public class StudentPartnersViewModel : BaseViewModel
    {
        public ObservableCollection<StudentPartner> StudentPartners { get; set; }
        Page page;

        public StudentPartnersViewModel(Page page)
        {
            this.page = page;

            var address = new Address
            {
                Attention = "Xamarin, Inc.",
                AddressLine1 = "2 Park Plaza",
                AddressLine2 = "7th Floor",
                City = "Boston",
                State = "Massachusetts",
                ZipCode = "02116",
                Country = "United States of America"
            };

            StudentPartners = new ObservableCollection<StudentPartner>
            {
                new StudentPartner { FirstName = "Nat", LastName = "Friedman", Address = address, PhotoUrl = "http://static4.businessinsider.com/image/559d359decad04574c42a3c4-480/xamarin-nat-friedman.jpg" },
                new StudentPartner { FirstName = "Miguel", LastName = "de Icaza", Address = address, PhotoUrl = "http://images.techhive.com/images/idge/imported/article/nww/2011/03/031111-deicaza-100272676-orig.jpg" },
                new StudentPartner { FirstName = "Joseph", LastName = "Hill", Address = address, PhotoUrl = "https://www.gravatar.com/avatar/f763ec6935726b7f7715808828e52223.jpg?s=256" },
                new StudentPartner { FirstName = "James", LastName = "Montemagno", Address = address, PhotoUrl = "http://www.gravatar.com/avatar/7d1f32b86a6076963e7beab73dddf7ca?s=256" },
                new StudentPartner { FirstName = "Pierce", LastName = "Boggan", Address = address, PhotoUrl = "https://avatars3.githubusercontent.com/u/1091304?v=3&s=460" },
            };

            foreach (var sp in StudentPartners)
                sp.Biography = "Pierce has built mobile applications with Xamarin since 2011 and is the author of several popular open source applications, including Moments, a Snapchat clone for iOS and Android built with Xamarin.Forms and Microsoft Azure. In 2012, he began working at Xamarin and now works as a Program Manager at Microsoft for Xamarin.";
        }

        Command refreshCommand;
        public Command RefreshCommand
        {
            get { return refreshCommand ?? (refreshCommand = new Command(async () => await ExecuteRefreshCommandAsync())); }
        }

        async Task ExecuteRefreshCommandAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                // Pull down data from ASH.
            }
            catch (Exception ex)
            {
                 Logger.Report(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        StudentPartner selectedItem;
        public StudentPartner SelectedItem
        {
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");

                if (selectedItem != null)
                {
                    page.Navigation.PushAsync(new StudentPartnersDetailPage(selectedItem));

                    SelectedItem = null;
                }
            }
            get { return selectedItem; }
        }
    }
}
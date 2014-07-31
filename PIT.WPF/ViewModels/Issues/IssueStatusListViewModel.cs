using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PIT.Core;

namespace PIT.WPF.ViewModels.Issues
{
    public class IssueStatusListViewModel : ObservableCollectionEx<IssueStatusViewModel>
    {
        public IssueStatusListViewModel(IEnumerable<IssueStatusViewModel> collection) : base(collection)
        {
        }

        public IssueStatusListViewModel(List<IssueStatusViewModel> list) : base(list)
        {
        }

        public IssueStatusListViewModel()
        {
        }

        public string DisplayText
        {
            get
            {
                IEnumerable<IssueStatusViewModel> vms = Items.Where(i => i.IsSelected);
                switch (vms.Count())
                {
                    case 0:
                        return "Status: All";
                    case 1:
                        return "Status: " + vms.FirstOrDefault().Text;
                    default:
                        return "Status: *";
                }
            }
            private set { throw new NotImplementedException(); }
        }

        public override void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.EntityViewModelPropertyChanged(sender, e);
            if (e.PropertyName == "IsSelected")
                OnPropertyChanged(new PropertyChangedEventArgs("DisplayText"));
        }
    }
}
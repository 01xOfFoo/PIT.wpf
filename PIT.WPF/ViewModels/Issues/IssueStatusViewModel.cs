using System;
using System.ComponentModel;
using PIT.Business.Entities;
using PIT.WPF.Converters;

namespace PIT.WPF.ViewModels.Issues
{
    public class IssueStatusViewModel : INotifyPropertyChanged
    {
        private bool _isSelected;

        public IssueStatusViewModel(IssueStatus status)
        {
            Status = status;
        }

        public IssueStatus Status { get; set; }

        public string Text
        {
            get { return EnumExtension.GetEnumDescription(Status); }
            set { throw new NotImplementedException(); }
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
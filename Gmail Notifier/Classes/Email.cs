using System;
using System.Collections.Generic;
using System.Text;

namespace Gmail_Notifier
{
    public class Email
    {
        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }
        public string summary
        {
            get
            {
                return _summary;
            }
            set
            {
                _summary = value;
            }
        }
        public string link
        {
            get
            {
                return _link;
            }
            set
            {
                _link = value;
            }
        }
        public DateTime modified;
        public DateTime issued;
        public string id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string author
        {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
            }
        }
        public string email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        private string _title;
        private string _summary;
        private string _link;
        //private DateTime _modified;
        //private DateTime _issued;
        private string _id;
        private string _author;
        private string _email;
    }
}

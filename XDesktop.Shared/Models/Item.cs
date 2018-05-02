using System;
using System.Collections.Generic;
using System.Text;

namespace XDesktop.Shared.Models
{
    public class Item : BaseModel
    {
        private string _name;

        public Item()
        {

        }

        #if MAC 
        Export("Name") 
        #endif
        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
            }
        }
    }
}

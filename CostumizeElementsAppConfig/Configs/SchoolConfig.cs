using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace CostumizeElementsAppConfig.Configs
{
    public class SchoolConfig : ConfigurationSection 
    {
        private static SchoolConfig _SchoolConfig = (SchoolConfig)ConfigurationManager.GetSection("school");
        public static SchoolConfig Settings { get { return _SchoolConfig; } }

        [ConfigurationProperty("name")]
        public string Name { get { return (string)base["name"]; } }

        [ConfigurationProperty("address")]
        public AddressElement Adress { get { return (AddressElement)base["address"]; } }
        [ConfigurationProperty("courses")]
        public CourseElementCollection courses { get { return (CourseElementCollection)base["courses"]; } }
    }

    public class AddressElement: ConfigurationElement
    {
        [ConfigurationProperty("street",IsRequired=true)]
        public string Street { get { return (string)base["street"]; } }


        [ConfigurationProperty("city", IsRequired = true)]
        public string City { get { return (string)base["city"]; } }


        [ConfigurationProperty("state", IsRequired = true)]
        public string State { get { return (string)base["state"]; } }

    }
    public class CourseElement : ConfigurationElement
    {
        [ConfigurationProperty("title", IsRequired = true)]
        public string Title { get { return (string)base["title"]; } }


        [ConfigurationProperty("instructor", IsRequired = false)]
        public string Instructor { get { return (string)base["instructor"]; } }


     

    }


    [ConfigurationCollection(typeof(CourseElement), AddItemName = "course", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class CourseElementCollection : ConfigurationElementCollection
    {
        public ConfigurationElementCollectionType CollectionType { get { return ConfigurationElementCollectionType.BasicMap; } }

        protected override string ElementName
        {
            get
            {
                return "course";
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new CourseElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as CourseElement).Title;
        }

        public CourseElement this[int index]
        {
            get
            {
                return (CourseElement)base.BaseGet(index);
            }
            set
            {
                if(base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                base.BaseAdd(index, value);
            }
        }
        public CourseElement this[string title]
        {
            get
            {
                return (CourseElement)base.BaseGet(title);
            }
        }


    }
}

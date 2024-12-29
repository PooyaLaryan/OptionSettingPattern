using Microsoft.Extensions.Options;

namespace OptionSettingPattern
{
    /*
     It's registered as singleton. It retrieves data in anytime at runtime and save to memory. 
     */
    public interface IPersonServiceWithOptionsMonitor 
    {
        PersonSetting Get();
    }
    public class PersonServiceWithOptionsMonitor : IPersonServiceWithOptionsMonitor
    {
        private readonly PersonSetting personSetting;
        public PersonServiceWithOptionsMonitor(IOptionsMonitor<PersonSetting> options)
        {
            personSetting = options.CurrentValue;
        }

        public PersonSetting Get()
        {
            return personSetting;
        }
    }
}

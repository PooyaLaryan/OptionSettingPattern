using Microsoft.Extensions.Options;

namespace OptionSettingPattern
{

    /*
        It is registered as singleton and it retrieves data after the application has compiled and save to memory. 
        It does not read updated settings at runtime.
        Don't be shocked at debugging when you try to read an updated setting and you still not getting the current value/values. 
        Use it when the setting does not change at runtime. 
     */
    public interface IPersonServiceWithOptions
    {
        PersonSetting Get();
    }
    public class PersonServiceWithOptions : IPersonServiceWithOptions
    {
        private readonly PersonSetting personSetting;

        public PersonServiceWithOptions(IOptions<PersonSetting> options)
        {
            personSetting = options.Value;
        }

        public PersonSetting Get() 
        {
            return personSetting;
        }
    }
}

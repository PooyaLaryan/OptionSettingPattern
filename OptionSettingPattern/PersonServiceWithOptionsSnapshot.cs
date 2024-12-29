using Microsoft.Extensions.Options;

namespace OptionSettingPattern
{
    /*
        It is registered as scooped and can only be used in scooped or transient services.
        It can retrieve updated data for each request which makes it a good choice when you need to read updated values at runtime.
     */
    public interface IPersonServiceWithOptionsSnapshot
    {
        PersonSetting Get();
    }
    public class PersonServiceWithOptionsSnapshot : IPersonServiceWithOptionsSnapshot   
    {
        private readonly PersonSetting personSetting;
        public PersonServiceWithOptionsSnapshot(IOptionsSnapshot<PersonSetting> options)
        {
            personSetting = options.Value;
        }

        public PersonSetting Get()
        {
            return personSetting;
        }
    }
}

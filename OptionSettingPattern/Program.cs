using OptionSettingPattern;

var builder = WebApplication.CreateBuilder(args);
/*
 * We have 𝘐𝘊𝘰𝘯𝘧𝘪𝘨𝘶𝘳𝘢𝘵𝘪𝘰𝘯 to retrieve data from json, but it is not strongly typed. 

And there come 𝐈𝐎𝐩𝐭𝐢𝐨𝐧𝐬 instances to help us with other benefits.

Now, let's simplify these Options. 

𝐎𝐩𝐭𝐢𝐨𝐧𝐬 𝐩𝐚𝐭𝐭𝐞𝐫𝐧 gives our classes or settings strongly typed configuration and with enough features. 

It helps to encapsulate our settings. 

Let's look into these patterns 


𝐓𝐡𝐞 𝐈𝐎𝐩𝐭𝐢𝐨𝐧𝐬<> 𝐩𝐚𝐭𝐭𝐞𝐫𝐧:
It is registered as singleton and it retrieves data after the application has compiled and save to memory. 

It does not read updated settings at runtime.

Don't be shocked at debugging when you try to read an updated setting and you still not getting the current value/values. 

Use it when the setting does not change at runtime. 


𝐓𝐡𝐞 𝐈𝐎𝐩𝐭𝐢𝐨𝐧𝐬𝐒𝐧𝐚𝐩𝐬𝐡𝐨𝐭<> 𝐩𝐚𝐭𝐭𝐞𝐫𝐧: 
It is registered as scooped and can only be used in scooped or transient services.

It can retrieve updated data for each request which makes it a good choice when you need to read updated values at runtime.


𝐓𝐡𝐞 𝐈𝐎𝐩𝐭𝐢𝐨𝐧𝐬𝐌𝐨𝐧𝐢𝐭𝐨𝐫<> 𝐩𝐚𝐭𝐭𝐞𝐫𝐧:
It's registered as singleton. It retrieves data in anytime at runtime and save to memory. 

𝘚𝘪𝘮𝘪𝘭𝘢𝘳𝘪𝘵𝘺 𝘣𝘦𝘵𝘸𝘦𝘦𝘯 𝘐𝘖𝘱𝘵𝘪𝘰𝘯𝘴<> 𝘢𝘯𝘥 𝘐𝘖𝘱𝘵𝘪𝘰𝘯𝘴𝘔𝘰𝘯𝘪𝘵𝘰𝘳<>
They are registered as Singleton. 

𝘚𝘪𝘮𝘪𝘭𝘢𝘳𝘪𝘵𝘺 𝘣𝘦𝘵𝘸𝘦𝘦𝘯 𝘐𝘖𝘱𝘵𝘪𝘰𝘯𝘴𝘚𝘯𝘢𝘱𝘴𝘩𝘰𝘵<> 𝘢𝘯𝘥 𝘐𝘖𝘱𝘵𝘪𝘰𝘯𝘴𝘔𝘰𝘯𝘪𝘵𝘰𝘳<>
They can retrieve data in any time at runtime. 

𝘋𝘪𝘧𝘧𝘦𝘳𝘦𝘯𝘤𝘦 𝘣𝘦𝘵𝘸𝘦𝘦𝘯 𝘐𝘖𝘱𝘵𝘪𝘰𝘯𝘴<> 𝘢𝘯𝘥 𝘐𝘖𝘱𝘵𝘪𝘰𝘯𝘴𝘔𝘰𝘯𝘪𝘵𝘰𝘳<>
IOptions<>: It reads data after the application has compiled(not for updated data).
IOptionsSnapshot<>: It can read data at anytime. 

𝘋𝘪𝘧𝘧𝘦𝘳𝘦𝘯𝘤𝘦 𝘣𝘦𝘵𝘸𝘦𝘦𝘯 𝘐𝘖𝘱𝘵𝘪𝘰𝘯𝘴𝘚𝘯𝘢𝘱𝘴𝘩𝘰𝘵<> 𝘢𝘯𝘥 𝘐𝘖𝘱𝘵𝘪𝘰𝘯𝘴𝘔𝘰𝘯𝘪𝘵𝘰𝘳<>
IOptionsSnapshot<>: It's registered as scoped. 
IOptionsMonitor<>: it's registered as singleton. 
 */
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.Configure<PersonSetting>(builder.Configuration.GetSection(nameof(PersonSetting)));
builder.Services.AddScoped<IPersonServiceWithOptions, PersonServiceWithOptions>();
builder.Services.AddScoped<IPersonServiceWithOptionsSnapshot, PersonServiceWithOptionsSnapshot>();
builder.Services.AddScoped<IPersonServiceWithOptionsMonitor, PersonServiceWithOptionsMonitor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

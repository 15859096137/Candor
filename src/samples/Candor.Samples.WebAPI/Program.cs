using Candor.Samples.WebAPI.Filter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args).Inject();

// Add services to the container.

builder.Services.AddControllers()
     .AddNewtonsoftJson(options =>
     {
         //忽略循环引用
         options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
         //不使用驼峰样式的key
         //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
         //使用驼峰样式
         options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
         //设置时间格式
         options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
         //忽略Model中为null的属性
         //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
         //设置本地时间而非UTC时间
         options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
         //添加Enum转string
         options.SerializerSettings.Converters.Add(new StringEnumConverter());
     })
     .AddInjectWithUnifyResult<RESTfulResultProvider>()
    
   // .AddInjectWithUnifyResult<RESTfulResultProvider>()
    //.AddFriendlyException()
    ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseUnifyResultStatusCodes();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseInject("swagger");

app.MapControllers();

app.Run();

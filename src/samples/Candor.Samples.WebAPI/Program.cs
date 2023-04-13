using Candor.Samples.WebAPI.Filter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args).Inject();

// Add services to the container.

builder.Services.AddControllers()
     .AddNewtonsoftJson(options =>
     {
         //����ѭ������
         options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
         //��ʹ���շ���ʽ��key
         //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
         //ʹ���շ���ʽ
         options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
         //����ʱ���ʽ
         options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
         //����Model��Ϊnull������
         //options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
         //���ñ���ʱ�����UTCʱ��
         options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
         //���Enumתstring
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

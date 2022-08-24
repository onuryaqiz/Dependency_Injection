using Dependency_Injection.Services;
using Dependency_Injection.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.Add(new ServiceDescriptor(typeof(ConsoleLog), new ConsoleLog())); // Default olarak AddSingleton'dır. 
//builder.Services.Add(new ServiceDescriptor(typeof(TextLog), new TextLog())/*ServiceLifetime.Transient*/);       // Default olarak AddSingleton'dır. Transient olarak kullan dedik.

//builder.Services.AddSingleton<ConsoleLog>(); new T(); // Bu şekilde Singleton kullanmayız. Çünkü constructor'ında parametre alıyor . Runtime sırasında patlayacaktır. 

//builder.Services.AddSingleton<ConsoleLog>(p => new ConsoleLog(5)); // Eğer parametre alan bir constructor var ise , yukarıdaki gibi bir davranış sergileyemeyiz.
//                                                                      Sadece bir tek ConsoleLog nesnesini tüm isteklere tek bir tane ConsoleLog nesnesi gönderecektir.  

//builder.Services.AddScoped<ConsoleLog>(p=>new ConsoleLog(5));      // Her talebe bir ConsoleLog nesnesi üretip gönderecektir. 

//builder.Services.AddTransient<ConsoleLog>(p=>new ConsoleLog(5));   // Her talebin içindeki request'e göre nesne üretip o şekilde gönderecektir. yani 10 request içinde 10 ayrı talep var ise,
// 100 nesne üretecektir. 

builder.Services.AddScoped<ILog>(p => new ConsoleLog(5)); // ILog interface'ini Container'e yani IoC'ye eklemiş olduk. 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

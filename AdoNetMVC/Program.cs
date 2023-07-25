namespace AdoNetMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            app.UseRouting();
            app.UseStaticFiles();
            //app.MapDefaultControllerRoute(); 
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //app.MapGet("/", () => "Hello World!");

            app.Run();
             
        }

    }
}


 
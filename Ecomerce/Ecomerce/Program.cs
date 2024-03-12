using Ecomerce.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Protocol.Core.Types;
using System.Configuration;

namespace Ecomerce
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddSession(c => { c.IdleTimeout = TimeSpan.FromMinutes(20); });
			
            builder.Services.AddDbContext<SystemContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
            //userManager + SignInManager + roleManager
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SystemContext>();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			//Enviroment variables there are three predefined and you can make custom ones
			if (!app.Environment.IsDevelopment())
			{
				app.UseStatusCodePagesWithRedirects("/Home/Error");
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();//take the request=> then try to match it with an end_point (Route)
			app.UseSession();
			app.UseAuthentication();
			app.UseAuthorization();

			//Routing Define end_points and run it
			app.MapControllerRoute(
				name: "default",
				//           = is like andefult value
				//             ? means optinal
				//             {place holder}
				//             value is constant
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}